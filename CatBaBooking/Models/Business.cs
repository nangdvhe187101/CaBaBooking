using System;
using System.Collections.Generic;

namespace CatBaBooking.Models;

public partial class Business
{
    public int BusinessId { get; set; }

    public int OwnerId { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Image { get; set; }

    public int? AreaId { get; set; }

    public decimal? AvgRating { get; set; }

    public int? ReviewCount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Area? Area { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<DiningSession> DiningSessions { get; set; } = new List<DiningSession>();

    public virtual ICollection<DishCategory> DishCategories { get; set; } = new List<DishCategory>();

    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();

    public virtual HomestayDetail? HomestayDetail { get; set; }

    public virtual User Owner { get; set; } = null!;

    public virtual RestaurantDetail? RestaurantDetail { get; set; }

    public virtual ICollection<RestaurantTable> RestaurantTables { get; set; } = new List<RestaurantTable>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<TempCart> TempCarts { get; set; } = new List<TempCart>();

    public virtual ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();

    public virtual ICollection<CuisineType> Cuisines { get; set; } = new List<CuisineType>();

    public virtual ICollection<Occasion> Occasions { get; set; } = new List<Occasion>();

    public virtual ICollection<RestaurantType> Types { get; set; } = new List<RestaurantType>();
}
