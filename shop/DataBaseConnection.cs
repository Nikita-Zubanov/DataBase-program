using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace shop
{
    class DataBaseConnection
    {
        private static string connectionString;
        
        public static SqlConnection sqlConnection;
        public static string serverName;
        public static string dataBaseName;
        public static void setSqlConnection()
        {
            connectionString = @"Data Source=" + serverName + "; Initial Catalog=" + dataBaseName + "; Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }

        public static DataTable dataTable;
        public static void setDataTable(SqlConnection sqlConnection, string value)
        {
            sqlConnection.Open();

            dataTable = sqlConnection.GetSchema(value);

            sqlConnection.Close();
        }

        public static SqlCommand sqlCommand;
        public static void setSqlCommand(string query)
        {
            sqlCommand = new SqlCommand(query, sqlConnection);
        }

        public static SqlDataReader sqlReader;
        public static void setSqlReader(string query)
        {
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlReader = sqlCommand.ExecuteReader();
        }
        
        public static List<string> getListSqlReader(List<string> columnNames)
        {
            List<string> columnValues = new List<string>();
            foreach (string columnName in columnNames)
            {
                columnValues.Add(sqlReader[columnName].ToString());
            }

            return columnValues;
        }
    }
}
