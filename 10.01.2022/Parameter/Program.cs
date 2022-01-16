namespace Parameter
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    internal class Program
    {
        public static bool ThemSv(string connectionString, int maSv, string hoTen, DateTime ngaySinh, string gioiTinh)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "insertSV";
                    sqlCommand.Parameters.AddWithValue("@masv", maSv);
                    sqlCommand.Parameters.AddWithValue("@hoten", hoTen);
                    sqlCommand.Parameters.AddWithValue("@ngaysinh", ngaySinh);
                    sqlCommand.Parameters.AddWithValue("@gioitinh", gioiTinh);
                    sqlConnection.Open();
                    int i = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    return i > 0;
                }
            }
        }

        public static bool XoaSv(string connectionString, int maSv)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "deleteSV";
                    sqlCommand.Parameters.AddWithValue("@masv", maSv);
                    sqlConnection.Open();
                    int i = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    return i > 0;
                }
            }
        }

        public static void HienSv(string connectionString)
        {
            string sqlQuery = "select * from tblSinhVien";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        Console.WriteLine("Mã SV \t Tên SV \t Ngày sinh \t Giới tính");
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine("{0}\t{1}\t{2}\t{3}", sqlDataReader["MaSv"], sqlDataReader["sHoTen"], sqlDataReader["dNgaySinh"], sqlDataReader["sGioiTinh"]);
                        }
                        sqlDataReader.Close();
                    }
                    sqlConnection.Close();
                }
            }
        }

        //check trùng mã bằng sql reader
        public static bool CheckMaSv(string connectionString, int maSv)
        {
            string sqlQuery = "select * from tblSinhVien";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            if (maSv == sqlDataReader.GetInt32(0))
                                return true;
                        }
                        sqlDataReader.Close();
                    }
                    sqlConnection.Close();
                    return false;
                }
            }
        }

        //check trùng mã sqlcommand scalar
        public static int CheckMaSv_2(string connectionString, int maSv)
        {
            string query = "select count(MaSv) from tblSinhVien where MaSv = " + maSv;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlConnection.Open();
                        int i = (int)sqlCommand.ExecuteScalar();
                        sqlConnection.Close();
                        return i;
                    }
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
                    int luachon;
                    do
                    {
                        Console.WriteLine("\n---CÁC CHỨC NĂNG---");                    
                        Console.WriteLine("1. Hiển thị DSSV");
                        Console.WriteLine("2. Thêm Sinh viên");
                        Console.WriteLine("3. Xóa Sinh viên theo Mã Sv");
                        Console.WriteLine("0. Thoát");
                        Console.Write("BẠN CHỌN: ");
                        luachon = int.Parse(Console.ReadLine());
                        switch (luachon)
                        {
                            case 0:
                                break;
                            case 1:
                                Console.WriteLine("\n1. DANH SÁCH SINH VIÊN");
                                Program.HienSv(connectionString);
                                break;
                            case 2:
                                Console.WriteLine("\n2. THÊM SINH VIÊN");
                                int maSv,n; DateTime ngaySinh; string hoTen, gioiTinh;
                                Console.Write("Nhập số sinh viên muốn thêm: ");
                                n = int.Parse(Console.ReadLine());
                                for (int i = 0; i <n; i++)
                                {
                                    Console.WriteLine("\nTHÔNG TIN SINH VIÊN THỨ {0}", i+1);
                                    Console.Write("Nhập mã sinh viên: ");
                                    maSv = int.Parse(Console.ReadLine());
                                    bool checkMaSv = Program.CheckMaSv(connectionString, maSv);
                                    if (checkMaSv)
                                    {
                                        Console.WriteLine("Mã sinh viên đã tồn tại");
                                    }
                                    else
                                    {
                                        Console.Write("Nhập tên sinh viên: ");
                                        hoTen = Console.ReadLine();

                                        Console.Write("Nhập ngày sinh: ");
                                        ngaySinh = Convert.ToDateTime(Console.ReadLine());

                                        Console.Write("Nhập giới tính: ");
                                        gioiTinh = Console.ReadLine();
                                        bool checkInsert = Program.ThemSv(connectionString, maSv, hoTen, ngaySinh, gioiTinh);
                                        if (checkInsert)
                                        {
                                            Console.WriteLine("=> THÊM THÀNH CÔNG");
                                            Console.WriteLine("\n\tDANH SÁCH SINH VIÊN SAU KHI THÊM");
                                            Program.HienSv(connectionString);
                                        }
                                        else
                                            Console.WriteLine("=> THÊM THẤT BẠI");
                                    }                                    
                                }                               
                                break;
                            case 3:
                                Console.WriteLine("\n3. XÓA SINH VIÊN THEO MÃ SINH VIÊN");
                                int masv;
                                Console.Write("Nhập mã sinh viên cần xóa: ");
                                masv = int.Parse(Console.ReadLine());
                                int checkMa = Program.CheckMaSv_2(connectionString, masv);
                                if (checkMa==1)
                                {
                                    bool checkDelete = Program.XoaSv(connectionString, masv);
                                    if (checkDelete)
                                    {
                                        Console.WriteLine("=> XÓA THÀNH CÔNG");
                                        Console.WriteLine("\n\tDANH SÁCH SINH VIÊN SAU KHI XÓA");
                                        Program.HienSv(connectionString);
                                    }
                                    else
                                        Console.WriteLine("=> XÓA THẤT BẠI");
                                }
                                else
                                {
                                    Console.WriteLine("Mã sinh viên không tồn tại");
                                }
                                break;
                            default:
                                Console.Write("\nBạn chọn sai xin mời chọn lại:");
                                break;
                        }
                    } while (luachon != 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
