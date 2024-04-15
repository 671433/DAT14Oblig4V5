using System;
using System.Collections.Generic;

namespace DAT14Oblig4V5.Models;

public partial class RoomStatus
{
    public int RoomStatusId { get; set; }

    public string? RoomStatusDescription { get; set; }

    public virtual ICollection<DayView> DayViews { get; set; } = new List<DayView>();
}
