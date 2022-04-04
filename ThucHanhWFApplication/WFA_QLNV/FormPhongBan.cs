using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_QLNV
{
    public partial class FormPhongBan : Form
    {
        public FormPhongBan()
        {
            InitializeComponent();
        }

        private void FormPhongBan_Load(object sender, EventArgs e)
        {
            cbMaLoaiPb.Text = "";
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            layDsPhongBan();
            ComboBoxMaLoaiPb();
        }

        private DataTable layDsPhongBan()
        {
            string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
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
            string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(constr))
            {
                using (SqlCommand sqlCommand = new SqlCommand("select * from LoaiPhongBan", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        private void hienTenLoaipb()
        {
            string maLoaipb = cbMaLoaiPb.GetItemText(cbMaLoaiPb.SelectedItem).ToString();
            string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(constr))
            {
                using (SqlCommand sqlCommand = new SqlCommand("select TenLoaiPB from LoaiPhongBan where MaLoaiPB ='" + maLoaipb.ToString() + "'", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            txtTenLoaiPb.Text = sqlDataReader.GetString(0);
                        }                       
                    }
                    sqlConnection.Close();
                }
            }
        }

        private int checkMapb()
        {
            string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(constr))
            {
                string ma = txtMaPb.Text;
                string sql = "select * from PhongBan where MaPB ='" + ma.ToString() + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count > 0)
                            return 1;
                        else
                            return 0;
                    }
                }
            }
        }

        private int checkNhanVien_PhongBan()
        {
            string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(constr))
            {
                string mapb = txtMaPb.Text;
                string sql = "select * from NhanVien where MaPB ='" + mapb.ToString() + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count > 0)
                            return 1;
                        else
                            return 0;
                    }
                }
            }
        }

        private void ComboBoxMaLoaiPb()
        {
            DataTable dataTable = layDsLoaiPhongBan();
            cbMaLoaiPb.DataSource = dataTable;
            cbMaLoaiPb.DisplayMember = "MaLoaiPB";
            cbMaLoaiPb.ValueMember = "MaLoaiPB";
        }

        private void dgvPhongBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            hienTenLoaipb();
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaPb.Text = dgvPhongBan.CurrentRow.Cells["MaPB"].Value.ToString();
            txtMaPb.Enabled = false;
            cbMaLoaiPb.Text = dgvPhongBan.CurrentRow.Cells["MaLoaiPB"].Value.ToString();
            txtDiaChi.Text = dgvPhongBan.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtTenPb.Text = dgvPhongBan.CurrentRow.Cells["TenPB"].Value.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaPb.Text = "";
            txtMaPb.Enabled = true;
            txtTenPb.Text = "";
            txtDiaChi.Text = "";
            cbMaLoaiPb.Text = "";
            txtTenLoaiPb.Text = "";
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            layDsPhongBan();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa thông tin phòng ban này không?", "Thông báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("updatePB", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@mapb", txtMaPb.Text);
                        cmd.Parameters.AddWithValue("@maloaipb", cbMaLoaiPb.Text);
                        cmd.Parameters.AddWithValue("@tenpb", txtTenPb.Text);
                        cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        FormPhongBan_Load(sender, e);
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaPb.Text != "")
            {
                if (checkMapb() == 1)
                {
                    MessageBox.Show("Mã phòng ban đã tồn tại", "Thông báo");
                }
                else
                {
                    string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
                    using (SqlConnection cnn = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("ThemPB", cnn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@mapb", txtMaPb.Text);
                            cmd.Parameters.AddWithValue("@maloaipb", cbMaLoaiPb.Text);
                            cmd.Parameters.AddWithValue("@tenpb", txtTenPb.Text);
                            cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                            cnn.Open();
                            cmd.ExecuteNonQuery();
                            FormPhongBan_Load(sender, e);
                        }
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkNhanVien_PhongBan() == 1)
            {
                MessageBox.Show("Đang có nhân viên làm việc ở phòng ban này không thể xóa", "Thông báo");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa phòng ban này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
                    using (SqlConnection cnn = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("XoaPB", cnn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@mapb", txtMaPb.Text);
                            cnn.Open();
                            cmd.ExecuteNonQuery();
                            FormPhongBan_Load(sender, e);
                        }
                    }
                }                  
            }
        }

        private void Timkiem(string keyword)
        {
            string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
            string sqlSelect = "select * from PhongBan where TenPB like N'%" + keyword + "%'";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlSelect, cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvPhongBan.DataSource = dt;
                    }
                    cnn.Close();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Timkiem(txtSearch.Text);
        }

        private void cbMaLoaiPb_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienTenLoaipb();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(constr))
            {
                using (SqlCommand sqlCommand = new SqlCommand("select TenPB as[Tên phòng ban], TenLoaiPB as [Tên Loại phòng ban], count(NhanVien.MaPB) as [Số lượng nhân viên] from NhanVien inner join PhongBan on NhanVien.MaPB=PhongBan.MaPB inner join LoaiPhongBan on PhongBan.MaLoaiPB = LoaiPhongBan.MaLoaiPB group by TenPB, TenLoaiPB", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        dgvPhongBan.DataSource = dataTable;
                    }
                }
            }
        }

        private void cbMaLoaiPb_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
