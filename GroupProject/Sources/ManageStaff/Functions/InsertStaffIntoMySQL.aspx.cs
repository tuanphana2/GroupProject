using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject.Sources.ManageStaff.Functions
{
    public partial class InsertStaffIntoMySQL : System.Web.UI.Page
    {
        GroupProject.Sources.ConnectDB.ConnectMySQL connect = new GroupProject.Sources.ConnectDB.ConnectMySQL(); // Tạo một thể hiện của lớp kết nối
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string sql = "SELECT * FROM mydb.employee;";
                    DataTable dt = connect.GetData(sql);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dl_Staff.DataSource = dt;
                        dl_Staff.DataBind();
                    }
                    else
                    {
                        Console.WriteLine("Không có dữ liệu để hiển thị.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi tải trang: " + ex.Message);
                }
            }
        }
    }
}