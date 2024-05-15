using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject.Sources.ManageStaff.Functions
{
    public partial class ViewStaff : System.Web.UI.Page
    {
        GroupProject.Sources.ConnectDB.ClassConnectSQLSV connect = new GroupProject.Sources.ConnectDB.ClassConnectSQLSV(); // Tạo một thể hiện của lớp kết nối
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * from PERSONAL";
            dl_Staff.DataSource = connect.GetData(sql);
            dl_Staff.DataBind();
        }
    }
}