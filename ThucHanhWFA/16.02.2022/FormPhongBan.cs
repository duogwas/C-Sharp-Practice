using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16._02._2022
{
    public partial class FormPhongBan : Form
    {
        public FormPhongBan()
        {
            InitializeComponent();
        }

        private void FormPhongBan_Load(object sender, EventArgs e)
        {
            lbTbaoLoi.Enabled = false;
            layDsPhongBan();
            loadDsPhongBan_Combobox();
        }

        private DataTable layDsPhongBan()
        {
                string constr = @"Data Source=DUOGWAS\SQLEXPRESS;Initial Catalog=QLNV;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                //string constr = ConfigurationManager.ConnectionStrings["QLNV"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(constr))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("select * from PhongBan", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            DataTable dataTable = new DataTable();
                            sqlDataAdapter.Fill(dataTable);
                            dgvPhongBan.DataSource = dataTable;
                            return dataTable;
                        }
                    }
                }
        }

        private DataTable layDsLoaiPhongBan()
        {
            string constr = @"Data Source=DUOGWAS\SQLEXPRESS;Initial Catalog=QLNV;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //string constr = ConfigurationManager.ConnectionStrings["QLNV"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(constr))
            {
                using (SqlCommand sqlCommand = new SqlCommand("select * from LoaiPhongBan", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        //dgvPhongBan.DataSource = dataTable;
                        return dataTable;
                    }
                }
            }
        }
        private void loadDsPhongBan_Combobox()
        {
            DataTable dataTable = layDsPhongBan();
            cbMaLoaiPb.DataSource = dataTable;
            cbMaLoaiPb.DisplayMember = "MaLoaiPB";
            cbMaLoaiPb.ValueMember = "MaPB";
        }

        private static bool CheckMaPb(string connectionString, string maPb)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPB.Text = dgvPhongBan.CurrentRow.Cells["MaPB"].Value.ToString();
            txtMaPB.Enabled = false;
            cbMaLoaiPb.Text = dgvPhongBan.CurrentRow.Cells["MaLoaiPB"].Value.ToString();
            txtTenPB.Text = dgvPhongBan.CurrentRow.Cells["TenPB"].Value.ToString();
            txtDiaChi.Text = dgvPhongBan.CurrentRow.Cells["DiaChi"].Value.ToString();
            btnThem.Enabled = false;           
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=DUOGWAS\SQLEXPRESS;Initial Catalog=QLNV;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection sqlConnection = new SqlConnection(constr))
            {
                using (SqlCommand sqlCommand = new SqlCommand("ThemPB", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@mapb", txtMaPB.Text);
                    string maPb = Console.ReadLine();                   
                    //bool checkmaPb = CheckMaPb(constr, maPb);                   
                    sqlCommand.Parameters.AddWithValue("@maloaipb", cbMaLoaiPb.GetItemText(cbMaLoaiPb.SelectedItem).ToString());
                    sqlCommand.Parameters.AddWithValue("@tenpb", txtTenPB.Text);
                    sqlCommand.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    FormPhongBan_Load(sender, e);
                }
            }
        }
    }
}
