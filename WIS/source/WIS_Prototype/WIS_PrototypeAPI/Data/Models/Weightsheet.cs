using System;
using System.Collections.Generic;

namespace WIS_PrototypeAPI.Data.Models;

public partial class Weightsheet
{
    public long WeightsheetId { get; set; }

    public int WarehouseIdLink { get; set; }

    public int? ProducerIdLink { get; set; }

    public int? SourceIdLink { get; set; }

    public int CommodityTypeIdLink { get; set; }

    public long? CommodityVerityIdLink { get; set; }

    public DateTime? OpenDate { get; set; }

    public string? WeighterName { get; set; }

    public string? HaulerName { get; set; }

    public short? Miles { get; set; }

    public short? Bill { get; set; }

    public string? Notes { get; set; }

    public long? LotIdLink { get; set; }

    public virtual CommodityType CommodityTypeIdLinkNavigation { get; set; } = null!;

    public virtual CommodityVariety? CommodityVerityIdLinkNavigation { get; set; }

    public virtual ICollection<Load> Loads { get; set; } = new List<Load>();

    public virtual Lot? LotIdLinkNavigation { get; set; }

    public virtual Producer? ProducerIdLinkNavigation { get; set; }

    public virtual Warehouse? SourceIdLinkNavigation { get; set; }

    public virtual Warehouse WarehouseIdLinkNavigation { get; set; } = null!;
}
