//https://support.microsoft.com/en-gb/help/314145/how-to-populate-a-dataset-object-from-a-database-by-using-visual-c-net
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

//Load the specified Table of the specified Database to the specified Dataset
namespace ControlBindingsCollection
{

    class LoadDatabase
    {
        private string _databaseName;
        private string _tableName;

        private string _strConn;         //Connection string
        private string _strSelection;    //Selection string
        private SqlConnection _sqlConn;
        private SqlDataAdapter _sqlDataAdapter;
        private DataSet _dataset;
        private DataTable _dataTable;

        public LoadDatabase(DataSet dataset, string databaseName, string tableName)
        {
            _dataset = dataset;
            _databaseName = databaseName;
            _tableName = tableName;
            Init();
        }

        private void Init()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"Data Source=(LocalDB)\MSSQLLocalDB;");
            sb.Append(@"AttachDbFilename=E:\Visual Studio 2019\Databases\");
            sb.Append(_databaseName + ".mdf;");
            sb.Append("Integrated Security=True;");
            sb.Append("Connect Timeout=30");
            _strConn = sb.ToString();

            _sqlConn = new SqlConnection(_strConn);
            _sqlConn.Open();

            _strSelection = "Select * From " + _tableName;

            _sqlDataAdapter = new SqlDataAdapter(_strSelection, _sqlConn);

            _dataset = new DataSet(_databaseName);

            _sqlDataAdapter.FillSchema(_dataset, SchemaType.Source, _tableName);
            _sqlDataAdapter.Fill(_dataset.Tables[_tableName]);

            _dataTable = _dataset.Tables[_tableName];
        }

        public void DisplayData()
        {
            foreach (DataRow row in _dataTable.Rows)
            {
                foreach (DataColumn column in _dataTable.Columns)
                {
                    Console.WriteLine(row[column]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}

