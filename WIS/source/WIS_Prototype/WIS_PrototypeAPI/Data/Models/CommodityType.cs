using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WIS_PrototypeAPI.Data.Models;

[Table("commodity_type")]
public partial class CommodityType
{
    [Key]
    [Column("commodity_type_id")]
    public int CommodityTypeId { get; set; }

    [Column("commodity_type_name")]
    [StringLength(75)]
    public string? CommodityTypeName { get; set; }

    [InverseProperty("CommodityTypeIdLinkNavigation")]
    public virtual ICollection<Bin> Bins { get; set; } = new List<Bin>();

    [InverseProperty("CommodityTypeIdLinkNavigation")]
    public virtual ICollection<CommodityVariety> CommodityVarieties { get; set; } = new List<CommodityVariety>();

    [InverseProperty("CommodityTypeIdLinkNavigation")]
    public virtual ICollection<Weightsheet> Weightsheets { get; set; } = new List<Weightsheet>();
}
