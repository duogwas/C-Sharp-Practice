using System;
using System.Windows.Forms;

namespace ThucHanh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPhongBan formPhongBan = new FormPhongBan();
            formPhongBan.MdiParent = this;
            formPhongBan.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhanVien formNhanVien = new FormNhanVien();
            formNhanVien.MdiParent = this;
            formNhanVien.Show();
        }
    }
}
