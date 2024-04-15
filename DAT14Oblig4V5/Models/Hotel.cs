using System;
using System.Collections.Generic;

namespace DAT14Oblig4V5.Models;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string HotelName { get; set; } = null!;

    public string HotelAdress { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
