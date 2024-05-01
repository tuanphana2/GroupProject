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

        protected void LinkQuanLySanPham_Click(object sender, EventArgs e)
        {

        }

        protected void LinkQuanLyDonHang_Click(object sender, EventArgs e)
        {

        }

        protected void LinkQuanLyNoiBo_Click(object sender, EventArgs e)
        {

        }

        protected void LinkBangKeLuong_Click(object sender, EventArgs e)
        {

        }

        protected void LinkBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void LinkDangNhap_Click(object sender, EventArgs e)
        {

        }

        protected void LinkDangKy_Click(object sender, EventArgs e)
        {

        }
    }
}