using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms.VisualStyles;

namespace shop
{
    class FormElement : MainWindow
    {
        public static void fillListBox(ListBox listBox, List<string> listValue)
        {
            foreach (string tableName in listValue)
            {
                listBox.Items.Add(tableName);
            }
        }
        
        public static void fillDataGridColumn(DataGrid dataGrid, List<string> columnNames)
        {
            for (int i = 0; i < columnNames.Count; i++)
            {
                DataGridTextColumn DataGridColumn = new DataGridTextColumn();

                DataGridColumn.Header = columnNames[i];
                DataGridColumn.Binding = new Binding(columnNames[i]);

                dataGrid.Columns.Add(DataGridColumn);
            }
        }

        public static void fillDataGridItem(DataGrid dataGrid, SqlDataReader sqlReader, List<string> columnNames)
        {
            while (DataBaseConnection.sqlReader.Read())
            {
                Table tableData = new Table();
                
                List<string> listColumnValues = DataBaseConnection.getListSqlReader(columnNames);
                tableData.setColumnValues(columnNames, listColumnValues);
                
                dataGrid.Items.Add(tableData);
            }
        }

        public static void clearDataGrid(DataGrid dataGrid)
        {
            dataGrid.Columns.Clear();
            dataGrid.Items.Clear();
        }

        public static void createListBox(ListBox listBox, string name, Visibility visibility)
        {
            listBox.Name = name;
            listBox.Width = 45;
            listBox.Height = 30;
            listBox.FontSize = 16;
            listBox.Margin = new Thickness(160, 10, 0, 0);
            listBox.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            listBox.HorizontalAlignment = HorizontalAlignment.Left;
            listBox.Visibility = visibility;
        }

        public static void createLable(Label label, string name, Dictionary<string, int> elementPosition)
        {
            label.Content = name;
            label.Width = 90;
            label.Height = 30;
            label.Margin = new Thickness(10, elementPosition["marginTop"], 0, 0);
            label.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            label.HorizontalAlignment = HorizontalAlignment.Left;
        }

        public static void createTextBox(TextBox textBox, string name, Dictionary<string, int> elementPosition)
        {
            textBox.Name = name;
            textBox.Width = 560;
            textBox.Height = 28;
            textBox.Margin = new Thickness(100, elementPosition["marginTop"], 0, 0);
            textBox.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            textBox.HorizontalAlignment = HorizontalAlignment.Left;
        }

        public static void createCheckBox(CheckBox checkBox, string name, Dictionary<string, int> elementPosition)
        {
            checkBox.Name = name;
            checkBox.Margin = new Thickness(100, elementPosition["marginTop"] + 7, 0, 0);
            checkBox.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            checkBox.HorizontalAlignment = HorizontalAlignment.Left;
        }

        public static void createButton(Button button, string content, Dictionary<string, int> elementPosition)
        {
            button.Content = content;
            button.Width = 100;
            button.Height = 25;
            button.Margin = new Thickness(670, elementPosition["marginTop"] + 5, 0, 0);
            button.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            button.HorizontalAlignment = HorizontalAlignment.Left;
        }

        public static void createGrid(DataGrid dataGrid, Dictionary<string, int> elementPosition)
        {
            dataGrid.Width = 650;
            dataGrid.Height = 250;
            dataGrid.Margin = new Thickness(10, elementPosition["marginTop"] + 5, 0, 0);
            dataGrid.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            dataGrid.HorizontalAlignment = HorizontalAlignment.Left;
        }

        public static List<TextBox> listTextBox;
        public static List<CheckBox> listCheckBox;
        public static void giveDataFromElementsToTable(Table tableData)
        {
            if (FormElement.listTextBox.Count != 0)
            {
                List<string>  listTextBoxNames = new List<string>();
                List<string>  listTextBoxValues = new List<string>();
                
                for (int i = 0; i < listTextBox.Count; i++)
                {
                    listTextBoxNames.Add(listTextBox[i].Name);
                    listTextBoxValues.Add(listTextBox[i].Text);
                }

                tableData.setColumnValues(listTextBoxNames, listTextBoxValues);
            }
            if (FormElement.listCheckBox.Count != 0)
            {
                List<string> listCheckBoxNames = new List<string>();
                List<string> listCheckBoxValues = new List<string>();
                
                for (int i = 0; i < listCheckBox.Count; i++)
                {
                    listCheckBoxNames.Add(listCheckBox[i].Name);
                    listCheckBoxValues.Add(listCheckBox[i].IsChecked.ToString());
                }

                tableData.setColumnValues(listCheckBoxNames, listCheckBoxValues);
            }
        }

        public static bool checkTextBoxesErrors()
        {
            for (int i = 0; i < listTextBox.Count; i++)
                if (listTextBox[i].Text == "")
                    return false;

            return true;
        }

        public static DataGrid dataGrid;
        public static Label label;
        public static CheckBox checkBox;
        public static TextBox textBox;
        public static ListBox listBox;
        public static Button button;
        public static void createGridElements(Grid grid, List<string> listColumnNames)
        {
            PropertyInfo[] tableColumInfo = typeof(Table).GetProperties();
            Dictionary<string, int> elementPosition = new Dictionary<string, int>
            {
                { "marginTop", 10 }
            };

            button = new Button();
            dataGrid = new DataGrid();
            listTextBox = new List<TextBox>();
            listCheckBox = new List<CheckBox>();

            elementPosition["marginTop"] = 10;
            foreach (string columnName in listColumnNames)
            {
                label = new Label();
                checkBox = new CheckBox();
                textBox = new TextBox();

                for (int i = 0; i < tableColumInfo.Length; i++)
                    if (tableColumInfo[i].Name == columnName && (
                        tableColumInfo[i].PropertyType == typeof(int) ||
                        tableColumInfo[i].PropertyType == typeof(string) ||
                        tableColumInfo[i].PropertyType == typeof(double)))
                    {
                        FormElement.createTextBox(textBox, columnName, elementPosition);
                        FormElement.listTextBox.Add(textBox);
                        grid.Children.Add(textBox);

                        break;
                    }
                    else if (tableColumInfo[i].Name == columnName &&
                        tableColumInfo[i].PropertyType == typeof(bool))
                    {
                        FormElement.createCheckBox(checkBox, columnName, elementPosition);
                        FormElement.listCheckBox.Add(checkBox);
                        grid.Children.Add(checkBox);

                        break;
                    }
                FormElement.createLable(label, columnName, elementPosition);
                grid.Children.Add(label);

                elementPosition["marginTop"] += 30;
            }

            FormElement.createGrid(dataGrid, elementPosition);
            grid.Children.Add(dataGrid);

            FormElement.createButton(FormElement.button, "Выполнить", elementPosition);
            grid.Children.Add(FormElement.button);
        }
    }
}
