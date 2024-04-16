using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppFrontDesk.Models;

[Table("role")]
public partial class Role
{
    [Key]
    [Column("roleID")]
    public int RoleId { get; set; }

    [Column("role_Desctription")]
    [StringLength(10)]
    [Unicode(false)]
    public string RoleDesctription { get; set; } = null!;

    [InverseProperty("RoleNavigation")]
    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
