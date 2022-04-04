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
    public partial class frmTrangChu : Form
    {
        public static string TaiKhoan;
        //public static string DisplayName;
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            TaiKhoan = frmDangNhap.TaiKhoan;
            GetDisplayName();
        }

        private void GetDisplayName()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select DisplayName from Account where Username = N'" + TaiKhoan + "'", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                lbDisplayName.Text = "Xin chào " + sqlDataReader.GetString(0);
            }
            sqlConnection.Close();
        }

        #region ClickButton
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien f = new frmNhanVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnChucVu_Click(object sender, EventArgs e)
        {
            frmChucVu f = new frmChucVu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            frmPhongBan f = new frmPhongBan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnLoaiPB_Click(object sender, EventArgs e)
        {
            frmLoaiPhongBan f = new frmLoaiPhongBan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            frmLuong f = new frmLuong();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnChiTietLuong_Click(object sender, EventArgs e)
        {
            frmChiTietLuong f = new frmChiTietLuong();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        #endregion

        #region ToolStripMenuClick
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

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrangChu_Load(sender, e);
        }


        #endregion
    }
}
