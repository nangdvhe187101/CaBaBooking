using System;
using System.Collections.Generic;

namespace CatBaBooking.Models;

public partial class TableAvailability
{
    public long AvailabilityId { get; set; }

    public int TableId { get; set; }

    public int SessionId { get; set; }

    public DateOnly Date { get; set; }

    public string Status { get; set; } = null!;

    public int? BookingId { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual DiningSession Session { get; set; } = null!;

    public virtual RestaurantTable Table { get; set; } = null!;
}
