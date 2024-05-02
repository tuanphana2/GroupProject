using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject.Sources.ManageStaff.Functions
{
    public partial class AddStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_Add_Click(object sender, EventArgs e)
        {
            // Tạo truy vấn SQL để thêm một nhân viên mới
            string sql = "INSERT INTO Staff VALUES ('"+txt_pID.Text+"', '"+txt_FN.Text+"', '"+txt_LN.Text+"'," +
                "'"+txt_MN.Text+"', '"+datePicker.Text+"', '"+txt_SSN.Text+"', '"+txt_DL.Text+"', '"+txt_Adr1.Text+"'," +
                "'"+txt_Adr2.Text+"', '"+txt_City.Text+"', '"+txt_Country.Text+"', '"+txt_Zip.Text+"', '"+txt_Gender.Text+"'," +
                "'"+txt_Phone.Text+"', '"+txt_Email.Text+"', '"+txt_MS.Text+"', '"+txt_Ethnicity.Text+"')";

            // Sử dụng lớp ClassConnectSQLSV để thực hiện truy vấn SQL
            ClassConnectSQLSV sqlConnection = new ClassConnectSQLSV(); // Tạo một thể hiện của lớp kết nối
            int rowsAffected = sqlConnection.CapNhat(sql); // Thực hiện câu lệnh SQL và lấy số hàng bị ảnh hưởng

            // Phản hồi cho người dùng về kết quả của hành động
            if (rowsAffected > 0) // Nếu có ít nhất một hàng bị ảnh hưởng, nghĩa là thêm thành công
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