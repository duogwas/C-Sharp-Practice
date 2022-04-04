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
    public partial class frmLoaiPhongBan : Form
    {
        public frmLoaiPhongBan()
        {
            InitializeComponent();
        }

        private void frmLoaiPhongBan_Load(object sender, EventArgs e)
        {
            DsLoaiPhongBan();
            btnThem_LPB.Enabled = false;
            btnSua_LPB.Enabled = false;
            btnXoa_LPB.Enabled = false;
        }

        #region MenuStripClick
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrangChu f = new frmTrangChu();
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
        private void txt_LPB_maLoaiPB_Validating(object sender, CancelEventArgs e)
        {
            if (txt_LPB_maLoaiPB.Text == "")
                errorProvider1.SetError(txt_LPB_maLoaiPB, "Bạn chưa nhập Mã loại phòng ban");
            else
                errorProvider1.SetError(txt_LPB_maLoaiPB, "");
        }

        private void txt_LPB_tenLoaiPB_Validating(object sender, CancelEventArgs e)
        {
            if (txt_LPB_tenLoaiPB.Text == "")
                errorProvider1.SetError(txt_LPB_tenLoaiPB, "Bạn chưa nhập Tên loại phòng ban");
            else
                errorProvider1.SetError(txt_LPB_tenLoaiPB, "");
        }
        #endregion

        #region CheckTrungDuLieu
        private int checkMaLoaiPB()
        {
            string ma = txt_LPB_maLoaiPB.Text;
            string sql = "select * from LoaiPhongBan where MaLoaiPB = N'" + ma + "'";
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

        private int checkTenLoaiPB()
        {
            string ten = txt_LPB_tenLoaiPB.Text;
            string sql = "select * from LoaiPhongBan where TenLoaiPB = N'" + ten + "'";
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

        private void txt_LPB_maLoaiPB_TextChanged(object sender, EventArgs e)
        {
            if (txt_LPB_maLoaiPB.Text != "")
            {
                if (checkMaLoaiPB() == 1)
                {
                    lbMaLoaiPB_error.Visible = true;
                    lbMaLoaiPB_error.Text = "Mã loại phòng ban đã tồn tại";
                    lbMaLoaiPB_error.ForeColor = Color.Red;
                    btnThem_LPB.Enabled = false;
                }
                else
                {
                    lbMaLoaiPB_error.Visible = true;
                    lbMaLoaiPB_error.Text = "Mã loại phòng ban hợp lệ";
                    lbMaLoaiPB_error.ForeColor = Color.Green;
                    btnThem_LPB.Enabled = true;
                    if (txt_LPB_tenLoaiPB.Text == "")
                    {
                        btnThem_LPB.Enabled = false;
                    }
                    else
                    {
                        if (checkTenLoaiPB() == 1)
                        {
                            btnThem_LPB.Enabled = false;
                        }
                        else
                        {
                            btnThem_LPB.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                lbMaLoaiPB_error.Visible = true;
                lbMaLoaiPB_error.Text = "Mã loại phòng ban không được bỏ trống";
                lbMaLoaiPB_error.ForeColor = Color.Red;
                btnThem_LPB.Enabled = false;
            }
        }

        private void txt_LPB_tenLoaiPB_TextChanged(object sender, EventArgs e)
        {
            if (txt_LPB_tenLoaiPB.Text != "")
            {
                if (checkTenLoaiPB() == 1)
                {
                    lbTenLoaiPB_error.Visible = true;
                    lbTenLoaiPB_error.Text = "Loại phòng ban đã tồn tại";
                    lbTenLoaiPB_error.ForeColor = Color.Red;
                    btnThem_LPB.Enabled = false;
                }
                else
                {
                    lbTenLoaiPB_error.Visible = true;
                    lbTenLoaiPB_error.Text = "Loại phòng ban hợp lệ";
                    lbTenLoaiPB_error.ForeColor = Color.Green;
                    btnThem_LPB.Enabled = true;
                    if (txt_LPB_maLoaiPB.Text == "")
                    {
                        btnThem_LPB.Enabled = false;
                    }
                    else
                    {
                        if (checkMaLoaiPB() == 1)
                        {
                            btnThem_LPB.Enabled = false;
                        }
                        else
                        {
                            btnThem_LPB.Enabled = true;
                        }
                    }

                }
            }
            else
            {
                lbTenLoaiPB_error.Visible = true;
                lbTenLoaiPB_error.Text = "Tên loại phòng ban không được bỏ trống";
                lbTenLoaiPB_error.ForeColor = Color.Red;
                btnThem_LPB.Enabled = false;
            }
        }
        #endregion

        #region DataGridView
        private void dgvLoaiPB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem_LPB.Enabled = false;
            btnSua_LPB.Enabled = true;
            btnXoa_LPB.Enabled = true;
            txt_LPB_maLoaiPB.Enabled = false;
            txt_LPB_maLoaiPB.Text = dgvLoaiPB.CurrentRow.Cells["Mã loại phòng ban"].Value.ToString();
            txt_LPB_tenLoaiPB.Text = dgvLoaiPB.CurrentRow.Cells["Tên loại phòng ban"].Value.ToString();
            lbTenLoaiPB_error.Visible = false;
            lbMaLoaiPB_error.Visible = false;
        }

        private DataTable DsLoaiPhongBan()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select * from v_DsLoaiPB", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvLoaiPB.DataSource = dataTable;
            return dataTable;
        }
        #endregion

        #region btnBoQua
        private void btnBoQua_LPB_Click(object sender, EventArgs e)
        {
            DsLoaiPhongBan();
            btnThem_LPB.Enabled = false;
            btnSua_LPB.Enabled = false;
            btnXoa_LPB.Enabled = false;
            txt_LPB_maLoaiPB.Enabled = true;
            txt_LPB_maLoaiPB.Text = "";
            txt_LPB_tenLoaiPB.Text = "";
            lbMaLoaiPB_error.Text = "";
            lbTenLoaiPB_error.Text = "";
        }
        #endregion

        #region btnThem
        private void btnThem_LPB_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("ThemLoaiPB", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@maloaipb", txt_LPB_maLoaiPB.Text);
            sqlCommand.Parameters.AddWithValue("@tenloaipb", txt_LPB_tenLoaiPB.Text);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            frmLoaiPhongBan_Load(sender, e);
            txt_LPB_maLoaiPB.Text = "";
            txt_LPB_tenLoaiPB.Text = "";
            lbMaLoaiPB_error.Text = "";
            lbTenLoaiPB_error.Text = "";
        }
        #endregion

        #region btnSua
        private void btnSua_LPB_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa thông tin Loại phòng ban này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(constr);
                SqlCommand sqlCommand = new SqlCommand("SuaLoaiPB", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@maloaipb", txt_LPB_maLoaiPB.Text);
                sqlCommand.Parameters.AddWithValue("@tenloaipb", txt_LPB_tenLoaiPB.Text);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                frmLoaiPhongBan_Load(sender, e);
            }
            txt_LPB_maLoaiPB.Enabled = true;
            txt_LPB_maLoaiPB.Text = "";
            txt_LPB_tenLoaiPB.Text = "";
            lbMaLoaiPB_error.Text = "";
            lbTenLoaiPB_error.Text = "";
        }
        #endregion

        #region btnXoa
        private int checkLoaiPB_PhongBan()
        {
            string maloai = txt_LPB_maLoaiPB.Text;
            string sql = "select * from PhongBan where MaLoaiPB = N'" + maloai + "'";
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

        private void btnXoa_LPB_Click(object sender, EventArgs e)
        {
            if (checkLoaiPB_PhongBan() == 1)
            {
                MessageBox.Show("Không thể xóa vì đang có phòng ban thuộc loại phòng ban này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa Loại phòng ban này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
                    SqlConnection sqlConnection = new SqlConnection(constr);
                    SqlCommand sqlCommand = new SqlCommand("XoaLoaiPB", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@maloaipb", txt_LPB_maLoaiPB.Text);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    frmLoaiPhongBan_Load(sender, e);
                }
            }
            txt_LPB_maLoaiPB.Enabled = true;
            txt_LPB_maLoaiPB.Text = "";
            txt_LPB_tenLoaiPB.Text = "";
            lbMaLoaiPB_error.Text = "";
            lbTenLoaiPB_error.Text = "";
        }
        #endregion

        #region btnTimKiem
        private DataTable TimKiemLoaiPB()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("TimKiemLoaiPB", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@maloaipb", txt_LPB_maLoaiPB.Text);
            sqlCommand.Parameters.AddWithValue("@tenloaipb", txt_LPB_tenLoaiPB.Text);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvLoaiPB.DataSource = dataTable;
            if (dataTable.Rows.Count == 0)
                MessageBox.Show("Không có kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return dataTable;
        }

        private void btnTimKiem_LPB_Click(object sender, EventArgs e)
        {
            TimKiemLoaiPB();
        }

        #endregion

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeLoaiPB f = new ThongKeLoaiPB();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
