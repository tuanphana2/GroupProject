using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject.Sources.ManageStaff.Functions
{
    public partial class EditStaff : System.Web.UI.Page
    {
        GroupProject.Sources.ConnectDB.ClassConnectSQLSV connect = new GroupProject.Sources.ConnectDB.ClassConnectSQLSV(); // Tạo một thể hiện của lớp kết nối
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        private void BindGrid()
        {
            string pID = Request.QueryString["PERSONAL_ID"] + "";
            string sql = $"select * from PERSONAL where PERSONAL_ID = {pID}";
            dl_Staff.DataSource = connect.GetData(sql);
            dl_Staff.DataBind();
        }
        protected void bt_Edit_Click(object sender, EventArgs e)
        {

        }
    }
}