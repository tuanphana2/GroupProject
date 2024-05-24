using System;
using System.Globalization;
using System.Web.UI.WebControls;
using GroupProject.Sources.ConnectDB;

namespace GroupProject.Sources.ManageStaff.Functions
{
    public partial class EditStaff : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV();
        ConnectMySQL con = new ConnectMySQL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataIntoFields();
                LoadPayRates();
                LoadBenefitPlan();
            }
        }

        private void LoadDataIntoFields()
        {
            string personalId = Request.QueryString["PID"];

            if (!string.IsNullOrEmpty(personalId))
            {
                string sql = "SELECT * FROM PERSONAL WHERE PERSONAL_ID = '" + personalId + "'";
                var data = connect.GetData(sql);

                if (data != null && data.Rows.Count > 0)
                {
                    var row = data.Rows[0];

                    // Nạp dữ liệu vào các trường
                    lbtb_PID.Text = row["PERSONAL_ID"].ToString();
                    txt_FN.Text = row["CURRENT_FIRST_NAME"].ToString();
                    txt_LN.Text = row["CURRENT_LAST_NAME"].ToString();
                    txt_MN.Text = row["CURRENT_MIDDLE_NAME"].ToString();
                    txt_SSN.Text = row["SOCIAL_SECURITY_NUMBER"].ToString();
                    datePicker.Text = row["BIRTH_DATE"].ToString();
                    txt_DL.Text = row["DRIVERS_LICENSE"].ToString();
                    txt_Adr1.Text = row["CURRENT_ADDRESS_1"].ToString();
                    txt_Adr2.Text = row["CURRENT_ADDRESS_2"].ToString();
                    txt_City.Text = row["CURRENT_CITY"].ToString();
                    txt_Country.Text = row["CURRENT_COUNTRY"].ToString();
                    txt_Zip.Text = row["CURRENT_ZIP"].ToString();
                    ddl_Gentle.SelectedValue = row["CURRENT_GENDER"].ToString();
                    txt_Phone.Text = row["CURRENT_PHONE_NUMBER"].ToString();
                    txt_Email.Text = row["CURRENT_PERSONAL_EMAIL"].ToString();
                    txt_MS.Text = row["CURRENT_MARITAL_STATUS"].ToString();
                    txt_Ethnicity.Text = row["ETHNICITY"].ToString();
                    txt_Shareholder.Text = row["SHAREHOLDER_STATUS"].ToString();
                    ddl_Benefit.SelectedValue = row["BENEFIT_PLAN_ID"].ToString();

                    // Nạp dữ liệu vào các trường liên quan đến Employee
                    LoadEmployeeData(personalId);
                }
                else
                {
                    Response.Write("Không tìm thấy thông tin nhân viên.");
                }
            }
            else
            {
                Response.Write("Thiếu thông tin PersonalId.");
            }
        }

        private void LoadEmployeeData(string personalId)
        {
            string sql = "SELECT * FROM mydb.`employee` WHERE idEmployee = '" + personalId + "'";
            var data = con.GetData(sql);

            if (data != null && data.Rows.Count > 0)
            {
                var row = data.Rows[0];

                // Nạp dữ liệu vào các trường của bảng Employee
                txt_EN.Text = row["Employee Number"].ToString();
                ddl_PR.SelectedValue = row["Pay Rate"].ToString(); // Nếu PayRate là Text
                txt_PRID.Text = row["Pay Rates_idPay Rates"].ToString();
                txt_VD.Text = row["Vacation Days"].ToString();
                txt_PTD.Text = row["Paid To Date"].ToString();
                txt_PLY.Text = row["Paid Last Year"].ToString();
            }
            else
            {
                Response.Write("Không tìm thấy thông tin nhân viên.");
            }
        }

        private void LoadPayRates()
        {
            string sqlpr = "select * from mydb.`pay rates`;";
            ddl_PR.DataSource = con.GetData(sqlpr);
            ddl_PR.DataTextField = "Pay Rate Name";
            ddl_PR.DataValueField = "idPay Rates";
            ddl_PR.DataBind();
        }

        private void LoadBenefitPlan()
        {
            string sqlbp = "select * from BENEFIT_PLANS";
            ddl_Benefit.DataSource = connect.GetData(sqlbp);
            ddl_Benefit.DataTextField = "PLAN_NAME";
            ddl_Benefit.DataValueField = "BENEFIT_PLANS_ID";
            ddl_Benefit.DataBind();
        }

        protected void bt_Update_Click(object sender, EventArgs e)
        {
            string pID = lbtb_PID.Text + "", fN = txt_FN.Text + "", lN = txt_LN.Text + "", mN = txt_MN.Text + "", sSN = txt_SSN.Text + "", dL = txt_DL.Text + "";
            string adr1 = txt_Adr1.Text + "", adr2 = txt_Adr2.Text + "", city = txt_City.Text + "", country = txt_Country.Text + "", zip = txt_Zip.Text + "";
            string gender = ddl_Gentle.Text + "", phone = txt_Phone.Text + "", email = txt_Email.Text + "", ms = txt_MS.Text + "";
            string eth = txt_Ethnicity.Text + "", shs = txt_Shareholder.Text + "", bpid = ddl_Benefit.Text + "";
            string eN = txt_EN.Text + "", pR = ddl_PR.SelectedValue + "", pRID = txt_PRID.Text + "", vD = txt_VD.Text + "", pTD = txt_PTD.Text + "", pLY = txt_PLY.Text + "";

            string rawDate = datePicker.Text;
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
                formattedDate = parsedDate.ToString("yyyy-MM-dd");
            }
            else
            {
                Response.Write("Ngày tháng không hợp lệ.");
            }

            string sql = "UPDATE PERSONAL SET CURRENT_FIRST_NAME = N'" + fN + "', CURRENT_LAST_NAME = N'" + lN + "', CURRENT_MIDDLE_NAME = N'" + mN + "', BIRTH_DATE = '" + formattedDate +
                "', SOCIAL_SECURITY_NUMBER = N'" + sSN + "', DRIVERS_LICENSE = N'" + dL + "', CURRENT_ADDRESS_1 = N'" + adr1 + "', CURRENT_ADDRESS_2 = N'" + adr2 + "', CURRENT_CITY = N'" + city +
                "', CURRENT_COUNTRY = N'" + country + "', CURRENT_ZIP = N'" + zip + "', CURRENT_GENDER = N'" + gender + "', CURRENT_PHONE_NUMBER = N'" + phone + "', CURRENT_PERSONAL_EMAIL = N'" + email +
                "', CURRENT_MARITAL_STATUS = N'" + ms + "', ETHNICITY = '" + eth + "', SHAREHOLDER_STATUS = '" + shs + "', BENEFIT_PLAN_ID = '" + bpid + "' WHERE PERSONAL_ID = '" + pID + "'";
            string sql1 = "UPDATE mydb.`employee` SET `Employee Number` = N'" + eN + "', `Last Name` = N'" + lN + "', `First Name` = N'" + fN + "', `SSN` = '" + sSN + "', `Pay Rate` = N'" + pR +
               "', `Pay Rates_idPay Rates` = '" + pRID + "', `Vacation Days` = '" + vD + "', `Paid To Date` = '" + pTD + "', `Paid Last Year` = '" + pLY + "' WHERE idEmployee = '" + pID + "'";
            int results = connect.ExecuteQuery(sql);
            int results1 = con.ExecuteQuery(sql1);

            if (results > 0 && results1 > 0)
            {
                Response.Write("The employee was updated successfully.");
            }
            else
            {
                Response.Write("Failed to update employee.");
            }
        }
    }
}
