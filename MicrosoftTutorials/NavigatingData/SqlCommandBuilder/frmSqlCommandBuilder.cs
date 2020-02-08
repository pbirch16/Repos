using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SqlCommandBuilderExample
{
    public partial class frmSqlCommandBuilder : Form
    {
        private string _connectionString =
            @"Data Source = (LocalDB)\MSSQLLocalDB;" +
            @"AttachDbFilename = C:\Users\pbirc\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\northwnd.mdf;" +
            " Integrated Security = True; Connect Timeout = 30";

        public frmSqlCommandBuilder()
        {
            InitializeComponent();
        }

        public DataSet SelectSqlRows(string strConnection, string strQry, string strTableName)
        {
            using (SqlConnection sqlconnection = new SqlConnection(strConnection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(strQry, sqlconnection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                sqlconnection.Open();

                DataSet dataSet = new DataSet("Customers");
                dataSet.Tables.Add("Customers");
                adapter.Fill(dataSet.Tables["Customers"]);

                //dataSet.
                //Modify data in dataset

                builder.GetUpdateCommand();

                //Without the SqlCommandBuilder this line would fail
                adapter.Update(dataSet, strTableName);

                return dataSet;
            }
        }

        private void frmSqlCommandBuilder_Load(object sender, EventArgs e)
        {
            string strQuery = "Select * From Customers";
            string strTableName = "Customers";
            DataSet ds = SelectSqlRows(_connectionString, strQuery, strTableName);

        }
    }
}
