using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using GroupProject.Sources.ConnectDB;

namespace GroupProject.Sources.ManageStaff.Functions
{
    public partial class AddStaff : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV(); // Tạo một thể hiện của lớp kết nối
        ConnectMySQL con = new ConnectMySQL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tdn = Session["tdn"] + "";
                if (tdn == "")
                    Response.Redirect("~/Sources/Login.aspx");
                LoadPayRates(); // Load dữ liệu vào Dropdownlist
                LoadBenefitPlan();// Load dữ liệu vào Dropdownlist
            }
        }
        private void LoadPayRates()
        {
            string sqlpr = "select * from mydb.`pay rates`;";
            ddl_PRID.DataSource = con.GetData(sqlpr);
            ddl_PRID.DataTextField = "Pay Rate Name";
            ddl_PRID.DataValueField = "idPay Rates";
            ddl_PRID.DataBind();
        }

        private void LoadBenefitPlan()
        {
            string sqlbp = "select * from BENEFIT_PLANS";
            ddl_Benefit.DataSource = connect.GetData(sqlbp);
            ddl_Benefit.DataTextField = "PLAN_NAME";
            ddl_Benefit.DataValueField = "BENEFIT_PLANS_ID";
            ddl_Benefit.DataBind();
        }

        protected void bt_Add_Click(object sender, EventArgs e)
        {
            string pID = txt_pID.Text + "", fN = txt_FN.Text + "", lN = txt_LN.Text + "", mN = txt_MN.Text + "", sSN = txt_SSN.Text + "", dL = txt_DL.Text + "";
            string adr1 = txt_Adr1.Text + "", adr2 = txt_Adr2.Text + "", city = txt_City.Text + "", country = txt_Country.Text + "", zip = txt_Zip.Text + "";
            string gender = ddl_Gentle.Text + "", phone = txt_Phone.Text + "", email = txt_Email.Text + "", ms = txt_MS.Text + "";
            string eth = txt_Ethnicity.Text + "", shs = txt_Shareholder.Text + "", bpid = ddl_Benefit.Text + "";
            string eN = txt_EN.Text + "", pR = txt_PR.Text + "", pRID = ddl_PRID.SelectedValue + "", vD = txt_VD.Text + "", pTD = txt_PTD.Text + "", pLY = txt_PLY.Text + "";

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
            string formattedDate = "";
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
            string sql = "INSERT INTO PERSONAL VALUES('" + pID + "', N'" + fN + "', N'" + lN + "', N'" + mN + "', '" + formattedDate + "', N'" + sSN +
                "', N'" + dL + "', N'" + adr1 + "', N'" + adr2 + "', N'" + city + "', N'" + country + "', N'" + zip + "', N'" + gender + "', N'" + phone +
                "', N'" + email + "', N'" + ms + "', '" + eth + "', '" + shs + "', '" + bpid + "')";
            string sql1 = "insert into mydb.employee values ('" + pID + "', N'" + eN + "', N'" + lN + "', N'" + fN + "', '" + sSN + "', N'" + pR +
               "', '" + pRID + "', '" + vD + "', '" + pTD + "', '" + pLY + "')";
            // Sử dụng lớp ClassConnectSQLSV để thực hiện truy vấn SQL
            int results = connect.ExecuteQuery(sql); // Thực hiện câu lệnh SQL và lấy số hàng bị ảnh hưởng
            int results1 = con.ExecuteQuery(sql1); // Thực hiện câu lệnh SQL và lấy số hàng bị ảnh hưởng

            // Phản hồi cho người dùng về kết quả của hành động
            if (results > 0 && results1 > 0) // Nếu có ít nhất một hàng bị ảnh hưởng, nghĩa là thêm thành công
            {
                Response.Write("The employee was added successfully.");
            }
            else
            {
                Response.Write("Failed to add employee.");
            }

        }
    }
}