using GroupProject.Sources.ConnectDB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject.Sources.ManageStaff.Functions.Employment
{
    public partial class AddEmployment : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_Add_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ TextBox
            string eid = txt_EID.Text + "", ec = txt_EC.Text + "", es = txt_ES.Text + "", hdfw = txt_HDFW.Text + "", wcc = txt_WCC.Text + "", td = txt_TerDate.Text + "";
            string rhfw = txt_RDFW.Text + "", lrd = txt_LRD.Text + "", ndrowprm = txt_NDROWPRM.Text + "", pid = txt_PID.Text + "";
            hdfw = ConvertToDate(hdfw);
            td = ConvertToDate(td);
            rhfw = ConvertToDate(rhfw);
            lrd = ConvertToDate(lrd);
            string sqladd = "insert into EMPLOYMENT values('" + eid + "', '" + ec + "', '" + es + "', '" + hdfw
                + "', '" + wcc + "', '" + td + "', '" + rhfw + "', '" + lrd + "', '" + ndrowprm + "', '" + pid + "')";
            int results = connect.ExecuteQuery(sqladd); // Thực hiện câu lệnh SQL và lấy số hàng bị ảnh hưởng

            // Phản hồi cho người dùng về kết quả của hành động
            if (results > 0) // Nếu có ít nhất một hàng bị ảnh hưởng, nghĩa là thêm thành công
            {
                Response.Write("Employment added successfully.");
            }
            else
            {
                Response.Write("Failed to add employment.");
            }
        }
        public static string ConvertToDate(string rawDate)
        {
            DateTime parsedDate;
            bool isParsed = DateTime.TryParseExact(
                rawDate,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out parsedDate
            );

            if (isParsed)
            {
                // Định dạng lại DateTime thành chuỗi "yyyy-MM-dd"
                return parsedDate.ToString("yyyy-MM-dd");
            }
            else
            {
                // Trường hợp không thể chuyển đổi ngày tháng
                return "Ngày tháng không hợp lệ.";
            }
        }
    }
}