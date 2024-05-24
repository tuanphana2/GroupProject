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
        //protected void bt_Import_Click(object sender, EventArgs e)
        //{
        //    // Lấy đường dẫn tệp Excel từ người dùng
        //    string filePath = FileUpload1.PostedFile.FileName;

        //    // Gọi phương thức để nhập dữ liệu từ tệp Excel
        //    ImportFromExcel(filePath);

        //    // Sau khi nhập xong, bạn có thể cập nhật giao diện người dùng hoặc cung cấp phản hồi
        //}

        //protected void ImportFromExcel(string filePath)
        //{
        //    using (var package = new ExcelPackage(new FileInfo(filePath)))
        //    {
        //        // Lấy Sheet đầu tiên từ tệp Excel
        //        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

        //        // Đọc dữ liệu từ các ô trong cột A đến cột S, bắt đầu từ hàng thứ 2 (do hàng đầu tiên thường là tiêu đề)
        //        int rowCount = worksheet.Dimension.Rows;
        //        for (int row = 2; row <= rowCount; row++)
        //        {
        //            string pID = worksheet.Cells[row, 1].Value?.ToString() ?? "";
        //            string fN = worksheet.Cells[row, 2].Value?.ToString() ?? "";
        //            string lN = worksheet.Cells[row, 3].Value?.ToString() ?? "";
        //            string mN = worksheet.Cells[row, 4].Value?.ToString() ?? "";
        //            string formattedDate = worksheet.Cells[row, 5].Value?.ToString() ?? "";
        //            string sSN = worksheet.Cells[row, 6].Value?.ToString() ?? "";
        //            string dL = worksheet.Cells[row, 7].Value?.ToString() ?? "";
        //            string adr1 = worksheet.Cells[row, 8].Value?.ToString() ?? "";
        //            string adr2 = worksheet.Cells[row, 9].Value?.ToString() ?? "";
        //            string city = worksheet.Cells[row, 10].Value?.ToString() ?? "";
        //            string country = worksheet.Cells[row, 11].Value?.ToString() ?? "";
        //            string zip = worksheet.Cells[row, 12].Value?.ToString() ?? "";
        //            string gender = worksheet.Cells[row, 13].Value?.ToString() ?? "";
        //            string phone = worksheet.Cells[row, 14].Value?.ToString() ?? "";
        //            string email = worksheet.Cells[row, 15].Value?.ToString() ?? "";
        //            string ms = worksheet.Cells[row, 16].Value?.ToString() ?? "";
        //            string eth = worksheet.Cells[row, 17].Value?.ToString() ?? "";
        //            string shs = worksheet.Cells[row, 18].Value?.ToString() ?? "";
        //            string bpid = worksheet.Cells[row, 19].Value?.ToString() ?? "";

        //            // Tạo truy vấn SQL để thêm một nhân viên mới
        //            string sql = "INSERT INTO PERSONAL VALUES('" + pID + "', '" + fN + "', '" + lN + "', '" + mN + "', '" + formattedDate + "', '" + sSN +
        //                "', '" + dL + "', '" + adr1 + "', '" + adr2 + "', '" + city + "', '" + country + "', '" + zip + "', '" + gender + "', '" + phone +
        //                "', '" + email + "', '" + ms + "', '" + eth + "', '" + shs + "', '" + bpid + "')";

        //            // Thực hiện truy vấn SQL để thêm dữ liệu vào cơ sở dữ liệu
        //            int results = connect.ExecuteQuery(sql); // Thực hiện câu lệnh SQL và lấy số hàng bị ảnh hưởng

        //            // Phản hồi cho người dùng về kết quả của hành động
        //            if (results > 0) // Nếu có ít nhất một hàng bị ảnh hưởng, nghĩa là thêm thành công
        //            {
        //                //Response.Write("The person was added successfully.");
        //            }
        //            else
        //            {
        //                //Response.Write("Failed to add person.");
        //            }
        //        }
        //    }
        //}
    }
}