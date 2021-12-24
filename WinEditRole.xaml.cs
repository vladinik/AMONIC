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

namespace AMONIC
{
    /// <summary>
    /// Логика взаимодействия для WinEditRole.xaml
    /// </summary>
    public partial class WinEditRole : Window
    {
        public WinEditRole(Users users)
        {
            CbOffice.IsEnabled = false;
            DataContext = users;
            AddEmailAddress.Text = users.Email;
            AddFirstName.Text = users.Name;
            AddLastName.Text = users.Surname;
            CbOffice.SelectedValue = users.Ofice;
            if (users.Role == 1)
            {
                RAdmin.IsChecked = true;
            }
            else
            {
                RUser.IsChecked = true;
            }
        }

        private void BtApply_Click(object sender, RoutedEventArgs e)
        {
            var users = DataContext as Users;
            if (RAdmin.IsChecked == true)
            {
                users.Role = 1;
            }
            else
            {
                users.Role = 2;
            }
            Helper.GetEntities().SaveChanges();
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
