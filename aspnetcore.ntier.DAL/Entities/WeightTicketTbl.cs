using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.BLL;

public partial class WeightTicketTbl
{
    public decimal WTicketId { get; set; }

    public string? WTicketName { get; set; }

    public int? WTicketStart { get; set; }

    public int? WTicketEnd { get; set; }

    public decimal? WTicketPrice { get; set; }

    public bool? WTicketState { get; set; }

    public decimal? SiteId { get; set; }

    public virtual SiteTbl? Site { get; set; }
}
