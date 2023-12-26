using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WIS_PrototypeAPI.Data.Models;

[Table("weightsheet")]
public partial class Weightsheet
{
    [Key]
    [Column("weightsheet_id")]
    public long WeightsheetId { get; set; }

    [Column("warehouse_id_link")]
    public int WarehouseIdLink { get; set; }

    [Column("producer_id_link")]
    public int? ProducerIdLink { get; set; }

    [Column("source_id_link")]
    public int? SourceIdLink { get; set; }

    [Column("commodity_type_id_link")]
    public int CommodityTypeIdLink { get; set; }

    [Column("commodity_verity_id_link")]
    public long? CommodityVerityIdLink { get; set; }

    [Column("open_date", TypeName = "date")]
    public DateTime? OpenDate { get; set; }

    [Column("weighter_name")]
    [StringLength(50)]
    public string? WeighterName { get; set; }

    [Column("hauler_name")]
    [StringLength(50)]
    public string? HaulerName { get; set; }

    [Column("miles")]
    public short? Miles { get; set; }

    [Column("bill")]
    public short? Bill { get; set; }

    [Column("notes")]
    [StringLength(250)]
    public string? Notes { get; set; }

    [ForeignKey("CommodityTypeIdLink")]
    [InverseProperty("Weightsheets")]
    public virtual CommodityType CommodityTypeIdLinkNavigation { get; set; } = null!;

    [ForeignKey("CommodityVerityIdLink")]
    [InverseProperty("Weightsheets")]
    public virtual CommodityVariety? CommodityVerityIdLinkNavigation { get; set; }

    [InverseProperty("WeightsheetIdLinkNavigation")]
    public virtual ICollection<Load> Loads { get; set; } = new List<Load>();

    [ForeignKey("ProducerIdLink")]
    [InverseProperty("Weightsheets")]
    public virtual Producer? ProducerIdLinkNavigation { get; set; }

    [ForeignKey("SourceIdLink")]
    [InverseProperty("WeightsheetSourceIdLinkNavigations")]
    public virtual Warehouse? SourceIdLinkNavigation { get; set; }

    [ForeignKey("WarehouseIdLink")]
    [InverseProperty("WeightsheetWarehouseIdLinkNavigations")]
    public virtual Warehouse WarehouseIdLinkNavigation { get; set; } = null!;
}
