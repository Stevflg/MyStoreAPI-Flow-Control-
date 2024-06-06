using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class User
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? EmployeeId { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public DateTime? Locked { get; set; }
    public int? Counter { get; set; }

    public bool? ChangePassword { get; set; }

    public bool? State { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedOn { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Userrol> Userrols { get; } = new List<Userrol>();
}
