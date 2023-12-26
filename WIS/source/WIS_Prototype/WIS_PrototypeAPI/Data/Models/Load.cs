using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WIS_PrototypeAPI.Data.Models;

[Table("load")]
public partial class Load
{
    [Key]
    [Column("load_id")]
    public long LoadId { get; set; }

    [Column("weightsheet_id_link")]
    public long WeightsheetIdLink { get; set; }

    [Column("gross_weight")]
    public int? GrossWeight { get; set; }

    [Column("tare_weight")]
    public int? TareWeight { get; set; }

    [Column("net_weight")]
    public int? NetWeight { get; set; }

    [Column("truck_id")]
    [StringLength(25)]
    public string? TruckId { get; set; }

    [Column("time_in", TypeName = "datetime")]
    public DateTime? TimeIn { get; set; }

    [Column("time_out", TypeName = "datetime")]
    public DateTime? TimeOut { get; set; }

    [Column("bol_number")]
    public int? BolNumber { get; set; }

    [Column("dest_bin")]
    [StringLength(20)]
    public string? DestBin { get; set; }

    [Column("moisture_percent")]
    public float? MoisturePercent { get; set; }

    [Column("test_weight")]
    public float? TestWeight { get; set; }

    [Column("protein_percent")]
    public float? ProteinPercent { get; set; }

    [Column("notes")]
    [StringLength(250)]
    public string? Notes { get; set; }

    [ForeignKey("WeightsheetIdLink")]
    [InverseProperty("Loads")]
    public virtual Weightsheet WeightsheetIdLinkNavigation { get; set; } = null!;
}
