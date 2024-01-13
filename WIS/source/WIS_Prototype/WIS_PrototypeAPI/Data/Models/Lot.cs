using System;
using System.Collections.Generic;

namespace WIS_PrototypeAPI.Data.Models;

public partial class Lot
{
    public long LotId { get; set; }

    public int ProducerIdLink { get; set; }

    public string? StateId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Landlord { get; set; }

    public string? FarmNumber { get; set; }

    public string? TruckId { get; set; }

    public string? Notes { get; set; }

    public virtual Producer ProducerIdLinkNavigation { get; set; } = null!;

    public virtual ICollection<Weightsheet> Weightsheets { get; set; } = new List<Weightsheet>();
}
