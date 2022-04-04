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
    public partial class frmLuong : Form
    {
        public frmLuong()
        {
            InitializeComponent();
        }

        private void frmLuong_Load(object sender, EventArgs e)
        {
            DsLuong();
            this.dgvLuong.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            LayDuLieuComboBoxNhanVien();
            lbTenNv_error.Text = "";
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
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

        private void loạiPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoaiPhongBan f = new frmLoaiPhongBan();
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

        private void chiTiếtLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChiTietLuong f = new frmChiTietLuong();
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
        #endregion

        #region ComboBox
        private DataTable DsNhanVien()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select * from NhanVien", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        private void LayDuLieuComboBoxNhanVien()
        {
            DataTable dataTable = DsNhanVien();
            cbTenNv.DataSource = dataTable;
            cbTenNv.DisplayMember = "TenNV";
            cbTenNv.ValueMember = "MaNV";
        }
        #endregion

        #region DataGridView
        private DataTable DsLuong()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select * from v_DsLuong", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvLuong.DataSource = dataTable;
            return dataTable;
        }

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLuong.Enabled = false;
            txtMaLuong.Text = dgvLuong.CurrentRow.Cells["Mã lương"].Value.ToString();
            cbTenNv.Text = dgvLuong.CurrentRow.Cells["Tên nhân viên"].Value.ToString();
            lbMaLuong_error.Text = "";
            lbTenNv_error.Text = "";
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        #endregion

        #region checkDuLieu
        private int checkMaLuong()
        {
            string ma = txtMaLuong.Text;
            string sql = "select * from Luong where MaLuong = N'" + ma + "'";
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

        private int checkNhanVien_MaLuong()
        {
            string manv = cbTenNv.SelectedValue.ToString();
            string sql = "select * from Luong where MaNV = N'" + manv + "'";
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

        private void txtMaLuong_TextChanged(object sender, EventArgs e)
        {
            if (txtMaLuong.Text != "")
            {
                if (checkMaLuong() == 1)
                {
                    lbMaLuong_error.Visible = true;
                    lbMaLuong_error.Text = "Mã lương đã tồn tại";
                    lbMaLuong_error.ForeColor = Color.Red;
                    btnThem.Enabled = false;
                }
                else
                {
                    lbMaLuong_error.Visible = true;
                    lbMaLuong_error.Text = "Mã lương hợp lệ";
                    lbMaLuong_error.ForeColor = Color.Green;
                    btnThem.Enabled = true;
                    if (checkNhanVien_MaLuong() == 1)
                        btnThem.Enabled = false;
                    else
                        btnThem.Enabled = true;
                }
            }
            else
            {
                lbMaLuong_error.Visible = true;
                lbMaLuong_error.Text = "Mã lương không được bỏ trống";
                lbMaLuong_error.ForeColor = Color.Red;
                btnThem.Enabled = false;
            }
        }

        private void cbTenNv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkNhanVien_MaLuong() == 1)
            {
                lbTenNv_error.Visible = true;
                lbTenNv_error.Text = "Nhân viên này đã có mã lương";
                lbTenNv_error.ForeColor = Color.Red;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
            }
            else
            {
                lbTenNv_error.Visible = true;
                lbTenNv_error.Text = "Nhân viên này chưa có mã lương";
                lbTenNv_error.ForeColor = Color.Green;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                if (txtMaLuong.Text == "")
                    btnThem.Enabled = false;
                else
                {
                    if (checkMaLuong() == 1)
                        btnThem.Enabled = false;
                    else
                        btnThem.Enabled = true;
                }
            }
        }
        #endregion

        #region btnBoQua
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            DsLuong();
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtMaLuong.Enabled = true;
            txtMaLuong.Text = "";
            lbMaLuong_error.Text = "";
            lbTenNv_error.Text = "";
        }
        #endregion

        #region btnThem
        private void btnThem_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("ThemLuong", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@maluong", txtMaLuong.Text);
            sqlCommand.Parameters.AddWithValue("@manv", cbTenNv.SelectedValue);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            txtMaLuong.Text = "";
            txtMaLuong.Enabled = true;
            lbMaLuong_error.Text = "";
            lbTenNv_error.Text = "";
        }
        #endregion

        #region btnSua
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa mã lương này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(constr);
                SqlCommand sqlCommand = new SqlCommand("SuaLuong", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@maluong", txtMaLuong.Text);
                sqlCommand.Parameters.AddWithValue("@manv", cbTenNv.SelectedValue);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                frmLuong_Load(sender, e);
            }
            txtMaLuong.Text = "";
            txtMaLuong.Enabled = true;
            lbMaLuong_error.Text = "";
            lbTenNv_error.Text = "";
        }
        #endregion

        #region btnXoa
        private int checkLuong_ChiTietLuong()
        {
            string ma = txtMaLuong.Text;
            string sql = "select * from ChiTietLuong where MaLuong = N'" + ma + "'";
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkLuong_ChiTietLuong() == 1)
                MessageBox.Show("Không thể xóa vì mã lương này đang có chi tiết lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa mã lương này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
                    SqlConnection sqlConnection = new SqlConnection(constr);
                    SqlCommand sqlCommand = new SqlCommand("XoaLuong", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@maluong", txtMaLuong.Text);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    frmLuong_Load(sender, e);
                }
                txtMaLuong.Text = "";
                txtMaLuong.Enabled = true;
                lbMaLuong_error.Text = "";
                lbTenNv_error.Text = "";
            }
        }
        #endregion

        #region btnTimKiem
        private DataTable TimKiemLuong()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("TimKiemLuong", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@maluong", txtMaLuong.Text);
            sqlCommand.Parameters.AddWithValue("@tennv", cbTenNv.GetItemText(cbTenNv.SelectedItem).ToString());
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvLuong.DataSource = dataTable;
            if (dataTable.Rows.Count == 0)
                MessageBox.Show("Không có kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return dataTable;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemLuong();
        }
        #endregion

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            frmChiTietLuong f = new frmChiTietLuong();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
