using System;
using System.Collections.Generic;

namespace WIS_PrototypeAPI.Data.Models;

public partial class CommodityVariety
{
    public long CommodityVarietyId { get; set; }

    public int CommodityTypeIdLink { get; set; }

    public string? CommodityVarietyName { get; set; }

    public virtual CommodityType CommodityTypeIdLinkNavigation { get; set; } = null!;

    public virtual ICollection<Weightsheet> Weightsheets { get; set; } = new List<Weightsheet>();
}
