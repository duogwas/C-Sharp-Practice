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
    public partial class frmChucVu : Form
    {
        public frmChucVu()
        {
            InitializeComponent();
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            DsChucVu();
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
        private void txtMaCV_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaCV.Text == "")
            {
                errorProvider1.SetError(txtMaCV, "Bạn chưa nhập mã chức vụ");
                btnThem.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(txtMaCV, "");
            }
        }

        private void txtTenCV_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenCV.Text == "")
            {
                errorProvider1.SetError(txtTenCV, "Bạn chưa nhập tên chức vụ");
                btnThem.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(txtTenCV, "");
            }
        }
        #endregion

        #region CheckTrungDuLieu
        private int checkMaChucVu()
        {
            string ma = txtMaCV.Text;
            string sql = "select * from ChucVu where MaChucVu = N'" + ma + "'";
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

        private int checkTenChucVu()
        {
            string ten = txtTenCV.Text;
            string sql = "select * from ChucVu where TenChucVu = N'" + ten + "'";
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

        private void txtMaCV_TextChanged(object sender, EventArgs e)
        {
            if (txtMaCV.Text != "")
            {
                if (checkMaChucVu() == 1)
                {
                    lbMaCv_error.Visible = true;
                    lbMaCv_error.Text = "Mã chức vụ đã tồn tại";
                    lbMaCv_error.ForeColor = Color.Red;
                    btnThem.Enabled = false;
                }
                else
                {
                    lbMaCv_error.Visible = true;
                    lbMaCv_error.Text = "Mã chức vụ đã hợp lệ";
                    lbMaCv_error.ForeColor = Color.Green;
                    btnThem.Enabled = true;
                    if (txtTenCV.Text == "")
                    {
                        btnThem.Enabled = false;
                    }
                    else
                    {
                        if (checkTenChucVu() == 1)
                        {
                            btnThem.Enabled = false;
                        }
                        else
                        {
                            btnThem.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                lbMaCv_error.Visible = true;
                lbMaCv_error.Text = "Mã chức vụ không được bỏ trống";
                lbMaCv_error.ForeColor = Color.Red;
                btnThem.Enabled = false;
            }
        }

        private void txtTenCV_TextChanged(object sender, EventArgs e)
        {
            if (txtTenCV.Text != "")
            {
                if (checkTenChucVu() == 1)
                {
                    lbTenCv_error.Visible = true;
                    lbTenCv_error.Text = "Tên chức vụ đã tồn tại";
                    lbTenCv_error.ForeColor = Color.Red;
                    btnThem.Enabled = false;
                }
                else
                {
                    lbTenCv_error.Visible = true;
                    lbTenCv_error.Text = "Tên chức vụ hợp lệ";
                    lbTenCv_error.ForeColor = Color.Green;
                    btnThem.Enabled = true;
                    if (txtMaCV.Text == "")
                    {
                        btnThem.Enabled = false;
                    }
                    else
                    {
                        if (checkMaChucVu() == 1)
                        {
                            btnThem.Enabled = false;
                        }
                        else
                        {
                            btnThem.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                lbTenCv_error.Visible = true;
                lbTenCv_error.Text = "Tên chức vụ không được bỏ trống";
                lbTenCv_error.ForeColor = Color.Red;
                btnThem.Enabled = false;
            }
        }

        #endregion

        #region DataGridView
        private DataTable DsChucVu()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select * from v_DsChucVu", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvChucVu.DataSource = dataTable;
            return dataTable;
        }

        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider1.SetError(txtMaCV, "");
            errorProvider1.SetError(txtTenCV, "");
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaCV.Enabled = false;
            txtMaCV.Text = dgvChucVu.CurrentRow.Cells["Mã chức vụ"].Value.ToString();
            txtTenCV.Text = dgvChucVu.CurrentRow.Cells["Tên chức vụ"].Value.ToString();
            lbMaCv_error.Visible = false;
            lbTenCv_error.Visible = false;
        }
        #endregion

        #region btnBoQua
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            DsChucVu();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaCV.Enabled = true;
            txtMaCV.Text = "";
            txtTenCV.Text = "";
            lbMaCv_error.Text = "";
            lbTenCv_error.Text = "";
        }
        #endregion

        #region btnThem
        private void btnThem_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("ThemChucVu", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@macv", txtMaCV.Text);
            sqlCommand.Parameters.AddWithValue("@tencv", txtTenCV.Text);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            frmChucVu_Load(sender, e);
            txtMaCV.Text = "";
            txtTenCV.Text = "";
            lbMaCv_error.Text = "";
            lbTenCv_error.Text = "";
        }
        #endregion

        #region btnSua
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa thông tin Chức vụ này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(constr);
                SqlCommand sqlCommand = new SqlCommand("SuaChucVu", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@macv", txtMaCV.Text);
                sqlCommand.Parameters.AddWithValue("@tencv", txtTenCV.Text);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                frmChucVu_Load(sender, e);
            }
            txtMaCV.Enabled = true;
            txtMaCV.Text = "";
            txtTenCV.Text = "";
            lbMaCv_error.Text = "";
            lbTenCv_error.Text = "";
        }
        #endregion

        #region btnXoa
        private int checkChucVu_NhanVien()
        {
            string ma = txtMaCV.Text;
            string sql = "select * from NhanVien where MaChucVu = N'" + ma + "'";
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
            if (checkChucVu_NhanVien() == 1)
            {
                MessageBox.Show("Không thể xóa vì đang có nhân viên thuộc chức vụ này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa Chức vụ này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
                    SqlConnection sqlConnection = new SqlConnection(constr);
                    SqlCommand sqlCommand = new SqlCommand("XoaChucVu", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@macv", txtMaCV.Text);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    frmChucVu_Load(sender, e);
                }
            }
            txtMaCV.Enabled = true;
            txtMaCV.Text = "";
            txtTenCV.Text = "";
            lbMaCv_error.Text = "";
            lbTenCv_error.Text = "";
        }
        #endregion

        #region btnTimKiem
        private DataTable TimKiemChucVu()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("TimKiemChucVu", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@macv", txtMaCV.Text);
            sqlCommand.Parameters.AddWithValue("@tencv", txtTenCV.Text);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvChucVu.DataSource = dataTable;
            if (dataTable.Rows.Count == 0)
                MessageBox.Show("Không có kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return dataTable;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemChucVu();
        }
        #endregion     
    }
}
