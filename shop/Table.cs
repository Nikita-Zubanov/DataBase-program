using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;

namespace shop
{
    class Table
    {
        public int id { get; set; }
        public int category_id { get; set; }
        public int client_id { get; set; }
        public int product_id { get; set; }
        public int client_order_id { get; set; }
        public int warehouse_id { get; set; }
        public string phone_number { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public double price { get; set; }
        public bool in_stock { get; set; }

        public void setColumnValues(List<string> columnNames, List<string> columnValues)
        {
            for (int i = 0; i < columnNames.Count; i++)
                switch (columnNames[i])
                {
                    case nameof(this.id): this.id = Convert.ToInt32(0 + columnValues[i]); break;
                    case nameof(this.category_id): this.category_id = Convert.ToInt32(0 + columnValues[i]); break;
                    case nameof(this.client_id): this.client_id = Convert.ToInt32(0 + columnValues[i]); break;
                    case nameof(this.product_id): this.product_id = Convert.ToInt32(0 + columnValues[i]); break;
                    case nameof(this.client_order_id): this.client_order_id = Convert.ToInt32(0 + columnValues[i]); break;
                    case nameof(this.warehouse_id): this.warehouse_id = Convert.ToInt32(0 + columnValues[i]); break;
                    case nameof(this.name): this.name = Convert.ToString(columnValues[i]); break;
                    case nameof(this.description): this.description = Convert.ToString(columnValues[i]); break;
                    case nameof(this.address): this.address = Convert.ToString(columnValues[i]); break;
                    case nameof(this.phone_number): this.phone_number = Regex.Replace(columnValues[i], @"[^0-9$,]", ""); break;
                    case nameof(this.email): this.email = Convert.ToString(columnValues[i]); break;
                    case nameof(this.price): this.price = Math.Round(Convert.ToDouble(0 + columnValues[i].Replace('.', ',')), 2); break;
                    case nameof(this.in_stock): this.in_stock = Convert.ToBoolean(columnValues[i]); break;
                }
        }

        public Object getColumnValue(string columnName)
        {
            switch (columnName)
            {
                case nameof(this.id): return this.id;
                case nameof(this.category_id): return this.category_id;
                case nameof(this.client_id): return this.client_id;
                case nameof(this.product_id): return this.product_id;
                case nameof(this.client_order_id): return this.client_order_id;
                case nameof(this.warehouse_id): return this.warehouse_id;
                case nameof(this.name): return this.name;
                case nameof(this.description): return this.description;
                case nameof(this.address): return this.address;
                case nameof(this.phone_number): return this.phone_number;
                case nameof(this.email): return this.email;
                case nameof(this.price): return this.price;
                case nameof(this.in_stock): return this.in_stock;
                default: return null;
            }
        }

        public static string tableName;
        public static void setTableName(string name)
        {
            tableName = name;
        }
        public static bool checkTableNameErrors()
        {
            if (tableName != null)
                return true;

            return false;
        }

        public static List<String> listColumnNames;
        public static void setListColumnNames(string tableName)
        {
            listColumnNames = new List<string>();
            string query = "SELECT * FROM " + tableName;

            DataBaseConnection.sqlConnection.Open();
            DataBaseConnection.setSqlReader(query);
            
            for (int i = 0; i < DataBaseConnection.sqlReader.FieldCount; i++)
            {
                listColumnNames.Add(DataBaseConnection.sqlReader.GetName(i));
            }

            DataBaseConnection.sqlConnection.Close();
        }

        public static List<string> listTableNames;
        public static void setListTableNames(DataTable dataTable)
        {
            listTableNames = new List<string>();
            
            foreach (DataRow row in dataTable.Rows)
            {
                string tableName = (string)row[2];
                listTableNames.Add(tableName);
            }
        }

        public static string[] getArrayNames()
        {
            string[] columnNames = new string[listColumnNames.Count];

            for (int i = 0; i < listColumnNames.Count; i++)
            {
                columnNames[i] = listColumnNames[i];
            }

            return columnNames;
        }
    }
}
