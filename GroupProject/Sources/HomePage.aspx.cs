using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject
{
    public partial class HomePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (Session["tdn"] == null)
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
                Response.Redirect("~/Sources/Login.aspx");
=======
            if (!IsPostBack)
            {
                if (Session["tdn"] == null)
                    Response.Redirect("~/Sources/Login.aspx");
>>>>>>> GỐC
            }
        }
    }
}