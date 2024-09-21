using System;
using System.Collections.Generic;

namespace DML_BikeStore.Models;

public partial class ProductAudit
{
    public int ChangeId { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int BrandId { get; set; }

    public int CategoryId { get; set; }

    public short ModelYear { get; set; }

    public decimal ListPrice { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Operation { get; set; } = null!;
}
