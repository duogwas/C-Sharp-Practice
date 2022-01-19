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
            //Console.WriteLine("\t\tBảng: " + table.TableName);
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

        public static void ShowDataTable2(DataTable table)
        {
            //Console.WriteLine("\t\tBảng: " + table.TableName);
            // Hiện thị các cột
            foreach (DataColumn column in table.Columns)
            {
                Console.Write($"{column.ColumnName,26}");
            }
            Console.WriteLine();

            // Hiện thị các dòng dữ liệu
            int number_cols = table.Columns.Count;
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < number_cols; i++)
                {
                    Console.Write($"{row[i],26}");
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
                dataTable.Clear();
                sqlDataAdapter.Fill(dataSet, "tblPhongBan");
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

        public static void SuaDiaChiPhongBan(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter)
        {
            string query = "select * from PhongBan";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                sqlDataAdapter.Fill(dataSet, "tblPhongBan");
                dataTable = dataSet.Tables["tblPhongBan"];
                string maPb, diaChiMoi;
                Console.Write("Nhập mã phòng ban cần sửa địa chỉ: ");
                maPb = Console.ReadLine();
                bool checkmaPb = Program.CheckMaPb(connectionString, maPb);
                if (checkmaPb)
                {
                    Console.Write("Nhập địa chỉ mới: ");
                    diaChiMoi = Console.ReadLine();
                    bool checkupdate = ProcUpdateDiaChiPhongBan(connectionString, maPb, diaChiMoi);
                    if (checkupdate)
                    {
                        Console.WriteLine("Cập nhật thành công");
                        sqlDataAdapter.Update(dataSet, "tblPhongBan");
                        Console.WriteLine("Danh sách phòng ban sau khi sửa đổi");
                        dataTable.Clear();
                        sqlDataAdapter.Fill(dataSet, "tblPhongBan");
                        Program.ShowDataTable(dataTable);
                    }
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
                            {
                                Console.WriteLine("Cập nhật thành công");
                                sqlDataAdapter.Update(dataSet, "tblPhongBan");
                                Console.WriteLine("Danh sách phòng ban sau khi sửa đổi");
                                dataTable.Clear();
                                sqlDataAdapter.Fill(dataSet, "tblPhongBan");
                                Program.ShowDataTable(dataTable);
                            }
                            else
                                Console.WriteLine("Cập nhật thất bại");
                            break;
                        }
                    } while (checkmaPb != true);
                }
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
                    sqlDataAdapter.Fill(dataSet, "tblThongTinPhongBan");
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

        public static void HienDsLoaiPhongBan(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter)
        {
            string query = "select * from LoaiPhongBan";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                sqlDataAdapter.Fill(dataSet, "tblLoaiPhongBan");
                dataTable = dataSet.Tables["tblLoaiPhongBan"];
                Program.ShowDataTable(dataTable);
                sqlConnection.Close();
            }
        }

        public static void NhapDsLoaiPhongBan(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter)
        {
            string query = "select * from LoaiPhongBan";
            string insert = "insert into LoaiPhongBan values(@MaLoaiPB, @TenLoaiPB)";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                sqlDataAdapter.Fill(dataSet, "tblLoaiPhongBan");
                dataTable = dataSet.Tables["tblLoaiPhongBan"];
                SqlCommand sqlCommand = new SqlCommand(insert, sqlConnection);
                sqlCommand.Parameters.Add("@MaLoaiPB", SqlDbType.NVarChar, 20, "MaLoaiPB");
                sqlCommand.Parameters.Add("@TenLoaiPB", SqlDbType.NVarChar, 20, "TenLoaiPB");
                int n; string maLoaiPb, tenLoaiPb;
                Console.Write("Nhập số lượng loại phòng ban muốn thêm: ");
                n = int.Parse(Console.ReadLine());
                int column_old = dataTable.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("\nTHÔNG TIN LOẠI PHÒNG BAN THỨ {0}", i + 1);
                    DataRow dataRow = dataTable.NewRow();
                    Console.Write("Nhập mã Loại Phòng ban: ");
                    maLoaiPb = Console.ReadLine();
                    dataRow["MaLoaiPB"] = maLoaiPb;
                    bool checkmaLoaiPb = Program.CheckMaLoaiPb(connectionString, maLoaiPb);
                    if (checkmaLoaiPb)
                    {
                        do
                        {
                            Console.Write("Mã loại phòng ban đã tồn tại, vui lòng nhập mã loại phòng ban khác: ");
                            maLoaiPb = Console.ReadLine();
                            dataRow["MaLoaiPB"] = maLoaiPb;
                            bool checkma2 = Program.CheckMaLoaiPb(connectionString, maLoaiPb);
                            if (checkma2 != true)
                                break;
                        } while (checkmaLoaiPb);
                    }

                    Console.Write("Nhập tên Loại Phòng ban: ");
                    tenLoaiPb = Console.ReadLine();
                    dataRow["TenLoaiPB"] = tenLoaiPb;

                    sqlDataAdapter.InsertCommand = sqlCommand;
                    dataTable.Rows.Add(dataRow);
                    sqlDataAdapter.Update(dataSet, "tblLoaiPhongBan");
                    if (dataTable.Rows.Count > column_old)
                        Console.WriteLine("Thêm thành công");
                    else
                        Console.WriteLine("Thất bại");
                }
                Console.WriteLine("Danh sách sau khi thêm");
                dataTable.Clear();
                sqlDataAdapter.Fill(dataSet, "tblLoaiPhongBan");
                Program.ShowDataTable(dataTable);
                sqlConnection.Close();
            }
        }

        public static bool ProcUpdateTenLoaiPhongBan(string connectionString, string maLoaiPb, string tenLoaiPb)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "UpdateTenLoaiPhongBan";
                sqlCommand.Parameters.AddWithValue("@maloaipb", maLoaiPb);
                sqlCommand.Parameters.AddWithValue("@tenloaipb", tenLoaiPb);
                sqlConnection.Open();
                int i = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return i > 0;
            }
        }

        public static void SuaTenLoaiPhongBan(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter)
        {
            string query = "select * from LoaiPhongBan";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                sqlDataAdapter.Fill(dataSet, "tblLoaiPhongBan");
                dataTable = dataSet.Tables["tblLoaiPhongBan"];
                string maLoaiPb, tenMoi;
                Console.Write("Nhập mã loại phòng ban cần sửa tên: ");
                maLoaiPb = Console.ReadLine();
                bool checkmaLoaiPb = Program.CheckMaLoaiPb(connectionString, maLoaiPb);
                if (checkmaLoaiPb)
                {
                    Console.Write("Nhập tên loại phòng ban mới: ");
                    tenMoi = Console.ReadLine();
                    bool checkupdate = ProcUpdateTenLoaiPhongBan(connectionString, maLoaiPb, tenMoi);
                    if (checkupdate)
                    {
                        Console.WriteLine("Cập nhật thành công");
                        sqlDataAdapter.Update(dataSet, "tblLoaiPhongBan");
                        Console.WriteLine("Danh sách loại phòng ban sau khi sửa đổi");
                        dataTable.Clear();
                        sqlDataAdapter.Fill(dataSet, "tblLoaiPhongBan");
                        Program.ShowDataTable(dataTable);
                    }
                    else
                    {
                        Console.WriteLine("Cập nhật thất bại");
                    }
                }
                else
                {
                    do
                    {
                        Console.Write("Mã loại phòng ban không tồn tại, vui lòng nhập lại: ");
                        maLoaiPb = Console.ReadLine();
                        bool checkmaLoaiPb2 = Program.CheckMaLoaiPb(connectionString, maLoaiPb);
                        if (checkmaLoaiPb2)
                        {
                            Console.Write("Nhập tên loại phòng ban mới: ");
                            tenMoi = Console.ReadLine();
                            bool checkupdate = ProcUpdateTenLoaiPhongBan(connectionString, maLoaiPb, tenMoi);
                            if (checkupdate)
                            {
                                Console.WriteLine("Cập nhật thành công");
                                sqlDataAdapter.Update(dataSet, "tblLoaiPhongBan");
                                Console.WriteLine("Danh sách loại phòng ban sau khi sửa đổi");
                                dataTable.Clear();
                                sqlDataAdapter.Fill(dataSet, "tblLoaiPhongBan");
                                Program.ShowDataTable(dataTable);
                            }
                            else
                                Console.WriteLine("Cập nhật thất bại");
                            break;
                        }
                    } while (checkmaLoaiPb != true);
                }
                sqlConnection.Close();
            }
        }

        public static void ThongTinLoaiPhongBan(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter, string maLoaiPb)
        {
            string query = "select * from LoaiPhongBan where MaLoaiPB = '" + maLoaiPb + "'";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                bool checkmaLoaiPb = Program.CheckMaLoaiPb(connectionString, maLoaiPb);
                if (checkmaLoaiPb)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                    sqlDataAdapter.Fill(dataSet, "tblThongTinLoaiPhongBan");
                    dataTable = dataSet.Tables["tblThongTinLoaiPhongBan"];
                    Program.ShowDataTable(dataTable);
                }
                else
                {
                    do
                    {
                        Console.Write("Mã loại phòng ban không tồn tại, vui lòng nhập lại: ");
                        maLoaiPb = Console.ReadLine();
                        bool checkmaLoaiPb2 = Program.CheckMaLoaiPb(connectionString, maLoaiPb);
                        if (checkmaLoaiPb2)
                        {
                            sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                            dataSet = new DataSet();
                            sqlDataAdapter.Fill(dataSet, "tblThongTinLoaiPhongBan");
                            dataTable = dataSet.Tables["tblThongTinLoaiPhongBan"];
                            Program.ShowDataTable(dataTable);
                            break;
                        }
                    } while (checkmaLoaiPb != true);
                }
                sqlConnection.Close();
            }
        }

        //BẢNG CHUCVU
        public static bool CheckMaChucVu(string connectionString, string maCv)
        {
            string sqlQuery = "select * from ChucVu";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            if (maCv == sqlDataReader.GetString(0))
                                return true;
                        }
                        sqlDataReader.Close();
                    }
                    sqlConnection.Close();
                    return false;
                }
            }
        }

        public static void HienDsChucVu(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter)
        {
            string query = "select * from ChucVu";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                sqlDataAdapter.Fill(dataSet, "tblChucVu");
                dataTable = dataSet.Tables["tblChucVu"];
                Program.ShowDataTable(dataTable);
                sqlConnection.Close();
            }
        }

        public static void NhapDsChucVu(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter)
        {
            string query = "select * from ChucVu";
            string insert = "insert into ChucVu values(@MaChucVu, @TenChucVu)";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                sqlDataAdapter.Fill(dataSet, "tblChucVu");
                dataTable = dataSet.Tables["tblChucVu"];
                SqlCommand sqlCommand = new SqlCommand(insert, sqlConnection);
                sqlCommand.Parameters.Add("@MaChucVu", SqlDbType.NVarChar, 20, "MaChucVu");
                sqlCommand.Parameters.Add("@TenChucVu", SqlDbType.NVarChar, 50, "TenChucVu");
                int n; string maCv, tenCv;
                Console.Write("Nhập số lượng chức vụ muốn thêm: ");
                n = int.Parse(Console.ReadLine());
                int column_old = dataTable.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("\nTHÔNG TIN CHỨC VỤ THỨ {0}", i + 1);
                    DataRow dataRow = dataTable.NewRow();
                    Console.Write("Nhập mã chức vụ: ");
                    maCv = Console.ReadLine();
                    dataRow["MaChucVu"] = maCv;
                    bool checkMacv = Program.CheckMaChucVu(connectionString, maCv);
                    if (checkMacv)
                    {
                        do
                        {
                            Console.Write("Mã chức vụ đã tồn tại, vui lòng nhập mã chức vụ khác: ");
                            maCv = Console.ReadLine();
                            dataRow["MaChucVu"] = maCv;
                            bool checkma2 = Program.CheckMaChucVu(connectionString, maCv);
                            if (checkma2 != true)
                                break;
                        } while (checkMacv);
                    }

                    Console.Write("Nhập tên Chức vụ: ");
                    tenCv = Console.ReadLine();
                    dataRow["TenChucVu"] = tenCv;

                    sqlDataAdapter.InsertCommand = sqlCommand;
                    dataTable.Rows.Add(dataRow);
                    sqlDataAdapter.Update(dataSet, "tblChucVu");
                    if (dataTable.Rows.Count > column_old)
                        Console.WriteLine("Thêm thành công");
                    else
                        Console.WriteLine("Thất bại");
                }
                Console.WriteLine("Danh sách sau khi thêm");
                dataTable.Clear();
                sqlDataAdapter.Fill(dataSet, "tblChucVu");
                Program.ShowDataTable(dataTable);
                //dataTable.Clear();
                sqlConnection.Close();
            }
        }

        public static bool ProcUpdateChucVu(string connectionString, string maCv, string tenCv)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "UpdateTenChucVu";
                sqlCommand.Parameters.AddWithValue("@machucvu", maCv);
                sqlCommand.Parameters.AddWithValue("@tenchucvu", tenCv);
                sqlConnection.Open();
                int i = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return i > 0;
            }
        }

        public static void SuaThongTinChucVu(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter)
        {
            string query = "select * from ChucVu";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                sqlDataAdapter.Fill(dataSet, "tblChucVu");
                dataTable = dataSet.Tables["tblChucVu"];
                string maCv, tenMoi;
                Console.Write("Nhập mã chức vụ cần cập nhật: ");
                maCv = Console.ReadLine();
                bool checkmaCv = Program.CheckMaChucVu(connectionString, maCv);
                if (checkmaCv)
                {
                    Console.Write("Nhập tên chức vụ mới: ");
                    tenMoi = Console.ReadLine();
                    bool checkupdate = ProcUpdateChucVu(connectionString, maCv, tenMoi);
                    if (checkupdate)
                    {
                        Console.WriteLine("Cập nhật thành công");
                        sqlDataAdapter.Update(dataSet, "tblChucVu");
                        Console.WriteLine("Danh sách chức vụ sau khi sửa đổi");
                        dataTable.Clear();
                        sqlDataAdapter.Fill(dataSet, "tblChucVu");
                        Program.ShowDataTable(dataTable);
                    }
                    else
                    {
                        Console.WriteLine("Cập nhật thất bại");
                    }
                }
                else
                {
                    Console.Write("Mã chức vụ không tồn tại");
                    /*do
                    {
                        Console.Write("Mã chức vụ không tồn tại, vui lòng nhập lại: ");
                        maCv = Console.ReadLine();
                        bool checkmaCv2 = Program.CheckMaChucVu(connectionString, maCv);
                        if (checkmaCv2)
                        {
                            Console.Write("Nhập tên chức vụ ban mới: ");
                            tenMoi = Console.ReadLine();
                            bool checkupdate = ProcUpdateChucVu(connectionString, maCv, tenMoi);
                            if (checkupdate)
                            {
                                Console.WriteLine("Cập nhật thành công");
                                sqlDataAdapter.Update(dataSet, "tblChucVu");
                                Console.WriteLine("Danh sách chức vụ sau khi sửa đổi");
                                dataTable.Clear();
                                sqlDataAdapter.Fill(dataSet, "tblChucVu");
                                Program.ShowDataTable(dataTable);
                            }
                            else
                                Console.WriteLine("Cập nhật thất bại");
                            break;
                        }
                    } while (checkmaCv != true);*/
                }
                sqlConnection.Close();
            }
        }

        public static bool ProcXoaChucVu(string connectionString, string maCv)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "XoaChucVu";
                sqlCommand.Parameters.AddWithValue("@machucvu", maCv);
                sqlConnection.Open();
                int i = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return i > 0;
            }
        }

        public static void XoaChucVu(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter, string maCv)
        {
            string query = "select * from ChucVu";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                sqlDataAdapter.Fill(dataSet, "tblChucVu");
                dataTable = dataSet.Tables["tblChucVu"];

                bool checkmaCv = Program.CheckMaChucVu(connectionString, maCv);
                if (checkmaCv)
                {
                    int checksl = Program.DemNvTheoChucVu(connectionString, maCv);
                    if (checksl > 0)
                    {
                        Console.WriteLine("Không thể xóa chức vụ này vì đang có nhân viên làm việc tại chức vụ này");
                    }
                    else
                    {
                        bool checkdel = ProcXoaChucVu(connectionString, maCv);
                        if (checkdel)
                        {
                            Console.WriteLine("Xóa thành công");
                            sqlDataAdapter.Update(dataSet, "tblChucVu");
                            Console.WriteLine("Dữ liệu sau khi xóa");
                            dataTable.Clear();
                            sqlDataAdapter.Fill(dataSet, "tblChucVu");
                            Program.ShowDataTable(dataTable);
                        }
                        else
                        {
                            Console.WriteLine("Xóa thất bại");
                        }
                    }
                }
                else
                {
                    Console.Write("Mã chức vụ không tồn tại: ");
                    /*do
                    {
                        Console.Write("Mã chức vụ không tồn tại, vui lòng nhập lại: ");
                        maCv = Console.ReadLine();
                        bool checkmaCv2 = Program.CheckMaChucVu(connectionString, maCv);
                        if (checkmaCv2)
                        {
                            bool checkdel = ProcXoaChucVu(connectionString, maCv);
                            if (checkdel)
                            {
                                Console.WriteLine("Xóa thành công");
                                sqlDataAdapter.Update(dataSet, "tblChucVu");
                                Console.WriteLine("Dữ liệu sau khi xóa");
                                dataTable.Clear();
                                sqlDataAdapter.Fill(dataSet, "tblChucVu");
                                Program.ShowDataTable(dataTable);
                            }
                            else
                            {
                                Console.WriteLine("Xóa thất bại");
                            }
                            break;
                        }
                    } while (checkmaCv != true);*/
                }
                sqlConnection.Close();
            }
        }

        public static void ThongTinChucVu(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter, string maCv)
        {
            string query = "select * from ChucVu where MaChucVu = '" + maCv + "'";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                bool checkmaCv = Program.CheckMaChucVu(connectionString, maCv);
                if (checkmaCv)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                    sqlDataAdapter.Fill(dataSet, "tblThongTinChucVu");
                    dataTable = dataSet.Tables["tblThongTinChucVu"];
                    Program.ShowDataTable(dataTable);
                }
                else
                {
                    Console.WriteLine("Mã chức vụ không tồn tại");
                    /*do
                     {
                         Console.Write("Mã chức vụ không tồn tại, vui lòng nhập lại: ");
                         maCv = Console.ReadLine();
                         bool checkmaCv2 = Program.CheckMaChucVu(connectionString, maCv);
                         if (checkmaCv2)
                         {
                             sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                             dataSet = new DataSet();
                             sqlDataAdapter.Fill(dataSet, "tblThongTinChucVu");
                             dataTable = dataSet.Tables["tblThongTinChucVu"];
                             Program.ShowDataTable(dataTable);
                             break;
                         }
                     } while (checkmaCv != true);*/
                }
                sqlConnection.Close();
            }
        }


        //BẢNG NHANVIEN
        public static bool CheckMaNhanVien(string connectionString, string maNv)
        {
            string sqlQuery = "select * from NhanVien";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            if (maNv == sqlDataReader.GetString(0))
                                return true;
                        }
                        sqlDataReader.Close();
                    }
                    sqlConnection.Close();
                    return false;
                }
            }
        }

        public static int DemNvTheoChucVu(string connectionString, string maCv)
        {
            int sl = 0;
            string sqlQuery = "select count (*) from NhanVien where MaChucVu = " + "'" + maCv + "'";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        sqlDataReader.Read();
                        sl = sqlDataReader.GetInt32(0);
                        return sl;
                        sqlDataReader.Close();
                    }
                    sqlConnection.Close();
                    return sl;
                }
            }
        }

        public static void HienDsNhanVien(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter)
        {
            string query = "select * from NhanVien";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                sqlDataAdapter.Fill(dataSet, "tblNhanVien");
                dataTable = dataSet.Tables["tblNhanVien"];
                Program.ShowDataTable2(dataTable);
                sqlConnection.Close();
            }
        }

        public static void NhapDsNhanVien(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter)
        {
            string query = "select * from NhanVien";
            string insert = "insert into NhanVien values(@MaNV,@TenNV,@NgaySinh,@GioiTinh,@SDT,@DiaChi,@MaChucVu,@MaPB)";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                sqlDataAdapter.Fill(dataSet, "tblNhanVien");
                dataTable = dataSet.Tables["tblNhanVien"];
                SqlCommand sqlCommand = new SqlCommand(insert, sqlConnection);
                sqlCommand.Parameters.Add("@MaNV", SqlDbType.NVarChar, 20, "MaNV");
                sqlCommand.Parameters.Add("@TenNV", SqlDbType.NVarChar, 50, "TenNV");
                sqlCommand.Parameters.Add("@NgaySinh", SqlDbType.DateTime, 13, "NgaySinh");
                sqlCommand.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 5, "GioiTinh");
                sqlCommand.Parameters.Add("@SDT", SqlDbType.NVarChar, 20, "SDT");
                sqlCommand.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50, "DiaChi");
                sqlCommand.Parameters.Add("@MaChucVu", SqlDbType.NVarChar, 20, "MaChucVu");
                sqlCommand.Parameters.Add("@MaPB", SqlDbType.NVarChar, 20, "MaPB");
                int n; string maNv, tenNv, gioiTinh, sdt, diaChi, maCv, maPb; DateTime ngaySinh;
                Console.Write("Nhập số lượng nhân viên muốn thêm: ");
                n = int.Parse(Console.ReadLine());
                int old_column = dataTable.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("\nTHÔNG TIN NHÂN VIÊN THỨ {0}", i + 1);
                    DataRow dataRow = dataTable.NewRow();
                    Console.Write("Nhập mã nhân viên: ");
                    maNv = Console.ReadLine();
                    dataRow["MaNv"] = maNv;
                    bool checkmaNv = Program.CheckMaNhanVien(connectionString, maNv);
                    if (checkmaNv)
                    {
                        do
                        {
                            Console.Write("Mã nhân viên đã tồn tại, hãy nhập mã nhân viên khác: ");
                            maNv = Console.ReadLine();
                            dataRow["MaNv"] = maNv;
                            bool checkmaNv2 = Program.CheckMaNhanVien(connectionString, maNv);
                            if (checkmaNv2 != true)
                                break;

                        } while (checkmaNv);
                    }
                    Console.Write("Nhập tên nhân viên: ");
                    tenNv = Console.ReadLine();
                    dataRow["TenNV"] = tenNv;
                    Console.Write("Nhập ngày sinh: ");
                    ngaySinh = Convert.ToDateTime(Console.ReadLine());
                    dataRow["NgaySinh"] = ngaySinh;
                    Console.Write("Nhập giới tính: ");
                    gioiTinh = Console.ReadLine();
                    dataRow["GioiTinh"] = gioiTinh;
                    Console.Write("Nhập số điện thoại: ");
                    sdt = Console.ReadLine();
                    dataRow["SDT"] = sdt;
                    Console.Write("Nhập địa chỉ: ");
                    diaChi = Console.ReadLine();
                    dataRow["DiaChi"] = diaChi;
                    Console.Write("Nhập mã chức vụ: ");
                    maCv = Console.ReadLine();
                    dataRow["MaChucVu"] = maCv;
                    bool checkmaCv = Program.CheckMaChucVu(connectionString, maCv);
                    if (checkmaCv != true)
                    {
                        do
                        {
                            Console.Write("Mã chức vụ không tồn tại, vui lòng nhập lại: ");
                            maCv = Console.ReadLine();
                            dataRow["MaChucVu"] = maCv;
                            bool checkmaCv2 = Program.CheckMaChucVu(connectionString, maCv);
                            if (checkmaCv2)
                                break;
                        } while (checkmaCv != true);
                    }
                    Console.Write("Nhập mã phòng ban: ");
                    maPb = Console.ReadLine();
                    dataRow["MaPB"] = maPb;
                    bool checkmaPb = Program.CheckMaPb(connectionString, maPb);
                    if (checkmaPb != true)
                    {
                        do
                        {
                            Console.Write("Mã phòng ban không tồn tại, vui lòng nhập lại: ");
                            maPb = Console.ReadLine();
                            dataRow["MaPB"] = maPb;
                            bool checkmaPb2 = Program.CheckMaPb(connectionString, maPb);
                            if (checkmaPb2)
                                break;
                        } while (checkmaPb != true);
                    }
                    sqlDataAdapter.InsertCommand = sqlCommand;
                    dataTable.Rows.Add(dataRow);
                    sqlDataAdapter.Update(dataSet, "tblNhanVien");
                    if (dataTable.Rows.Count > old_column)
                        Console.WriteLine("Thêm thành công");
                    else
                        Console.WriteLine("Thất bại");
                }
                Console.WriteLine("Danh sách sau khi thêm");
                dataTable.Clear();
                sqlDataAdapter.Fill(dataSet, "tblNhanVien");
                Program.ShowDataTable2(dataTable);
                sqlConnection.Close();
            }
        
        
    
    
    
    }

        public static bool ProcUpdateNhanVien(string connectionString, string maNv, string diaChi)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "UpdateDiaChiNhanVien";
                sqlCommand.Parameters.AddWithValue("@manv", maNv);
                sqlCommand.Parameters.AddWithValue("@diachi", diaChi);
                sqlConnection.Open();
                int i = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return i > 0;
            }
        }

        public static void SuaDiaChiNhanVien(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter)
        {
            string query = "select * from NhanVien";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                sqlDataAdapter.Fill(dataSet, "tblNhanVien");
                dataTable = dataSet.Tables["tblNhanVien"];
                string maNv, diaChiMoi;
                Console.Write("Nhập mã nhân viên cần cập nhật: ");
                maNv = Console.ReadLine();
                bool checkmaNv = Program.CheckMaNhanVien(connectionString, maNv);
                if (checkmaNv)
                {
                    Console.Write("Nhập địa chỉ mới: ");
                    diaChiMoi = Console.ReadLine();
                    bool checkupdate = ProcUpdateNhanVien(connectionString, maNv, diaChiMoi);
                    if (checkupdate)
                    {
                        Console.WriteLine("Cập nhật thành công");
                        sqlDataAdapter.Update(dataSet, "tblNhanVien");
                        Console.WriteLine("Danh sách nhân viên sau khi sửa đổi");
                        dataTable.Clear();
                        sqlDataAdapter.Fill(dataSet, "tblNhanVien");
                        Program.ShowDataTable2(dataTable);
                    }
                    else
                    {
                        Console.WriteLine("Cập nhật thất bại");
                    }
                }
                else
                {
                    Console.Write("Mã nhân viên không tồn tại");
                    /*do
                    {
                        Console.Write("Mã nhân viên không tồn tại, vui lòng nhập lại: ");
                        maNv = Console.ReadLine();
                        bool checkmaNv2 = Program.CheckMaNhanVien(connectionString, maNv);
                        if (checkmaNv2)
                        {
                            Console.Write("Nhập địa chỉ mới: ");
                            diaChiMoi = Console.ReadLine();
                            bool checkupdate = ProcUpdateNhanVien(connectionString, maNv, diaChiMoi);
                            if (checkupdate)
                            {
                                Console.WriteLine("Cập nhật thành công");
                                sqlDataAdapter.Update(dataSet, "tblNhanVien");
                                Console.WriteLine("Danh sách chức vụ sau khi sửa đổi");
                                dataTable.Clear();
                                sqlDataAdapter.Fill(dataSet, "tblNhanVien");
                                Program.ShowDataTable2(dataTable);
                            }
                            else
                                Console.WriteLine("Cập nhật thất bại");
                            break;
                        }
                    } while (checkmaNv != true);*/
                }
                sqlConnection.Close();
            }
        }

        public static bool ProcXoaNhanVien(string connectionString, string maNv)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "XoaNv";
                sqlCommand.Parameters.AddWithValue("@manv", maNv);
                sqlConnection.Open();
                int i = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return i > 0;
            }
        }

        public static void XoaNhanVien(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter, string maNv)
        {
            string query = "select * from NhanVien";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                sqlDataAdapter.Fill(dataSet, "tblNhanVien");
                dataTable = dataSet.Tables["tblNhanVien"];

                bool checkmaNv = Program.CheckMaNhanVien(connectionString, maNv);
                if (checkmaNv)
                {
                    bool checkdel = ProcXoaNhanVien(connectionString, maNv);
                    if (checkdel)
                    {
                        Console.WriteLine("Xóa thành công");
                        sqlDataAdapter.Update(dataSet, "tblNhanVien");
                        Console.WriteLine("Dữ liệu sau khi xóa");
                        dataTable.Clear();
                        sqlDataAdapter.Fill(dataSet, "tblNhanVien");
                        Program.ShowDataTable2(dataTable);
                    }
                    else
                    {
                        Console.WriteLine("Xóa thất bại");
                    }
                }
                else
                {
                    Console.Write("Mã nhân viên không tồn tại: ");
                    /*do
                    {
                        Console.Write("Mã nhân viên không tồn tại, vui lòng nhập lại: ");
                        maNv = Console.ReadLine();
                        bool checkmaNv2 = Program.CheckMaNhanVien(connectionString, maNv);
                        if (checkmaNv2)
                        {
                            bool checkdel = ProcXoaNhanVien(connectionString, maNv);
                            if (checkdel)
                            {
                                Console.WriteLine("Xóa thành công");
                                sqlDataAdapter.Update(dataSet, "tblNhanVien");
                                Console.WriteLine("Dữ liệu sau khi xóa");
                                dataTable.Clear();
                                sqlDataAdapter.Fill(dataSet, "tblNhanVien");
                                Program.ShowDataTable2(dataTable);
                            }
                            else
                            {
                                Console.WriteLine("Xóa thất bại");
                            }
                            break;
                        }
                    } while (checkmaNv != true);*/
                }
                sqlConnection.Close();
            }
        }

        public static void ThongTinNhanVien(string connectionString, DataSet dataSet, DataTable dataTable, SqlDataAdapter sqlDataAdapter, string maNv)
        {
            string query = "select * from NhanVien where MaNV = '" + maNv + "'";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                bool checkmaNv = Program.CheckMaNhanVien(connectionString, maNv);
                if (checkmaNv)
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                    sqlDataAdapter.Fill(dataSet, "tblThongTinNhanVien");
                    dataTable = dataSet.Tables["tblThongTinNhanVien"];
                    Program.ShowDataTable2(dataTable);
                }
                else
                {
                    Console.WriteLine("Mã nhân viên không tồn tại");
                   /* do
                    {
                        Console.Write("Mã nhân viên không tồn tại, vui lòng nhập lại: ");
                        maNv = Console.ReadLine();
                        bool checkmaNv2 = Program.CheckMaNhanVien(connectionString, maNv);
                        if (checkmaNv2)
                        {
                            sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                            dataSet = new DataSet();
                            sqlDataAdapter.Fill(dataSet, "tblThongTinNhanVien");
                            dataTable = dataSet.Tables["tblThongTinNhanVien"];
                            Program.ShowDataTable(dataTable);
                            break;
                        }
                    } while (checkmaNv != true);*/
                }
                sqlConnection.Close();
            }
        }


        //main
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
                    DataTable dtPhongBan = dsQLNV.Tables["tblPhongBan"];

                    SqlDataAdapter LoaiPhongBanAdapter = new SqlDataAdapter();
                    DataTable dtLoaiPhongBan = dsQLNV.Tables["tblLoaiPhongBan"];

                    SqlDataAdapter ChucVuAdapter = new SqlDataAdapter();
                    DataTable dtChucVu = dsQLNV.Tables["tblChucVu"];

                    SqlDataAdapter NhanVienAdapter = new SqlDataAdapter();
                    DataTable dtNhanVien = dsQLNV.Tables["tblNhanVien"];
                    while (true)
                    {
                        Console.WriteLine("\n\t\t==============>MENU TABLE<==============");
                        Console.WriteLine("\t\t1.BẢNG PhongBan");
                        Console.WriteLine("\t\t2.BẢNG LoaiPhongBan");
                        Console.WriteLine("\t\t3.BẢNG ChucVu");
                        Console.WriteLine("\t\t4.BẢNG NhanVien");
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
                                Console.WriteLine("\n\t\t==============>MENU CHỨC NĂNG<==============");
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
                                Console.WriteLine("\n\t\t==============>MENU CHỨC NĂNG<==============");
                                Console.WriteLine("\t\t1. Hiển thị danh sách LoaiPhongBan");
                                Console.WriteLine("\t\t2. Nhập danh sách LoaiPhongBan");
                                Console.WriteLine("\t\t3. Sửa thông tin LoaiPhongBan");
                                Console.WriteLine("\t\t4. Xem thông tin LoaiPhongBan theo mã loại phòng ban");
                                Console.WriteLine("\t\t0. Thoát");
                                Console.Write("\n\tBẠN CHỌN: ");
                                chon2 = int.Parse(Console.ReadLine());
                                switch (chon2)
                                {
                                    case 0:
                                        break;
                                    case 1:
                                        Program.HienDsLoaiPhongBan(connectionString, dsQLNV, dtLoaiPhongBan, LoaiPhongBanAdapter);
                                        break;
                                    case 2:
                                        Program.NhapDsLoaiPhongBan(connectionString, dsQLNV, dtLoaiPhongBan, LoaiPhongBanAdapter);
                                        break;
                                    case 3:
                                        Program.SuaTenLoaiPhongBan(connectionString, dsQLNV, dtLoaiPhongBan, LoaiPhongBanAdapter);
                                        break;
                                    case 4:
                                        string maLoaiPb;
                                        Console.Write("Nhập mã loại phòng ban cần xem: ");
                                        maLoaiPb = Console.ReadLine();
                                        Program.ThongTinLoaiPhongBan(connectionString, dsQLNV, dtLoaiPhongBan, LoaiPhongBanAdapter, maLoaiPb);
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
                                Console.WriteLine("\n\t\t==============>MENU CHỨC NĂNG<==============");
                                Console.WriteLine("\t\t1. Hiển thị danh sách ChucVu");
                                Console.WriteLine("\t\t2. Nhập danh sách ChucVu");
                                Console.WriteLine("\t\t3. Sửa thông tin tên ChucVu");
                                Console.WriteLine("\t\t4. Xóa ChucVu theo mã chức vụ");
                                Console.WriteLine("\t\t5. Tìm kiếm ChucVu theo mã chức vụ");
                                Console.WriteLine("\t\t0. Thoát");
                                Console.Write("\n\tBẠN CHỌN: ");
                                chon3 = int.Parse(Console.ReadLine());
                                switch (chon3)
                                {
                                    case 0:
                                        break;
                                    case 1:
                                        Program.HienDsChucVu(connectionString, dsQLNV, dtChucVu, ChucVuAdapter);
                                        break;
                                    case 2:
                                        Program.NhapDsChucVu(connectionString, dsQLNV, dtNhanVien, ChucVuAdapter);
                                        break;
                                    case 3:
                                        Program.SuaThongTinChucVu(connectionString, dsQLNV, dtChucVu, ChucVuAdapter);
                                        break;
                                    case 4:
                                        string maCv;
                                        Console.Write("Nhập mã chức vụ muốn xóa: ");
                                        maCv = Console.ReadLine();
                                        Program.XoaChucVu(connectionString, dsQLNV, dtChucVu, ChucVuAdapter, maCv);
                                        break;
                                    case 5:
                                        string maCv2;
                                        Console.Write("Nhập mã chức vụ muốn tìm kiếm: ");
                                        maCv2 = Console.ReadLine();
                                        Program.ThongTinChucVu(connectionString, dsQLNV, dtChucVu, ChucVuAdapter, maCv2);
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
                                Console.WriteLine("\n\t\t==============>MENU CHỨC NĂNG<==============");
                                Console.WriteLine("\t\t1. Hiển thị danh sách NhanVien");
                                Console.WriteLine("\t\t2. Nhập danh sách NhanVien");
                                Console.WriteLine("\t\t3. Sửa thông tin địa chỉ NhanVien");
                                Console.WriteLine("\t\t4. Xóa NhanVien theo mã nhân viên");
                                Console.WriteLine("\t\t5. Tìm kiếm NhanVien theo mã nhân viên");
                                Console.WriteLine("\t\t0. Thoát");
                                Console.Write("\n\tBẠN CHỌN: ");
                                chon4 = int.Parse(Console.ReadLine());
                                switch (chon4)
                                {
                                    case 0:
                                        break;
                                    case 1:
                                        Program.HienDsNhanVien(connectionString, dsQLNV, dtNhanVien, NhanVienAdapter);
                                        break;
                                    case 2:
                                        Program.NhapDsNhanVien(connectionString, dsQLNV, dtNhanVien, NhanVienAdapter);
                                        break;
                                    case 3:
                                        Program.SuaDiaChiNhanVien(connectionString, dsQLNV, dtNhanVien, NhanVienAdapter);
                                        break;
                                    case 4:
                                        string maNv;
                                        Console.Write("Nhập mã nhân viên cần xóa: ");
                                        maNv = Console.ReadLine();
                                        Program.XoaNhanVien(connectionString, dsQLNV, dtNhanVien, NhanVienAdapter, maNv);
                                        break;
                                    case 5:
                                        string maNv2;
                                        Console.Write("Nhập mã nhân viên cần tìm kiếm: ");
                                        maNv2 = Console.ReadLine();
                                        Program.ThongTinNhanVien(connectionString, dsQLNV, dtNhanVien, NhanVienAdapter, maNv2);
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
    

