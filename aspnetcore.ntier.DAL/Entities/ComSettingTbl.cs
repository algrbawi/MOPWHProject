using System;
using System.Collections.Generic;

namespace aspnetcore.ntier.BLL;

public partial class ComSettingTbl
{
    public decimal ComId { get; set; }

    public string? ComName { get; set; }

    public int? Bps { get; set; }

    public int? Db { get; set; }

    public string? Parity { get; set; }

    public int? Sb { get; set; }

    public string? Hdsh { get; set; }

    public string? Sstart { get; set; }

    public string? Send { get; set; }

    public decimal SiteId { get; set; }

    public virtual SiteTbl Site { get; set; } = null!;
}
