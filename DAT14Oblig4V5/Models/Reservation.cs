using System;
using System.Collections.Generic;

namespace DAT14Oblig4V5.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int? CustomerId { get; set; }

    public int? HotelId { get; set; }

    public DateOnly? ReservationStart { get; set; }

    public DateOnly? ReservationEnd { get; set; }

    public DateTime? Checkin { get; set; }

    public DateTime? Checkout { get; set; }

    public virtual Person? Customer { get; set; }

    public virtual ICollection<DayView> DayViews { get; set; } = new List<DayView>();

    public virtual Hotel? Hotel { get; set; }
    public  int? RoomNr { get;  set; }

    public virtual Room? RoomNrNavigation { get; set; } = null!;
}
