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
                // Kiểm tra Session có tồn tại và ddlLoginOptions đã được tìm thấy
                if (Session["tdn"] != null && ddlLoginOptions != null)
                {
                    ddlLoginOptions.Items.Clear();
                    ddlLoginOptions.Items.Add(new ListItem("Account", ""));
                    ddlLoginOptions.Items.Add(new ListItem("Logout", "Logout"));
                }
                else if (ddlLoginOptions != null)
                {
                    ddlLoginOptions.Items.Clear();
                    ddlLoginOptions.Items.Add(new ListItem("Account", ""));
                    ddlLoginOptions.Items.Add(new ListItem("Login", "Login"));
                }
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

        protected void ddlLoginOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLoginOptions != null)
            {
                if (ddlLoginOptions.SelectedValue == "Login")
                {
                    Response.Redirect("~/Sources/Login.aspx");
                }
                else if (ddlLoginOptions.SelectedValue == "Logout")
                {
                    Session.Clear();
                    Response.Redirect("~/Sources/Login.aspx");
                }
            }
        }
    }
}