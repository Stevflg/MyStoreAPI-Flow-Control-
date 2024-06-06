using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Userrol
{
    public string UserId { get; set; } = null!;

    public string RolId { get; set; } = null!;

    public bool? State { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedOn { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Role Rol { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
