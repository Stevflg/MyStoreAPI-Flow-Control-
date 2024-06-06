using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Invoicedetail
{
    public string Id { get; set; } = null!;

    public string? InvoiceId { get; set; }

    public string? ProductId { get; set; }

    public int Units { get; set; }

    public decimal Price { get; set; }

    public decimal? Iva { get; set; }

    public bool? State { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedOn { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Invoice? Invoice { get; set; }

    public virtual Product? Product { get; set; }
}
