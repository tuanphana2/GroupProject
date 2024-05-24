using System;
using System.Collections.Generic;
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
                LoadIncomeOverview();
                LoadLeaveOverview();
                LoadBenefitCostOverview();
            }
        }

        private void LoadIncomeOverview()
        {
            string query = @"
                SELECT PERSONAL, 
                       SUM(CASE WHEN SHAREHOLDER_STATUS = 1 THEN Income ELSE 0 END) AS TotalIncomeShareholder,
                       SUM(CASE WHEN SHAREHOLDER_STATUS = 0 THEN Income ELSE 0 END) AS TotalIncomeNonShareholder,
                       SUM(CASE WHEN CURRENT_GENDER = 'Male' THEN Income ELSE 0 END) AS TotalIncomeMale,
                       SUM(CASE WHEN CURRENT_GENDER = 'Female' THEN Income ELSE 0 END) AS TotalIncomeFemale,
                       SUM(CASE WHEN Ethnicity = 'SpecificEthnicity' THEN Income ELSE 0 END) AS TotalIncomeSpecificEthnicity,
                       SUM(CASE WHEN EMPLOYMENT_STATUS = 'FullTime' THEN Income ELSE 0 END) AS TotalIncomeFullTime,
                       SUM(CASE WHEN EMPLOYMENT_STATUS = 'PartTime' THEN Income ELSE 0 END) AS TotalIncomePartTime,
                       SUM(CASE WHEN YEAR_WORKING = YEAR(GETDATE()) THEN Income ELSE 0 END) AS TotalIncomeThisYear,
                       SUM(CASE WHEN YEAR_WORKING = YEAR(GETDATE()) - 1 THEN Income ELSE 0 END) AS TotalIncomeLastYear
                FROM EmployeeIncome
                GROUP BY Department";

            DataTable dtIncome = connect.GetData(query);
            gvIncomeOverview.DataSource = dtIncome;
            gvIncomeOverview.DataBind();
        }

        private void LoadLeaveOverview()
        {
            string query = @"
                SELECT Department, 
                       SUM(CASE WHEN ShareholderStatus = 1 THEN LeaveDays ELSE 0 END) AS TotalLeaveShareholder,
                       SUM(CASE WHEN ShareholderStatus = 0 THEN LeaveDays ELSE 0 END) AS TotalLeaveNonShareholder,
                       SUM(CASE WHEN Gender = 'Male' THEN LeaveDays ELSE 0 END) AS TotalLeaveMale,
                       SUM(CASE WHEN Gender = 'Female' THEN LeaveDays ELSE 0 END) AS TotalLeaveFemale,
                       SUM(CASE WHEN Ethnicity = 'SpecificEthnicity' THEN LeaveDays ELSE 0 END) AS TotalLeaveSpecificEthnicity,
                       SUM(CASE WHEN EmploymentStatus = 'FullTime' THEN LeaveDays ELSE 0 END) AS TotalLeaveFullTime,
                       SUM(CASE WHEN EmploymentStatus = 'PartTime' THEN LeaveDays ELSE 0 END) AS TotalLeavePartTime,
                       SUM(CASE WHEN Year = YEAR(GETDATE()) THEN LeaveDays ELSE 0 END) AS TotalLeaveThisYear,
                       SUM(CASE WHEN Year = YEAR(GETDATE()) - 1 THEN LeaveDays ELSE 0 END) AS TotalLeaveLastYear
                FROM EmployeeLeave
                GROUP BY Department";

            DataTable dtLeave = connect.GetData(query);
            gvLeaveOverview.DataSource = dtLeave;
            gvLeaveOverview.DataBind();
        }

        private void LoadBenefitCostOverview()
        {
            string query = @"
                SELECT BenefitPlan, 
                       AVG(CASE WHEN ShareholderStatus = 1 THEN BenefitCost ELSE 0 END) AS AvgBenefitCostShareholder,
                       AVG(CASE WHEN ShareholderStatus = 0 THEN BenefitCost ELSE 0 END) AS AvgBenefitCostNonShareholder
                FROM EmployeeBenefits
                GROUP BY BenefitPlan";

            DataTable dtBenefitCost = connect.GetData(query);
            gvBenefitCostOverview.DataSource = dtBenefitCost;
            gvBenefitCostOverview.DataBind();
        }
    }
}