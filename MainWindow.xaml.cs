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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AMONIC
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List<Offices> offices = Helper.GetEntities().Offices.ToList();
        List<Users> users = new List<Users>();
        //List<UserRole> userRoles = new List<UserRole>();
        public MainWindow()
        {

            InitializeComponent();
            var usersList = Helper.GetEntities().Users.ToList();
            using (UserOficeEntities db = new UserOficeEntities())
            {
                Users users = new Users();
                
            }
            DgListUser.ItemsSource = usersList;
            
            var cbm = Helper.GetEntities().Offices.ToList();
            cbm.Insert(0, new Offices() { Title = "Все группы" });
            CbNameOffices.ItemsSource = cbm;
            
        }

        private void BtnChangeRole_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEnableDisableLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TbAddUser_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("DA");
        }

        private void TbExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
