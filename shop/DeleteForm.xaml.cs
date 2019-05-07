using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для DeleteForm.xaml
    /// </summary>
    public partial class DeleteForm : Window
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Table.setListColumnNames(Table.tableName);
            FormElement.fillListBox(listBoxColumns, Table.listColumnNames);
        }

        private bool checkAndShowItemsErrors()
        {
            if (TextBoxDelete.Text == "")
                MessageBox.Show("Заполните поле.");
            else if (listBoxColumns.SelectedItem == null)
                MessageBox.Show("Выберите столбец.");
            else if (FormElement.listBox != null && FormElement.listBox.SelectedItem == null && FormElement.listBox.Visibility == Visibility)
                MessageBox.Show("Выберите знак.");
            else
                return true;

            return false;
        }

        Dictionary<string, string> tableData = new Dictionary<string, string>
        {
            { "tableName", Table.tableName },
            { "columnName", "id" },
            { "columnValue", "" },
            { "sign", null}
        };
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            if (checkAndShowItemsErrors())
            {
                FormElement.clearDataGrid(DataGridOutputData);
                try
                {
                    Table.setListColumnNames(Table.tableName);

                    DataBaseConnection.sqlConnection.Open();

                    string query = "DELETE FROM " + Table.tableName + " WHERE " + listBoxColumns.SelectedItem.ToString() + " " + tableData["sign"] + "'" + TextBoxDelete.Text + "'";
                    DataBaseConnection.setSqlReader(query);

                    FormElement.fillDataGridColumn(DataGridOutputData, Table.listColumnNames);
                    FormElement.fillDataGridItem(DataGridOutputData, DataBaseConnection.sqlReader, Table.listColumnNames);
                }
                catch
                {
                    MessageBox.Show("По вашему запросу ничего не найдено.");
                }
                finally
                {
                    DataBaseConnection.sqlConnection.Close();
                }
            }
        }
        
        private void changeEntryDataForm()
        {
            GridDelete.Children.Remove(FormElement.listBox);
            FormElement.listBox = new ListBox();

            PropertyInfo[] tableColumInfo = typeof(Table).GetProperties();
            for (int i = 0; i < tableColumInfo.Length; i++)
                if (listBoxColumns.SelectedItem.ToString() == tableColumInfo[i].Name)
                {
                    if (tableColumInfo[i].PropertyType == typeof(int))
                    {
                        FormElement.createListBox(FormElement.listBox, "listBoxSign", Visibility.Visible);
                        FormElement.fillListBox(FormElement.listBox, new List<string> { "=", ">", "<" });

                        TextBoxDelete.Margin = new Thickness(210, 10, 0, 0);
                        TextBoxDelete.Width = 450;
                        TextBoxDelete.Height = 30;

                        break;
                    }
                    else
                    {
                        FormElement.createListBox(FormElement.listBox, "listBoxSign", Visibility.Hidden);
                        tableData["sign"] = null;

                        TextBoxDelete.Margin = new Thickness(160, 10, 0, 0);
                        TextBoxDelete.Width = 500;
                        TextBoxDelete.Height = 30;

                        break;
                    }
                }
            GridDelete.Children.Add(FormElement.listBox);
        }

        private void ListBoxColumns_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tableData["columnName"] = listBoxColumns.SelectedItem.ToString();

            changeEntryDataForm();
        }

        private bool checkItemsErrors()
        {
            if (FormElement.listBox != null && FormElement.listBox.SelectedItem != null && TextBoxDelete.Text != "")
                return true;

            return false;
        }

        private void GridDelete_KeyUp(object sender, KeyEventArgs e)
        {
            if (checkItemsErrors())
                ListBoxSign_SelectionChanged();
            else
            {
                tableData["columnValue"] = TextBoxDelete.Text;

                MainWindow.Select(DataGridOutputData, tableData);
            }
        }
        
        private void ListBoxSign_SelectionChanged()
        {
            tableData["columnValue"] = TextBoxDelete.Text;
            tableData["sign"] = FormElement.listBox.SelectedItem.ToString();

            MainWindow.Select(DataGridOutputData, tableData);
        }

        private void GridDelete_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (checkItemsErrors())
                ListBoxSign_SelectionChanged();
        }
    }
}
