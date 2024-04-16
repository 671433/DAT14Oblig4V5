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
    /// Interaction logic for ManageReservation.xaml
    /// </summary>
    public partial class ManageReservation : Page
    {
        private Oblig4Dat154DbContext dbContext;
        public ManageReservation()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            dbContext = new Oblig4Dat154DbContext();
            List<Reservation> reservations = dbContext.Reservations.ToList();
            reservationGrid.ItemsSource = reservations;
            
            List<Room> RoomList = dbContext.Rooms.ToList();
            serchRoomGrid.ItemsSource = RoomList;
        }

        private void Btn_home_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new FrontPage());
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = userNamesDropDown.SelectedItem as Person;

            dbContext = new Oblig4Dat154DbContext();

            DateTime? checkIn = getDatesSelected().Item1;
            DateTime? checkOut = getDatesSelected().Item2;
            if (checkIn != null && checkOut != null && selectedPerson != null)
            {
               // List<Room> hrList = dbContext.
                //serchResGrid.ItemsSource = hrList;
            }
        }

        private (DateTime?, DateTime?) getDatesSelected()
        {
            return (CheckInCal.SelectedDate, CheckOutCal.SelectedDate);
        }

        public List<Room> getRoomsInTimeperiod((DateTime?, DateTime?) dates)
        {

            List<Room> roomList = dbContext.Rooms.ToList();
            List<Reservation> resList = dbContext.Reservations.ToList();

            //Removes rooms that are already reserved in the time period chosen
            foreach (Reservation res in resList)
            {
                if ((dates.Item1 >= res.Checkin && dates.Item1 <= res.Checkout) || (dates.Item2 >= res.Checkin && dates.Item2 <= res.Checkout))
                {
                   // int id = res.;
                  //  roomList.RemoveAll((x) => x.Id == id);
                }
                
            }

            return roomList;
        }
    }
}
