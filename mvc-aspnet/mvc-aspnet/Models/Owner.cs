using System;
using System.Collections.Generic;

namespace mvc_aspnet.Models;

public partial class Owner
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? DriverLicense { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
}
