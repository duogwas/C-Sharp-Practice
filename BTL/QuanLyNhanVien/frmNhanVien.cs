using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            DsNhanVien();
            LayDuLieuComboBoxChucVu();
            LayDuLieuComboBoxPhongBan();
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
        private void txtTenNv_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenNv.Text == "")
                errorProvider1.SetError(txtTenNv, "Không được bỏ trống");
            else
                errorProvider1.SetError(txtTenNv, "");
        }

        private void txtDiaChi_Validating(object sender, CancelEventArgs e)
        {
            if (txtDiaChi.Text == "")
                errorProvider1.SetError(txtDiaChi, "Không được bỏ trống");
            else
                errorProvider1.SetError(txtDiaChi, "");
        }
        #endregion

        #region checkDuLieu
        private int checkMaNv()
        {
            string ma = txtMaNv.Text;
            string sql = "select * from NhanVien where MaNV = N'" + ma + "'";
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

        private int checkSDT()
        {
            string sdt = txtSdt.Text;
            string sql = "select * from NhanVien where SDT = N'" + sdt + "'";
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

        private void txtMaNv_TextChanged(object sender, EventArgs e)
        {
            if (txtMaNv.Text != "")
            {
                if (checkMaNv() == 1)
                {
                    lbMaNv_error.Visible = true;
                    lbMaNv_error.Text = "Mã nhân viên đã tồn tại";
                    lbMaNv_error.ForeColor = Color.Red;
                    btnThem.Enabled = false;
                }
                else
                {
                    lbMaNv_error.Visible = true;
                    lbMaNv_error.Text = "Mã nhân viên hợp lệ";
                    lbMaNv_error.ForeColor = Color.Green;
                    btnThem.Enabled = true;

                    if (txtSdt.Text != "")
                    {
                        if (checkSDT() == 1)
                            btnThem.Enabled = false;
                        else
                        {
                            Regex regex = new Regex(@"^\d{10}$");
                            string sdt = txtSdt.Text;
                            Match result = regex.Match(sdt);
                            if (result == Match.Empty)
                                btnThem.Enabled = false;
                            else
                                btnThem.Enabled = true;
                        }
                    }
                    else
                        btnThem.Enabled = false;

                    if (DateTime.Now < dtpNgaySinh.Value)
                        btnThem.Enabled = false;
                    else
                    {
                        if (checkTuoi(dtpNgaySinh) >= 18)
                            btnThem.Enabled = true;
                        else
                            btnThem.Enabled = false;
                    }

                }               
            }
            else
            {
                lbMaNv_error.Visible = true;
                lbMaNv_error.Text = "Không được bỏ trống";
                lbMaNv_error.ForeColor = Color.Red;
                btnThem.Enabled = false;
            }
        }    
        
        private void txtSdt_TextChanged(object sender, EventArgs e)
        {
            if (txtSdt.Text != "")
            {
                if (checkSDT() == 1)
                {
                    lbSdt_error.Visible = true;
                    lbSdt_error.Text = "Đã có nhân viên sử dụng SĐT này!";
                    lbSdt_error.ForeColor = Color.Red;
                    btnThem.Enabled = false;
                }
                else
                {
                    Regex regex = new Regex(@"^0+\d{9}$");
                    string sdt = txtSdt.Text;
                    Match result = regex.Match(sdt);
                    if (result == Match.Empty)
                    {
                        lbSdt_error.Visible = true;
                        lbSdt_error.Text = "SĐT phải là số, độ dài là 10";
                        lbSdt_error.ForeColor = Color.Red;
                        btnThem.Enabled = false;
                    }
                    else
                    {
                        lbSdt_error.Visible = true;
                        lbSdt_error.Text = "Số điện thoại phù hợp";
                        lbSdt_error.ForeColor = Color.Green;
                        btnThem.Enabled = true;

                        if (txtMaNv.Text != "")
                        {
                            if (checkMaNv() == 1)
                                btnThem.Enabled = false;
                            else
                                btnThem.Enabled = true;
                        }
                        else
                            btnThem.Enabled = false;

                        if (DateTime.Now < dtpNgaySinh.Value)
                            btnThem.Enabled = false;
                        else
                        {
                            if (checkTuoi(dtpNgaySinh) >= 18)
                                btnThem.Enabled = true;
                            else
                                btnThem.Enabled = false;
                        }
                    }

                }
            }
            else
            {
                lbSdt_error.Visible = true;
                lbSdt_error.Text = "Số điện thoại không được bỏ trống";
                lbSdt_error.ForeColor = Color.Red;
                btnThem.Enabled = false;
            }
        }

        private double checkTuoi(DateTimePicker dateTimePicker)
        {
            TimeSpan timeDifference = DateTime.Now - dateTimePicker.Value;
            double Age = timeDifference.TotalDays / 365;
            return Age;
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Now < dtpNgaySinh.Value)
            {
                lbNgaySinh_error.Visible = true;
                lbNgaySinh_error.Text = "Ngày sinh lớn hơn ngày hiện tại";
                lbNgaySinh_error.ForeColor = Color.Red;
                btnThem.Enabled = false;
            }
            else
            {
                if (checkTuoi(dtpNgaySinh) >= 18)
                {
                    lbNgaySinh_error.Visible = true;
                    lbNgaySinh_error.Text = "Đủ 18 tuổi";
                    lbNgaySinh_error.ForeColor = Color.Green;
                    btnThem.Enabled = true;

                    if (txtMaNv.Text != "")
                    {
                        if (checkMaNv() == 1)
                            btnThem.Enabled = false;
                        else
                            btnThem.Enabled = true;
                    }
                    else
                        btnThem.Enabled = false;

                    if (txtSdt.Text != "")
                    {
                        if (checkSDT() == 1)
                            btnThem.Enabled = false;
                        else
                        {
                            Regex regex = new Regex(@"^\d{10}$");
                            string sdt = txtSdt.Text;
                            Match result = regex.Match(sdt);
                            if (result == Match.Empty)
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
                    lbNgaySinh_error.Visible = true;
                    lbNgaySinh_error.Text = "Chưa đủ 18 tuổi";
                    lbNgaySinh_error.ForeColor = Color.Red;
                    btnThem.Enabled = false;
                }
            }
        }
        #endregion

        #region ComboBox
        private DataTable DsChucVu()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select * from ChucVu", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        private void LayDuLieuComboBoxChucVu()
        {
            DataTable dataTable = DsChucVu();
            cbChucVu.DataSource = dataTable;
            cbChucVu.DisplayMember = "TenChucVu";
            cbChucVu.ValueMember = "MaChucVu";
        }

        private DataTable DsPhongBan()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select * from PhongBan", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        private void LayDuLieuComboBoxPhongBan()
        {
            DataTable dataTable = DsPhongBan();
            cbPhongBan.DataSource = dataTable;
            cbPhongBan.DisplayMember = "TenPB";
            cbPhongBan.ValueMember = "MaPB";
        }
        #endregion

        #region DataGridView
        private DataTable DsNhanVien()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select * from v_DsNhanVien", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvNhanVien.DataSource = dataTable;
            return dataTable;
        }
        
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNv.Enabled = false;
            txtMaNv.Text = dgvNhanVien.CurrentRow.Cells["Mã nhân viên"].Value.ToString();
            txtTenNv.Text = dgvNhanVien.CurrentRow.Cells["Tên nhân viên"].Value.ToString();
            dtpNgaySinh.Text = dgvNhanVien.CurrentRow.Cells["Ngày sinh"].Value.ToString();
            if (dgvNhanVien.CurrentRow.Cells["Giới tính"].Value.ToString() == "Nam")
                rbNam.Checked = true;         
            else 
                rbNu.Checked = true;
            cbPhongBan.Text = dgvNhanVien.CurrentRow.Cells["Phòng ban"].Value.ToString();
            cbChucVu.Text = dgvNhanVien.CurrentRow.Cells["Chức vụ"].Value.ToString();
            txtSdt.Text = dgvNhanVien.CurrentRow.Cells["Số điện thoại"].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells["Địa chỉ"].Value.ToString();
            lbMaNv_error.Text = "";
            lbNgaySinh_error.Text = "";
            lbSdt_error.Text = "";
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        #endregion

        #region btnBoQua
        private void ResetTextBox()
        {
            txtMaNv.Text = "";
            txtMaNv.Enabled = true;
            txtTenNv.Text = "";
            dtpNgaySinh.Text = "";
            rbNam.Checked = false;
            rbNu.Checked = false;
            txtDiaChi.Text = "";
            txtSdt.Text = "";
            lbMaNv_error.Text = "";
            lbNgaySinh_error.Text = "";
            lbSdt_error.Text = "";
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            DsNhanVien();
            ResetTextBox();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;              
        }
        #endregion

        #region btnThem
        private void btnThem_Click(object sender, EventArgs e)
        {
            string gt;
            if (rbNam.Checked == true)
                gt = "Nam";
            else
            {
                if (rbNu.Checked == true)
                    gt = "Nữ";
                else
                    gt = "";
            }
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("ThemNhanVien", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@MaNV", txtMaNv.Text);
            sqlCommand.Parameters.AddWithValue("@TenNV", txtTenNv.Text);
            sqlCommand.Parameters.AddWithValue("@NgaySinh", DateTime.Parse(dtpNgaySinh.Text));
            sqlCommand.Parameters.AddWithValue("@GioiTinh", gt);
            sqlCommand.Parameters.AddWithValue("@SDT", txtSdt.Text);
            sqlCommand.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
            sqlCommand.Parameters.AddWithValue("@MaChucVu", cbChucVu.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@MaPB", cbPhongBan.SelectedValue);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            frmNhanVien_Load(sender, e);
            ResetTextBox();
        }
        #endregion

        #region btnSua
        private void btnSua_Click(object sender, EventArgs e)
        {
            string gt;
            if (rbNam.Checked == true)
                gt = "Nam";
            else
            {
                if (rbNu.Checked == true)
                    gt = "Nữ";
                else
                    gt = "";
            }
            if (MessageBox.Show("Bạn có muốn sửa thông tin Nhân viên này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(constr);
                SqlCommand sqlCommand = new SqlCommand("SuaNhanVien", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MaNV", txtMaNv.Text);
                sqlCommand.Parameters.AddWithValue("@TenNV", txtTenNv.Text);
                sqlCommand.Parameters.AddWithValue("@NgaySinh", DateTime.Parse(dtpNgaySinh.Text));
                sqlCommand.Parameters.AddWithValue("@GioiTinh", gt);
                sqlCommand.Parameters.AddWithValue("@SDT", txtSdt.Text);
                sqlCommand.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                sqlCommand.Parameters.AddWithValue("@MaChucVu", cbChucVu.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@MaPB", cbPhongBan.SelectedValue);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                frmNhanVien_Load(sender, e);
                ResetTextBox();
            }          
        }
        #endregion

        #region btnXoa
        private int checkNhanVien_Luong()
        {
            string manv = txtMaNv.Text;
            string sql = "select * from Luong where MaNV ='" + manv + "'";
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
            if (checkNhanVien_Luong() == 1)
                MessageBox.Show("Không thể xóa vì nhân viên đang có dữ liệu về lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa Nhân viên này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
                    SqlConnection sqlConnection = new SqlConnection(constr);
                    SqlCommand sqlCommand = new SqlCommand("XoaNhanVien", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@MaNV", txtMaNv.Text);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    frmNhanVien_Load(sender, e);
                    ResetTextBox();
                }           
            }          
        }
        #endregion

        #region btnTimKiem
        private DataTable TimKiemNhanVien()
        {
            string gt;
            if (rbNam.Checked == true) 
                gt = "Nam";
            else
            {
                if (rbNu.Checked == true)
                    gt = "Nữ";
                else
                    gt = "";
            }
           // MessageBox.Show(string.Format("gt là {0}", gt), "tb", MessageBoxButtons.OK);
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("TimKiemNhanVien_PB", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@TenPB", cbPhongBan.GetItemText(cbPhongBan.SelectedItem).ToString());
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvNhanVien.DataSource = dataTable;
            if (dataTable.Rows.Count == 0)
                MessageBox.Show("Không có kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return dataTable;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemNhanVien();
        }

        #endregion

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            tangluong f = new tangluong();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
