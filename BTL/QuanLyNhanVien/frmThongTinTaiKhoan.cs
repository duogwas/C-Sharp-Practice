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
    public partial class frmThongTinTaiKhoan : Form
    {
        public frmThongTinTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = frmDangNhap.TaiKhoan;
            txtMatKhau.Text = frmDangNhap.MatKhau;
            btnCapNhat.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
                txtMatKhau.UseSystemPasswordChar = true;
            else
                txtMatKhau.UseSystemPasswordChar = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
                txtNewPass.UseSystemPasswordChar = true;
            else
                txtNewPass.UseSystemPasswordChar = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
                txtReNewPass.UseSystemPasswordChar = true;
            else
                txtReNewPass.UseSystemPasswordChar = false;
        }

        private void txtNewPass_TextChanged(object sender, EventArgs e)
        {
            if (txtNewPass.Text == "")
            {
                lbNewPass_error.Visible = true;
                lbNewPass_error.Text = "Không được để trống";
                lbNewPass_error.ForeColor = Color.Red;
                btnCapNhat.Enabled = false;
            }
            else
            {
                if (txtNewPass.Text == txtMatKhau.Text)
                {
                    lbNewPass_error.Visible = true;
                    lbNewPass_error.Text = "Mật khẩu mới phải khác mật khẩu cũ";
                    txtReNewPass.Enabled = false;
                    lbNewPass_error.ForeColor = Color.Red;
                    btnCapNhat.Enabled = false;
                }
                else
                {
                    lbNewPass_error.Visible = true;
                    lbNewPass_error.Text = "Mật khẩu hợp lệ";
                    lbNewPass_error.ForeColor = Color.Green;
                    btnCapNhat.Enabled = false;
                    txtReNewPass.Enabled = true;
                }
            }

        }

        private void txtReNewPass_TextChanged(object sender, EventArgs e)
        {
            if (txtReNewPass.Text != txtNewPass.Text)
            {
                lbReNewPass_error.Visible = true;
                lbReNewPass_error.Text = "Xác nhận mật khẩu không trùng khớp";
                lbReNewPass_error.ForeColor = Color.Red;
                btnCapNhat.Enabled = false;
            }
            else
            {

                lbReNewPass_error.Visible = true;
                lbReNewPass_error.Text = "Xác nhận mật khẩu trùng khớp";
                lbReNewPass_error.ForeColor = Color.Green;
                btnCapNhat.Enabled = true;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn cập nhật mật khẩu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(constr);
                SqlCommand sqlCommand = new SqlCommand("UpdateAccount", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@username", txtTaiKhoan.Text);
                sqlCommand.Parameters.AddWithValue("@password", txtNewPass.Text);
                sqlConnection.Open();
                int i = sqlCommand.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTaiKhoan.Text = "";
                    txtMatKhau.Text = "";
                    txtNewPass.Text = "";
                    txtReNewPass.Text = "";
                    lbNewPass_error.Text = "";
                    lbReNewPass_error.Text = "";
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                  
                }
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmTrangChu f = new frmTrangChu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
