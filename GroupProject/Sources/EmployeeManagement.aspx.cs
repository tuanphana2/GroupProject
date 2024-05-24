using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject.Sources
{
    public partial class EmployeeManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load data for the first time
                LoadEmployeeData();
            }
        }
        private void LoadEmployeeData()
        {
            // Kết nối với cơ sở dữ liệu
            string connectionString = "your_connection_string_here";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employees";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    // Bind dữ liệu vào control, ví dụ GridView
                    // GridViewEmployees.DataSource = reader;
                    // GridViewEmployees.DataBind();
                }
                connection.Close();
            }
        }
    }
}