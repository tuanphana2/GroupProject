using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject.Sources.ManageStaff
{
    public partial class ManageStaff : System.Web.UI.Page
    {
        GroupProject.Sources.ConnectDB.ClassConnectSQLSV connect = new GroupProject.Sources.ConnectDB.ClassConnectSQLSV(); // Tạo một thể hiện của lớp kết nối

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                // Kiểm tra xem đang hiển thị DataGridView nào
                if (GridView1.Visible)
                {
                    LoadDataForGridView1();
                }
                else if (GridView2.Visible)
                {
                    LoadDataForGridView2();
                }
                else if (GridView3.Visible)
                {
                    LoadDataForGridView3();
                }
            }
        }

        private void BindGrid()
        {
            DataTable dt = connect.GetData("SELECT PERSONAL_ID, CURRENT_FIRST_NAME, CURRENT_LAST_NAME, BIRTH_DATE, CURRENT_COUNTRY, CURRENT_GENDER, CURRENT_PHONE_NUMBER, CURRENT_PERSONAL_EMAIL, BENEFIT_PLAN_ID FROM PERSONAL");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Bt_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/ManageStaff/Functions/Personal/AddPerson.aspx");
        }

        protected void Bt_View_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/ManageStaff/Functions/Personal/ViewPerson.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                string personalId = e.CommandArgument.ToString();
                Response.Redirect($"~/Sources/ManageStaff/Functions/Personal/EditPerson.aspx?PID={personalId}");
            }
        }

        protected void Bt_Delete_Click(object sender, EventArgs e)
        {
            bool isDeleted = false;
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chkRow = (CheckBox)row.FindControl("chkRow");
                if (chkRow != null && chkRow.Checked)
                {
                    string id = GridView1.DataKeys[row.RowIndex].Value.ToString();
                    if (DeleteRowFromDatabase(id))
                    {
                        isDeleted = true;
                    }
                }
            }
            BindGrid();
            if (isDeleted)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Deleted successfully!');", true);
            }
        }

        private bool DeleteRowFromDatabase(string id)
        {
            string sql = $"DELETE FROM PERSONAL WHERE PERSONAL_ID = {id}";
            int result = connect.ExecuteQuery(sql);
            return result > 0;
        }

        protected void Bt_Import_Click(object sender, EventArgs e)
        {
            Response.Redirect("Functions/InsertStaffIntoMySQL.aspx");
        }

        protected void Bt_Export_Click(object sender, EventArgs e)
        {
            // Implement export functionality
        }

        protected void Bt_Print_Click(object sender, EventArgs e)
        {
            // Implement print functionality
        }


        protected void Bt_Filter_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đang hiển thị DataGridView nào
            if (GridView1.Visible)
            {
                LoadDataForGridView1();
            }
            else if (GridView2.Visible)
            {
                LoadDataForGridView2();
            }
            else if (GridView3.Visible)
            {
                LoadDataForGridView3();
            }
        }

        protected void ddlReportSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ẩn tất cả DataGridView
            GridView1.Visible = false;
            GridView2.Visible = false;
            GridView3.Visible = false;

            // Hiển thị DataGridView được chọn
            int selectedValue = Convert.ToInt32(ddlReportSelector.SelectedValue);
            switch (selectedValue)
            {
                case 1:
                    GridView1.Visible = true;
                    // Load dữ liệu cho DataGridView 1 (Tổng Quan Thu Nhập)
                    LoadDataForGridView1();
                    break;
                case 2:
                    GridView2.Visible = true;
                    // Load dữ liệu cho DataGridView 2 (Tổng Quan Ngày Nghỉ)
                    LoadDataForGridView2();
                    break;
                case 3:
                    GridView3.Visible = true;
                    // Load dữ liệu cho DataGridView 3 (Trung Bình Chi Phí Phúc Lợi)
                    LoadDataForGridView3();
                    break;
            }
        }
        // Các phương thức LoadDataForGridViewX() dùng để tải dữ liệu cho từng DataGridView
        private void LoadDataForGridView1()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PERSONAL"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
            SELECT 
                p.SHAREHOLDER_STATUS,
                p.CURRENT_GENDER,
                p.ETHNICITY,
                e.EMPLOYMENT_STATUS,
                jh.DEPARTMENT,
                SUM(jh.SALARY) AS Total_Income
            FROM 
                PERSONAL p
            JOIN 
                EMPLOYMENT e ON p.PERSONAL_ID = e.PERSONAL_ID
            JOIN 
                JOB_HISTORY jh ON e.EMPLOYMENT_ID = jh.EMPLOYMENT_ID
            WHERE 
                jh.FROM_DATE <= GETDATE() AND 
                (jh.THRU_DATE IS NULL OR jh.THRU_DATE >= DATEADD(year, -1, GETDATE()))";

                if (chkShareholder.Checked)
                {
                    query += " AND p.SHAREHOLDER_STATUS = 1";
                }
                // Thêm phần lọc cho No Shareholder
                if (chkNoShareholder.Checked)
                {
                    query += " AND p.SHAREHOLDER_STATUS = 0"; // Filter out shareholders
                }
                // Thêm phần lọc cho giới tính
                if (!string.IsNullOrEmpty(txtGenderFilter.Text))
                {
                    query += $" AND UPPER(p.CURRENT_GENDER) = '{txtGenderFilter.Text.ToUpper()}'";
                }
                if (chkEthnicity.Checked)
                {
                    query += " AND p.ETHNICITY IS NOT NULL";
                }
                if (chkPartTime.Checked)
                {
                    query += " AND e.EMPLOYMENT_STATUS = 'Part-time'";
                }
                if (chkFullTime.Checked)
                {
                    query += " AND e.EMPLOYMENT_STATUS = 'Full-time'";
                }

                query += @"
            GROUP BY 
                p.SHAREHOLDER_STATUS,
                p.CURRENT_GENDER,
                p.ETHNICITY,
                e.EMPLOYMENT_STATUS,
                jh.DEPARTMENT
            ORDER BY 
                p.SHAREHOLDER_STATUS,
                p.CURRENT_GENDER,
                p.ETHNICITY,
                e.EMPLOYMENT_STATUS,
                jh.DEPARTMENT";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        private void LoadDataForGridView2()
        {
            // Thực hiện tải dữ liệu cho DataGridView 2 (Tổng Quan Ngày Nghỉ)
            string connStr = ConfigurationManager.ConnectionStrings["YOUR_CONNECTION_STRING"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
            SELECT 
                p.SHAREHOLDER_STATUS,
                p.CURRENT_GENDER,
                p.ETHNICITY,
                e.EMPLOYMENT_STATUS,
                COUNT(*) AS Total_Leave_Days
            FROM 
                PERSONAL p
            JOIN 
                EMPLOYMENT e ON p.PERSONAL_ID = e.PERSONAL_ID
            JOIN 
                LEAVE_HISTORY lh ON e.EMPLOYMENT_ID = lh.EMPLOYMENT_ID
            WHERE 
                lh.LEAVE_DATE >= DATEADD(year, -1, GETDATE()) AND 
                lh.LEAVE_DATE <= GETDATE()";

                // Thêm các điều kiện lọc nếu cần
                // Ví dụ: 
                // if (chkShareholder.Checked)
                // {
                //     query += " AND p.SHAREHOLDER_STATUS = 1";
                // }

                query += @"
            GROUP BY 
                p.SHAREHOLDER_STATUS,
                p.CURRENT_GENDER,
                p.ETHNICITY,
                e.EMPLOYMENT_STATUS
            ORDER BY 
                p.SHAREHOLDER_STATUS,
                p.CURRENT_GENDER,
                p.ETHNICITY,
                e.EMPLOYMENT_STATUS";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }

        private void LoadDataForGridView3()
        {
            // Thực hiện tải dữ liệu cho DataGridView 3 (Trung Bình Chi Phí Phúc Lợi)
            string connStr = ConfigurationManager.ConnectionStrings["YOUR_CONNECTION_STRING"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
            SELECT 
                p.SHAREHOLDER_STATUS,
                p.CURRENT_GENDER,
                p.ETHNICITY,
                AVG(bw.BENEFIT_COST) AS Average_Benefit_Cost
            FROM 
                PERSONAL p
            LEFT JOIN 
                BENEFIT_WORKER bw ON p.PERSONAL_ID = bw.PERSONAL_ID
            WHERE 
                bw.BENEFIT_DATE >= DATEADD(year, -1, GETDATE()) AND 
                bw.BENEFIT_DATE <= GETDATE()";

                // Thêm các điều kiện lọc nếu cần
                // Ví dụ: 
                // if (chkShareholder.Checked)
                // {
                //     query += " AND p.SHAREHOLDER_STATUS = 1";
                // }

                query += @"
            GROUP BY 
                p.SHAREHOLDER_STATUS,
                p.CURRENT_GENDER,
                p.ETHNICITY
            ORDER BY 
                p.SHAREHOLDER_STATUS,
                p.CURRENT_GENDER,
                p.ETHNICITY";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView3.DataSource = dt;
                GridView3.DataBind();
            }
        }
    }
}
