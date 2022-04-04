using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_QLNV
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(@"D:\ProjectCSharp\ThucHanhWFApplication\WFA_QLNV\CrystalReport1.rpt");
            crystalReportViewer1.ReportSource = reportDocument;
            crystalReportViewer1.Refresh();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(@"D:\ProjectCSharp\ThucHanhWFApplication\WFA_QLNV\CrystalReport1.rpt");
            ParameterFieldDefinition parameterFieldDefinition = reportDocument.DataDefinition.ParameterFields["TenChucVu"];
            ParameterValues parameterValue = new ParameterValues();
            ParameterDiscreteValue parameterDiscreteValue = new ParameterDiscreteValue();
            parameterDiscreteValue.Value = txtChucVu.Text;
            parameterValue.Add(parameterDiscreteValue);
            parameterFieldDefinition.CurrentValues.Clear();
            parameterFieldDefinition.ApplyCurrentValues(parameterValue);
            crystalReportViewer1.ReportSource = reportDocument;
            crystalReportViewer1.Refresh();
        }

       
    }
}
