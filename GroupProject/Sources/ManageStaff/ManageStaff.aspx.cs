using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject.Sources.ManageStaff
{
    public partial class ManageStaff : System.Web.UI.Page
    {
        GroupProject.Sources.ConnectDB.ClassConnectSQLSV connect = new GroupProject.Sources.ConnectDB.ClassConnectSQLSV(); // Tạo một thể hiện của lớp kết nối
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        private void BindGrid()
        {
            DataTable dt = connect.GetData("SELECT PERSONAL_ID, CURRENT_FIRST_NAME, CURRENT_LAST_NAME, BIRTH_DATE, CURRENT_COUNTRY, CURRENT_GENDER, CURRENT_PHONE_NUMBER, CURRENT_PERSONAL_EMAIL, BENEFIT_PLAN_ID FROM PERSONAL");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void Bt_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("Functions/AddStaff.aspx");
        }
        protected void Bt_View_Click(object sender, EventArgs e)
        {
            Response.Redirect("Functions/ViewStaff.aspx");
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                string personalId = e.CommandArgument.ToString();
                Response.Redirect($"Functions/EditStaff.aspx?PERSONAL_ID={personalId}");
            }
        }
        protected void Bt_Edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Functions/EditStaff.aspx");
        }

        protected void Bt_Delete_Click(object sender, EventArgs e)
        {
            bool isDeleted = false;
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chkRow = (CheckBox)row.FindControl("chkRow");
                if (chkRow != null && chkRow.Checked)
                {
                    string id = GridView1.DataKeys[row.RowIndex].ToString();
                    if (DeleteRowFromDatabase(id))
                    {
                        isDeleted = true;
                    }
                }
            }
            BindGrid();
            // Hiển thị thông báo nếu đã xóa thành công
            if (isDeleted)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Deleted successfully!');", true);
            }
        }
        private bool DeleteRowFromDatabase(string id)
        {
            string sql = $"delete from PERSONAL where PERSONAL_ID = {id}";
            int result = connect.ExecuteQuery(sql);
            return result > 0;
        }
        protected void Bt_Import_Click(object sender, EventArgs e)
        {
            Response.Redirect("Functions/InsertStaffIntoMySQL.aspx");
        }

        protected void Bt_Export_Click(object sender, EventArgs e)
        {

        }

        protected void Bt_Print_Click(object sender, EventArgs e)
        {

        }
    }
}