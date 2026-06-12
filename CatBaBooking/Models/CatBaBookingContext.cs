using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CatBaBooking.Models;

public partial class CatBaBookingContext : DbContext
{
    public CatBaBookingContext()
    {
    }

    public CatBaBookingContext(DbContextOptions<CatBaBookingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Amenity> Amenities { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<BookedRoom> BookedRooms { get; set; }

    public virtual DbSet<BookedTable> BookedTables { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingDish> BookingDishes { get; set; }

    public virtual DbSet<Business> Businesses { get; set; }

    public virtual DbSet<CuisineType> CuisineTypes { get; set; }

    public virtual DbSet<DiningSession> DiningSessions { get; set; }

    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<DishCategory> DishCategories { get; set; }

    public virtual DbSet<Feature> Features { get; set; }

    public virtual DbSet<HomestayBookingDetail> HomestayBookingDetails { get; set; }

    public virtual DbSet<HomestayDetail> HomestayDetails { get; set; }

    public virtual DbSet<Occasion> Occasions { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<RestaurantDetail> RestaurantDetails { get; set; }

    public virtual DbSet<RestaurantTable> RestaurantTables { get; set; }

    public virtual DbSet<RestaurantType> RestaurantTypes { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomAvailability> RoomAvailabilities { get; set; }

    public virtual DbSet<RoomImage> RoomImages { get; set; }

    public virtual DbSet<TableAvailability> TableAvailabilities { get; set; }

    public virtual DbSet<TempCart> TempCarts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.HasKey(e => e.AmenityId).HasName("PK__amenitie__E908452D8582EBA1");

            entity.ToTable("amenities");

            entity.HasIndex(e => e.Name, "uq_amenities_name").IsUnique();

            entity.Property(e => e.AmenityId).HasColumnName("amenity_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__areas__985D6D6BC3C5C6FF");

            entity.ToTable("areas");

            entity.HasIndex(e => e.Name, "uq_areas_name").IsUnique();

            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<BookedRoom>(entity =>
        {
            entity.HasKey(e => e.BookedRoomId).HasName("PK__booked_r__C04DCB29EC3AD0AB");

            entity.ToTable("booked_rooms");

            entity.Property(e => e.BookedRoomId).HasColumnName("booked_room_id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.PriceAtBooking)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("price_at_booking");
            entity.Property(e => e.RoomId).HasColumnName("room_id");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookedRooms)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("booked_rooms_ibfk_1");

            entity.HasOne(d => d.Room).WithMany(p => p.BookedRooms)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("booked_rooms_ibfk_2");
        });

        modelBuilder.Entity<BookedTable>(entity =>
        {
            entity.HasKey(e => e.BookedTableId).HasName("PK__booked_t__687E9894178D8E9B");

            entity.ToTable("booked_tables");

            entity.HasIndex(e => new { e.BookingId, e.TableId }, "uq_booked_tables_unique_booking_table").IsUnique();

            entity.Property(e => e.BookedTableId).HasColumnName("booked_table_id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.TableId).HasColumnName("table_id");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookedTables)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("booked_tables_ibfk_1");

            entity.HasOne(d => d.Table).WithMany(p => p.BookedTables)
                .HasForeignKey(d => d.TableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("booked_tables_ibfk_2");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__bookings__5DE3A5B1369163D1");

            entity.ToTable("bookings");

            entity.HasIndex(e => e.BookingCode, "uq_bookings_booking_code").IsUnique();

            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.BookerEmail)
                .HasMaxLength(255)
                .HasColumnName("booker_email");
            entity.Property(e => e.BookerName)
                .HasMaxLength(255)
                .HasColumnName("booker_name");
            entity.Property(e => e.BookerPhone)
                .HasMaxLength(20)
                .HasColumnName("booker_phone");
            entity.Property(e => e.BookingCode)
                .HasMaxLength(100)
                .HasColumnName("booking_code");
            entity.Property(e => e.BusinessId).HasColumnName("business_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("expires_at");
            entity.Property(e => e.Notes)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("notes");
            entity.Property(e => e.NumGuests).HasColumnName("num_guests");
            entity.Property(e => e.PaidAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("paid_amount");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .HasDefaultValue("unpaid")
                .HasColumnName("payment_status");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasDefaultValue("pending")
                .HasColumnName("status");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_price");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Business).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.BusinessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bookings_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("bookings_ibfk_1");
        });

        modelBuilder.Entity<BookingDish>(entity =>
        {
            entity.HasKey(e => e.BookingDishId).HasName("PK__booking___8386979E65AFB315");

            entity.ToTable("booking_dishes");

            entity.Property(e => e.BookingDishId).HasColumnName("booking_dish_id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.DishId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("dish_id");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("notes");
            entity.Property(e => e.PriceAtBooking)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("price_at_booking");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingDishes)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("fk_bd_booking");

            entity.HasOne(d => d.Dish).WithMany(p => p.BookingDishes)
                .HasForeignKey(d => d.DishId)
                .HasConstraintName("fk_bd_dish");
        });

        modelBuilder.Entity<Business>(entity =>
        {
            entity.HasKey(e => e.BusinessId).HasName("PK__business__DC0DC16EE4D37015");

            entity.ToTable("businesses");

            entity.Property(e => e.BusinessId).HasColumnName("business_id");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("address");
            entity.Property(e => e.AreaId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("area_id");
            entity.Property(e => e.AvgRating)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("avg_rating");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.ReviewCount)
                .HasDefaultValue(0)
                .HasColumnName("review_count");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Area).WithMany(p => p.Businesses)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("businesses_ibfk_2");

            entity.HasOne(d => d.Owner).WithMany(p => p.Businesses)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("businesses_ibfk_1");

            entity.HasMany(d => d.Amenities).WithMany(p => p.Businesses)
                .UsingEntity<Dictionary<string, object>>(
                    "BusinessAmenity",
                    r => r.HasOne<Amenity>().WithMany()
                        .HasForeignKey("AmenityId")
                        .HasConstraintName("business_amenities_ibfk_2"),
                    l => l.HasOne<Business>().WithMany()
                        .HasForeignKey("BusinessId")
                        .HasConstraintName("business_amenities_ibfk_1"),
                    j =>
                    {
                        j.HasKey("BusinessId", "AmenityId").HasName("PK__business__129D453C8027BDA0");
                        j.ToTable("business_amenities");
                        j.IndexerProperty<int>("BusinessId").HasColumnName("business_id");
                        j.IndexerProperty<int>("AmenityId").HasColumnName("amenity_id");
                    });

            entity.HasMany(d => d.Cuisines).WithMany(p => p.Businesses)
                .UsingEntity<Dictionary<string, object>>(
                    "BusinessCuisine",
                    r => r.HasOne<CuisineType>().WithMany()
                        .HasForeignKey("CuisineId")
                        .HasConstraintName("business_cuisines_ibfk_2"),
                    l => l.HasOne<Business>().WithMany()
                        .HasForeignKey("BusinessId")
                        .HasConstraintName("business_cuisines_ibfk_1"),
                    j =>
                    {
                        j.HasKey("BusinessId", "CuisineId").HasName("PK__business__8F14BD01AC80E399");
                        j.ToTable("business_cuisines");
                        j.IndexerProperty<int>("BusinessId").HasColumnName("business_id");
                        j.IndexerProperty<int>("CuisineId").HasColumnName("cuisine_id");
                    });

            entity.HasMany(d => d.Occasions).WithMany(p => p.Businesses)
                .UsingEntity<Dictionary<string, object>>(
                    "BusinessOccasion",
                    r => r.HasOne<Occasion>().WithMany()
                        .HasForeignKey("OccasionId")
                        .HasConstraintName("business_occasions_ibfk_2"),
                    l => l.HasOne<Business>().WithMany()
                        .HasForeignKey("BusinessId")
                        .HasConstraintName("business_occasions_ibfk_1"),
                    j =>
                    {
                        j.HasKey("BusinessId", "OccasionId").HasName("PK__business__94B7CB65EAE8E119");
                        j.ToTable("business_occasions");
                        j.IndexerProperty<int>("BusinessId").HasColumnName("business_id");
                        j.IndexerProperty<int>("OccasionId").HasColumnName("occasion_id");
                    });

            entity.HasMany(d => d.Types).WithMany(p => p.Businesses)
                .UsingEntity<Dictionary<string, object>>(
                    "BusinessRestaurantType",
                    r => r.HasOne<RestaurantType>().WithMany()
                        .HasForeignKey("TypeId")
                        .HasConstraintName("business_restaurant_types_ibfk_2"),
                    l => l.HasOne<Business>().WithMany()
                        .HasForeignKey("BusinessId")
                        .HasConstraintName("business_restaurant_types_ibfk_1"),
                    j =>
                    {
                        j.HasKey("BusinessId", "TypeId").HasName("PK__business__4ECDC13793300CD3");
                        j.ToTable("business_restaurant_types");
                        j.IndexerProperty<int>("BusinessId").HasColumnName("business_id");
                        j.IndexerProperty<int>("TypeId").HasColumnName("type_id");
                    });
        });

        modelBuilder.Entity<CuisineType>(entity =>
        {
            entity.HasKey(e => e.CuisineId).HasName("PK__cuisine___3197C6F437316639");

            entity.ToTable("cuisine_types");

            entity.HasIndex(e => e.Name, "uq_cuisine_types_name").IsUnique();

            entity.Property(e => e.CuisineId).HasColumnName("cuisine_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DiningSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__dining_s__69B13FDC98FD2B57");

            entity.ToTable("dining_sessions");

            entity.HasIndex(e => new { e.BusinessId, e.StartTime }, "uq_dining_sessions_unique_session_per_business").IsUnique();

            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.BusinessId).HasColumnName("business_id");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.StartTime).HasColumnName("start_time");

            entity.HasOne(d => d.Business).WithMany(p => p.DiningSessions)
                .HasForeignKey(d => d.BusinessId)
                .HasConstraintName("dining_sessions_ibfk_1");
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasKey(e => e.DishId).HasName("PK__dishes__9F2B4CF90AA27D53");

            entity.ToTable("dishes");

            entity.Property(e => e.DishId).HasColumnName("dish_id");
            entity.Property(e => e.BusinessId).HasColumnName("business_id");
            entity.Property(e => e.CategoryId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("image_url");
            entity.Property(e => e.IsAvailable)
                .HasDefaultValue(true)
                .HasColumnName("is_available");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("price");

            entity.HasOne(d => d.Business).WithMany(p => p.Dishes)
                .HasForeignKey(d => d.BusinessId)
                .HasConstraintName("fk_dish_business");

            entity.HasOne(d => d.Category).WithMany(p => p.Dishes)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("fk_dish_category");
        });

        modelBuilder.Entity<DishCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__dish_cat__D54EE9B4A0176E8A");

            entity.ToTable("dish_categories");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.BusinessId).HasColumnName("business_id");
            entity.Property(e => e.DisplayOrder)
                .HasDefaultValue(0)
                .HasColumnName("display_order");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.Business).WithMany(p => p.DishCategories)
                .HasForeignKey(d => d.BusinessId)
                .HasConstraintName("fk_category_business");
        });

        modelBuilder.Entity<Feature>(entity =>
        {
            entity.HasKey(e => e.FeatureId).HasName("PK__features__7906CBD745BA8E77");

            entity.ToTable("features");

            entity.HasIndex(e => e.Url, "uq_features_url").IsUnique();

            entity.Property(e => e.FeatureId).HasColumnName("feature_id");
            entity.Property(e => e.FeatureName)
                .HasMaxLength(100)
                .HasColumnName("feature_name");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
        });

        modelBuilder.Entity<HomestayBookingDetail>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__homestay__5DE3A5B10DB7F606");

            entity.ToTable("homestay_booking_details");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("booking_id");
            entity.Property(e => e.ReservationEndTime)
                .HasColumnType("datetime")
                .HasColumnName("reservation_end_time");
            entity.Property(e => e.ReservationStartTime)
                .HasColumnType("datetime")
                .HasColumnName("reservation_start_time");

            entity.HasOne(d => d.Booking).WithOne(p => p.HomestayBookingDetail)
                .HasForeignKey<HomestayBookingDetail>(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hbd_ibfk_1");
        });

        modelBuilder.Entity<HomestayDetail>(entity =>
        {
            entity.HasKey(e => e.BusinessId).HasName("PK__homestay__DC0DC16EB7EF98A8");

            entity.ToTable("homestay_details");

            entity.Property(e => e.BusinessId)
                .ValueGeneratedNever()
                .HasColumnName("business_id");
            entity.Property(e => e.GuestCapacity)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("guest_capacity");
            entity.Property(e => e.NumBedrooms)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("num_bedrooms");
            entity.Property(e => e.PricePerNight)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("price_per_night");

            entity.HasOne(d => d.Business).WithOne(p => p.HomestayDetail)
                .HasForeignKey<HomestayDetail>(d => d.BusinessId)
                .HasConstraintName("homestay_details_ibfk_1");
        });

        modelBuilder.Entity<Occasion>(entity =>
        {
            entity.HasKey(e => e.OccasionId).HasName("PK__occasion__8BA0A0B5341B1C99");

            entity.ToTable("occasions");

            entity.HasIndex(e => e.Name, "uq_occasions_name").IsUnique();

            entity.Property(e => e.OccasionId).HasColumnName("occasion_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__payments__ED1FC9EA1286A18C");

            entity.ToTable("payments");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.CompletedBookingKey)
                .HasMaxLength(20)
                .HasComputedColumnSql("(case when [status]='completed' then CONVERT([nvarchar](20),[booking_id])  end)", true)
                .HasColumnName("completed_booking_key");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.GatewayResponse)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("gateway_response");
            entity.Property(e => e.PaidAt).HasColumnName("paid_at");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("payment_method");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.TransactionCode)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("transaction_code");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payments_ibfk_1");
        });

        modelBuilder.Entity<RestaurantDetail>(entity =>
        {
            entity.HasKey(e => e.BusinessId).HasName("PK__restaura__DC0DC16EFB84E373");

            entity.ToTable("restaurant_details");

            entity.Property(e => e.BusinessId)
                .ValueGeneratedNever()
                .HasColumnName("business_id");
            entity.Property(e => e.ClosingHour)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("closing_hour");
            entity.Property(e => e.OpeningHour)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("opening_hour");
            entity.Property(e => e.SeatingCapacity)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("seating_capacity");

            entity.HasOne(d => d.Business).WithOne(p => p.RestaurantDetail)
                .HasForeignKey<RestaurantDetail>(d => d.BusinessId)
                .HasConstraintName("restaurant_details_ibfk_1");
        });

        modelBuilder.Entity<RestaurantTable>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__restaura__B21E8F24F1127670");

            entity.ToTable("restaurant_tables");

            entity.Property(e => e.TableId).HasColumnName("table_id");
            entity.Property(e => e.BusinessId).HasColumnName("business_id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.Business).WithMany(p => p.RestaurantTables)
                .HasForeignKey(d => d.BusinessId)
                .HasConstraintName("restaurant_tables_ibfk_1");
        });

        modelBuilder.Entity<RestaurantType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__restaura__2C0005987D875C5A");

            entity.ToTable("restaurant_types");

            entity.HasIndex(e => e.Name, "uq_restaurant_types_name").IsUnique();

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__reviews__60883D90F2CAAF18");

            entity.ToTable("reviews");

            entity.HasIndex(e => e.BookingId, "uq_reviews_booking_id").IsUnique();

            entity.Property(e => e.ReviewId).HasColumnName("review_id");
            entity.Property(e => e.BookingId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("booking_id");
            entity.Property(e => e.BusinessId).HasColumnName("business_id");
            entity.Property(e => e.Comment)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Booking).WithOne(p => p.Review)
                .HasForeignKey<Review>(d => d.BookingId)
                .HasConstraintName("reviews_ibfk_3");

            entity.HasOne(d => d.Business).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.BusinessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reviews_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reviews_ibfk_2");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__roles__760965CC4FAC83CD");

            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleName, "uq_roles_role_name").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");

            entity.HasMany(d => d.Features).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "RolesFeature",
                    r => r.HasOne<Feature>().WithMany()
                        .HasForeignKey("FeatureId")
                        .HasConstraintName("fk_rf_feature"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_rf_role"),
                    j =>
                    {
                        j.HasKey("RoleId", "FeatureId").HasName("PK__roles_fe__119909710FE2903D");
                        j.ToTable("roles_features");
                        j.IndexerProperty<int>("RoleId").HasColumnName("role_id");
                        j.IndexerProperty<int>("FeatureId").HasColumnName("feature_id");
                    });
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__rooms__19675A8A5C5D42F7");

            entity.ToTable("rooms");

            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.BusinessId).HasColumnName("business_id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PricePerNight)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("price_per_night");

            entity.HasOne(d => d.Business).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.BusinessId)
                .HasConstraintName("rooms_ibfk_1");
        });

        modelBuilder.Entity<RoomAvailability>(entity =>
        {
            entity.HasKey(e => e.AvailabilityId).HasName("PK__room_ava__86E3A8014B253DF2");

            entity.ToTable("room_availability");

            entity.HasIndex(e => new { e.RoomId, e.Date }, "uq_room_availability_room_id").IsUnique();

            entity.Property(e => e.AvailabilityId).HasColumnName("availability_id");
            entity.Property(e => e.BookingId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("booking_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Price)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("price");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasColumnName("status");

            entity.HasOne(d => d.Booking).WithMany(p => p.RoomAvailabilities)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("room_availability_ibfk_2");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomAvailabilities)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("room_availability_ibfk_1");
        });

        modelBuilder.Entity<RoomImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__room_ima__DC9AC955A92D6C43");

            entity.ToTable("room_images");

            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .HasColumnName("image_url");
            entity.Property(e => e.RoomId).HasColumnName("room_id");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomImages)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("room_images_ibfk_1");
        });

        modelBuilder.Entity<TableAvailability>(entity =>
        {
            entity.HasKey(e => e.AvailabilityId).HasName("PK__table_av__86E3A8013587E016");

            entity.ToTable("table_availability");

            entity.HasIndex(e => new { e.TableId, e.SessionId, e.Date }, "uq_table_availability_unique_table_session_date").IsUnique();

            entity.Property(e => e.AvailabilityId).HasColumnName("availability_id");
            entity.Property(e => e.BookingId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("booking_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasColumnName("status");
            entity.Property(e => e.TableId).HasColumnName("table_id");

            entity.HasOne(d => d.Booking).WithMany(p => p.TableAvailabilities)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("table_availability_ibfk_3");

            entity.HasOne(d => d.Session).WithMany(p => p.TableAvailabilities)
                .HasForeignKey(d => d.SessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("table_availability_ibfk_2");

            entity.HasOne(d => d.Table).WithMany(p => p.TableAvailabilities)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("table_availability_ibfk_1");
        });

        modelBuilder.Entity<TempCart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__temp_car__2EF52A2766A2B1E1");

            entity.ToTable("temp_carts");

            entity.HasIndex(e => new { e.UserId, e.BusinessId, e.DishId }, "uq_temp_carts_unique_cart_item").IsUnique();

            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.BusinessId).HasColumnName("business_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DishId).HasColumnName("dish_id");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("notes");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1)
                .HasColumnName("quantity");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Business).WithMany(p => p.TempCarts)
                .HasForeignKey(d => d.BusinessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("temp_carts_ibfk_2");

            entity.HasOne(d => d.Dish).WithMany(p => p.TempCarts)
                .HasForeignKey(d => d.DishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("temp_carts_ibfk_3");

            entity.HasOne(d => d.User).WithMany(p => p.TempCarts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("temp_carts_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370F277B21B6");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "uq_users_email").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CitizenId)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("citizen_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.PersonalAddress)
                .HasMaxLength(500)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("personal_address");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("active")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
