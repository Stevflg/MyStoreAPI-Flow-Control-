using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Product
{
    public string Id { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public string? UrlImage { get; set; }

    public string Name { get; set; } = null!;

    public string? Units { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public bool? State { get; set; }

    public string? Price { get; set; }

    public string? Type { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedOn { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Invoicedetail> Invoicedetails { get; } = new List<Invoicedetail>();

    public virtual Price? PriceNavigation { get; set; }

    public virtual Producttype? TypeNavigation { get; set; }
}
