using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject.Sources.ManageStaff.Functions
{
    public partial class AddStaff : System.Web.UI.Page
    {
        GroupProject.Sources.ConnectDB.ClassConnectSQLSV connect = new GroupProject.Sources.ConnectDB.ClassConnectSQLSV(); // Tạo một thể hiện của lớp kết nối
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_Add_Click(object sender, EventArgs e)
        {
            string pID = txt_pID.Text + "", fN = txt_FN.Text + "", lN = txt_LN.Text + "", mN = txt_MN.Text + "", sSN = txt_SSN.Text + "", dL = txt_DL.Text + "";
            string adr1 = txt_Adr1.Text + "", adr2 = txt_Adr2.Text + "", city = txt_City.Text + "", country = txt_Country.Text + "", zip = txt_Zip.Text + "";
            string gender = txt_Gender.Text + "", phone = txt_Phone.Text + "", email = txt_Email.Text + "", ms = txt_MS.Text + "";
            string eth = txt_Ethnicity.Text + "", shs = txt_Shareholder.Text + "", bpid = txt_Benefit.Text + "";

            // Lấy giá trị từ TextBox
            string rawDate = datePicker.Text;

            // Cố gắng chuyển đổi chuỗi ngày tháng thành DateTime
            DateTime parsedDate;
            bool isParsed = DateTime.TryParseExact(
                rawDate,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out parsedDate
            );
            string formattedDate="";
            if (isParsed)
            {
                // Định dạng lại DateTime thành chuỗi "yyyy-MM-dd"
                formattedDate = parsedDate.ToString("yyyy-MM-dd");
            }
            else
            {
                // Xử lý trường hợp không thể chuyển đổi ngày tháng
                Response.Write("Ngày tháng không hợp lệ.");
            }
            // Tạo truy vấn SQL để thêm một nhân viên mới
            string sql = "INSERT INTO PERSONAL VALUES('" + pID + "', '" + fN + "', '" + lN + "', '" + mN + "', '" + formattedDate + "', '" + sSN +
                "', '" + dL + "', '" + adr1 + "', '" + adr2 + "', '" + city + "', '" + country + "', '" + zip + "', '" + gender + "', '" + phone +
                "', '" + email + "', '" + ms + "', '" + eth + "', '" + shs + "', '" + bpid + "')";

            // Sử dụng lớp ClassConnectSQLSV để thực hiện truy vấn SQL
            int results = connect.ExecuteQuery(sql); // Thực hiện câu lệnh SQL và lấy số hàng bị ảnh hưởng

            // Phản hồi cho người dùng về kết quả của hành động
            if (results > 0) // Nếu có ít nhất một hàng bị ảnh hưởng, nghĩa là thêm thành công
            {
                Response.Write("Staff added successfully.");
            }
            else
            {
                Response.Write("Failed to add staff.");
            }
        }
    }
}