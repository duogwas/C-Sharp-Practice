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
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            layDsNhanVien();
            ComboBoxMaCV();
            ComboBoxMaPB();
            hienTenPb();
            hienTenCv();
        }

        private void txtMaNv_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaNv.Text == "")
            {
                errorProvider1.SetError(txtMaNv, "Bạn chưa nhập Mã nhân viên");
            }
            else
                errorProvider1.SetError(txtMaNv, "");
        }

        private void txtTenNv_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenNv.Text == "")
            {
                errorProvider1.SetError(txtTenNv, "Bạn chưa nhập Tên nhân viên");
            }
            else
                errorProvider1.SetError(txtTenNv, "");
        }

        private void dtpNgaySinh_Validating(object sender, CancelEventArgs e)
        {
            if (dtpNgaySinh.Text == "")
            {
                errorProvider1.SetError(dtpNgaySinh, "Bạn chưa nhập Ngày sinh");
            }
            else
                errorProvider1.SetError(dtpNgaySinh, "");
        }

        private void txtDiaChi_Validating(object sender, CancelEventArgs e)
        {
            if (txtDiaChi.Text == "")
            {
                errorProvider1.SetError(txtDiaChi, "Bạn chưa nhập Địa chỉ");
            }
            else
                errorProvider1.SetError(txtDiaChi, "");
        }

        private void txtSdt_Validating(object sender, CancelEventArgs e)
        {
            if (txtSdt.Text == "")
            {
                errorProvider1.SetError(txtSdt, "Bạn chưa nhập Số điện thoại");
            }
            else
                errorProvider1.SetError(txtSdt, "");
        }

        private void cbMaPb_Validating(object sender, CancelEventArgs e)
        {
            if (cbMaPb.Text == "")
            {
                errorProvider1.SetError(cbMaPb, "Bạn chưa nhập Mã phòng ban");
            }
            else
                errorProvider1.SetError(cbMaPb, "");
        }

        private void cbMaCv_Validating(object sender, CancelEventArgs e)
        {
            if (cbMaCv.Text == "")
            {
                errorProvider1.SetError(cbMaCv, "Bạn chưa nhập Mã chức vụ");
            }
            else
                errorProvider1.SetError(cbMaCv, "");
        }

        private int checkMaNv()
        {
            string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(constr))
            {
                string ma = txtMaNv.Text;
                string sql = "select * from NhanVien where MaNV ='" + ma.ToString() + "'";
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

        private DataTable layDsNhanVien()
        {
            string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(constr))
            {
                using (SqlCommand sqlCommand = new SqlCommand("select * from NhanVien", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        dgvNhanVien.DataSource = dataTable;
                        return dataTable;
                    }
                }
            }
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
                        return dataTable;
                    }
                }
            }
        }

        private void hienTenPb()
        {
            string mapb = cbMaPb.GetItemText(cbMaPb.SelectedItem).ToString();
            string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(constr))
            {
                using (SqlCommand sqlCommand = new SqlCommand("select TenPB from PhongBan where MaPB ='" + mapb.ToString() + "'", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            txtTenPb.Text = sqlDataReader.GetString(0);
                        }
                    }
                    sqlConnection.Close();
                }
            }
        }

        private void hienTenCv()
        {
            string maCv = cbMaCv.GetItemText(cbMaCv.SelectedItem).ToString();
            string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(constr))
            {
                using (SqlCommand sqlCommand = new SqlCommand("select TenChucVu from ChucVu where MaChucVu ='" + maCv.ToString() + "'", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            txtTenCv.Text = sqlDataReader.GetString(0);
                        }
                    }
                    sqlConnection.Close();
                }
            }
        }

        private void ComboBoxMaPB()
        {
            DataTable dataTable = layDsPhongBan();
            cbMaPb.DataSource = dataTable;
            cbMaPb.DisplayMember = "MaPB";
            cbMaPb.ValueMember = "MaPB";
        }

        private DataTable layDsChucVu()
        {
            string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(constr))
            {
                using (SqlCommand sqlCommand = new SqlCommand("select * from ChucVu", sqlConnection))
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

        private void ComboBoxMaCV()
        {
            DataTable dataTable = layDsChucVu();
            cbMaCv.DataSource = dataTable;
            cbMaCv.DisplayMember = "MaChucVu";
            cbMaCv.ValueMember = "MaChucVu";
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaNv.Text = dgvNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
            txtMaNv.Enabled = false;
            txtTenNv.Text = dgvNhanVien.CurrentRow.Cells["TenNV"].Value.ToString();
            dtpNgaySinh.Text = dgvNhanVien.CurrentRow.Cells["NgaySinh"].Value.ToString();
            if (dgvNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam")
            {
                rbNam.Checked = true;
            }
            else rbNu.Checked = true;
            txtSdt.Text = dgvNhanVien.CurrentRow.Cells["SDT"].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells["DiaChi"].Value.ToString();
            cbMaCv.Text = dgvNhanVien.CurrentRow.Cells["MaChucVu"].Value.ToString();
            cbMaPb.Text = dgvNhanVien.CurrentRow.Cells["MaPB"].Value.ToString();
            hienTenPb();
            hienTenCv();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaNv.Text = "";
            txtMaNv.Enabled = true;
            txtTenNv.Text = "";
            dtpNgaySinh.Text = "";
            rbNam.Checked = false;
            rbNu.Checked = false;
            txtSdt.Text = "";
            txtDiaChi.Text = "";
            cbMaCv.Text = "";
            cbMaPb.Text = "";
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            layDsNhanVien();
            txtTenPb.Text = "";
            txtTenCv.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNv.Text != "")
            {
                if (checkMaNv() == 1)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại", "Thông báo");
                }
                else
                {
                    string gt;
                    if (rbNam.Checked == true) gt = "Nam";
                    else gt = "Nu";
                    {
                        string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
                        using (SqlConnection cnn = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.Connection = cnn;
                                cmd.CommandText = "ThemNhanVien";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@MaNV", txtMaNv.Text);
                                cmd.Parameters.AddWithValue("@TenNV", txtTenNv.Text);
                                cmd.Parameters.AddWithValue("@NgaySinh", DateTime.Parse(dtpNgaySinh.Text));
                                cmd.Parameters.AddWithValue("@GioiTinh", gt);
                                cmd.Parameters.AddWithValue("@SDT", txtSdt.Text);
                                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                                cmd.Parameters.AddWithValue("@MaChucVu", cbMaCv.Text);
                                cmd.Parameters.AddWithValue("@MaPB", cbMaPb.Text);
                                cnn.Open();
                                cmd.ExecuteNonQuery();
                                FormNhanVien_Load(sender, e);
                            }
                        }
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string gt;
            if (rbNam.Checked == true) gt = "Nam";
            else gt = "Nu";
            if (MessageBox.Show("Bạn có muốn sửa thông tin nhân viên này không?", "Thông báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("updateNV", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@maNV", txtMaNv.Text);
                        cmd.Parameters.AddWithValue("@tenNV", txtTenNv.Text);
                        cmd.Parameters.AddWithValue("@NgaySinh", DateTime.Parse(dtpNgaySinh.Text));
                        cmd.Parameters.AddWithValue("@GioiTinh", gt);
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                        cmd.Parameters.AddWithValue("@SDT", txtSdt.Text);
                        cmd.Parameters.AddWithValue("@MaChucVu", cbMaCv.Text);
                        cmd.Parameters.AddWithValue("@MaPB", cbMaPb.Text);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        FormNhanVien_Load(sender, e);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có xóa nhân viên này không?", "Thông báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("XoaNv", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@manv", txtMaNv.Text);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        FormNhanVien_Load(sender, e);
                    }
                }
            }
        }

        public void LoadNhanVienByKeyWord(string keyword)
        {
            string constr = ConfigurationManager.ConnectionStrings["QuanLiNhanVien"].ConnectionString;
            string sqlSelect = "select * from NhanVien where TenNV like N'%" + keyword + "%'";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlSelect, cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvNhanVien.DataSource = dt;
                    }
                    cnn.Close();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadNhanVienByKeyWord(txtTimKiem.Text);
        }

        private void cbMaPb_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienTenPb();
        }

        private void cbMaCv_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienTenCv();
        }
    }
}
