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
        
        List<Users> users = new List<Users>();
        
        public MainWindow()
        {

            InitializeComponent();
            
            var cbm = Helper.GetEntities().Offices.ToList();
            cbm.Insert(0, new Offices() { Title = "Все группы" });
            CbNameOffices.ItemsSource = cbm;
            LoadUser();
            
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
            if (DgListUser.Items.Count > 0)
            {
                var index = DgListUser.SelectedItem;

                using (UserOficeEntities db = new UserOficeEntities())
                {
                    if (DgListUser.SelectedItem is Users users)
                    {
                        WinEditRole winEditRole = new WinEditRole(users);
                        winEditRole.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("NO");
                    }
                }
            }
            else
            {
                MessageBox.Show("Не выбран пользователь");
            }
        }

        private void BtnEnableDisableLogin_Click(object sender, RoutedEventArgs e)
        {

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

        private void TbExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
