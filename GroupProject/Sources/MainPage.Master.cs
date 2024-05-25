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
            if (!IsPostBack)
            {
                string tdn = Session["tdn"] + "";
                if (tdn == "")
                    Response.Redirect("~/Sources/Login.aspx");
            }
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
                case "SalaryOverview":
                    Response.Redirect("~/Sources/ManageStaff/TotalSalary.aspx");
                    break;
                case "IncomeOverview":
                    Response.Redirect("~/Sources/ManageStaff/TotalSalary.aspx");
                    break;
                case "VacationOverview":
                    Response.Redirect("~/Sources/ManageStaff/VacationDay.aspx");
                    break;
                case "AverageBenefitCosts":
                    Response.Redirect("~/Sources/ManageStaff/AverageBenefitCost.aspx");
                    break;
                default:
                    // Do nothing or redirect to a default page if necessary
                    break;
            }
        }

        protected void Link_Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Server.Transfer("~/Sources/Login.aspx");
        }
    }
}