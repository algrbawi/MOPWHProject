using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.DAL.Entities;

public partial class ProductsTbl
{
    public decimal ProductId { get; set; }

    public decimal? ProductCode { get; set; }

    public string? ProductName { get; set; }

    public string? ProductLocation { get; set; }

    public bool? ProductState { get; set; }

    public decimal? SiteId { get; set; }

    public virtual SiteTbl? Site { get; set; }
}
