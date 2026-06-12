using System;
using System.Collections.Generic;

namespace CatBaBooking.Models;

public partial class DiningSession
{
    public int SessionId { get; set; }

    public int BusinessId { get; set; }

    public string Name { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public bool IsActive { get; set; }

    public virtual Business Business { get; set; } = null!;

    public virtual ICollection<TableAvailability> TableAvailabilities { get; set; } = new List<TableAvailability>();
}
