using AppFrontDesk.Data;
using AppFrontDesk.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<DayView> dayViews; // Create an ObservableCollection as the underlying data source

        public DayViewReservation()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            dbContext = new Oblig4Dat154DbContext();
            dayViews = new ObservableCollection<DayView>(dbContext.DayViews.ToList()); // Initialize the ObservableCollection with the data from the database
            dayViewGrid.ItemsSource = dayViews;
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FrontPage());
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            dayViewGrid.IsReadOnly = false;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            foreach (var dayView in dayViews)
            {
                if (dbContext.Entry(dayView).State == EntityState.Modified || dbContext.Entry(dayView).State == EntityState.Added)
                {
                    dbContext.Entry(dayView).State = EntityState.Modified;
                }
            }

            dbContext.SaveChanges();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            // Create a new item and add it to the ObservableCollection (underlying data source)
            DayView newItem = new DayView();
            dayViews.Add(newItem);

            // Scroll to the newly added item
            dayViewGrid.ScrollIntoView(newItem);
            dbContext.SaveChanges();
        }


    }
}
