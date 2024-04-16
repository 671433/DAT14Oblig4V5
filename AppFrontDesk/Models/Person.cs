using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppFrontDesk.Models;

[Table("Person")]
public partial class Person
{
    [Key]
    [Column("PersonID")]
    public int PersonId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Surname { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Lastname { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Email { get; set; }

    public int? Phone { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    public int? Role { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    [ForeignKey("Role")]
    [InverseProperty("People")]
    public virtual Role? RoleNavigation { get; set; }

    [InverseProperty("Person")]
    public virtual ICollection<RoomRequestNote> RoomRequestNotes { get; set; } = new List<RoomRequestNote>();
}
