using System;
using System.Collections.Generic;

namespace DAT14Oblig4V5.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleDesctription { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
