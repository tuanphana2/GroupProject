using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject.Sources
{
    public partial class AlertsManagement : System.Web.UI.Page
    {
        GroupProject.Sources.ConnectDB.ClassConnectSQLSV connect = new GroupProject.Sources.ConnectDB.ClassConnectSQLSV();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAlerts(); // Load các cảnh báo khi trang được tải
            }
        }

        private void LoadAlerts()
        {
            // Cảnh báo ngày kỷ niệm làm việc
            DataTable dtWorkAnniversary = connect.GetData("SELECT * FROM JOB_HISTORY WHERE FROM_DATE = CONVERT(date, GETDATE())");
            if (dtWorkAnniversary.Rows.Count > 0)
            {
                workAnniversaryAlert.Text = "Hôm nay là ngày kỷ niệm làm việc của bạn!";
            }

            // Cảnh báo ngày nghỉ tích lũy
            DataTable dtLeaveAccumulation = connect.GetData("SELECT * FROM EMPLOYMENT_WORKING_TIME WHERE TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH >= 4");
            if (dtLeaveAccumulation.Rows.Count > 0)
            {
                leaveAccumulationAlert.Text = "Bạn đã tích lũy một lượng nghỉ phép đáng kể!";
            }

            // Cảnh báo thay đổi kế hoạch phúc lợi
            DataTable dtBenefitPlanChange = connect.GetData("SELECT * FROM PERSONAL WHERE BenefitPlanChangeDate >= GETDATE()");
            if (dtBenefitPlanChange.Rows.Count > 0)
            {
                benefitPlanAlert.Text = "Thông báo về thay đổi kế hoạch phúc lợi của bạn!";
            }

            // Cảnh báo sinh nhật
            DataTable dtBirthday = connect.GetData("SELECT * FROM PERSONAL WHERE BirthDate = CONVERT(date, GETDATE())");
            if (dtBirthday.Rows.Count > 0)
            {
                birthdayAlert.Text = "Chúc mừng sinh nhật!";
            }
        }
    }
}