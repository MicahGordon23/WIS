using System;
using System.Collections.Generic;

namespace WIS_PrototypeAPI.Data.Models;

public partial class District
{
    public int DistrictId { get; set; }

    public string DistrictName { get; set; } = null!;

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
