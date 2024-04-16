using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppFrontDesk.Models;

[Table("bed_options")]
public partial class BedOption
{
    [Key]
    [Column("bed_optionsID")]
    public int BedOptionsId { get; set; }

    [Column("bed_options_Desctription")]
    [StringLength(100)]
    [Unicode(false)]
    public string? BedOptionsDesctription { get; set; }

    [InverseProperty("BedOptionNavigation")]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
