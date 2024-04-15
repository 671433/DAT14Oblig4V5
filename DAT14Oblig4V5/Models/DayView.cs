using System;
using System.Collections.Generic;

namespace DAT14Oblig4V5.Models;

public partial class DayView
{
    public int DayViewId { get; set; }

    public DateOnly? Date { get; set; }

    public int? ReservationId { get; set; }

    public bool? RoomService { get; set; }

    public int? RoomStatus { get; set; }

    public int? CleaningStatus { get; set; }

    public int? ServiceStatus { get; set; }

    public int? MaintenanceStatus { get; set; }

    public int? RoomNr { get; set; }

    public virtual RoomRequestEnum? CleaningStatusNavigation { get; set; }

    public virtual RoomRequestEnum? MaintenanceStatusNavigation { get; set; }

    public virtual Reservation? Reservation { get; set; }

    public virtual Room? RoomNrNavigation { get; set; }

    public virtual ICollection<RoomRequestNote> RoomRequestNotes { get; set; } = new List<RoomRequestNote>();

    public virtual RoomStatus? RoomStatusNavigation { get; set; }

    public virtual RoomRequestEnum? ServiceStatusNavigation { get; set; }
}
