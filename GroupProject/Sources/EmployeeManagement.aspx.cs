using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject.Sources
{
    public partial class EmployeeManagement : System.Web.UI.Page
    {
        GroupProject.Sources.ConnectDB.ClassConnectSQLSV connect = new GroupProject.Sources.ConnectDB.ClassConnectSQLSV();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LoadIncomeOverview();
                //LoadLeaveOverview();
                //LoadBenefitCostOverview();
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
    //private void LoadIncomeOverview()
    //{
    //    string query = @"
    //        SELECT PERSONAL, 
    //               SUM(CASE WHEN SHAREHOLDER_STATUS = 1 THEN Income ELSE 0 END) AS TotalIncomeShareholder,
    //               SUM(CASE WHEN SHAREHOLDER_STATUS = 0 THEN Income ELSE 0 END) AS TotalIncomeNonShareholder,
    //               SUM(CASE WHEN CURRENT_GENDER = 'Male' THEN Income ELSE 0 END) AS TotalIncomeMale,
    //               SUM(CASE WHEN CURRENT_GENDER = 'Female' THEN Income ELSE 0 END) AS TotalIncomeFemale,
    //               SUM(CASE WHEN Ethnicity = 'SpecificEthnicity' THEN Income ELSE 0 END) AS TotalIncomeSpecificEthnicity,
    //               SUM(CASE WHEN EMPLOYMENT_STATUS = 'FullTime' THEN Income ELSE 0 END) AS TotalIncomeFullTime,
    //               SUM(CASE WHEN EMPLOYMENT_STATUS = 'PartTime' THEN Income ELSE 0 END) AS TotalIncomePartTime,
    //               SUM(CASE WHEN YEAR_WORKING = YEAR(GETDATE()) THEN Income ELSE 0 END) AS TotalIncomeThisYear,
    //               SUM(CASE WHEN YEAR_WORKING = YEAR(GETDATE()) - 1 THEN Income ELSE 0 END) AS TotalIncomeLastYear
    //        FROM EmployeeIncome
    //        GROUP BY Department";

    //    DataTable dtIncome = connect.GetData(query);
    //    gvIncomeOverview.DataSource = dtIncome;
    //    gvIncomeOverview.DataBind();
    //}

    //private void LoadLeaveOverview()
    //{
    //    string query = @"
    //        SELECT Department, 
    //               SUM(CASE WHEN ShareholderStatus = 1 THEN LeaveDays ELSE 0 END) AS TotalLeaveShareholder,
    //               SUM(CASE WHEN ShareholderStatus = 0 THEN LeaveDays ELSE 0 END) AS TotalLeaveNonShareholder,
    //               SUM(CASE WHEN Gender = 'Male' THEN LeaveDays ELSE 0 END) AS TotalLeaveMale,
    //               SUM(CASE WHEN Gender = 'Female' THEN LeaveDays ELSE 0 END) AS TotalLeaveFemale,
    //               SUM(CASE WHEN Ethnicity = 'SpecificEthnicity' THEN LeaveDays ELSE 0 END) AS TotalLeaveSpecificEthnicity,
    //               SUM(CASE WHEN EmploymentStatus = 'FullTime' THEN LeaveDays ELSE 0 END) AS TotalLeaveFullTime,
    //               SUM(CASE WHEN EmploymentStatus = 'PartTime' THEN LeaveDays ELSE 0 END) AS TotalLeavePartTime,
    //               SUM(CASE WHEN Year = YEAR(GETDATE()) THEN LeaveDays ELSE 0 END) AS TotalLeaveThisYear,
    //               SUM(CASE WHEN Year = YEAR(GETDATE()) - 1 THEN LeaveDays ELSE 0 END) AS TotalLeaveLastYear
    //        FROM EmployeeLeave
    //        GROUP BY Department";

    //    DataTable dtLeave = connect.GetData(query);
    //    gvLeaveOverview.DataSource = dtLeave;
    //    gvLeaveOverview.DataBind();
    //}

    //private void LoadBenefitCostOverview()
    //{
    //    string query = @"
    //        SELECT BenefitPlan, 
    //               AVG(CASE WHEN ShareholderStatus = 1 THEN BenefitCost ELSE 0 END) AS AvgBenefitCostShareholder,
    //               AVG(CASE WHEN ShareholderStatus = 0 THEN BenefitCost ELSE 0 END) AS AvgBenefitCostNonShareholder
    //        FROM EmployeeBenefits
    //        GROUP BY BenefitPlan";

    //    DataTable dtBenefitCost = connect.GetData(query);
    //    gvBenefitCostOverview.DataSource = dtBenefitCost;
    //    gvBenefitCostOverview.DataBind();
    //}
}
}