using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WIS_PrototypeAPI.Data.Models;

[Table("lot")]
public partial class Lot
{
    [Key]
    [Column("lot_id")]
    public long LotId { get; set; }

    [Column("producer_id_link")]
    public int ProducerIdLink { get; set; }

    [Column("state_id")]
    [StringLength(3)]
    public string? StateId { get; set; }

    [Column("start_date", TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column("end_date", TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    [Column("landlord")]
    [StringLength(25)]
    public string? Landlord { get; set; }

    [Column("farm_number")]
    [StringLength(20)]
    public string? FarmNumber { get; set; }

    [Column("truck_id")]
    [StringLength(25)]
    public string? TruckId { get; set; }

    [Column("notes")]
    [StringLength(250)]
    public string? Notes { get; set; }

    [ForeignKey("ProducerIdLink")]
    [InverseProperty("Lots")]
    public virtual Producer ProducerIdLinkNavigation { get; set; } = null!;
}
