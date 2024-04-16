using AppFrontDesk.Models;
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

namespace AppFrontDesk
{
    /// <summary>
    /// Interaction logic for FrontPage.xaml
    /// </summary>
    public partial class FrontPage : Page
    {
        public FrontPage()
        {
            InitializeComponent();
        }

        private void ManageReservation_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ManageReservation());
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CheckInOut());
        }


        private void Register_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegisterRoomService());
        }

        private void DayView_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DayViewReservation());
        }
    }
}
