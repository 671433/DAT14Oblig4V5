using System;
using System.Collections.Generic;

namespace DAT14Oblig4V5.Models;

public partial class BedOption
{
    public int BedOptionsId { get; set; }

    public string? BedOptionsDesctription { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
