namespace DataAdapter
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    internal class Program
    {
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
        public static void HienSv_DataReader(string connectionString)
        {
            string sqlQuery = "select * from tblSinhVien";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                Console.WriteLine("{0}\t{1}\t{2}\t{3}", sqlDataReader["MaSv"], sqlDataReader["sHoTen"], sqlDataReader["dNgaySinh"], sqlDataReader["sGioiTinh"]);
                            }
                        }
                        else
                            Console.WriteLine("Không có dữ liệu");
                        sqlDataReader.Close();
                    }
                    sqlConnection.Close();
                }
            }
        }

        public static void HienSv_Adapter(string connectionString)
        {
            string query = "select * from tblSinhVien where MaSv =1";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        using (DataTable dataTable = new DataTable("tblSinhVien"))
                        {
                            Console.WriteLine("Tên bảng: {0}", dataTable.TableName);
                            dataAdapter.Fill(dataTable);
                            if (dataTable.Rows.Count == 0)
                                Console.WriteLine("Không có dữ liệu");
                            else
                            {
                                foreach (DataRow dataRow in dataTable.Rows)
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", dataRow["MaSv"], dataRow["sHoTen"], dataRow["dNgaySinh"], dataRow["sGioiTinh"]);
                            }
                        }
                    }
                }
            }
        }

        public static void HienSv_DataView(string connectionString)
        {
            string query = "select * from tblSinhVien";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        using (DataTable dataTable = new DataTable("tblSinhVien"))
                        {
                            dataAdapter.Fill(dataTable);
                            if (dataTable.Rows.Count == 0)
                                Console.WriteLine("Không có dữ liệu");
                            else
                            {
                                using (DataView dataView = new DataView(dataTable, "sGioiTinh like'%am%'", "dNgaySinh", DataViewRowState.CurrentRows))
                                {
                                    if (dataView.Count == 0)
                                        Console.WriteLine("Không có dữ liệu");
                                    else
                                    {
                                        foreach (DataRowView dataRowView in dataView)
                                            Console.WriteLine("{0}\t{1}\t{2}\t{3}", dataRowView["MaSv"], dataRowView["sHoTen"], dataRowView["dNgaySinh"], dataRowView["sGioiTinh"]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        internal static void ShowDataTable(DataTable table)
        {
            Console.WriteLine("Bảng: " + table.TableName);
            // Hiện thị các cột
            foreach (DataColumn column in table.Columns)
            {
                Console.Write($"{column.ColumnName,25}");
            }
            Console.WriteLine();

            // Hiện thị các dòng dữ liệu
            int number_cols = table.Columns.Count;
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < number_cols; i++)
                {
                    Console.Write($"{row[i],25}");
                }
                Console.WriteLine();
            }
        }

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

        internal static void Main(string[] args)
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
                        Console.WriteLine("1. Hiển thị DSSV sử dụng DataAdapter");
                        Console.WriteLine("2. Hiển thị DSSV sử dụng DataReader");
                        Console.WriteLine("3. Hiển thị DSSV nam, sắp xếp theo ngày sinh");
                        Console.WriteLine("4. InsertDataSet");
                        Console.WriteLine("5. DeleteDataSet");
                        Console.WriteLine("6. UpdateDataSet");
                        Console.WriteLine("0. Thoát");
                        Console.Write("BẠN CHỌN: ");
                        luachon = int.Parse(Console.ReadLine());
                        switch (luachon)
                        {
                            case 1:
                                Program.HienSv_Adapter(connectionString);
                                break;
                            case 2:
                                Program.HienSv_DataReader(connectionString);
                                break;
                            case 3:
                                Program.HienSv_DataView(connectionString);
                                break;
                            case 4:
                                string query = "select * from tblSinhVien";
                                string insert = "insert into tblSinhVien values(@masv, @hoten, @ngaysinh, @gioitinh)";
                                try
                                {
                                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                                    {
                                        sqlDataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
                                        DataSet dataSet = new DataSet();
                                        sqlDataAdapter.Fill(dataSet, "tblSinhVien");
                                        DataTable dataTable = dataSet.Tables["tblSinhVien"];
                                        Program.ShowDataTable(dataTable);
                                        SqlCommand sqlCommand = new SqlCommand(insert, sqlConnection);
                                        sqlCommand.Parameters.Add("@masv", SqlDbType.Int, 4, "MaSv");
                                        sqlCommand.Parameters.Add("@hoten", SqlDbType.NVarChar, 30, "sHoTen");
                                        sqlCommand.Parameters.Add("@ngaysinh", SqlDbType.Date, 12, "dNgaySinh");
                                        sqlCommand.Parameters.Add("@gioitinh", SqlDbType.NVarChar, 3, "sGioiTinh");
                                        int maSv, n; DateTime ngaySinh; string hoTen, gioiTinh;
                                        Console.Write("Nhập số sinh viên muốn thêm: ");
                                        n = int.Parse(Console.ReadLine());
                                        int column_old = dataTable.Rows.Count;
                                        for (int i = 0; i < n; i++)
                                        {
                                            Console.WriteLine("\nTHÔNG TIN SINH VIÊN THỨ {0}", i + 1);
                                            DataRow dataRow = dataTable.NewRow();
                                            Console.Write("Nhập mã sinh viên: ");
                                            maSv = int.Parse(Console.ReadLine());
                                            dataRow["MaSv"] = maSv;
                                            bool checkma = Program.CheckMaSv(connectionString, maSv);
                                            if (checkma)
                                            {
                                                do
                                                {
                                                    Console.Write("Mã sinh viên đã tồn tại, vui lòng nhập mã sinh viên khác: ");
                                                    maSv = int.Parse(Console.ReadLine());
                                                    dataRow["MaSv"] = maSv;
                                                    bool checkma2 = Program.CheckMaSv(connectionString, maSv);
                                                    if (checkma2 != true)
                                                        break;
                                                } while (checkma);
                                            }
                                            Console.Write("Nhập tên sinh viên: ");
                                            hoTen = Console.ReadLine();
                                            dataRow["sHoTen"] = hoTen;

                                            Console.Write("Nhập ngày sinh: ");
                                            ngaySinh = Convert.ToDateTime(Console.ReadLine());
                                            dataRow["dNgaySinh"] = ngaySinh;

                                            Console.Write("Nhập giới tính: ");
                                            gioiTinh = Console.ReadLine();
                                            dataRow["sGioiTinh"] = gioiTinh;

                                            sqlDataAdapter.InsertCommand = sqlCommand;
                                            dataTable.Rows.Add(dataRow);
                                            sqlDataAdapter.Update(dataSet, "tblSinhVien");
                                            if (dataTable.Rows.Count > column_old)
                                                Console.WriteLine("Thêm thành công");
                                            else
                                                Console.WriteLine("Thất bại");
                                        }
                                        Program.ShowDataTable(dataTable);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            case 5:
                                string sqlquery = "select * from tblSinhVien";                              
                                try
                                {
                                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                                    {
                                        sqlDataAdapter.SelectCommand = new SqlCommand(sqlquery, sqlConnection);
                                        DataSet dataSet = new DataSet();
                                        sqlDataAdapter.Fill(dataSet, "tblSinhVien");
                                        DataTable dataTable = dataSet.Tables["tblSinhVien"];
                                        Program.ShowDataTable(dataTable);
                                        
                                        int maSv;
                                        Console.Write("Nhập mã sinh viên: ");
                                        maSv = int.Parse(Console.ReadLine());                                      
                                        bool checkma = Program.CheckMaSv(connectionString, maSv);
                                        if (checkma)
                                        {
                                            XoaSv(connectionString, maSv);
                                        }                                     
                                        
                                        sqlDataAdapter.Update(dataSet, "tblSinhVien");
                                        Console.WriteLine("dữ liệu sau khi xóa");
                                        sqlDataAdapter.Fill(dataSet, "tblSinhVien");
                                        Program.ShowDataTable(dataTable);
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            case 6:
                                break;
                            default:
                                Console.WriteLine("Bạn chọn sai mời chọn lại:");
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
