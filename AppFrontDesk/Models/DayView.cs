using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppFrontDesk.Models;

[Table("Day_view")]
public partial class DayView
{
    [Key]
    [Column("Day_viewID")]
    public int DayViewId { get; set; }

    [Column("date")]
    public DateOnly? Date { get; set; }

    [Column("ReservationID")]
    public int? ReservationId { get; set; }

    [Column("Room_service")]
    public bool? RoomService { get; set; }

    [Column("Room_status")]
    public int? RoomStatus { get; set; }

    [Column("Cleaning_status")]
    public int? CleaningStatus { get; set; }

    [Column("Service_status")]
    public int? ServiceStatus { get; set; }

    [Column("Maintenance_status")]
    public int? MaintenanceStatus { get; set; }

    [Column("Room_nr")]
    public int? RoomNr { get; set; }

    [ForeignKey("CleaningStatus")]
    [InverseProperty("DayViewCleaningStatusNavigations")]
    public virtual RoomRequestEnum? CleaningStatusNavigation { get; set; }

    [ForeignKey("MaintenanceStatus")]
    [InverseProperty("DayViewMaintenanceStatusNavigations")]
    public virtual RoomRequestEnum? MaintenanceStatusNavigation { get; set; }

    [ForeignKey("ReservationId")]
    [InverseProperty("DayViews")]
    public virtual Reservation? Reservation { get; set; }

    [ForeignKey("RoomNr")]
    [InverseProperty("DayViews")]
    public virtual Room? RoomNrNavigation { get; set; }

    [InverseProperty("DayViewNavigation")]
    public virtual ICollection<RoomRequestNote> RoomRequestNotes { get; set; } = new List<RoomRequestNote>();

    [ForeignKey("RoomStatus")]
    [InverseProperty("DayViews")]
    public virtual RoomStatus? RoomStatusNavigation { get; set; }

    [ForeignKey("ServiceStatus")]
    [InverseProperty("DayViewServiceStatusNavigations")]
    public virtual RoomRequestEnum? ServiceStatusNavigation { get; set; }
}
