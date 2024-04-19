using System;
using System.Collections.Generic;

namespace DAT14Oblig4V5.Models;

public partial class Person
{
    public string PersonId { get; set; }

    public string Surname { get; set; } = null!;

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public int? Phone { get; set; }

    public string Password { get; set; } = null!;

    public int? Role { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual Role? RoleNavigation { get; set; }

    public virtual ICollection<RoomRequestNote> RoomRequestNotes { get; set; } = new List<RoomRequestNote>();
}
