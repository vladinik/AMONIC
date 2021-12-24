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
        public void LoadUser()
        {
            if(CbNameOffices.SelectedIndex==0)
            {
                DgListUser.ItemsSource = Helper.GetEntities().Users.ToList();
            } 
            else
            {
                var office = CbNameOffices.SelectedItem as Offices;
                var user = Helper.GetEntities().Users.Where(x => x.Ofice == office.ID).ToList();
                DgListUser.ItemsSource = user;
            }
        }

        private void BtnChangeRole_Click(object sender, RoutedEventArgs e)
        {
            WinEditRole winEditRole = new WinEditRole();
            winEditRole.Show();
            this.Hide();
        }

        private void BtnEnableDisableLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TbExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CbNameOffices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadUser();
        }

        private void TBAdd_Click(object sender, RoutedEventArgs e)
        {
            WinAddUser winAddUser = new WinAddUser();
            winAddUser.Show();
            this.Hide();
        }
    }
}
