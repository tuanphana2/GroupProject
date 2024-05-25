using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject.Sources.ManageStaff
{
    public partial class TotalSalary : System.Web.UI.Page
    {
        GroupProject.Sources.ConnectDB.ClassConnectSQLSV connect = new GroupProject.Sources.ConnectDB.ClassConnectSQLSV(); // Tạo một thể hiện của lớp kết nối

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tdn = Session["tdn"] + "";
                if (tdn == "")
                    Response.Redirect("~/Sources/Login.aspx");
                BindGrid();
                LoadShareholder();
                LoadGender();
                LoadEthnicity();
                LoadDepartment();
                LoadTypeOfWork();
            }
        }

        private void BindGrid()
        {
            DataTable dt = connect.GetData("SELECT * FROM PERSONAL, EMPLOYMENT, JOB_HISTORY WHERE PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID AND EMPLOYMENT.EMPLOYMENT_ID = JOB_HISTORY.EMPLOYMENT_ID");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        private void LoadGender()
        {
            string sqlbp = "SELECT * FROM PERSONAL, EMPLOYMENT, JOB_HISTORY WHERE PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID AND EMPLOYMENT.EMPLOYMENT_ID = JOB_HISTORY.EMPLOYMENT_ID";
            ddl_Gender.DataSource = connect.GetData(sqlbp);
            ddl_Gender.DataTextField = "CURRENT_GENDER";
            ddl_Gender.DataValueField = "CURRENT_GENDER";
            ddl_Gender.DataBind();
        }
        private void LoadShareholder()
        {
            string sqlbp = @"
                            SELECT 
                                PERSONAL.*, 
                                EMPLOYMENT.*, 
                                JOB_HISTORY.*, 
                                CASE 
                                    WHEN PERSONAL.SHAREHOLDER_STATUS = 1 THEN 'Shareholder'
                                    WHEN PERSONAL.SHAREHOLDER_STATUS = 0 THEN 'Non-shareholder'
                                END AS SHAREHOLDER_STATUS_DISPLAY
                            FROM 
                                PERSONAL 
                            JOIN 
                                EMPLOYMENT ON PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID 
                            JOIN 
                                JOB_HISTORY ON EMPLOYMENT.EMPLOYMENT_ID = JOB_HISTORY.EMPLOYMENT_ID";
            ddl_Shareholder.DataSource = connect.GetData(sqlbp);
            ddl_Shareholder.DataTextField = "SHAREHOLDER_STATUS_DISPLAY";
            ddl_Shareholder.DataValueField = "SHAREHOLDER_STATUS";
            ddl_Shareholder.DataBind();
        }
        private void LoadEthnicity()
        {
            string sqlbp = "SELECT * FROM PERSONAL, EMPLOYMENT, JOB_HISTORY WHERE PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID AND EMPLOYMENT.EMPLOYMENT_ID = JOB_HISTORY.EMPLOYMENT_ID";
            ddl_Ethnicity.DataSource = connect.GetData(sqlbp);
            ddl_Ethnicity.DataTextField = "ETHNICITY";
            ddl_Ethnicity.DataValueField = "ETHNICITY";
            ddl_Ethnicity.DataBind();
        }
        private void LoadDepartment()
        {
            string sqlbp = "SELECT * FROM PERSONAL, EMPLOYMENT, JOB_HISTORY WHERE PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID AND EMPLOYMENT.EMPLOYMENT_ID = JOB_HISTORY.EMPLOYMENT_ID";
            ddl_Department.DataSource = connect.GetData(sqlbp);
            ddl_Department.DataTextField = "DEPARTMENT";
            ddl_Department.DataValueField = "DEPARTMENT";
            ddl_Department.DataBind();
        }
        private void LoadTypeOfWork()
        {
            string sqlbp = @"
                            SELECT 
                                PERSONAL.*, 
                                EMPLOYMENT.*, 
                                JOB_HISTORY.*, 
                                CASE 
                                    WHEN JOB_HISTORY.TYPE_OF_WORK = 1 THEN 'Full Time'
                                    WHEN JOB_HISTORY.TYPE_OF_WORK = 0 THEN 'Part Time'
                                END AS TYPE_OF_WORK_DISPLAY
                            FROM 
                                PERSONAL 
                            JOIN 
                                EMPLOYMENT ON PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID 
                            JOIN 
                                JOB_HISTORY ON EMPLOYMENT.EMPLOYMENT_ID = JOB_HISTORY.EMPLOYMENT_ID";
            //string sqlbp = "SELECT * FROM PERSONAL, EMPLOYMENT, JOB_HISTORY WHERE PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID AND EMPLOYMENT.EMPLOYMENT_ID = JOB_HISTORY.EMPLOYMENT_ID";
            ddl_TypeOfWork.DataSource = connect.GetData(sqlbp);
            ddl_TypeOfWork.DataTextField = "TYPE_OF_WORK_DISPLAY";
            ddl_TypeOfWork.DataValueField = "TYPE_OF_WORK";
            ddl_TypeOfWork.DataBind();
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

        protected void bt_submitS_Click(object sender, EventArgs e)
        {
            string shareholder = ddl_Shareholder.SelectedValue + "";
            string sqlSort = "SELECT * FROM PERSONAL, EMPLOYMENT, JOB_HISTORY WHERE PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID AND EMPLOYMENT.EMPLOYMENT_ID = JOB_HISTORY.EMPLOYMENT_ID AND SHAREHOLDER_STATUS = '" + shareholder + "'";
            DataTable dt = connect.GetData(sqlSort);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            string calculateSalary = "SELECT sum(EMPLOYMENT_WORKING_TIME.NUMBER_DAYS_ACTUAL_OF_WORKING_PER_MONTH * 300) as total_salary FROM PERSONAL, EMPLOYMENT, EMPLOYMENT_WORKING_TIME WHERE PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID AND EMPLOYMENT.EMPLOYMENT_ID = EMPLOYMENT_WORKING_TIME.EMPLOYMENT_ID AND SHAREHOLDER_STATUS = '" + shareholder + "'";
            double dt1 = connect.GetValueFloat(calculateSalary);
            lb_TotalSalary.Text = dt1 + "";
        }
        protected void bt_submitG_Click(object sender, EventArgs e)
        {
            string gender = ddl_Gender.SelectedValue + "";
            string sqlSort = "SELECT * FROM PERSONAL, EMPLOYMENT, JOB_HISTORY WHERE PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID AND EMPLOYMENT.EMPLOYMENT_ID = JOB_HISTORY.EMPLOYMENT_ID AND CURRENT_GENDER = '" + gender + "'";
            DataTable dt = connect.GetData(sqlSort);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            string calculateSalary = "SELECT sum(EMPLOYMENT_WORKING_TIME.NUMBER_DAYS_ACTUAL_OF_WORKING_PER_MONTH * 300) as total_salary FROM PERSONAL, EMPLOYMENT, EMPLOYMENT_WORKING_TIME WHERE PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID AND EMPLOYMENT.EMPLOYMENT_ID = EMPLOYMENT_WORKING_TIME.EMPLOYMENT_ID AND CURRENT_GENDER = '" + gender + "'";
            double dt1 = connect.GetValueFloat(calculateSalary);
            lb_TotalSalary.Text = dt1 + "";
        }

        protected void bt_submitE_Click(object sender, EventArgs e)
        {
            string ethnicity = ddl_Ethnicity.SelectedValue + "";
            string sqlSort = "SELECT * FROM PERSONAL, EMPLOYMENT, JOB_HISTORY WHERE PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID AND EMPLOYMENT.EMPLOYMENT_ID = JOB_HISTORY.EMPLOYMENT_ID AND ETHNICITY = '" + ethnicity + "'";
            DataTable dt = connect.GetData(sqlSort);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            string calculateSalary = "SELECT sum(EMPLOYMENT_WORKING_TIME.NUMBER_DAYS_ACTUAL_OF_WORKING_PER_MONTH * 300) as total_salary FROM PERSONAL, EMPLOYMENT, EMPLOYMENT_WORKING_TIME WHERE PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID AND EMPLOYMENT.EMPLOYMENT_ID = EMPLOYMENT_WORKING_TIME.EMPLOYMENT_ID AND ETHNICITY = '" + ethnicity + "'";
            double dt1 = connect.GetValueFloat(calculateSalary);
            lb_TotalSalary.Text = dt1 + "";
        }

        protected void bt_submitD_Click(object sender, EventArgs e)
        {
            string department = ddl_Department.SelectedValue + "";
            string sqlSort = "SELECT * FROM PERSONAL, EMPLOYMENT, JOB_HISTORY WHERE PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID AND EMPLOYMENT.EMPLOYMENT_ID = JOB_HISTORY.EMPLOYMENT_ID AND DEPARTMENT = '" + department + "'";
            DataTable dt = connect.GetData(sqlSort);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            string calculateSalary = "SELECT sum(EMPLOYMENT_WORKING_TIME.NUMBER_DAYS_ACTUAL_OF_WORKING_PER_MONTH * 300) as total_salary FROM PERSONAL, EMPLOYMENT, EMPLOYMENT_WORKING_TIME, JOB_HISTORY WHERE PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID AND EMPLOYMENT.EMPLOYMENT_ID = EMPLOYMENT_WORKING_TIME.EMPLOYMENT_ID AND EMPLOYMENT.EMPLOYMENT_ID = JOB_HISTORY.EMPLOYMENT_ID AND DEPARTMENT = '" + department + "'";
            double dt1 = connect.GetValueFloat(calculateSalary);
            lb_TotalSalary.Text = dt1 + "";
        }

        protected void bt_TOW_Click(object sender, EventArgs e)
        {
            string typeofwork = ddl_TypeOfWork.SelectedValue + "";
            string sqlSort = "SELECT * FROM PERSONAL, EMPLOYMENT, JOB_HISTORY WHERE PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID AND EMPLOYMENT.EMPLOYMENT_ID = JOB_HISTORY.EMPLOYMENT_ID AND TYPE_OF_WORK = '" + typeofwork + "'";
            DataTable dt = connect.GetData(sqlSort);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            string calculateSalary = "SELECT sum(EMPLOYMENT_WORKING_TIME.NUMBER_DAYS_ACTUAL_OF_WORKING_PER_MONTH * 300) as total_salary FROM PERSONAL, EMPLOYMENT, EMPLOYMENT_WORKING_TIME, JOB_HISTORY WHERE PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID AND EMPLOYMENT.EMPLOYMENT_ID = EMPLOYMENT_WORKING_TIME.EMPLOYMENT_ID AND EMPLOYMENT.EMPLOYMENT_ID = JOB_HISTORY.EMPLOYMENT_ID AND TYPE_OF_WORK = '" + typeofwork + "'";
            double dt1 = connect.GetValueFloat(calculateSalary);
            lb_TotalSalary.Text = dt1 + "";
        }
    }
}