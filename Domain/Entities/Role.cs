using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Role
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool? State { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedOn { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Rolscreenui> Rolscreenuis { get; } = new List<Rolscreenui>();

    public virtual ICollection<Userrol> Userrols { get; } = new List<Userrol>();
}
