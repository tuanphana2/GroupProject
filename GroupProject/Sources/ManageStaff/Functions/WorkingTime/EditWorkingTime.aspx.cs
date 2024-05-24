using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject.Sources.ManageStaff.Functions.WorkingTime
{
    public partial class EditWorkingTime : System.Web.UI.Page
    {
        GroupProject.Sources.ConnectDB.ClassConnectSQLSV connect = new GroupProject.Sources.ConnectDB.ClassConnectSQLSV();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string workingTimeId = Request.QueryString["EWTID"];
                if (!string.IsNullOrEmpty(workingTimeId))
                {
                    LoadWorkingTimeData(workingTimeId);
                }
            }
        }

        protected void bt_Update_Click(object sender, EventArgs e)
        {
            string ewtID = lbtb_EWTID.Text, eID = txt_EID.Text, mw = txt_MW.Text, nd = txt_NDAOWPM.Text, tn = txt_TNVWDPM.Text;

            DateTime yw;
            if (!DateTime.TryParseExact(txt_YW.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out yw))
            {
                // Handle invalid date
                return;
            }

            string updateSQL = $"UPDATE EMPLOYMENT_WORKING_TIME SET EMPLOYMENT_ID = '{eID}', YEAR_WORKING = '{yw.ToString("yyyy-MM-dd")}', MONTH_WORKING = '{mw}', " +
                               $"NUMBER_DAYS_ACTUAL_OF_WORKING_PER_MONTH = '{nd}', TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH = '{tn}' WHERE EMPLOYMENT_WORKING_TIME_ID = '{ewtID}'";
            connect.ExecuteQuery(updateSQL);
            // Sử dụng lớp ClassConnectSQLSV để thực hiện truy vấn SQL
            int results = connect.ExecuteQuery(updateSQL); // Thực hiện câu lệnh SQL và lấy số hàng bị ảnh hưởng

            // Phản hồi cho người dùng về kết quả của hành động
            if (results > 0) // Nếu có ít nhất một hàng bị ảnh hưởng, nghĩa là thêm thành công
            {
                Response.Write("Edit Working Time successfully.");
            }
            else
            {
                Response.Write("Failed to edit Working Time.");
            }
        }
        private void LoadWorkingTimeData(string workingTimeId)
        {
            string sql = $"SELECT * FROM EMPLOYMENT_WORKING_TIME WHERE EMPLOYMENT_WORKING_TIME_ID = '{workingTimeId}'";
            var dt = connect.GetData(sql);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                lbtb_EWTID.Text = row["EMPLOYMENT_WORKING_TIME_ID"].ToString();
                txt_EID.Text = row["EMPLOYMENT_ID"].ToString();
                txt_YW.Text = DateTime.Parse(row["YEAR_WORKING"].ToString()).ToString("yyyy-MM-dd");
                txt_MW.Text = row["MONTH_WORKING"].ToString();
                txt_NDAOWPM.Text = row["NUMBER_DAYS_ACTUAL_OF_WORKING_PER_MONTH"].ToString();
                txt_TNVWDPM.Text = row["TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH"].ToString();
            }
        }
    }
}