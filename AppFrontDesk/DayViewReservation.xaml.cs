using AppFrontDesk.Data;
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
    /// Interaction logic for DayViewReservation.xaml
    /// </summary>
    public partial class DayViewReservation : Page
    {
        private Oblig4Dat154DbContext dbContext;
        public DayViewReservation()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            dbContext = new Oblig4Dat154DbContext();
            List<DayView> dayViews = dbContext.DayViews.ToList();
            dayViewGrid.ItemsSource = dayViews;
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FrontPage());
        }
    }
}
