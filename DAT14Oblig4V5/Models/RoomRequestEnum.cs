using System;
using System.Collections.Generic;

namespace DAT14Oblig4V5.Models;

public partial class RoomRequestEnum
{
    public int RoomRequestEnumId { get; set; }

    public string? RoomRequestEnumDescription { get; set; }

    public virtual ICollection<DayView> DayViewCleaningStatusNavigations { get; set; } = new List<DayView>();

    public virtual ICollection<DayView> DayViewMaintenanceStatusNavigations { get; set; } = new List<DayView>();

    public virtual ICollection<DayView> DayViewServiceStatusNavigations { get; set; } = new List<DayView>();
}
