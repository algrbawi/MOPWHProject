using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.BLL;

public partial class PicturesTbl
{
    public decimal PicId { get; set; }

    public DateOnly? PicDate { get; set; }

    public TimeOnly? PicTime { get; set; }

    public string? PicCamera { get; set; }

    public bool? PicState { get; set; }

    public string? PicImage { get; set; }

    public string? PicTruckId { get; set; }

    public decimal? SiteId { get; set; }

    public virtual SiteTbl? Site { get; set; }
}
