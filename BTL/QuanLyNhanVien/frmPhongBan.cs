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

namespace QuanLyNhanVien
{
    public partial class frmPhongBan : Form
    {
        public frmPhongBan()
        {
            InitializeComponent();
        }

        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            btnThem_PB.Enabled = false;
            btnSua_PB.Enabled = false;
            btnXoa_PB.Enabled = false;
            DsPhongBan();
            LayDuLieuComboBoxTenLoaiPB();
            this.dgvPhongBan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;           
        }
        #region MenuStripClick
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrangChu f = new frmTrangChu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinTaiKhoan f = new frmThongTinTaiKhoan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap f = new frmDangNhap();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhongBan f = new frmPhongBan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChucVu f = new frmChucVu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien f = new frmNhanVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLuong f = new frmLuong();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void chiTiếtLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChiTietLuong f = new frmChiTietLuong();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        #endregion

        #region CheckTextBox
        private void txt_PB_maPB_Validating(object sender, CancelEventArgs e)
        {
            if (txt_PB_maPB.Text == "")
                errorProvider1.SetError(txt_PB_maPB, "Bạn chưa nhập Mã phòng ban");
            else
                errorProvider1.SetError(txt_PB_maPB, "");
        }

        private void txt_PB_tenPB_Validating(object sender, CancelEventArgs e)
        {
            if (txt_PB_tenPB.Text == "")
                errorProvider1.SetError(txt_PB_tenPB, "Bạn chưa nhập Tên phòng ban");
            else
                errorProvider1.SetError(txt_PB_tenPB, "");
        }

        #endregion

        #region CheckTrungDuLieu
        private int checkMaPB()
        {
            string ma = txt_PB_maPB.Text;
            string sql = "select * from PhongBan where MaPB = N'" + ma + "'";
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
                return 1;
            else
                return 0;
        }

        private int checkTenPB()
        {
            string ten = txt_PB_tenPB.Text;
            string sql = "select * from PhongBan where TenPB = N'" + ten + "'";
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
                return 1;
            else
                return 0;
        }

        private void txt_PB_maPB_TextChanged(object sender, EventArgs e)
        {
            if (txt_PB_maPB.Text != "")
            {
                if (checkMaPB() == 1)
                {
                    lbMaPB_error.Visible = true;
                    lbMaPB_error.Text = "Mã phòng ban đã tồn tại";
                    lbMaPB_error.ForeColor = Color.Red;
                    btnThem_PB.Enabled = false;
                }
                else
                {
                    lbMaPB_error.Visible = true;
                    lbMaPB_error.Text = "Mã phòng ban hợp lệ";
                    lbMaPB_error.ForeColor = Color.Green;
                    btnThem_PB.Enabled = true;
                    if (txt_PB_tenPB.Text == "")
                        btnThem_PB.Enabled = false;
                    else
                    {
                        if (checkTenPB() == 1)
                            btnThem_PB.Enabled = false;
                        else
                            btnThem_PB.Enabled = true;
                    }

                }
            }
            else
            {
                lbMaPB_error.Text = "Mã phòng ban không được bỏ trống";
                lbMaPB_error.ForeColor = Color.Red;
                btnThem_PB.Enabled = false;
            }
        }

        private void txt_PB_tenPB_TextChanged(object sender, EventArgs e)
        {

            if (txt_PB_tenPB.Text != "")
            {
                if (checkTenPB() == 1)
                {
                    lbTenPB_error.Visible = true;
                    lbTenPB_error.Text = "Tên phòng ban đã tồn tại";
                    lbTenPB_error.ForeColor = Color.Red;
                    btnThem_PB.Enabled = false;
                }
                else
                {
                    lbTenPB_error.Visible = true;
                    lbTenPB_error.Text = "Tên phòng ban hợp lệ";
                    lbTenPB_error.ForeColor = Color.Green;
                    btnThem_PB.Enabled = true;
                    if (txt_PB_maPB.Text == "")
                        btnThem_PB.Enabled = false;
                    else
                    {
                        if (checkMaPB() == 1)
                            btnThem_PB.Enabled = false;
                        else
                            btnThem_PB.Enabled = true;
                    }
                }
            }
            else
            {
                lbTenPB_error.Text = "Tên phòng ban không được bỏ trống";
                lbTenPB_error.ForeColor = Color.Red;
                btnThem_PB.Enabled = false;
            }
        }
        #endregion

        #region ComboBox
        private DataTable DsLoaiPhongBan()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select * from LoaiPhongBan", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        private void LayDuLieuComboBoxTenLoaiPB()
        {
            DataTable dataTable = DsLoaiPhongBan();
            cb_PB_tenLoaiPB.DataSource = dataTable;
            cb_PB_tenLoaiPB.DisplayMember = "TenLoaiPB";
            cb_PB_tenLoaiPB.ValueMember = "MaLoaiPB";
        }

        /*private void HienMaLoaiPB()
        {
            string ten = cb_PB_tenLoaiPB.GetItemText(cb_PB_tenLoaiPB.SelectedItem).ToString();
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select [Mã loại phòng ban] from v_DsLoaiPB where [Tên loại phòng ban] = N'" + ten + "'", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                txt_PB_maLoaiPB.Text = sqlDataReader.GetString(0);
            }
            sqlConnection.Close();
        }*/

        
        #endregion

        #region DataGridView
        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider1.SetError(txt_PB_maPB, "");
            errorProvider1.SetError(txt_PB_tenPB, "");
            errorProvider1.SetError(cb_PB_tenLoaiPB, "");
            btnThem_PB.Enabled = false;
            btnSua_PB.Enabled = true;
            btnXoa_PB.Enabled = true;
            txt_PB_maPB.Enabled = false;            
            txt_PB_maPB.Text = dgvPhongBan.CurrentRow.Cells["Mã phòng ban"].Value.ToString();
            txt_PB_tenPB.Text = dgvPhongBan.CurrentRow.Cells["Tên phòng ban"].Value.ToString();
            cb_PB_tenLoaiPB.Text = dgvPhongBan.CurrentRow.Cells["Loại phòng ban"].Value.ToString();
            lbMaPB_error.Visible = false;
            lbTenPB_error.Visible = false;           
        }

        private DataTable DsPhongBan()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select * from v_DsPhongBan", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvPhongBan.DataSource = dataTable;
            return dataTable;
        }
        #endregion

        #region btnBoQua
        private void btnBoQua_PB_Click(object sender, EventArgs e)
        {
            DsPhongBan();
            btnThem_PB.Enabled = true;
            btnSua_PB.Enabled = false;
            btnXoa_PB.Enabled = false;
            txt_PB_maPB.Enabled = true;
            txt_PB_maPB.Text = "";
            txt_PB_tenPB.Text = "";
            lbMaPB_error.Text = "";
            lbTenPB_error.Text = "";
        }
        #endregion

        #region btnThem
        private void btnThem_PB_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("ThemPhongBan", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@mapb", txt_PB_maPB.Text);
            sqlCommand.Parameters.AddWithValue("@maloaipb", cb_PB_tenLoaiPB.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@tenpb", txt_PB_tenPB.Text);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            frmPhongBan_Load(sender, e);
            txt_PB_maPB.Enabled = true;
            txt_PB_maPB.Text = "";
            txt_PB_tenPB.Text = "";
            lbMaPB_error.Text = "";
            lbTenPB_error.Text = "";
        }
        #endregion

        #region btnSua
        private void btnSua_PB_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa thông tin phòng ban này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(constr);
                SqlCommand sqlCommand = new SqlCommand("SuaPhongBan", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@mapb", txt_PB_maPB.Text);
                sqlCommand.Parameters.AddWithValue("@maloaipb", cb_PB_tenLoaiPB.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@tenpb", txt_PB_tenPB.Text);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                frmPhongBan_Load(sender, e);
            }
            txt_PB_maPB.Enabled = true;
            txt_PB_maPB.Text = "";
            txt_PB_tenPB.Text = "";
            lbMaPB_error.Text = "";
            lbTenPB_error.Text = "";
        }
        #endregion

        #region btnXoa
        private int checkPhongBan_NhanVien()
        {
            string mapb = txt_PB_maPB.Text;
            string sql = "select * from NhanVien where MaPB ='" + mapb.ToString() + "'";
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
                return 1;
            else
                return 0;
        }

        private void btnXoa_PB_Click(object sender, EventArgs e)
        {
            if (checkPhongBan_NhanVien() == 1)
            {
                MessageBox.Show("Không thể xóa vì đang có nhân viên làm việc tại phòng ban này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa phòng ban này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
                    SqlConnection sqlConnection = new SqlConnection(constr);
                    SqlCommand sqlCommand = new SqlCommand("XoaPhongBan", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@mapb", txt_PB_maPB.Text);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    frmPhongBan_Load(sender, e);
                }
            }
            txt_PB_maPB.Enabled = true;
            txt_PB_maPB.Text = "";
            txt_PB_tenPB.Text = "";
            lbMaPB_error.Text = "";
            lbTenPB_error.Text = "";
        }

        #endregion

        #region btnTimKiem
        private DataTable TimKiemPhongBan()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("TimKiemPhongBan", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@mapb", txt_PB_maPB.Text);
            sqlCommand.Parameters.AddWithValue("@tenpb", txt_PB_tenPB.Text);
            sqlCommand.Parameters.AddWithValue("@tenloaipb", cb_PB_tenLoaiPB.GetItemText(cb_PB_tenLoaiPB.SelectedItem).ToString());
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvPhongBan.DataSource = dataTable;
            if (dataTable.Rows.Count == 0)
                MessageBox.Show("Không có kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return dataTable;
        }

        private void btnTimKiem_PB_Click(object sender, EventArgs e)
        {
            TimKiemPhongBan();
        }


        #endregion

        private void cb_PB_tenLoaiPB_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(string.Format("bạn chọn {0} mã {1}", cb_PB_tenLoaiPB.Text, cb_PB_tenLoaiPB.SelectedValue), "tb", MessageBoxButtons.OK);
        }
    }
}

