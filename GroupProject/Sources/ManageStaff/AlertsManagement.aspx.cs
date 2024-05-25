using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject.Sources.ManageStaff
{
    public partial class AlertsManagement : System.Web.UI.Page
    {
        // Create an instance of the database connector
        GroupProject.Sources.ConnectDB.ClassConnectSQLSV connect = new GroupProject.Sources.ConnectDB.ClassConnectSQLSV();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load data for the default alert type when the page is first loaded
                LoadAlertData();
            }
        }

        protected void alertsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load data based on the selected alert type
            LoadAlertData();
        }

        private void LoadAlertData()
        {
            // Get the selected alert type
            string selectedValue = alertsDropDown.SelectedValue;

            // Define the query based on the selected alert type
            string query = "";

            switch (selectedValue)
            {
                case "WorkAnniversary":
                    query = @"
                SELECT P.PERSONAL_ID, P.CURRENT_FIRST_NAME, P.CURRENT_LAST_NAME, P.BIRTH_DATE, 
                       P.CURRENT_COUNTRY, P.CURRENT_GENDER, P.CURRENT_PHONE_NUMBER, 
                       P.CURRENT_PERSONAL_EMAIL, JH.FROM_DATE, '' as TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH, P.BENEFIT_PLAN_ID
                FROM JOB_HISTORY JH
                JOIN PERSONAL P ON JH.EMPLOYMENT_ID = P.PERSONAL_ID
                WHERE DATEPART(day, JH.FROM_DATE) = DATEPART(day, GETDATE()) 
                    AND DATEPART(month, JH.FROM_DATE) = DATEPART(month, GETDATE())";
                    break;
                case "LeaveAccumulation":
                    query = @"
                SELECT P.PERSONAL_ID, P.CURRENT_FIRST_NAME, P.CURRENT_LAST_NAME, P.BIRTH_DATE, 
                       P.CURRENT_COUNTRY, P.CURRENT_GENDER, P.CURRENT_PHONE_NUMBER, 
                       P.CURRENT_PERSONAL_EMAIL, '' as FROM_DATE, EWT.TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH, P.BENEFIT_PLAN_ID
                FROM EMPLOYMENT_WORKING_TIME EWT
                JOIN PERSONAL P ON EWT.EMPLOYMENT_ID = P.PERSONAL_ID
                WHERE EWT.TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH >= 4";
                    break;
                case "BenefitPlanChange":
                    query = @"
                SELECT PERSONAL_ID, CURRENT_FIRST_NAME, CURRENT_LAST_NAME, BIRTH_DATE, 
                       CURRENT_COUNTRY, CURRENT_GENDER, CURRENT_PHONE_NUMBER, 
                       CURRENT_PERSONAL_EMAIL, '' as FROM_DATE, '' as TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH, BENEFIT_PLAN_ID
                FROM PERSONAL
                WHERE BenefitPlanChangeDate >= GETDATE()";
                    break;
                case "Birthday":
                    query = @"
                SELECT PERSONAL_ID, CURRENT_FIRST_NAME, CURRENT_LAST_NAME, BIRTH_DATE, 
                       CURRENT_COUNTRY, CURRENT_GENDER, CURRENT_PHONE_NUMBER, 
                       CURRENT_PERSONAL_EMAIL, '' as FROM_DATE, '' as TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH, BENEFIT_PLAN_ID
                FROM PERSONAL
                WHERE DATEPART(month, BIRTH_DATE) = DATEPART(month, GETDATE())";
                    break;
                default:
                    // Handle default case or error handling if needed
                    break;
            }

            // Bind data to the GridView
            BindDataToGridView(query);
        }

        private void BindDataToGridView(string query)
        {
            // Get data from the database
            DataTable dt = connect.GetData(query);

            // Bind data to the GridView
            alertGridView.DataSource = dt;
            alertGridView.DataBind();
        }
        private void BindGrid()
        {
            DataTable dt = connect.GetData("SELECT * FROM PERSONAL, EMPLOYMENT, EMPLOYMENT_WORKING_TIME, JOB_HISTORY WHERE PERSONAL.PERSONAL_ID = EMPLOYMENT.PERSONAL_ID AND EMPLOYMENT.EMPLOYMENT_ID = JOB_HISTORY.EMPLOYMENT_ID AND EMPLOYMENT.EMPLOYMENT_ID = EMPLOYMENT_WORKING_TIME.EMPLOYMENT_ID");
            alertGridView.DataSource = dt;
            alertGridView.DataBind();
        }
        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Handle edit and delete commands here
        }
        protected void Bt_Delete_Click(object sender, EventArgs e)
        {
            bool isDeleted = false;
            foreach (GridViewRow row in alertGridView.Rows)
            {
                CheckBox chkRow = (CheckBox)row.FindControl("chkRow");
                if (chkRow != null && chkRow.Checked)
                {
                    string id = alertGridView.DataKeys[row.RowIndex].Value.ToString();
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
        protected void Bt_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/ManageStaff/Functions/Personal/AddPerson.aspx");
        }

        private bool DeleteRowFromDatabase(string id)
        {
            string sql = $"DELETE FROM PERSONAL WHERE PERSONAL_ID = {id}";
            int result = connect.ExecuteQuery(sql);
            return result > 0;
        }
    }
}