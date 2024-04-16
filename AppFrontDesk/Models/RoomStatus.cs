using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppFrontDesk.Models;

[Table("room_status")]
public partial class RoomStatus
{
    [Key]
    [Column("room_statusID")]
    public int RoomStatusId { get; set; }

    [Column("room_status_description")]
    [StringLength(100)]
    [Unicode(false)]
    public string? RoomStatusDescription { get; set; }

    [InverseProperty("RoomStatusNavigation")]
    public virtual ICollection<DayView> DayViews { get; set; } = new List<DayView>();
}
