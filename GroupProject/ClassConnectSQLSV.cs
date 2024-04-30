using System; // Các kiểu dữ liệu cơ bản của C#
using System.Collections.Generic; // Không gian tên cho các bộ sưu tập như List, Dictionary
using System.Data; // Không gian tên cho các thao tác liên quan đến cơ sở dữ liệu
using System.Data.SqlClient;
using System.Linq; // Không gian tên cho các phương pháp LINQ
using System.Web; // Không gian tên cho ứng dụng web
using System.Web.UI; // Không gian tên cho các trang web dạng ASP.NET
using System.Web.UI.WebControls; // Không gian tên cho các điều khiển trên trang web
using Org.BouncyCastle.Tls; // Không gian tên cho các chức năng liên quan đến mã hóa

namespace GroupProject
{
    // Lớp này quản lý kết nối với cơ sở dữ liệu SQL Server và tương tác với nó
    public class ClassConnectSQLSV : System.Web.UI.Page
    {
        // Biến lưu giữ kết nối với SQL Server
        SqlConnection con;

        // Mở kết nối với SQL Server
        private void connect()
        {
            // Chuỗi kết nối chứa thông tin máy chủ, cơ sở dữ liệu, và các tùy chọn bảo mật
            string sqlcn = "Data Source=TUAN\\SQLEXPRESS1; Initial Catalog=HRM; Integrated Security=True; Encrypt=True; Trust Server Certificate=True";
            con = new SqlConnection(sqlcn); // Tạo kết nối với SQL Server
            con.Open(); // Mở kết nối
        }

        // Đóng kết nối với SQL Server
        private void disConnect()
        {
            // Chỉ đóng kết nối nếu nó đang mở
            if (con.State == ConnectionState.Open)
                con.Close(); // Đóng kết nối
        }

        // Thực hiện truy vấn SQL và trả về dữ liệu dưới dạng DataTable
        public DataTable GetData(string sql)
        {
            DataTable dt = new DataTable(); // Tạo DataTable rỗng để chứa dữ liệu
            try
            {
                connect(); // Mở kết nối với SQL Server
                SqlDataAdapter da = new SqlDataAdapter(sql, con); // Tạo bộ điều hợp dữ liệu
                da.Fill(dt); // Đổ dữ liệu từ truy vấn SQL vào DataTable
            }
            catch (Exception ex) // Xử lý ngoại lệ nếu có lỗi
            {
                dt = null; // Trả về null nếu có lỗi
                Console.WriteLine("Lỗi khi lấy dữ liệu: " + ex.Message); // In ra thông báo lỗi
            }
            finally
            {
                disConnect(); // Đóng kết nối sau khi thực hiện xong
            }
            return dt; // Trả về DataTable chứa kết quả truy vấn
        }

        // Thực hiện lệnh SQL như INSERT, UPDATE, hoặc DELETE và trả về số hàng bị ảnh hưởng
        public int CapNhat(string sql)
        {
            int ketqua = 0; // Biến lưu trữ số hàng bị ảnh hưởng
            try
            {
                connect(); // Mở kết nối với SQL Server
                SqlCommand cmd = new SqlCommand(sql, con); // Tạo lệnh SQL
                ketqua = cmd.ExecuteNonQuery(); // Thực hiện lệnh SQL và trả về số hàng bị ảnh hưởng
            }
            catch (Exception ex) // Xử lý ngoại lệ nếu có lỗi
            {
                ketqua = 0; // Trả về 0 nếu có lỗi
                Console.WriteLine("Lỗi khi cập nhật dữ liệu: " + ex.Message); // In ra thông báo lỗi
            }
            finally
            {
                disConnect(); // Đóng kết nối sau khi thực hiện xong
            }
            return ketqua; // Trả về số hàng bị ảnh hưởng
        }

        // Thực hiện truy vấn SQL và trả về giá trị đơn lẻ dưới dạng chuỗi (SELECT)
        public string LayDuLieuChu(string sql)
        {
            string ketqua = ""; // Biến lưu trữ giá trị chuỗi
            try
            {
                connect(); // Mở kết nối với SQL Server
                SqlCommand cmd = new SqlCommand(sql, con); // Tạo lệnh SQL
                ketqua = (string)cmd.ExecuteScalar(); // Thực hiện lệnh và trả về giá trị chuỗi
            }
            catch (Exception ex) // Xử lý ngoại lệ nếu có lỗi
            {
                ketqua = ""; // Trả về chuỗi rỗng nếu có lỗi
                Console.WriteLine("Lỗi khi lấy dữ liệu: " + ex.Message); // In ra thông báo lỗi
            }
            finally
            {
                disConnect(); // Đóng kết nối sau khi thực hiện xong
            }
            return ketqua; // Trả về giá trị chuỗi
        }

        // Thực hiện truy vấn SQL và trả về giá trị đơn lẻ dưới dạng số (float)
        public float LayGia(string sql)
        {
            float ketqua = 0; // Biến lưu giá trị số
            try
            {
                connect(); // Mở kết nối với SQL Server
                SqlCommand cmd = new SqlCommand(sql, con); // Tạo lệnh SQL
                ketqua = Convert.ToSingle(cmd.ExecuteScalar()); // Thực hiện lệnh và trả về giá trị dưới dạng float
            }
            catch (Exception ex) // Xử lý ngoại lệ nếu có lỗi
            {
                ketqua = 0; // Trả về 0 nếu có lỗi
                Console.WriteLine("Lỗi khi lấy giá trị: " + ex.Message); // In ra thông báo lỗi
            }
            finally
            {
                disConnect(); // Đóng kết nối sau khi thực hiện xong
            }
            return ketqua; // Trả về giá trị float
        }
    }
}
