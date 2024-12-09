using System;
using System.Collections.Generic;
using aspnetcore.ntier.DAL.Entities;

namespace aspnetcore.ntier.DAL.Entities;

public partial class WeightTbl
{
    public decimal WId { get; set; }

    public decimal? SeqNo { get; set; }

    public DateOnly? InDate { get; set; }

    public TimeOnly? InTime { get; set; }

    public decimal? WClassId { get; set; }

    public int? ClassWeight { get; set; }

    public int? TruckWeight { get; set; }

    public int? DiffWeight { get; set; }

    public decimal? VioPrice { get; set; }

    public int? VioWeight { get; set; }

    public string? TruckNum { get; set; }

    public decimal? NationId { get; set; }

    public decimal? ProductId { get; set; }

    public decimal? DriverId { get; set; }

    public bool? Printed { get; set; }

    public bool? Transed { get; set; }

    public string? WeightS { get; set; }

    public bool? WeightLocation { get; set; }

    public string? WeightNote { get; set; }

    public bool? WeightState { get; set; }

    public decimal? UserId { get; set; }

    public decimal? SiteId { get; set; }

    public virtual DriversTbl? Driver { get; set; }

    public virtual NationTbl? Nation { get; set; }

    public virtual TrucksTbl? TruckNumNavigation { get; set; }
}
