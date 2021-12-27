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
    /// Логика взаимодействия для WinAddUser.xaml
    /// </summary>
    public partial class WinAddUser : Window
    {
        public WinAddUser()
        {
            InitializeComponent();
            LoadOffice();
            DataContext = new UserControl();
        }
        private void LoadOffice()
        {
            var offices = Helper.GetEntities().Offices.ToList();
            offices.Insert(0, new Offices() { Title = "Office name" });
            CbOffice.ItemsSource = offices;
        }
        

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            using (UserOficeEntities db = new UserOficeEntities())
            {
                Users user = new Users();
                user.Role = 2;
                user.Active = true;
                user.Email = AddEmailAddress.Text;
                user.Name = AddFirstName.Text;
                user.Surname = AddLastName.Text;
                user.DateBirth = DpBrithDate.SelectedDate.Value;
                user.Password = Helper.MD5Hash(PbPassword.Password);
                user.Ofice = (int)CbOffice.SelectedValue;
                
                Helper.GetEntities().Users.Add(user);
                Helper.GetEntities().SaveChanges();
                MessageBox.Show("Пользователь добавлен!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
