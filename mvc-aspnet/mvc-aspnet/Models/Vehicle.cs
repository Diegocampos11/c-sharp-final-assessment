using System;
using System.Collections.Generic;

namespace mvc_aspnet.Models;

public partial class Vehicle
{
    public int Id { get; set; }

    public string? Brand { get; set; }

    public string? Vin { get; set; }

    public string? Color { get; set; }

    public string? Year { get; set; }

    public int? OwnerId { get; set; }

    public virtual ICollection<Claim> Claims { get; } = new List<Claim>();

    public virtual Owner? Owner { get; set; }
}
