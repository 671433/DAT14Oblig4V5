using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace DAT14Oblig4V5.Models;

public class AvailableRooms
{
    //fra Reservations
    public int ReservationId { get; set; }

    public int? CustomerId { get; set; }

    public int? HotelId { get; set; }

    public DateOnly? ReservationStart { get; set; }

    public DateOnly? ReservationEnd { get; set; }

    public virtual Person? Customer { get; set; }

    public virtual Hotel? Hotel { get; set; }
    public int? RoomNr { get; set; }

    public virtual Room? RoomNrNavigation { get; set; } = null!;

    //fra Rooms


    public int BedOption { get; set; }

    public int RoomSize { get; set; }

    public int Quality { get; set; }

    public virtual BedOption BedOptionNavigation { get; set; } = null!;



    public virtual Quality QualityNavigation { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new Collection<Room>();

    



}

