using System;
using System.Collections.Generic;

namespace DAT14Oblig4V5.Models;

public partial class RoomRequestNote
{
    public int RoomRequestId { get; set; }

    public int? DayView { get; set; }

    public int? PersonId { get; set; }

    public DateTime? New { get; set; }

    public DateTime? InProgress { get; set; }

    public DateTime? Finished { get; set; }

    public string? RoomRequestComment { get; set; }

    public virtual DayView? DayViewNavigation { get; set; }

    public virtual Person? Person { get; set; }
}
