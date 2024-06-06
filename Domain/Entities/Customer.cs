using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Customer
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Identification { get; set; }

    public string Address { get; set; } = null!;

    public DateTime DateBirth { get; set; }

    public string? Email {  get; set; }

    public bool? State { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedOn { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();
}
