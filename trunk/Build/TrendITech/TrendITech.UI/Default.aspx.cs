using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using TrendITech.Core;
using TrendITech.Core.Repository;
using TrendITech.Core.Repository;


namespace TrendITech.UI
{
    public partial class Default : System.Web.UI.Page
    {
        private readonly AmazonTransactionsV2Repository _amazonTransactions = new AmazonTransactionsV2Repository();

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (!IsPostBack)
            {
                string MyFileName;
               

                MyFileName = Page.MapPath("Data.txt");

                var dt = GetCsvRows(MyFileName, true);
                dt = LoadCSVFile(MyFileName);
                List<string> errors;
                dt = Csv.DataSetGet(MyFileName, "\t", out errors);
                IEnumerable asa =  _amazonTransactions.LoadTransactions();
                gvCSV.DataSource = asa;
                gvCSV.DataBind();

            }*/
        }

        public static DataTable GetCsvRows(string path, bool isFirstRowHeader)
        {
            var header = "No";
            var sql = string.Empty;
            DataTable dataTable = null;
            var pathOnly = string.Empty;
            var fileName = string.Empty;

            try
            {

                pathOnly = Path.GetDirectoryName(path);
                fileName = Path.GetFileName(path);

                sql = @"SELECT * FROM [" + fileName + "]";

                if (isFirstRowHeader)
                {
                    header = "Yes";
                }

                using (var connection = new OleDbConnection(
                        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
                        ";Extended Properties=\"Text;HDR=" + header + "\""))
                {
                    using (var command = new OleDbCommand(sql, connection))
                    {
                        using (var adapter = new OleDbDataAdapter(command))
                        {
                            dataTable = new DataTable();
                            dataTable.Locale = CultureInfo.CurrentCulture;
                            adapter.Fill(dataTable);

                        }
                    }
                }
            }
            finally
            {

            }

            return dataTable;

        }

        public static DataTable LoadCSVFile(string path)
        {
            string CSVFilePathName = path;//@"C:\test.csv";
            string[] Lines = File.ReadAllLines(CSVFilePathName);
            string[] Fields;
            //Fields = Lines[0].Split(new char[] { ',' });
            Fields = Lines[0].Split(new char[] { '\t' });
            int Cols = Fields.GetLength(0);
            DataTable dt = new DataTable();
            //1st row must be column names; force lower case to ensure matching later on.
            for (int i = 0; i < Cols; i++)
                dt.Columns.Add(Fields[i].ToLower(), typeof(string));
            DataRow Row;
            for (int i = 1; i < Lines.GetLength(0); i++)
            {
                //Fields = Lines[i].Split(new char[] { ',' });
                Fields = Lines[i].Split(new char[] { '\t' });
                Row = dt.NewRow();
                for (int f = 0; f < Cols; f++)
                    Row[f] = Fields[f];
                dt.Rows.Add(Row);
            }
            return dt;

        }

    }
}