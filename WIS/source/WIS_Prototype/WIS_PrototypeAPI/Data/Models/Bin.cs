using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WIS_PrototypeAPI.Data.Models;

[Table("bin")]
public partial class Bin
{
    [Key]
    [Column("bin_id")]
    public long BinId { get; set; }

    [Column("warehouse_id_link")]
    public int WarehouseIdLink { get; set; }

    [Column("commodity_type_id_link")]
    public int CommodityTypeIdLink { get; set; }

    [Column("bin_name")]
    [StringLength(20)]
    public string? BinName { get; set; }

    [Column("commodity_verity_id_link")]
    public int? CommodityVerityIdLink { get; set; }

    [Column("net_intake")]
    public long? NetIntake { get; set; }

    [ForeignKey("CommodityTypeIdLink")]
    [InverseProperty("Bins")]
    public virtual CommodityType CommodityTypeIdLinkNavigation { get; set; } = null!;

    [ForeignKey("WarehouseIdLink")]
    [InverseProperty("Bins")]
    public virtual Warehouse WarehouseIdLinkNavigation { get; set; } = null!;
}
