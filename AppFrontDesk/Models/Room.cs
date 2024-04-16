using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppFrontDesk.Models;

[Table("Room")]
public partial class Room
{
    [Key]
    [Column("Room_nr")]
    public int RoomNr { get; set; }

    [Column("Bed_option")]
    public int BedOption { get; set; }

    [Column("Room_size")]
    public int RoomSize { get; set; }

    public int Quality { get; set; }

    [Column("HotelID")]
    public int? HotelId { get; set; }

    [ForeignKey("BedOption")]
    [InverseProperty("Rooms")]
    public virtual BedOption BedOptionNavigation { get; set; } = null!;

    [InverseProperty("RoomNrNavigation")]
    public virtual ICollection<DayView> DayViews { get; set; } = new List<DayView>();

    [ForeignKey("HotelId")]
    [InverseProperty("Rooms")]
    public virtual Hotel? Hotel { get; set; }

    [ForeignKey("Quality")]
    [InverseProperty("Rooms")]
    public virtual Quality QualityNavigation { get; set; } = null!;
}
