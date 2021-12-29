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
    /// Логика взаимодействия для WinManageWindow.xaml
    /// </summary>
    public partial class WinManageWindow : Window
    {
        
        public WinManageWindow()
        {
            InitializeComponent();
            DataContext = new Airports();
            CBAirportFrom.ItemsSource = Helper.GetEntities().Airports.ToList();
            CBAirportTo.ItemsSource = Helper.GetEntities().Airports.ToList();
            DGFightShedules.ItemsSource = Helper.GetEntities().Schedules.ToList();
        }
        private void BTNApply_Click(object sender, RoutedEventArgs e)
        {
            if(CBAirportFrom.Text==CBAirportTo.Text)
            {
                MessageBox.Show("Аэропорт отправления и аэропорт прибытия не должны быть одинаковые", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var airportFrom = CBAirportFrom.SelectedItem as Airports;
            var airportTo = CBAirportTo.SelectedItem as Airports;
            switch(CBDateTime.SelectedIndex)
            {
                case 0:
                    
                    var listShedules = Helper.GetEntities().Schedules.Where(x=>x.Routes.Airports.ID==airportFrom.ID && x.Routes.Airports1.ID==airportTo.ID).OrderBy(x => x.Date).ThenBy(x => x.Time).ToList();
                    DGFightShedules.ItemsSource = listShedules;
                    break;
                case 1:
                    var listShedules1 = Helper.GetEntities().Schedules.Where(x => x.Routes.Airports.ID == airportFrom.ID && x.Routes.Airports1.ID == airportTo.ID).OrderBy(x => x.EconomyPrice).ToList();
                    DGFightShedules.ItemsSource = listShedules1;
                    break;
                case 2:
                    var listShedules2 = Helper.GetEntities().Schedules.Where(x => x.Routes.Airports.ID == airportFrom.ID && x.Routes.Airports1.ID == airportTo.ID).OrderBy(x => x.Confirmed).ToList();
                    DGFightShedules.ItemsSource = listShedules2;
                    break;
            }
        }
        private void BTNCancel_Click(object sender, RoutedEventArgs e)
        {
            if (DGFightShedules.Items.Count > 0)
            {
                if (DGFightShedules.SelectedItem is Schedules shedul)
                {
                    shedul.Confirmed = "CANCELED";
                    Helper.GetEntities().SaveChanges();
                    var listSchedules = Helper.GetEntities().Schedules.OrderBy(x => x.Date).ThenBy(x => x.Time).ToList();
                    DGFightShedules.ItemsSource = listSchedules;
                }
            }
        }
        private void BTNEdit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BTNImport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
