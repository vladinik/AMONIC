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
using System.Windows.Threading;

namespace AMONIC
{
    /// <summary>
    /// Логика взаимодействия для WinLogin.xaml
    /// </summary>
    public partial class WinLogin : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private int countError;
        private int tick = 10;
        public WinLogin()
        {
            InitializeComponent();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += TimerTick;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            BTLogin.Content = $"Доступ заблокирован:{tick} сек.";
            tick--;
            if(tick==0)
            {
                BTLogin.IsEnabled = true;
                dispatcherTimer.Stop();
                tick = 10;
                countError = 0;
            }
        }

        private void BTLogin_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(TBUsername.Text) || string.IsNullOrEmpty(PBLogin.Password))
            {
                MessageBox.Show("Не заполнены поля", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            var pass = Helper.MD5Hash(PBLogin.Password);
            var user = Helper.GetEntities().Users.FirstOrDefault(x => x.Password == pass && x.Email == TBUsername.Text);
            if(user==null)
            {
              if(countError==3)
                {
                    BTLogin.IsEnabled = false;
                    dispatcherTimer.Start();
                    return;
                }
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                countError++;
                TBUsername.Text = string.Empty;
                PBLogin.Password = string.Empty;
                return;
            }
            if(user.Active.HasValue)
            {
                if(!user.Active.Value)
                {
                    MessageBox.Show("Аккаунт не активен", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            Helper.currentUser = user;
            if(user.Role==1)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            if (user.Role == 2)
            {
                UserActivity activity = new UserActivity()
                {
                    IDUser = user.ID,
                    LoginTime = DateTime.Now,
                };
                Helper.GetEntities().UserActivity.Add(activity);
                Helper.GetEntities().SaveChanges();
                Helper.currentUserActivity = activity;
                WinUser winUser = new WinUser();
                winUser.Show();
            }
            Close();
        }

        private void BTNExtin_Click(object sender, RoutedEventArgs e)
        {
            
            Application.Current.Shutdown();
        }
    }
}
