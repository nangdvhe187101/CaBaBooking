using System;
using System.Collections.Generic;

namespace CatBaBooking.Models;

public partial class RestaurantDetail
{
    public int BusinessId { get; set; }

    public TimeOnly? OpeningHour { get; set; }

    public TimeOnly? ClosingHour { get; set; }

    public int? SeatingCapacity { get; set; }

    public virtual Business Business { get; set; } = null!;
}
