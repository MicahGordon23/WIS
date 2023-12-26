using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WIS_PrototypeAPI.Data.Models;

[Table("commodity_variety")]
public partial class CommodityVariety
{
    [Key]
    [Column("commodity_variety_id")]
    public long CommodityVarietyId { get; set; }

    [Column("commodity_type_id_link")]
    public int CommodityTypeIdLink { get; set; }

    [Column("commodity_variety_name")]
    [StringLength(75)]
    public string? CommodityVarietyName { get; set; }

    [ForeignKey("CommodityTypeIdLink")]
    [InverseProperty("CommodityVarieties")]
    public virtual CommodityType CommodityTypeIdLinkNavigation { get; set; } = null!;

    [InverseProperty("CommodityVerityIdLinkNavigation")]
    public virtual ICollection<Weightsheet> Weightsheets { get; set; } = new List<Weightsheet>();
}
