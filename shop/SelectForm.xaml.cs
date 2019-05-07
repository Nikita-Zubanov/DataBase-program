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
    /// Логика взаимодействия для SelectForm.xaml
    /// </summary>
    public partial class SelectForm : Window
    {
        public SelectForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Table.setListColumnNames(Table.tableName);
            FormElement.fillListBox(listBoxColumns, Table.listColumnNames);
        }

        private static string selectedColumn;
        private void ListBoxColumns_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedColumn = listBoxColumns.SelectedItem.ToString();
        }

        private bool checkSelectColumnErrors()
        {
            if (selectedColumn != null)
                return true;

            return false;
        }

        private void GridSelect_KeyUp(object sender, KeyEventArgs e)
        {
            if (checkSelectColumnErrors())
            { 
                var textBoxValue = new string((from c in TextBoxSelect.Text where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c) select c).ToArray());
                Dictionary<string, string> tableData = new Dictionary<string, string>
                {
                    { "tableName", Table.tableName },
                    { "columnName", selectedColumn },
                    { "columnValue", textBoxValue }
                };
                MainWindow.Select(DataGridOutputData, tableData);
            }
                MessageBox.Show("Выберите слолбец.");
        }
    }
}
