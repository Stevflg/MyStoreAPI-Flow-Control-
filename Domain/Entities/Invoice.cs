using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Invoice
{
    public string Id { get; set; } = null!;

    public int InvoiceId { get; set; }

    public string? EmployeeId { get; set; }

    public string? CustomerId { get; set; }

    public bool? PreInvoicing { get; set; }

    public bool? State { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedOn { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Invoicedetail> Invoicedetails { get; } = new List<Invoicedetail>();
}
