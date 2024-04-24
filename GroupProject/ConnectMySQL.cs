using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace GroupProject
{
    public class ConnectMySQL
    {
        static void Main()
        {
            string connectionString = "server=localhost;user id=username;password=password;database=SI Payroll DB";

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Kết nối đến MySQL thành công!");

                // Thực hiện các thao tác với cơ sở dữ liệu ở đây...
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}