using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace shop
{
    /// <summary>
    /// Логика взаимодействия для UpdateForm.xaml
    /// </summary>
    public partial class UpdateForm : Window
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Table.setListColumnNames(Table.tableName);
            FormElement.createGridElements(GridUpdate, Table.listColumnNames);
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.GetPosition(FormElement.button).X <= FormElement.button.Width && e.GetPosition(FormElement.button).Y <= FormElement.button.Height &&
                e.GetPosition(FormElement.button).X >= 0 && e.GetPosition(FormElement.button).Y >= 0)
            {
                Button_Click();
            }
        }

        private static string getQuery(Table tableData)
        {
            string idColumn = FormElement.listTextBox.Find(item => item.Name == "id").Text;
            string query = @"UPDATE " + Table.tableName + " SET";
            for (int i = 1; i < Table.listColumnNames.Count; i++)
            {
                query += @" " + Table.listColumnNames[i] + " = '" + tableData.getColumnValue(Table.listColumnNames[i]) + "',";
            }
            query = query.Substring(0, query.Length - 1) + " WHERE id = " + idColumn;

            return query;
        }

        Dictionary<string, string> tableData = new Dictionary<string, string>
        {
            { "tableName", Table.tableName },
            { "columnName", "" },
            { "columnValue", "" }
        };
        private void Button_Click()
        {
            if (FormElement.checkTextBoxesErrors())
            {
                Table tableData = new Table();

                FormElement.giveDataFromElementsToTable(tableData);
                
                string query = getQuery(tableData);

                DataBaseConnection.setSqlCommand(query);
                DataBaseConnection.sqlConnection.Open();

                DataBaseConnection.setSqlCommand(query);

                DataBaseConnection.sqlCommand.ExecuteNonQuery();
                DataBaseConnection.sqlConnection.Close();
            }
            else
                MessageBox.Show("Заполните все поля.");
        }

        private void GridUpdate_KeyUp(object sender, KeyEventArgs e)
        {
            tableData["columnName"] = FormElement.listTextBox.Find(item => item.Name == "id").Name;
            tableData["columnValue"] = FormElement.listTextBox.Find(item => item.Name == "id").Text;
            MainWindow.Select(FormElement.dataGrid, tableData);
        }
    }
}
