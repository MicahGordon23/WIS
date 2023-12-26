using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WIS_PrototypeAPI.Data.Models;

[Table("producer")]
public partial class Producer
{
    [Key]
    [Column("producer_id")]
    public int ProducerId { get; set; }

    [Column("producer_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ProducerName { get; set; }

    [InverseProperty("ProducerIdLinkNavigation")]
    public virtual ICollection<Lot> Lots { get; set; } = new List<Lot>();

    [InverseProperty("ProducerIdLinkNavigation")]
    public virtual ICollection<Weightsheet> Weightsheets { get; set; } = new List<Weightsheet>();
}
