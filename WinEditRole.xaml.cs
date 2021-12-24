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
        public WinEditRole()
        {
            InitializeComponent();
            AddEmailAddress.IsEnabled = false;
            AddFirstName.IsEnabled = false;
            AddLastName.IsEnabled = false;
            CbOffice.IsEnabled = false;
        }

        private void BtApply_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
