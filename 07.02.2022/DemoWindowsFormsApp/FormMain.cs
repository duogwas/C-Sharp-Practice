using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoWindowsFormsApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void txtTen_Validating(object sender, CancelEventArgs e)
        {
            if (txtTen.Text == "")
                errorProvider1.SetError(txtTen, "Không được bỏ trống Họ và tên");
            else
                errorProvider1.SetError(txtTen, "");
        }

        private void txtTuoi_Validating(object sender, CancelEventArgs e)
        {
            if (txtTuoi.Text == "")
                errorProvider1.SetError(txtTuoi, "Bạn phải nhập tuổi");
            else
            {
                try
                {
                    int tuoi = int.Parse(txtTuoi.Text);
                    if(tuoi<18)
                        errorProvider1.SetError(txtTuoi, "Tuổi phải lớn hơn 18");
                    else
                        errorProvider1.SetError(txtTuoi, "");
                }
                catch
                {
                    errorProvider1.SetError(txtTuoi, "Tuổi phải là số");
                }
            }
                
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTuoi.Text = "";
            txtTen.Text = "";
            mtxtNgaysinh.Text = "";
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtTen.Text);
            MessageBox.Show(txtTuoi.Text);
            MessageBox.Show(mtxtNgaysinh.Text);
        }
    }
}
