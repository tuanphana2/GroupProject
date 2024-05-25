using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject.Sources
{
    public partial class MainPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkHomePage_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Sources/HomePage.aspx");
        }

        protected void LinkManageStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/ManageStaff/ManageStaff.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("~/Sources/HomePage.aspx");
        }

        protected void HRManagement_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = HRManagement.SelectedValue;

            switch (selectedValue)
            {
                case "IncomeOverview":
                    Response.Redirect("~/Sources/TotalIncome.aspx");
                    break;
                case "VacationOverview":
                    Response.Redirect("~/Sources/TotalVacation.aspx");
                    break;
                case "AverageBenefitCosts":
                    Response.Redirect("~/Sources/AverageWelfareCost.aspx");
                    break;
                default:
                    // Do nothing or redirect to a default page if necessary
                    break;
            }
        }
    }
}