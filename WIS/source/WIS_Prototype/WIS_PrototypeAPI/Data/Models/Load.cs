using System;
using System.Collections.Generic;

namespace WIS_PrototypeAPI.Data.Models;

public partial class Load
{
    public long LoadId { get; set; }

    public long WeightsheetIdLink { get; set; }

    public int? GrossWeight { get; set; }

    public int? TareWeight { get; set; }

    public int? NetWeight { get; set; }

    public string? TruckId { get; set; }

    public DateTime? TimeIn { get; set; }

    public DateTime? TimeOut { get; set; }

    public int? BolNumber { get; set; }

    public string? DestBin { get; set; }

    public float? MoisturePercent { get; set; }

    public float? TestWeight { get; set; }

    public float? ProteinPercent { get; set; }

    public string? Notes { get; set; }

    public virtual Weightsheet WeightsheetIdLinkNavigation { get; set; } = null!;
}
