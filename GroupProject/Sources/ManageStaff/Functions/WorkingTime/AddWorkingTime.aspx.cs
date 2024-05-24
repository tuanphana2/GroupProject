using GroupProject.Sources.ConnectDB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject.Sources.ManageStaff.Functions.WorkingTime
{
    public partial class AddWorkingTime : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV(); // Tạo một thể hiện của lớp kết nối
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_Add_Click(object sender, EventArgs e)
        {
            string ewtID = txt_EWTID.Text + "", eID = txt_EID.Text + "", yw = txt_YW.Text + "", mw = txt_MW.Text + "", nDAOWPM = txt_NDAOWPM.Text + "", tnVWDPM = txt_TNVWDPM.Text + "";
            yw = ConvertToDate(yw);

            // Tạo truy vấn SQL để thêm một nhân viên mới
            string sql = "INSERT INTO EMPLOYMENT_WORKING_TIME VALUES('" + ewtID + "', '" + eID + "', '" + yw + "', '" + mw + "', '" + nDAOWPM + "', '" + tnVWDPM + "')";

            // Sử dụng lớp ClassConnectSQLSV để thực hiện truy vấn SQL
            int results = connect.ExecuteQuery(sql); // Thực hiện câu lệnh SQL và lấy số hàng bị ảnh hưởng

            // Phản hồi cho người dùng về kết quả của hành động
            if (results > 0) // Nếu có ít nhất một hàng bị ảnh hưởng, nghĩa là thêm thành công
            {
                Response.Write("Working Time added successfully.");
            }
            else
            {
                Response.Write("Failed to add Working Time.");
            }
        }
        public static string ConvertToDate(string yw)
        {
            DateTime parsedDate;
            bool isParsed = DateTime.TryParseExact(
                yw,
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