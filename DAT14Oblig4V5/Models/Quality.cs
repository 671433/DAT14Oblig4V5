using System;
using System.Collections.Generic;

namespace DAT14Oblig4V5.Models;

public partial class Quality
{
    public int QualityId { get; set; }

    public string QualityDesctription { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
