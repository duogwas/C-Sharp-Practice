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
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void linkLabelDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangNhap f = new frmDangNhap();
            this.Hide();
            f.ShowDialog();
            this.Show();
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
                txtXacNhanMk.UseSystemPasswordChar = true;
            else
                txtXacNhanMk.UseSystemPasswordChar = false;
        }

        #region checkDuLieu
        private int CheckUsername()
        {
            string username = txtTaiKhoan.Text;
            string sql = "select * from Account where Username = N'" + username + "'";
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
        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text != "")
            {
                if (CheckUsername() == 1)
                {
                    lbCheckUsername.Visible = true;
                    lbCheckUsername.Text = "Tên tài khoản đã được sử dụng";
                    lbCheckUsername.ForeColor = Color.Red;
                    btnDangKy.Enabled = false;
                }
                else
                {
                    lbCheckUsername.Visible = true;
                    lbCheckUsername.Text = "Tên tài khoản hợp lệ";
                    lbCheckUsername.ForeColor = Color.Green;
                    btnDangKy.Enabled = true;
                }
            }
            else
            {
                lbCheckUsername.Visible = true;
                lbCheckUsername.Text = "Tên tài khoản không được để trống";
                lbCheckUsername.ForeColor = Color.Red;
                btnDangKy.Enabled = false;
            }

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.Text != "")
            {
                Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,10}$");
                string mk = txtMatKhau.Text;
                Match result = regex.Match(mk);
                if (result == Match.Empty)
                {
                    lbMK.Visible = true;
                    lbMK.Text = "Tối thiểu 8 và tối đa 10 ký tự, ít nhất một chữ cái viết hoa, \n một chữ cái viết thường, một số và một ký tự";
                    lbMK.ForeColor = Color.Red;
                    btnDangKy.Enabled = false;
                }
                else
                {
                    lbMK.Visible = false;
                    lbMK.Text = "";
                    lbMK.ForeColor = Color.Red;
                    btnDangKy.Enabled = false;
                }
            }

            else
            {
                lbMK.Visible = true;
                lbMK.Text = "Không được bỏ trống";
                lbMK.ForeColor = Color.Red;
                btnDangKy.Enabled = false;
            }
        }

        private void txtXacNhanMk_TextChanged(object sender, EventArgs e)
        {
            if (txtXacNhanMk.Text != txtMatKhau.Text)
            {
                lbCheckPassword.Visible = true;
                lbCheckPassword.Text = "Xác nhận mật khẩu không trùng khớp";
                lbCheckPassword.ForeColor = Color.Red;
                btnDangKy.Enabled = false;
            }
            else
            {
                lbCheckPassword.Visible = true;
                lbCheckPassword.Text = "Xác nhận mật khẩu trùng khớp";
                lbCheckPassword.ForeColor = Color.Green;
                if (CheckUsername() == 1)
                {
                    btnDangKy.Enabled = false;
                }
                else
                {
                    btnDangKy.Enabled = true;
                }
            }
        }
        #endregion

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("DangKy", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@username", txtTaiKhoan.Text);
            sqlCommand.Parameters.AddWithValue("@displayname", txtDisplayName.Text);
            sqlCommand.Parameters.AddWithValue("@password", txtMatKhau.Text);
            sqlConnection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTaiKhoan.Text = "";
                txtMatKhau.Text = "";
                txtXacNhanMk.Text = "";
                txtDisplayName.Text = "";
                lbCheckPassword.Text = "";
                lbCheckUsername.Text = "";
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
