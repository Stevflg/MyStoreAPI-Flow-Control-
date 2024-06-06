using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Price
{
    public string Id { get; set; } = null!;

    public decimal Price1 { get; set; }

    public decimal? DiscountPrice { get; set; }

    public decimal? PromotionPrice { get; set; }

    public bool? State { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedOn { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
