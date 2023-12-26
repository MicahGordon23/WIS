using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WIS_PrototypeAPI.Data.Models;

[Table("district")]
public partial class District
{
    [Key]
    [Column("district_id")]
    public int DistrictId { get; set; }

    [Column("district_name")]
    [StringLength(50)]
    public string DistrictName { get; set; } = null!;

    [InverseProperty("DistrictIdLinkNavigation")]
    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
