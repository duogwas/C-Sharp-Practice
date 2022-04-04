using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien
{
    public partial class tangluong : Form
    {
        public tangluong()
        {
            InitializeComponent();
        }

        private void tangluong_Load(object sender, EventArgs e)
        {
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(@"D:\ProjectCSharp\BTL\QuanLyNhanVien\cryNVTangLuong.rpt");
            crystalReportViewer1.ReportSource = reportDocument;
            crystalReportViewer1.Refresh();
        }
    }
}
