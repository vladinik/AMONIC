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
    /// Логика взаимодействия для WinUser.xaml
    /// </summary>
    public partial class WinUser : Window
    {
        public WinUser()
        {
            InitializeComponent();
            TB1.Text = $"Hi {Helper.currentUser.Name}, Welcome to AMONIC Airlines.";
            TimeSpan time = new TimeSpan(Helper.GetEntities().UserActivity.ToList()
                .Where(x => x.IDUser == Helper.currentUser.ID && x.LogutTime.HasValue && 
                x.LogutTime <= x.LogutTime.Value.AddDays(30) && x.TimeSpent.HasValue).ToList().Sum(x=>x.TimeSpent.Value.Ticks));
            TB2.Text = $"Time spent on system: {time:hh\\:mm}\t";
            TB3.Text = $"Number of crashes:{Helper.GetEntities().UserActivity.Where(x => x.IDUser == Helper.currentUser.ID && !string.IsNullOrEmpty(x.Reason)).Count()}";
            var activity = Helper.GetEntities().UserActivity.Where(x => x.IDUser == Helper.currentUser.ID).ToList();
            DGUser.ItemsSource = activity;
        }

        private void TBExit_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var logExiting = Helper.GetEntities().UserActivity.OrderByDescending(x => x.ID).FirstOrDefault(x => x.IDUser == Helper.currentUser.ID);
            if(!logExiting.LogutTime.HasValue)
            {
                logExiting.LogutTime = DateTime.Now;
                Helper.GetEntities().SaveChanges();
            }
            Close();
        }
    }
}
