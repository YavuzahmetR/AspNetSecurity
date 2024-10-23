using System;
using System.Collections.Generic;

namespace DataProtection.Web.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Stock { get; set; }

    public decimal? Price { get; set; }
}
