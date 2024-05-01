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

        protected void LinkTrangChu_Click(object sender, EventArgs e)
        {
            Server.Transfer("HomePage.aspx");
        }

        protected void LinkQuanLyNhanVien_Click(object sender, EventArgs e)
        {

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
    }
}