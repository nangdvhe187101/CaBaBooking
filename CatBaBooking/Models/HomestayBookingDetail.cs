using System;
using System.Collections.Generic;

namespace CatBaBooking.Models;

public partial class HomestayBookingDetail
{
    public int BookingId { get; set; }

    public DateTime ReservationStartTime { get; set; }

    public DateTime ReservationEndTime { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
