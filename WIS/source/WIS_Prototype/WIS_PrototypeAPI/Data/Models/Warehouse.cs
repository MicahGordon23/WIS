using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WIS_PrototypeAPI.Data.Models;

[Table("warehouse")]
public partial class Warehouse
{
    [Key]
    [Column("warehouse_id")]
    public int WarehouseId { get; set; }

    [Column("district_id_link")]
    public int DistrictIdLink { get; set; }

    [Column("warehouse_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string WarehouseName { get; set; } = null!;

    [InverseProperty("WarehouseIdLinkNavigation")]
    public virtual ICollection<Bin> Bins { get; set; } = new List<Bin>();

    [ForeignKey("DistrictIdLink")]
    [InverseProperty("Warehouses")]
    public virtual District DistrictIdLinkNavigation { get; set; } = null!;

    [InverseProperty("SourceIdLinkNavigation")]
    public virtual ICollection<Weightsheet> WeightsheetSourceIdLinkNavigations { get; set; } = new List<Weightsheet>();

    [InverseProperty("WarehouseIdLinkNavigation")]
    public virtual ICollection<Weightsheet> WeightsheetWarehouseIdLinkNavigations { get; set; } = new List<Weightsheet>();
}
