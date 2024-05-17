using System; // Không gian tên hệ thống cơ bản
using System.Collections.Generic; // Không gian tên cho các tập hợp dữ liệu
using System.Data; // Không gian tên cho các lớp dữ liệu
using System.Linq; // Không gian tên cho các phương pháp LINQ
using System.Web; // Không gian tên cho ứng dụng web
using System.Web.UI; // Không gian tên cho các trang web dạng ASP.NET
using MySql.Data.MySqlClient; // Không gian tên cho kết nối MySQL

namespace GroupProject.Sources.ConnectDB
{
    // Lớp quản lý kết nối với cơ sở dữ liệu MySQL
    public class ConnectMySQL
    {
        // Biến MySqlConnection để giữ kết nối với cơ sở dữ liệu MySQL
        MySqlConnection con;

        // Phương pháp mở kết nối với cơ sở dữ liệu MySQL
        private void Connect()
        {
            // Chuỗi kết nối bao gồm thông tin cần thiết để kết nối
            string sqlcn = "Server=localhost;Database=mydb;User Id=root;Password='';";
            con = new MySqlConnection(sqlcn); // Tạo đối tượng kết nối MySQL
            con.Open(); // Mở kết nối
        }

        // Phương pháp đóng kết nối với cơ sở dữ liệu MySQL
        private void Disconnect()
        {
            // Kiểm tra nếu kết nối đang mở
            if (con.State == ConnectionState.Open)
                con.Close(); // Đóng kết nối
        }

        // Phương pháp thực hiện truy vấn SQL và trả về kết quả dưới dạng DataTable
        public DataTable GetData(string sql)
        {
            DataTable dt = new DataTable(); // Tạo một bảng dữ liệu rỗng
            try
            {
                Connect(); // Mở kết nối với MySQL
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con); // Tạo bộ điều hợp dữ liệu
                da.Fill(dt); // Đổ dữ liệu từ truy vấn vào DataTable
            }
            catch (Exception ex) // Nếu có lỗi xảy ra
            {
                dt = null; // Trả về null nếu có lỗi
                Console.WriteLine("Lỗi khi lấy dữ liệu: " + ex.Message); // In ra thông báo lỗi
            }
            finally
            {
                Disconnect(); // Đóng kết nối sau khi thực hiện xong
            }
            return dt; // Trả về DataTable
        }

        // Phương pháp thực hiện lệnh SQL như INSERT, UPDATE, hoặc DELETE
        public int ExecuteQuery(string sql)
        {
            int ketqua = 0; // Biến để lưu số hàng bị ảnh hưởng
            try
            {
                Connect(); // Mở kết nối với MySQL
                MySqlCommand cmd = new MySqlCommand(sql, con); // Tạo lệnh SQL
                ketqua = cmd.ExecuteNonQuery(); // Thực hiện lệnh và trả về số hàng bị ảnh hưởng
            }
            catch (Exception ex) // Nếu có lỗi xảy ra
            {
                ketqua = 0; // Trả về 0 nếu có lỗi
                Console.WriteLine("Lỗi khi cập nhật dữ liệu: " + ex.Message); // In ra thông báo lỗi
            }
            finally
            {
                Disconnect(); // Đóng kết nối sau khi thực hiện xong
            }
            return ketqua; // Trả về số hàng bị ảnh hưởng
        }

        // Phương pháp thực hiện lệnh SQL và trả về giá trị đơn lẻ dưới dạng chuỗi
        public string LayDuLieuChu(string sql)
        {
            string ketqua = ""; // Biến để lưu giá trị chuỗi
            try
            {
                Connect(); // Mở kết nối với MySQL
                MySqlCommand cmd = new MySqlCommand(sql, con); // Tạo lệnh SQL
                ketqua = (string)cmd.ExecuteScalar(); // Thực hiện lệnh và trả về giá trị đơn lẻ
            }
            catch (Exception ex) // Nếu có lỗi xảy ra
            {
                ketqua = ""; // Trả về chuỗi rỗng nếu có lỗi
                Console.WriteLine("Lỗi khi lấy dữ liệu: " + ex.Message); // In ra thông báo lỗi
            }
            finally
            {
                Disconnect(); // Đóng kết nối sau khi thực hiện xong
            }
            return ketqua; // Trả về giá trị chuỗi
        }

        // Phương pháp thực hiện lệnh SQL và trả về giá trị đơn lẻ dưới dạng số
        public float LayGia(string sql)
        {
            float ketqua = 0; // Biến để lưu giá trị số
            try
            {
                Connect(); // Mở kết nối với MySQL
                MySqlCommand cmd = new MySqlCommand(sql, con); // Tạo lệnh SQL
                ketqua = Convert.ToSingle(cmd.ExecuteScalar()); // Thực hiện lệnh và trả về giá trị dưới dạng float
            }
            catch (Exception ex) // Nếu có lỗi xảy ra
            {
                ketqua = 0; // Trả về 0 nếu có lỗi
                Console.WriteLine("Lỗi khi lấy giá trị: " + ex.Message); // In ra thông báo lỗi
            }
            finally
            {
                Disconnect(); // Đóng kết nối sau khi thực hiện xong
            }
            return ketqua; // Trả về giá trị số
        }
    }
}
