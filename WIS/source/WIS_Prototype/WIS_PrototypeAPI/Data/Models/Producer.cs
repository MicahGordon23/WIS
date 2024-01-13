using System;
using System.Collections.Generic;

namespace WIS_PrototypeAPI.Data.Models;

public partial class Producer
{
    public int ProducerId { get; set; }

    public string? ProducerName { get; set; }

    public virtual ICollection<Lot> Lots { get; set; } = new List<Lot>();

    public virtual ICollection<Weightsheet> Weightsheets { get; set; } = new List<Weightsheet>();
}
