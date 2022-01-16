using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17._01._2022
{
    class Program
    {
        public static void ShowDataTable(DataTable table)
        {
            Console.WriteLine("\t\tBảng: " + table.TableName);
            // Hiện thị các cột
            foreach (DataColumn column in table.Columns)
            {
                Console.Write($"{column.ColumnName,40}");
            }
            Console.WriteLine();

            // Hiện thị các dòng dữ liệu
            int number_cols = table.Columns.Count;
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < number_cols; i++)
                {
                    Console.Write($"{row[i],40}");
                }
                Console.WriteLine();
            }
        }
        //BẢNG PHONGBAN
        public static bool CheckMaPb(string connectionString, string maPb)
        {
            string sqlQuery = "select * from PhongBan";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            if (maPb == sqlDataReader.GetString(0))
                                return true;
                        }
                        sqlDataReader.Close();
                    }
                    sqlConnection.Close();
                    return false;
                }
            }
        }

        public static void HienDsPhongBan(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter)
        {
            string query = "select * from PhongBan";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                sqlDataAdapter.Fill(dataSet, "tblPhongBan");
                dataTable = dataSet.Tables["tblPhongBan"];
                Program.ShowDataTable(dataTable);
                sqlConnection.Close();
            }
        }

        public static void NhapDsPhongBan(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter)
        {
            string query = "select * from PhongBan";
            string insert = "insert into PhongBan values(@MaPB, @MaLoaiPB, @TenPB, @DiaChi)";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                sqlDataAdapter.Fill(dataSet, "tblPhongBan");
                dataTable = dataSet.Tables["tblPhongBan"];
                SqlCommand sqlCommand = new SqlCommand(insert, sqlConnection);
                sqlCommand.Parameters.Add("@MaPB", SqlDbType.NVarChar, 20, "MaPB");
                sqlCommand.Parameters.Add("@MaLoaiPB", SqlDbType.NVarChar, 20, "MaLoaiPB");
                sqlCommand.Parameters.Add("@TenPB", SqlDbType.NVarChar, 50, "TenPB");
                sqlCommand.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50, "DiaChi");
                int n; string maPb, maLoaiPb, tenPb, diaChi;
                Console.Write("Nhập số lượng phòng ban muốn thêm: ");
                n = int.Parse(Console.ReadLine());
                int column_old = dataTable.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("\nTHÔNG TIN PHÒNG BAN THỨ {0}", i + 1);
                    DataRow dataRow = dataTable.NewRow();
                    Console.Write("Nhập mã Phòng ban: ");
                    maPb = Console.ReadLine();
                    dataRow["MaPB"] = maPb;
                    bool checkmaPb = Program.CheckMaPb(connectionString, maPb);
                    if (checkmaPb)
                    {
                        do
                        {
                            Console.Write("Mã phòng ban đã tồn tại, vui lòng nhập mã phòng ban khác: ");
                            maPb = Console.ReadLine();
                            dataRow["MaPB"] = maPb;
                            bool checkma2 = Program.CheckMaPb(connectionString, maPb);
                            if (checkma2 != true)
                                break;
                        } while (checkmaPb);
                    }

                    Console.Write("Nhập mã Loại Phòng ban: ");
                    maLoaiPb = Console.ReadLine();
                    dataRow["MaLoaiPB"] = maLoaiPb;
                    bool checkmaLoaiPb = Program.CheckMaLoaiPb(connectionString, maLoaiPb);
                    if (checkmaLoaiPb != true)
                    {
                        do
                        {
                            Console.Write("Mã loại phòng ban không tồn tại, vui lòng nhập lại: ");
                            maLoaiPb = Console.ReadLine();
                            dataRow["MaLoaiPB"] = maLoaiPb;
                            bool checkmaLoaiPb2 = Program.CheckMaLoaiPb(connectionString, maLoaiPb);
                            if (checkmaLoaiPb2)
                                break;
                        } while (checkmaLoaiPb != true);
                    }

                    Console.Write("Nhập tên Phòng ban: ");
                    tenPb = Console.ReadLine();
                    dataRow["TenPB"] = tenPb;

                    Console.Write("Nhập địa chỉ Phòng ban: ");
                    diaChi = Console.ReadLine();
                    dataRow["DiaChi"] = diaChi;

                    sqlDataAdapter.InsertCommand = sqlCommand;
                    dataTable.Rows.Add(dataRow);
                    sqlDataAdapter.Update(dataSet, "tblPhongBan");
                    if (dataTable.Rows.Count > column_old)
                        Console.WriteLine("Thêm thành công");
                    else
                        Console.WriteLine("Thất bại");
                }
                Console.WriteLine("Danh sách sau khi thêm");
                Program.ShowDataTable(dataTable);
                sqlConnection.Close();
            }
        }

        public static bool ProcUpdateDiaChiPhongBan(string connectionString, string maPb, string diaChiPb)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "UpdateDiaChiPhongBan";
                sqlCommand.Parameters.AddWithValue("@mapb", maPb);
                sqlCommand.Parameters.AddWithValue("@diachi", diaChiPb);
                sqlConnection.Open();
                int i = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return i > 0;
            }
        }

        public static void SuaDiaChiPhongBan (string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter)
        {
            string query = "select * from PhongBan";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "tblPhongBan");
                dataTable = dataSet.Tables["tblPhongBan"];
                Program.ShowDataTable(dataTable);

                string maPb, diaChiMoi;
                Console.Write("Nhập mã phòng ban cần sửa địa chỉ: ");
                maPb = Console.ReadLine();
                bool checkmaPb = Program.CheckMaPb(connectionString, maPb);
                if (checkmaPb)
                {
                    Console.Write("Nhập địa chỉ mới: ");
                    diaChiMoi = Console.ReadLine();
                    bool checkupdate=ProcUpdateDiaChiPhongBan(connectionString, maPb, diaChiMoi);
                    if (checkupdate)
                        Console.WriteLine("Cập nhật thành công");
                    else
                        Console.WriteLine("Cập nhật thất bại");
                }
                else
                {
                    do
                    {
                        Console.Write("Mã phòng ban không tồn tại, vui lòng nhập lại: ");
                        maPb = Console.ReadLine();                       
                        bool checkmaPb2 = Program.CheckMaPb(connectionString, maPb);
                        if (checkmaPb2)
                        {
                            Console.Write("Nhập địa chỉ mới: ");
                            diaChiMoi = Console.ReadLine();
                            bool checkupdate = ProcUpdateDiaChiPhongBan(connectionString, maPb, diaChiMoi);
                            if (checkupdate)
                                Console.WriteLine("Cập nhật thành công");
                            else
                                Console.WriteLine("Cập nhật thất bại");
                            break;
                        }
                    } while (checkmaPb != true);
                }                  
                sqlDataAdapter.Update(dataSet, "tblPhongBan");
                Console.WriteLine("Danh sách phòng ban sau khi sửa đổi");              
                Program.ShowDataTable(dataTable);
                sqlConnection.Close();
            }
        }
        public static void ThongTinPhongBan(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter, string maPb)
        {
            string query = "select * from PhongBan where MaPB = '" + maPb + "'";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                bool checkmaPb = Program.CheckMaPb(connectionString, maPb);
                if (checkmaPb)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                    dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet,"tblThongTinPhongBan");
                    dataTable = dataSet.Tables["tblThongTinPhongBan"];
                    Program.ShowDataTable(dataTable);
                }
                else
                {
                    do
                    {
                        Console.Write("Mã phòng ban không tồn tại, vui lòng nhập lại: ");
                        maPb = Console.ReadLine();
                        bool checkmaPb2 = Program.CheckMaPb(connectionString, maPb);
                        if (checkmaPb2)
                        {
                            sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                            dataSet = new DataSet();
                            sqlDataAdapter.Fill(dataSet, "tblThongTinPhongBan");
                            dataTable = dataSet.Tables["tblThongTinPhongBan"];
                            Program.ShowDataTable(dataTable);
                            break;
                        }
                    } while (checkmaPb != true);
                }
                sqlConnection.Close();
            }
        }    

        //BẢNG LOAIPHONGBAN
        public static bool CheckMaLoaiPb(string connectionString, string maLoaiPb)
        {
            string sqlQuery = "select * from LoaiPhongBan";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            if (maLoaiPb == sqlDataReader.GetString(0))
                                return true;
                        }
                        sqlDataReader.Close();
                    }
                    sqlConnection.Close();
                    return false;
                }
            }
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                string connectionString = @"Data Source=DUOGWAS\SQLEXPRESS;Initial Catalog=QLNV;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    int chonbang, chon1, chon2, chon3, chon4;
                    DataSet dsQLNV = new DataSet();
                    SqlDataAdapter PhongBanAdapter = new SqlDataAdapter();
                    //PhongBanAdapter.Fill(dsQLNV, "tblPhongBan");
                    DataTable dtPhongBan = dsQLNV.Tables["tblPhongBan"];

                    SqlDataAdapter LoaiPhongBanAdapter = new SqlDataAdapter();
                    //LoaiPhongBanAdapter.Fill(dsQLNV, "tblLoaiPhongBan");
                    DataTable dtLoaiPhongBan = dsQLNV.Tables["tblLoaiPhongBan"];

                    SqlDataAdapter ChucVuAdapter = new SqlDataAdapter();
                    //ChucVuAdapter.Fill(dsQLNV, "tblChucVu");
                    DataTable dtChucVu = dsQLNV.Tables["tblChucVu"];

                    SqlDataAdapter NhanVienAdapter = new SqlDataAdapter();
                    //ChucVuAdapter.Fill(dsQLNV, "tblNhanVien");
                    DataTable dtNhanVien = dsQLNV.Tables["tblNhanVien"];
                    while (true)
                    {
                        Console.WriteLine("\n\t\t==============>MENU<==============");
                        Console.WriteLine("\t\t1.BẢNG PhongBan");
                        Console.WriteLine("\t\t2.BẢNG LoaiPhongBan");
                        Console.WriteLine("\t\t3.BẢNG ChucVu");
                        Console.WriteLine("\t\t4.Bảng NHANVIEN");
                        Console.WriteLine("\t\t0. Thoát");
                        Console.Write("\n\tBẠN CHỌN: ");
                        chonbang = int.Parse(Console.ReadLine());
                        if (chonbang == 0)
                            break;
                        else if (chonbang == 1)
                        {
                            do
                            {
                                Console.WriteLine();
                                Console.WriteLine("\n\t\t==============>MENU<==============");
                                Console.WriteLine("\t\t1. Hiển thị danh sách PhongBan");
                                Console.WriteLine("\t\t2. Nhập danh sách PhongBan");
                                Console.WriteLine("\t\t3. Sửa địa chỉ của PhongBan");
                                Console.WriteLine("\t\t4. Xem thông tin PhongBan theo mã phòng ban");
                                Console.WriteLine("\t\t0. Thoát");
                                Console.Write("\n\tBẠN CHỌN: ");
                                chon1 = int.Parse(Console.ReadLine());
                                switch (chon1)
                                {
                                    case 0:
                                        break;
                                    case 1:
                                        Program.HienDsPhongBan(connectionString, dsQLNV, dtPhongBan, PhongBanAdapter);
                                        break;
                                    case 2:
                                        Program.NhapDsPhongBan(connectionString, dsQLNV, dtPhongBan, PhongBanAdapter);
                                        break;
                                    case 3:
                                        Program.SuaDiaChiPhongBan(connectionString, dsQLNV, dtPhongBan, PhongBanAdapter);
                                        break;
                                    case 4:
                                        string maPb;
                                        Console.Write("Nhập mã phòng ban cần xem: ");
                                        maPb = Console.ReadLine();
                                        Program.ThongTinPhongBan(connectionString, dsQLNV, dtPhongBan, PhongBanAdapter,maPb);
                                        break;
                                    default:
                                        Console.WriteLine("Bạn chọn sai, mời chọn lại");
                                        break;
                                }
                            } while (chon1 != 0);
                        }
                        else if (chonbang == 2)
                        {
                            do
                            {
                                Console.WriteLine();
                                Console.WriteLine("\n\t\t==============>MENU<==============");
                                Console.WriteLine("\t\t1. Hiển thị danh sách LoaiPhongBan");
                                Console.WriteLine("\t\t2. Nhập danh sách LoaiPhongBan");
                                Console.WriteLine("\t\t3. Sửa thông tin LoaiPhongBan");
                                Console.WriteLine("\t\t4. Xóa LoaiPhongBan theo mã loại phòng ban");
                                Console.WriteLine("\t\t0. Thoát");
                                Console.Write("\n\tBẠN CHỌN: ");
                                chon2 = int.Parse(Console.ReadLine());
                                switch (chon2)
                                {
                                    case 0:
                                        break;
                                    case 1:

                                        break;
                                    default:
                                        Console.WriteLine("Bạn chọn sai, mời chọn lại");
                                        break;
                                }
                            } while (chon2 != 0);
                        }
                        else if (chonbang == 3)
                        {
                            do
                            {
                                Console.WriteLine();
                                Console.WriteLine("\n\t\t==============>MENU<==============");
                                Console.WriteLine("\t\t1. Hiển thị danh sách ChucVu");
                                Console.WriteLine("\t\t2. Nhập danh sách ChucVu");
                                Console.WriteLine("\t\t3. Sửa thông tin ChucVu");
                                Console.WriteLine("\t\t4. Xóa ChucVu theo mã chức vụ");
                                Console.WriteLine("\t\t0. Thoát");
                                Console.Write("\n\tBẠN CHỌN: ");
                                chon3 = int.Parse(Console.ReadLine());
                                switch (chon3)
                                {
                                    case 0:
                                        break;
                                    case 1:
                                        Program.HienDsPhongBan(connectionString, dsQLNV, dtPhongBan, PhongBanAdapter);
                                        break;
                                    default:
                                        Console.WriteLine("Bạn chọn sai, mời chọn lại");
                                        break;
                                }
                            } while (chon3 != 0);
                        }
                        else if (chonbang == 4)
                        {
                            do
                            {
                                Console.WriteLine();
                                Console.WriteLine("\n\t\t==============>MENU<==============");
                                Console.WriteLine("\t\t1. Hiển thị danh sách NhanVien");
                                Console.WriteLine("\t\t2. Nhập danh sách NhanVien");
                                Console.WriteLine("\t\t3. Sửa thông tin NhanVien");
                                Console.WriteLine("\t\t4. Xóa NhanVien theo mã nhân viên");
                                Console.WriteLine("\t\t0. Thoát");
                                Console.Write("\n\tBẠN CHỌN: ");
                                chon4 = int.Parse(Console.ReadLine());
                                switch (chon4)
                                {
                                    case 0:
                                        break;
                                    case 1:
                                        Program.HienDsPhongBan(connectionString, dsQLNV, dtPhongBan, PhongBanAdapter);
                                        break;
                                    default:
                                        Console.WriteLine("Bạn chọn sai, mời chọn lại");
                                        break;
                                }
                            } while (chon4 != 0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
    

