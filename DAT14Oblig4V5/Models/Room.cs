using System;
using System.Collections.Generic;

namespace DAT14Oblig4V5.Models;

public partial class Room
{
    public int RoomNr { get; set; }

    public int BedOption { get; set; }

    public int RoomSize { get; set; }

    public int Quality { get; set; }

    public int? HotelId { get; set; }

    public virtual BedOption BedOptionNavigation { get; set; } = null!;

    public virtual ICollection<DayView> DayViews { get; set; } = new List<DayView>();

    public virtual Hotel? Hotel { get; set; }

    public virtual Quality QualityNavigation { get; set; } = null!;
}
