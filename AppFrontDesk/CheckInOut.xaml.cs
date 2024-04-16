using AppFrontDesk.Data;
using AppFrontDesk.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    /// Interaction logic for CheckInOut.xaml
    /// </summary>
    public partial class CheckInOut : Page
    {
        private Oblig4Dat154DbContext dbContext;
        private List<Reservation> reservationsList;
        private readonly LocalView<Reservation> _reservations;
        private readonly LocalView<Person> _people;

        public CheckInOut()
        {
            InitializeComponent();
            Load();


            //  _reservations = dbContext.Reservations.Local;
            //  _people = dbContext.People.Local;

            //  reservationGrid.ItemsSource = _reservations.ToList();
        }

        private void Load()
        {
            dbContext = new Oblig4Dat154DbContext();
            reservationsList = dbContext.Reservations.ToList();
            reservationGrid.ItemsSource = reservationsList;
            List<Person> personList = dbContext.People.ToList();

        }

        private void HomeBtnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new FrontPage());

        }

        private void CheckInBtnClick(object sender, RoutedEventArgs e)
        {
            Reservation selectedReservation = reservationGrid.SelectedItem as Reservation;

            Reservation DbReservation = reservationsList.Find(r => r.ReservationId == selectedReservation.ReservationId);

        }

        private void checkOutBtnClick(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBtnClick(object sender, RoutedEventArgs e)
        {

        }
        private void resetBtnClick(object sender, RoutedEventArgs e)
        {
            resetReservationGrid();
        }
        private void resetReservationGrid()
        {
            reservationGrid.ItemsSource = null;
            reservationGrid.ItemsSource = reservationsList;
        }

        private void TimePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            // var timePicker = sender as TimePicker;
            /*
             if (timePicker != null && timePicker.Value.HasValue)
             {
                 var selectedTime = timePicker.Value.Value;

                 // استرجاع السجل المحدد من ListView
                 Reservation selectedReservation = reservationGrid.SelectedItem as Reservation;

                 // تحديث القيمة المناسبة في السجل
                 if (timePicker.Name == "checkInTimePicker")
                 {
                     selectedReservation.CheckIn = selectedTime;
                 }
                 else if (timePicker.Name == "checkOutTimePicker")
                 {
                     selectedReservation.CheckOut = selectedTime;
                 }

                 // حفظ التغييرات في قاعدة البيانات
                 dbContext.SaveChanges();
            */


        }
    }
}
