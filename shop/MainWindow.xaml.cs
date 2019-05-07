using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace shop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitialWindow initialForm = new InitialWindow();
            initialForm.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataBaseConnection.setSqlConnection();
            DataBaseConnection.setDataTable(DataBaseConnection.sqlConnection, "Tables");

            Table.setListTableNames(DataBaseConnection.dataTable);
            FormElement.fillListBox(listBoxTables, Table.listTableNames);
        }
        
        private void ListBoxTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Table.setTableName(listBoxTables.SelectedItem.ToString());
        }

        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> tableData = new Dictionary<string, string>
            {
                { "tableName", Table.tableName }
            };
            MainWindow.Select(DataGrid, tableData);
        }

        private static string getQuery(Dictionary<string, string> tableData)
        {
            string query;

            if (tableData.ContainsKey("columnName") && tableData.ContainsKey("columnValue") && tableData.ContainsKey("sign") && tableData["sign"] != null)
                query = "SELECT * FROM " + tableData["tableName"] + " WHERE " + tableData["columnName"] + " " + tableData["sign"] + "  '" + tableData["columnValue"] + "'";
            else if (tableData.ContainsKey("columnName") && tableData.ContainsKey("columnValue"))
                query = "SELECT * FROM " + tableData["tableName"] + " WHERE " + tableData["columnName"] + " LIKE  '%" + tableData["columnValue"] + "%'";
            else
                query = "SELECT * FROM " + tableData["tableName"];

            return query;
        }

        public static void Select(DataGrid dataGrid, Dictionary<string, string> tableData)
        {
            FormElement.clearDataGrid(dataGrid);
            try
            {
                Table.setListColumnNames(tableData["tableName"]);

                DataBaseConnection.sqlConnection.Open();

                string query = getQuery(tableData);
                DataBaseConnection.setSqlReader(query);
                
                FormElement.fillDataGridColumn(dataGrid, Table.listColumnNames);
                FormElement.fillDataGridItem(dataGrid, DataBaseConnection.sqlReader, Table.listColumnNames);
            }
            catch
            {
                MessageBox.Show("Выберите название таблицы.");
            }
            finally
            {
                DataBaseConnection.sqlConnection.Close();
            }
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if (Table.checkTableNameErrors())
            {
                SelectForm selectForm = new SelectForm();
                selectForm.Show();
            }
            else
                MessageBox.Show("Выберите название таблицы.");
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            if (Table.checkTableNameErrors())
            {
                InsertForm insertForm = new InsertForm();
                insertForm.Show();
            }
            else
                MessageBox.Show("Выберите название таблицы.");
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (Table.checkTableNameErrors())
            {
                UpdateForm updateForm = new UpdateForm();
                updateForm.Show();
            }
            else
                MessageBox.Show("Выберите название таблицы.");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Table.checkTableNameErrors())
            {
                DeleteForm deleteForm = new DeleteForm();
                deleteForm.Show();
            }
            else
                MessageBox.Show("Выберите название таблицы.");
        }
    }
}