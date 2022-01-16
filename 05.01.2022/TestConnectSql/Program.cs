using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;


namespace TestConnectSql
{
    class Program
    {
        public static bool ThemSv(string connectionString, int maSv, string hoTen, string ngaySinh, string gioiTinh)
        {
            string sqlInsert = "insert into tblSinhVien "+"values("+ maSv + ",N'" + hoTen +"','" + ngaySinh + "',N'" + gioiTinh + "')";
            Console.WriteLine(sqlInsert);

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlInsert, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    int i = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    return i>0;
                }    
            }
        }

        public static bool XoaSv(string connectionString, int maSv)
        {
            string sqlDelete = "delete from tblSinhVien where MaSv = " + maSv;
            Console.WriteLine(sqlDelete);

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlDelete, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    int i = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    return i > 0;
                }
            }
        }

        public static bool UpdateSv(string connectionString, int maSv, string tenSv)
        {
            string sqlDelete = "update tblSinhVien set sHoTen = " + tenSv + "where MaSv =" + maSv;
            Console.WriteLine(sqlDelete);

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlDelete, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    int i = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    return i > 0;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                string connectionString = "Data Source=DUOGWAS\\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    Console.WriteLine("THÊM SINH VIÊN");
                    int maSv;
                    DateTime ngaySinh;
                    string hoTen, gioiTinh;
                    Console.Write("Nhập mã sinh viên: ");
                    maSv = int.Parse(Console.ReadLine());
                    Console.Write("Nhập tên sinh viên: ");
                    hoTen = Console.ReadLine();
                    Console.Write("Nhập ngày sinh: ");
                    ngaySinh = Convert.ToDateTime(Console.ReadLine());
                    string ngaySinh_formatted = ngaySinh.ToString("yyyy-MM-dd");
                    //Console.WriteLine(Ngaysinh_formatted);
                    Console.Write("Nhập giới tính: ");
                    gioiTinh = Console.ReadLine();
                    bool checkInsert = Program.ThemSv(connectionString, maSv, hoTen, ngaySinh_formatted, gioiTinh);
                    if (checkInsert)
                    {
                        Console.WriteLine("Thêm thành công");
                    }
                    else
                    {
                        Console.WriteLine("Thêm thất bại");
                    }
                    
                    Console.WriteLine("\nXÓA SINH VIÊN");
                    int maSv_del;
                    Console.Write("Nhập mã sinh viên cần xóa: ");
                    maSv_del = int.Parse(Console.ReadLine());
                    bool checkDelete = Program.XoaSv(connectionString, maSv_del);
                    if (checkDelete)
                    {
                        Console.WriteLine("Xóa thành công");
                    }
                    else
                    {
                        Console.WriteLine("Xóa thất bại");
                    }             
                }    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
