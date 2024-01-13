using System;
using System.Collections.Generic;

namespace WIS_PrototypeAPI.Data.Models;

public partial class CommodityType
{
    public int CommodityTypeId { get; set; }

    public string? CommodityTypeName { get; set; }

    public virtual ICollection<Bin> Bins { get; set; } = new List<Bin>();

    public virtual ICollection<CommodityVariety> CommodityVarieties { get; set; } = new List<CommodityVariety>();

    public virtual ICollection<Weightsheet> Weightsheets { get; set; } = new List<Weightsheet>();
}
