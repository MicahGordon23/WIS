using System;
using System.Collections.Generic;

namespace WIS_PrototypeAPI.Data.Models;

public partial class Warehouse
{
    public int WarehouseId { get; set; }

    public int DistrictIdLink { get; set; }

    public string WarehouseName { get; set; } = null!;

    public virtual ICollection<Bin> Bins { get; set; } = new List<Bin>();

    public virtual District DistrictIdLinkNavigation { get; set; } = null!;

    public virtual ICollection<Weightsheet> WeightsheetSourceIdLinkNavigations { get; set; } = new List<Weightsheet>();

    public virtual ICollection<Weightsheet> WeightsheetWarehouseIdLinkNavigations { get; set; } = new List<Weightsheet>();
}
