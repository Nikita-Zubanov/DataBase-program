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
    /// Логика взаимодействия для InitialWindow.xaml
    /// </summary>
    public partial class InitialWindow : Window
    {
        public InitialWindow()
        {
            InitializeComponent();
        }
        
        private bool checkItemsErrors()
        {
            if (TextBoxServerName.Text != "" && TextBoxDataBaseName.Text != "")
                return true;

            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (checkItemsErrors())
            {
                DataBaseConnection.serverName = TextBoxServerName.Text;
                DataBaseConnection.dataBaseName = TextBoxDataBaseName.Text;
                
                this.Close();
            }
            else
                MessageBox.Show("Заполните все поля");
        }
    }
}
