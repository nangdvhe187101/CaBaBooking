using System;
using System.Collections.Generic;

namespace CatBaBooking.Models;

public partial class HomestayDetail
{
    public int BusinessId { get; set; }

    public int? NumBedrooms { get; set; }

    public int? GuestCapacity { get; set; }

    public decimal? PricePerNight { get; set; }

    public virtual Business Business { get; set; } = null!;
}
