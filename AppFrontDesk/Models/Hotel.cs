using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppFrontDesk.Models;

public partial class Hotel
{
    [Key]
    [Column("HotelID")]
    public int HotelId { get; set; }

    [Column("Hotel_name")]
    [StringLength(30)]
    [Unicode(false)]
    public string HotelName { get; set; } = null!;

    [Column("Hotel_Adress")]
    [StringLength(100)]
    [Unicode(false)]
    public string HotelAdress { get; set; } = null!;

    [InverseProperty("Hotel")]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    [InverseProperty("Hotel")]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
