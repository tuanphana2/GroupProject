using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
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
                LoadPayRates(); // Load dữ liệu vào ListBox
            }
        }
        private void LoadPayRates()
        {
            string sqlpr = "select * from mydb.`pay rates`;";
            ddl_PR.DataSource = connect.GetData(sqlpr);
            ddl_PR.DataTextField = "Pay Rate Name";
            ddl_PR.DataValueField = "idPay Rates";
            ddl_PR.DataBind();
        }
        protected void bt_add_Click(object sender, EventArgs e)
        {
            string pID = txt_pID.Text + "", eN = txt_EN.Text + "", lN = txt_LN.Text + "", fN = txt_FN.Text + "", sSN = txt_SSN.Text + "";
            string pR = ddl_PR.SelectedValue + "", pRID = txt_PRID.Text + "", vD = txt_VD.Text + "", pTD = txt_PTD.Text + "", pLY = txt_PLY.Text + "";

            // Tạo truy vấn SQL để thêm một nhân viên mới
            string sql = "insert into mydb.employee values ('" + pID + "', '" + eN + "', '" + lN + "', '" + fN + "', '" + sSN + "', '" + pR +
                "', '" + pRID + "', '" + vD + "', '" + pTD + "', '" + pLY + "')";

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