using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppFrontDesk.Models;

[Table("room_request_enum")]
public partial class RoomRequestEnum
{
    [Key]
    [Column("room_request_enumID")]
    public int RoomRequestEnumId { get; set; }

    [Column("room_request_enum_description")]
    [StringLength(100)]
    [Unicode(false)]
    public string? RoomRequestEnumDescription { get; set; }

    [InverseProperty("CleaningStatusNavigation")]
    public virtual ICollection<DayView> DayViewCleaningStatusNavigations { get; set; } = new List<DayView>();

    [InverseProperty("MaintenanceStatusNavigation")]
    public virtual ICollection<DayView> DayViewMaintenanceStatusNavigations { get; set; } = new List<DayView>();

    [InverseProperty("ServiceStatusNavigation")]
    public virtual ICollection<DayView> DayViewServiceStatusNavigations { get; set; } = new List<DayView>();
}
