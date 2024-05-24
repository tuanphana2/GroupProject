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
                // Kiểm tra Session có tồn tại
                if (Session["tdn"] != null)
                {
                    // Nếu đã đăng nhập, hiển thị liên kết "Logout"
                    Response.Write("<a href='~/Sources/Login.aspx' OnClick='Button_Logout_Click'>Logout</a>");
                }
                else
                {
                    // Nếu chưa đăng nhập, hiển thị liên kết "Login"
                    Response.Write("<a href='~/Sources/Login.aspx'>Login</a>");
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
            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (Session["tdn"] != null)
            {
                // Nếu đã đăng nhập, xóa Session và chuyển hướng về trang Login
                Session.Clear();
                Response.Redirect("~/Sources/Login.aspx");
            }
            else
            {
                // Nếu chưa đăng nhập, chuyển hướng về trang Login
                Response.Redirect("~/Sources/Login.aspx");
            }
        }
        protected void Link_Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Sources/Login.aspx");
        }
    }
}