using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppFrontDesk.Models;

[Table("quality")]
public partial class Quality
{
    [Key]
    [Column("qualityID")]
    public int QualityId { get; set; }

    [Column("qualityDesctription")]
    [StringLength(10)]
    [Unicode(false)]
    public string QualityDesctription { get; set; } = null!;

    [InverseProperty("QualityNavigation")]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
