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
    public partial class frmChiTietLuong : Form
    {
        int SoLanSua=0;
        public frmChiTietLuong()
        {
            InitializeComponent();
        }

        private void frmChiTietLuong_Load(object sender, EventArgs e)
        {
            DsChiTietLuong();
            LayDuLieuComboBoxMaLuong();
            txtTenNv.Enabled = false;
            txtTongLuong.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
        }

        private void ResetTextBox()
        {
            txtLuongCB.Text = "";
            txtHSL.Text = "";
            txtPhuCap.Text = "";
            txtSoNgayLam.Text = "";
            dtpNgayTinh.Text = "";
            txtTongLuong.Text = "";
            lbLuongCB_error.Text = "";
            lbPhuCap_error.Text = "";
            lbHSL_error.Text = "";
            lbSoNgayLam_error.Text = "";
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

        private void loạiPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoaiPhongBan f = new frmLoaiPhongBan();
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
        #endregion

        #region DataGridView
        private DataTable DsChiTietLuong()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select * from v_DsChiTietLuong", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvChiTietLuong.DataSource = dataTable;
            return dataTable;
        }

        private void dgvChiTietLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbMaLuong.Enabled = false;
            cbMaLuong.Text = dgvChiTietLuong.CurrentRow.Cells["Mã lương"].Value.ToString();
            txtTenNv.Enabled = false;
            txtTenNv.Text = dgvChiTietLuong.CurrentRow.Cells["Tên nhân viên"].Value.ToString();
            txtLuongCB.Text = dgvChiTietLuong.CurrentRow.Cells["Lương cơ bản"].Value.ToString();
            txtHSL.Text= dgvChiTietLuong.CurrentRow.Cells["Hệ số lương"].Value.ToString();
            txtPhuCap.Text= dgvChiTietLuong.CurrentRow.Cells["Phụ cấp"].Value.ToString();
            txtSoNgayLam.Text= dgvChiTietLuong.CurrentRow.Cells["Số ngày làm"].Value.ToString();
            dtpNgayTinh.Enabled = false;
            dtpNgayTinh.Text= dgvChiTietLuong.CurrentRow.Cells["Ngày tính"].Value.ToString();
            txtTongLuong.Text= dgvChiTietLuong.CurrentRow.Cells["Tổng lương"].Value.ToString();
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            lbLuongCB_error.Text = "";
            lbPhuCap_error.Text = "";
            lbHSL_error.Text = "";
            lbSoNgayLam_error.Text = "";
        }
        #endregion

        #region ComboBox
        private DataTable DsMaLuong()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select * from Luong", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        private void LayDuLieuComboBoxMaLuong()
        {
            DataTable dataTable = DsMaLuong();
            cbMaLuong.DataSource = dataTable;
            cbMaLuong.DisplayMember = "MaLuong";
            cbMaLuong.ValueMember = "MaLuong";
        }

        private void HienTenNV()
        {
            string ma = cbMaLuong.GetItemText(cbMaLuong.SelectedItem).ToString();
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select [Tên nhân viên] from v_DsLuong where [Mã lương] = N'" + ma + "'", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                txtTenNv.Text = sqlDataReader.GetString(0);
            }
            sqlConnection.Close();
        }

        private void cbMaLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienTenNV();
        }
        #endregion

        #region checkDuLieu

        
        static bool IsNumeric(string value)
        {
            try
            {
                float number;
                bool result = float.TryParse(value, out number);
                return result;
            }
            catch (Exception ex) 
            { 
                return false; 
            }
        }

        private void txtLuongCB_TextChanged(object sender, EventArgs e)
        {
            if (txtLuongCB.Text != "")
            {
                if (IsNumeric(txtLuongCB.Text) == false)
                {
                    lbLuongCB_error.Visible = true;
                    lbLuongCB_error.Text = "Bạn phải nhập số";
                    lbLuongCB_error.ForeColor = Color.Red;
                    btnThem.Enabled = false;
                }
                else
                {
                    if (int.Parse(txtLuongCB.Text) < 0)
                    {
                        lbLuongCB_error.Visible = true;
                        lbLuongCB_error.Text = "Bạn phải nhập số dương";
                        lbLuongCB_error.ForeColor = Color.Red;
                        btnThem.Enabled = false;
                    }
                    else
                    {
                        lbLuongCB_error.Visible = true;
                        lbLuongCB_error.Text = "Hợp lệ";
                        lbLuongCB_error.ForeColor = Color.Green;
                        btnThem.Enabled = true;

                        if (txtPhuCap.Text != "")
                        {
                            if (IsNumeric(txtPhuCap.Text) == false)
                                btnThem.Enabled = false;
                            else
                            {
                                if (int.Parse(txtPhuCap.Text) < 0)
                                    btnThem.Enabled = false;
                                else
                                    btnThem.Enabled = true;
                            }
                        }
                        else
                            btnThem.Enabled = false;

                        if (txtHSL.Text != "")
                        {
                            if (IsNumeric(txtHSL.Text) == false)
                                btnThem.Enabled = false;
                            else
                            {
                                if (Math.Round(float.Parse(txtHSL.Text), 1) < 0)
                                    btnThem.Enabled = false;
                                else
                                    btnThem.Enabled = true;
                            }
                        }
                        else
                            btnThem.Enabled = false;

                        if (txtSoNgayLam.Text != "")
                        {
                            if (IsNumeric(txtSoNgayLam.Text) == false)
                                btnThem.Enabled = false;
                            else
                            {
                                if (int.Parse(txtSoNgayLam.Text) < 0)
                                    btnThem.Enabled = false;
                                else
                                {
                                    if (int.Parse(txtSoNgayLam.Text) < 30)
                                        btnThem.Enabled = true;
                                    else
                                        btnThem.Enabled = false;
                                }
                            }
                        }
                        else
                            btnThem.Enabled = false;
                    }
                }
            }
            else
            {
                lbLuongCB_error.Visible = true;
                lbLuongCB_error.Text = "Không được bỏ trống";
                lbLuongCB_error.ForeColor = Color.Red;
                btnThem.Enabled = false;
            }
        }

        private void txtPhuCap_TextChanged(object sender, EventArgs e)
        {
            if (txtPhuCap.Text != "")
            {
                if (IsNumeric(txtPhuCap.Text) == false)
                {
                    lbPhuCap_error.Visible = true;
                    lbPhuCap_error.Text = "Bạn phải nhập số";
                    lbPhuCap_error.ForeColor = Color.Red;
                    btnThem.Enabled = false;
                }
                else
                {
                    if (int.Parse(txtPhuCap.Text) < 0)
                    {
                        lbPhuCap_error.Visible = true;
                        lbPhuCap_error.Text = "Bạn phải nhập số dương";
                        lbPhuCap_error.ForeColor = Color.Red;
                        btnThem.Enabled = false;
                    }
                    else
                    {
                        lbPhuCap_error.Visible = true;
                        lbPhuCap_error.Text = "Hợp lệ";
                        lbPhuCap_error.ForeColor = Color.Green;
                        btnThem.Enabled = true;

                        if (txtLuongCB.Text != "")
                        {
                            if (IsNumeric(txtLuongCB.Text) == false)
                                btnThem.Enabled = false;
                            else
                            {
                                if (int.Parse(txtLuongCB.Text) < 0)
                                    btnThem.Enabled = false;
                                else
                                    btnThem.Enabled = true;
                            }
                        }
                        else
                            btnThem.Enabled = false;

                        if (txtHSL.Text != "")
                        {
                            if (IsNumeric(txtHSL.Text) == false)
                                btnThem.Enabled = false;
                            else
                            {
                                if (Math.Round(float.Parse(txtHSL.Text), 1) < 0)
                                    btnThem.Enabled = false;
                                else
                                    btnThem.Enabled = true;
                            }
                        }
                        else
                            btnThem.Enabled = false;

                        if (txtSoNgayLam.Text != "")
                        {
                            if (IsNumeric(txtSoNgayLam.Text) == false)
                                btnThem.Enabled = false;
                            else
                            {
                                if (int.Parse(txtSoNgayLam.Text) < 0)
                                    btnThem.Enabled = false;
                                else
                                {
                                    if (int.Parse(txtSoNgayLam.Text) < 30)
                                        btnThem.Enabled = true;
                                    else
                                        btnThem.Enabled = false;
                                }
                            }
                        }
                        else
                            btnThem.Enabled = false;


                    }
                }
            }
            else
            {
                lbPhuCap_error.Visible = true;
                lbPhuCap_error.Text = "Không được bỏ trống";
                lbPhuCap_error.ForeColor = Color.Red;
                btnThem.Enabled = false;
            }
        }

        private void txtHSL_TextChanged(object sender, EventArgs e)
        {
            if (txtHSL.Text != "")
            {

                if (IsNumeric(txtHSL.Text) == false)
                {
                    lbHSL_error.Visible = true;
                    lbHSL_error.Text = "Bạn phải nhập số";
                    lbHSL_error.ForeColor = Color.Red;
                    btnThem.Enabled = false;
                }
                else
                {
                    if (Math.Round(float.Parse(txtHSL.Text), 1) < 0)
                    {
                        lbHSL_error.Visible = true;
                        lbHSL_error.Text = "Bạn phải nhập số dương";
                        lbHSL_error.ForeColor = Color.Red;
                        btnThem.Enabled = false;
                    }
                    else
                    {
                        lbHSL_error.Visible = true;
                        lbHSL_error.Text = "Hợp lệ";
                        lbHSL_error.ForeColor = Color.Green;
                        btnThem.Enabled = true;

                        if (txtLuongCB.Text != "")
                        {
                            if (IsNumeric(txtLuongCB.Text) == false)
                                btnThem.Enabled = false;
                            else
                            {
                                if (int.Parse(txtLuongCB.Text) < 0)
                                    btnThem.Enabled = false;
                                else
                                    btnThem.Enabled = true;
                            }
                        }
                        else
                            btnThem.Enabled = false;

                        if (txtPhuCap.Text != "")
                        {
                            if (IsNumeric(txtPhuCap.Text) == false)
                                btnThem.Enabled = false;
                            else
                            {
                                if (int.Parse(txtPhuCap.Text) < 0)
                                    btnThem.Enabled = false;
                                else
                                    btnThem.Enabled = true;
                            }
                        }
                        else
                            btnThem.Enabled = false;

                        if (txtSoNgayLam.Text != "")
                        {
                            if (IsNumeric(txtSoNgayLam.Text) == false)
                                btnThem.Enabled = false;
                            else
                            {
                                if (int.Parse(txtSoNgayLam.Text) < 0)
                                    btnThem.Enabled = false;
                                else
                                {
                                    if (int.Parse(txtSoNgayLam.Text) < 30)
                                        btnThem.Enabled = true;
                                    else
                                        btnThem.Enabled = false;
                                }
                            }
                        }
                        else
                            btnThem.Enabled = false;
                    }
                }
            }
            else
            {
                lbHSL_error.Visible = true;
                lbHSL_error.Text = "Không được bỏ trống";
                lbHSL_error.ForeColor = Color.Red;
                btnThem.Enabled = false;
            }
        }

        private void txtSoNgayLam_TextChanged(object sender, EventArgs e)
        {
            if (txtSoNgayLam.Text != "")
            {

                if (IsNumeric(txtSoNgayLam.Text) == false)
                {
                    lbSoNgayLam_error.Visible = true;
                    lbSoNgayLam_error.Text = "Bạn phải nhập số";
                    lbSoNgayLam_error.ForeColor = Color.Red;
                    btnThem.Enabled = false;
                }
                else
                {
                    if (int.Parse(txtSoNgayLam.Text) < 0)
                    {
                        lbSoNgayLam_error.Visible = true;
                        lbSoNgayLam_error.Text = "Bạn phải nhập số dương";
                        lbSoNgayLam_error.ForeColor = Color.Red;
                        btnThem.Enabled = false;
                    }
                    else
                    {
                        if (int.Parse(txtSoNgayLam.Text) < 30)
                        {
                            lbSoNgayLam_error.Visible = true;
                            lbSoNgayLam_error.Text = "Hợp lệ";
                            lbSoNgayLam_error.ForeColor = Color.Green;
                            btnThem.Enabled = true;

                            if (txtLuongCB.Text != "")
                            {
                                if (IsNumeric(txtLuongCB.Text) == false)
                                    btnThem.Enabled = false;
                                else
                                {
                                    if (int.Parse(txtLuongCB.Text) < 0)
                                        btnThem.Enabled = false;
                                    else
                                        btnThem.Enabled = true;
                                }
                            }
                            else
                                btnThem.Enabled = false;

                            if (txtPhuCap.Text != "")
                            {
                                if (IsNumeric(txtPhuCap.Text) == false)
                                    btnThem.Enabled = false;
                                else
                                {
                                    if (int.Parse(txtPhuCap.Text) < 0)
                                        btnThem.Enabled = false;
                                    else
                                        btnThem.Enabled = true;
                                }
                            }
                            else
                                btnThem.Enabled = false;

                            if (txtHSL.Text != "")
                            {
                                if (IsNumeric(txtHSL.Text) == false)
                                    btnThem.Enabled = false;
                                else
                                {
                                    if (Math.Round(float.Parse(txtHSL.Text), 1) < 0)
                                        btnThem.Enabled = false;
                                    else
                                        btnThem.Enabled = true;
                                }
                            }
                            else
                                btnThem.Enabled = false;
                        }
                        else
                        {
                            lbSoNgayLam_error.Visible = true;
                            lbSoNgayLam_error.Text = "Số ngày làm phải < 30";
                            lbSoNgayLam_error.ForeColor = Color.Red;
                            btnThem.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                lbSoNgayLam_error.Visible = true;
                lbSoNgayLam_error.Text = "Không được bỏ trống";
                lbSoNgayLam_error.ForeColor = Color.Red;
                btnThem.Enabled = false;
            }
        }

        #endregion

        #region btnBoQua
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            DsChiTietLuong();
            ResetTextBox();
            cbMaLuong.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
        }
        #endregion

        #region btnThem
        private void btnThem_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("ThemChiTietLuong", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@maluong", cbMaLuong.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@luongcb", int.Parse(txtLuongCB.Text));
            sqlCommand.Parameters.AddWithValue("@hsl", Math.Round(float.Parse(txtHSL.Text),1));
            sqlCommand.Parameters.AddWithValue("@phucap", int.Parse(txtPhuCap.Text));
            sqlCommand.Parameters.AddWithValue("@songaylam", int.Parse(txtSoNgayLam.Text));
            sqlCommand.Parameters.AddWithValue("@thoigiantinh", DateTime.Parse(dtpNgayTinh.Text));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            frmChiTietLuong_Load(sender, e);
            ResetTextBox();
        }
        #endregion


        private int DemSoLanSua()
        {
            string ma = cbMaLuong.GetItemText(cbMaLuong.SelectedItem).ToString();
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select SoLanSua from Luong where MaLuong = N'" + ma + "'", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                SoLanSua = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();
            return SoLanSua;
        }


        #region btnSua
        private void btnSua_Click(object sender, EventArgs e)
        {
            if(DemSoLanSua() >= 2)
            {
                MessageBox.Show("Trong một năm không được sửa quá 2 lần", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else {
                if (MessageBox.Show("Bạn có muốn sửa thông tin lương này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
                    SqlConnection sqlConnection = new SqlConnection(constr);
                    SqlCommand sqlCommand = new SqlCommand("SuaChiTietLuong", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@maluong", cbMaLuong.SelectedValue);
                    sqlCommand.Parameters.AddWithValue("@luongcb", int.Parse(txtLuongCB.Text));
                    sqlCommand.Parameters.AddWithValue("@hsl", Math.Round(float.Parse(txtHSL.Text), 1));
                    sqlCommand.Parameters.AddWithValue("@phucap", int.Parse(txtPhuCap.Text));
                    sqlCommand.Parameters.AddWithValue("@songaylam", int.Parse(txtSoNgayLam.Text));
                    sqlCommand.Parameters.AddWithValue("@thoigiantinh", DateTime.Parse(dtpNgayTinh.Text));
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    frmChiTietLuong_Load(sender, e);
                    ResetTextBox();
                }
            }           
        }
        #endregion

        #region btnTimKiem
        private DataTable TimKiemChiTietLuong()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("TimKiemChiTietLuong", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@maluong", cbMaLuong.SelectedValue);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvChiTietLuong.DataSource = dataTable;
            if (dataTable.Rows.Count == 0)
                MessageBox.Show("Không có kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return dataTable;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemChiTietLuong();
        }

        #endregion

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeLuong f = new ThongKeLuong();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnTang_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
