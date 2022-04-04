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
    public partial class ThongKeLuong : Form
    {
        int thang;
        int nam;
        public ThongKeLuong()
        {
            InitializeComponent();
        }

        private void ThongKeLuong_Load(object sender, EventArgs e)
        {
            cbNam.Text = "";
            cbThang.Text = "";
            txtFrom.Text = "";
            txtTo.Text = "";
            LayDuLieuComboBoxNhanVien();
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(@"D:\ProjectCSharp\BTL\QuanLyNhanVien\cryLuong.rpt");
            crystalReportViewer1.ReportSource = reportDocument;
            crystalReportViewer1.Refresh();
        }

        private DataTable DsNhanVien()
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand("select * from NhanVien", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        private void LayDuLieuComboBoxNhanVien()
        {
            DataTable dataTable = DsNhanVien();
            cbTenNV.DataSource = dataTable;
            cbTenNV.DisplayMember = "TenNV";
            cbTenNV.ValueMember = "TenNV";
        }

        private void crystalReportViewer1_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {
            cbNam.Text = "";
            cbThang.Text = "";
            txtFrom.Text = "";
            txtTo.Text = "";
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(@"D:\ProjectCSharp\BTL\QuanLyNhanVien\cryLuong.rpt");
            crystalReportViewer1.ReportSource = reportDocument;
            crystalReportViewer1.Refresh();
        }

        private DataTable TimKiem(string sql)
        {
            string constr = ConfigurationManager.ConnectionStrings["KetNoi"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string ten = cbTenNV.SelectedValue.ToString();

            string from = txtFrom.Text;

            string to = txtTo.Text;

            if (cbThang.Text == "")
                thang = 0;
            else
                thang = int.Parse(cbThang.GetItemText(cbThang.SelectedItem).ToString());

            if (cbNam.Text == "")
                nam = 0;
            else
                nam = int.Parse(cbNam.GetItemText(cbNam.SelectedItem).ToString());

            string sqlTen = "select * from v_DsChiTietLuong where [Tên nhân viên] = N'" + ten + "'";
            string sqlNam = "select * from v_DsChiTietLuong where YEAR([Ngày tính])=" + nam;
            string sqlThang = "select * from v_DsChiTietLuong where MONTH([Ngày tính])=" + thang;
            string sqlNamThang = "select * from v_DsChiTietLuong where YEAR([Ngày tính])=" + nam + "and MONTH([Ngày tính])=" + thang;
            string sqlTen_Nam = "select * from v_DsChiTietLuong where [Tên nhân viên] = N'" + ten + "' and YEAR([Ngày tính])=" + nam;
            string sqlTen_thang = "select * from v_DsChiTietLuong where [Tên nhân viên] = N'" + ten + "' and MONTH([Ngày tính])=" + thang;
            string sqlTen_Nam_Thang = "select * from v_DsChiTietLuong where [Tên nhân viên] = N'" + ten + "' and YEAR([Ngày tính])=" + nam + "and MONTH([Ngày tính]) =" + thang;
            string sqlFromTo = "select * from v_DsChiTietLuong where [Tổng Lương] > " + from + "and [Tổng Lương] < " + to;

            //tìm kiếm theo tên
            if(cbNam.Text =="" && cbThang.Text =="" && txtFrom.Text =="" && txtTo.Text == "")
            {
                DataTable dataTable = TimKiem(sqlTen);
                if (dataTable.Rows.Count > 0)
                {
                    cryLuong cryLuong = new cryLuong();
                    cryLuong.SetDataSource(dataTable);
                    crystalReportViewer1.ReportSource = cryLuong;
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    MessageBox.Show("Không có kết quả phù hợp Tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThongKeLuong_Load(sender, e);
                }
            }

            //tìm kiếm theo năm
            if (cbNam.Text != "" && cbThang.Text == "" && txtFrom.Text == "" && txtTo.Text == "")
            {
                DataTable dataTable = TimKiem(sqlNam);
                if (dataTable.Rows.Count > 0)
                {
                    cryLuong cryLuong = new cryLuong();
                    cryLuong.SetDataSource(dataTable);
                    crystalReportViewer1.ReportSource = cryLuong;
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    MessageBox.Show("Không có kết quả phù hợp Năm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThongKeLuong_Load(sender, e);
                }
            }

            //tìm kiếm theo tháng
            if (cbThang.Text != "" && cbNam.Text == "" && txtFrom.Text == "" && txtTo.Text == "")
            {
                DataTable dataTable = TimKiem(sqlThang);
                if (dataTable.Rows.Count > 0)
                {
                    cryLuong cryLuong = new cryLuong();
                    cryLuong.SetDataSource(dataTable);
                    crystalReportViewer1.ReportSource = cryLuong;
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    MessageBox.Show("Không có kết quả phù hợp Tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThongKeLuong_Load(sender, e);
                }
            }

            //tìm kiếm theo năm tháng
            if (cbNam.Text != "" && cbThang.Text != "" && txtFrom.Text == "" && txtTo.Text == "")
            {
                DataTable dataTable = TimKiem(sqlNamThang);
                if (dataTable.Rows.Count > 0)
                {
                    cryLuong cryLuong = new cryLuong();
                    cryLuong.SetDataSource(dataTable);
                    crystalReportViewer1.ReportSource = cryLuong;
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    MessageBox.Show("Không có kết quả phù hợp Năm tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThongKeLuong_Load(sender, e);
                }
            }

            //tìm kiếm theo tên và năm
            if (cbNam.Text != "" && cbThang.Text == "" && txtFrom.Text == "" && txtTo.Text == "")
            {
                DataTable dataTable = TimKiem(sqlTen_Nam);
                if (dataTable.Rows.Count > 0)
                {
                    cryLuong cryLuong = new cryLuong();
                    cryLuong.SetDataSource(dataTable);
                    crystalReportViewer1.ReportSource = cryLuong;
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    MessageBox.Show("Không có kết quả phù hợp Tên và năm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThongKeLuong_Load(sender, e);
                }
            }

            //tìm kiếm theo tên và tháng
            if (cbThang.Text != "" && cbNam.Text != "" && txtFrom.Text == "" && txtTo.Text == "")
            {
                DataTable dataTable = TimKiem(sqlTen_thang);
                if (dataTable.Rows.Count > 0)
                {
                    cryLuong cryLuong = new cryLuong();
                    cryLuong.SetDataSource(dataTable);
                    crystalReportViewer1.ReportSource = cryLuong;
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    MessageBox.Show("Không có kết quả phù hợp Năm tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThongKeLuong_Load(sender, e);
                }
            }


            //tìm kiếm theo tên và năm tháng
            if (cbNam.Text !="" && cbThang.Text!="" && txtFrom.Text == "" && txtTo.Text == "")
            {
                DataTable dataTable = TimKiem(sqlTen_Nam_Thang);
                if (dataTable.Rows.Count > 0)
                {
                    cryLuong cryLuong = new cryLuong();
                    cryLuong.SetDataSource(dataTable);
                    crystalReportViewer1.ReportSource = cryLuong;
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    MessageBox.Show("Không có kết quả phù hợp Tên và năm tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThongKeLuong_Load(sender, e);
                }
            }

            //tìm kiếm theo khoảng
            if (txtFrom.Text != "" && txtTo.Text != "" && cbNam.Text == "" && cbThang.Text == "")
            {              
                DataTable dataTable = TimKiem(sqlFromTo);
                if (dataTable.Rows.Count > 0)
                {
                    cryLuong cryLuong = new cryLuong();
                    cryLuong.SetDataSource(dataTable);
                    crystalReportViewer1.ReportSource = cryLuong;
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    MessageBox.Show("Không có kết quả phù hợp Theo khoảng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThongKeLuong_Load(sender, e);
                }
            }
        }

        
    }
}
