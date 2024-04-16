using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppFrontDesk.Models;

public partial class Reservation
{
    [Key]
    [Column("ReservationID")]
    public int ReservationId { get; set; }

    [Column("CustomerID")]
    public int? CustomerId { get; set; }

    [Column("HotelID")]
    public int? HotelId { get; set; }

    [Column("Reservation_start")]
    public DateOnly? ReservationStart { get; set; }

    [Column("Reservation_end")]
    public DateOnly? ReservationEnd { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Checkin { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Checkout { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Reservations")]
    public virtual Person? Customer { get; set; }

    [InverseProperty("Reservation")]
    public virtual ICollection<DayView> DayViews { get; set; } = new List<DayView>();

    [ForeignKey("HotelId")]
    [InverseProperty("Reservations")]
    public virtual Hotel? Hotel { get; set; }
}
