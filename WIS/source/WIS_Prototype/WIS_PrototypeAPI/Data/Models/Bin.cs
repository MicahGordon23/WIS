using System;
using System.Collections.Generic;

namespace WIS_PrototypeAPI.Data.Models;

public partial class Bin
{
    public long BinId { get; set; }

    public int WarehouseIdLink { get; set; }

    public int CommodityTypeIdLink { get; set; }

    public string? BinName { get; set; }

    public int? CommodityVerityIdLink { get; set; }

    public long? NetIntake { get; set; }

    public virtual CommodityType CommodityTypeIdLinkNavigation { get; set; } = null!;

    public virtual Warehouse WarehouseIdLinkNavigation { get; set; } = null!;
}
