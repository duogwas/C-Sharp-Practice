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
    public partial class frmDangNhap : Form
    {
        public static string TaiKhoan;
        public static string MatKhau;
        int dem = 0;

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        #region CheckTextBox_CheckBox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
                txtMatKhau.UseSystemPasswordChar = true;
            else
                txtMatKhau.UseSystemPasswordChar = false;
        }

        private void txtTaiKhoan_Validating(object sender, CancelEventArgs e)
        {
            if (txtTaiKhoan.Text == "")
            {
                errorProvider1.SetError(txtTaiKhoan, "Bạn chưa nhập tài khoản");
                btnDangNhap.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(txtTaiKhoan, "");
                btnDangNhap.Enabled = true;
            }
        }

        private void txtMatKhau_Validating(object sender, CancelEventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                errorProvider1.SetError(txtMatKhau, "Bạn chưa nhập mật khẩu");
                btnDangNhap.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(txtMatKhau, "");
                btnDangNhap.Enabled = true;
            }
        }
        #endregion

        private void linkLabelQuenMk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmQuenMatKhau f = new frmQuenMatKhau();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void linkLabelDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangKy f = new frmDangKy();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        #region DangNhap
        private int CheckUsernamePassword()
        {
            string username = txtTaiKhoan.Text;
            string pass = txtMatKhau.Text;
            string sql = "select * from Account where Username = N'" + username + "' and Pass ='" + pass + "'";
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

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (CheckUsernamePassword() == 1)
            {
                TaiKhoan = txtTaiKhoan.Text;
                MatKhau = txtMatKhau.Text;
                frmTrangChu f = new frmTrangChu();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {              
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTaiKhoan.Focus();
                lbDem.Visible = true;
                dem++;
                lbDem.Text = string.Format("Số lần sai: {0}", dem);
                if (dem == 5)
                {
                    txtTaiKhoan.Enabled = false;
                    txtMatKhau.Enabled = false;
                    MessageBox.Show("Đăng nhập sai quá 5 lần, tài khoản của bạn đã bị khóa trong 5 phút", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    panelDemNguoc.Visible = true;
                    timer1.Start();
                    btnDangNhap.Enabled = false;
                }

            }
        }
        #endregion

        #region DemNguoc
        private void timer1_Tick(object sender, EventArgs e)
        {
            int phut = Int32.Parse(lbPhut.Text);
            int giay = Int32.Parse(lbGiay.Text);

            if (giay == 0 && phut == 0)
            {
                timer1.Stop();
                btnDangNhap.Enabled = true;
                txtMatKhau.Enabled = true;
                txtTaiKhoan.Enabled = true;
                dem = 0;
                lbDem.Visible = false;
                panelDemNguoc.Visible = false;
                phut = 0;
                giay = 59;
            }

            if (giay == 0)
            {      
                phut--;
                giay = 59;
            }

            if (giay <= 59)
                giay--;

            if (giay < 10)
                lbGiay.Text = "0" + giay;
            else
                lbGiay.Text = giay + "";

            if (phut < 10)
                lbPhut.Text = "0" + phut;
            else
                lbPhut.Text = phut + "";                   
        }
        #endregion
    }
}
