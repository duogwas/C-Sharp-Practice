using CrystalDecisions.CrystalReports.Engine;
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
    public partial class ThongKeLoaiPB : Form
    {
        public ThongKeLoaiPB()
        {
            InitializeComponent();
        }

        private void ThongKeLoaiPB_Load(object sender, EventArgs e)
        {
            LayDuLieuComboBoxTenLoaiPB();
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(@"D:\ProjectCSharp\BTL\QuanLyNhanVien\cryLoaiPhongBan.rpt");
            crystalReportViewer1.ReportSource = reportDocument;
            crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(@"D:\ProjectCSharp\BTL\QuanLyNhanVien\cryLoaiPhongBan.rpt");
            crystalReportViewer1.ReportSource = reportDocument;
            crystalReportViewer1.Refresh();
        }

        private DataTable DsLoaiPhongBan()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select * from LoaiPhongBan", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        private void LayDuLieuComboBoxTenLoaiPB()
        {
            DataTable dataTable = DsLoaiPhongBan();
            cbLoaiPB.DataSource = dataTable;
            cbLoaiPB.DisplayMember = "TenLoaiPB";
            cbLoaiPB.ValueMember = "TenLoaiPB";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("DsPhongBan_LoaiPB", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@tenloaipb", cbLoaiPB.SelectedValue);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if(dataTable.Rows.Count > 0)
            {
                cryLoaiPhongBan cryLoaiPhongBan = new cryLoaiPhongBan();
                cryLoaiPhongBan.SetDataSource(dataTable);
                crystalReportViewer1.ReportSource = cryLoaiPhongBan;
                crystalReportViewer1.Refresh();
            }
            else
            {
                MessageBox.Show("Không có kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ThongKeLoaiPB_Load(sender, e);
            }
        }

    }
}