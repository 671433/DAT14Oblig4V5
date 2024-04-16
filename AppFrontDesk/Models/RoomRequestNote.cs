using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppFrontDesk.Models;

[Table("room_request_notes")]
public partial class RoomRequestNote
{
    [Key]
    [Column("Room_requestID")]
    public int RoomRequestId { get; set; }

    public int? DayView { get; set; }

    [Column("PersonID")]
    public int? PersonId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? New { get; set; }

    [Column("In_progress", TypeName = "datetime")]
    public DateTime? InProgress { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Finished { get; set; }

    [Column("Room_request_comment")]
    [StringLength(400)]
    [Unicode(false)]
    public string? RoomRequestComment { get; set; }

    [ForeignKey("DayView")]
    [InverseProperty("RoomRequestNotes")]
    public virtual DayView? DayViewNavigation { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("RoomRequestNotes")]
    public virtual Person? Person { get; set; }
}
