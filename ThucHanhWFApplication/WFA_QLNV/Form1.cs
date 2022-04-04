using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace WFA_QLNV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhanVien formNhanvien = new FormNhanVien();
            formNhanvien.MdiParent = this;
            formNhanvien.Show();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            FormPhongBan formPhongBan = new FormPhongBan();
            formPhongBan.MdiParent = this;
            formPhongBan.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        /*
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(@"D:\ProjectCSharp\ThucHanhWFApplication\WFA_QLNV\CrystalReport1.rpt");
            reportDocument.RecordSelectionFormula = "{ChucVu.TenChucVu} = 'Nhan vien'";
            //reportDocument.GroupSelectionFormula = "{NhanVien.GioiTinh} = 'Nam'";
            crystalReportViewer1.ReportSource = reportDocument;
            crystalReportViewer1.Refresh();
        }*/
    }
}
