using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.BLL;

public partial class WeightClassTbl
{
    public decimal WClassId { get; set; }

    public decimal? WClassCode { get; set; }

    public string? WClassName { get; set; }

    public int? WClassAxles { get; set; }

    public int? WClassWeight { get; set; }

    public bool? WClassState { get; set; }

    public string? WClassImage { get; set; }

    public decimal? SiteId { get; set; }

    public virtual SiteTbl? Site { get; set; }

    public virtual ICollection<WeightTbl> WeightTbls { get; set; } = new List<WeightTbl>();
}
