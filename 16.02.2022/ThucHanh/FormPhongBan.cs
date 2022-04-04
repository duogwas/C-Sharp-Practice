using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace ThucHanh
{
    public partial class FormPhongBan : Form
    {
        public FormPhongBan()
        {
            InitializeComponent();
        }

        private void FormPhongBan_Load(object sender, EventArgs e)
        {
            layDsPhongBan();
        }

        private DataTable layDsPhongBan()
        {
            string constr = @"Data Source=DUOGWAS\SQLEXPRESS;Initial Catalog=QLNV;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //string constr = ConfigurationManager.ConnectionStrings["QLNV"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(constr))
            {
                using (SqlCommand sqlCommand = new SqlCommand("select * from PhongBan", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        dgvPhongBan.DataSource = dataTable;
                        dgvPhongBan.AutoResizeColumn = true;
                        dgvPhongBan.AutoResizeRow = true;
                        return dataTable;
                    }
                }
            }
        }
    }
}
