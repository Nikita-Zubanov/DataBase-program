using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace shop
{
    /// <summary>
    /// Логика взаимодействия для InsertForm.xaml
    /// </summary>
    public partial class InsertForm : Window
    {
        public InsertForm()
        {
            InitializeComponent();
        }

        private void Form_Loaded(object sender, RoutedEventArgs e)
        {
            Table.setListColumnNames(Table.tableName);
            Table.listColumnNames.Remove("id");
            FormElement.createGridElements(GridInsert, Table.listColumnNames);
        }

        private void Form_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.GetPosition(FormElement.button).X <= FormElement.button.Width && e.GetPosition(FormElement.button).Y <= FormElement.button.Height &&
                e.GetPosition(FormElement.button).X >= 0 && e.GetPosition(FormElement.button).Y >= 0)
            {
                Button_Click();
            }
        }

        private void Button_Click()
        {
            if (FormElement.checkTextBoxesErrors())
            {
                Table tableData = new Table();

                FormElement.giveDataFromElementsToTable(tableData);

                Table.listColumnNames.Remove("id");
                string[] columnNames = Table.getArrayNames();
                string query = @"INSERT INTO " + Table.tableName + " (" + String.Join(", ", columnNames) + ") VALUES(@" + String.Join(", @", columnNames) + ")";

                DataBaseConnection.setSqlCommand(query);
                DataBaseConnection.sqlConnection.Open();

                for (int i = 0; i < Table.listColumnNames.Count; i++)
                {
                    DataBaseConnection.sqlCommand.Parameters.AddWithValue(columnNames[i].Insert(0, "@"), tableData.getColumnValue(columnNames[i]));
                }

                DataBaseConnection.sqlCommand.ExecuteNonQuery();
                DataBaseConnection.sqlConnection.Close();
            }
            else
                MessageBox.Show("Заполните все поля.");
        }

        private int getLastId()
        {
            DataBaseConnection.sqlConnection.Open();

            string query = "SELECT * FROM " + Table.tableName;
            DataBaseConnection.setSqlReader(query);

            int lastId = 0;
            while (DataBaseConnection.sqlReader.Read())
            {
                lastId = Convert.ToInt32(DataBaseConnection.sqlReader["id"]);
            }
            
            DataBaseConnection.sqlConnection.Close();

            return lastId;
        }

        private void GridInsert_KeyUp(object sender, KeyEventArgs e)
        {
            Table.setListColumnNames(Table.tableName);

            FormElement.clearDataGrid(FormElement.dataGrid);
            FormElement.fillDataGridColumn(FormElement.dataGrid, Table.listColumnNames);

            Table tableData = new Table();

            tableData.setColumnValues(new List<string> { "id" }, new List<string> { (getLastId() + 1).ToString() });
            FormElement.giveDataFromElementsToTable(tableData);

            FormElement.dataGrid.Items.Add(tableData);
        }
    }
}
