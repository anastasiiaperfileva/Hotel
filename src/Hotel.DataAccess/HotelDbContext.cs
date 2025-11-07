using Microsoft.EntityFrameworkCore.Metadata.Builders;
﻿using Hotel.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DataAccess;

public class HotelDbContext: DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    public DbSet<HotelEntity> Hotels { get; set; }

    public DbSet<RoomEntity> Rooms { get; set; }
    public DbSet<RoomImageEntity> RoomImages { get; set; }

    public DbSet<TypeOfRoomEntity> TypesOfRooms { get; set; }

    public DbSet<BookingEntity> Bookings { get; set; }

    public DbSet<AnnouncementEntity> Announcements { get; set; }

    public DbSet<ReviewEntity> Reviews { get; set; }

    public HotelDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Users 
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();

        modelBuilder.Entity<UserEntity>().Property(x => x.Role).HasConversion<int>();
        modelBuilder.Entity<UserEntity>().Property(x => x.Status).HasConversion<int>().IsRequired();
        
        modelBuilder.Entity<UserEntity>().Property(x => x.Email).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.Email).IsUnique();
        modelBuilder.Entity<UserEntity>().Property(x => x.PhoneNumber).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.PhoneNumber).IsUnique();
        
        // Hotels
        modelBuilder.Entity<HotelEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<HotelEntity>().HasIndex(x => x.ExternalId).IsUnique();
        
        modelBuilder.Entity<HotelEntity>().Property(x => x.Name).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<HotelEntity>().Property(x => x.Address).IsRequired().HasMaxLength(300);
        modelBuilder.Entity<HotelEntity>().Property(x => x.Phone).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<HotelEntity>().HasIndex(x => x.Phone).IsUnique();
        modelBuilder.Entity<HotelEntity>().Property(x => x.Rating).HasPrecision(3, 2).HasDefaultValue(0);
        modelBuilder.Entity<HotelEntity>().HasCheckConstraint("CK_Hotel_Rating", "\"Rating\" >= 0 AND \"Rating\" <= 5");
        
         // Rooms
        modelBuilder.Entity<RoomEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<RoomEntity>().HasIndex(x => x.ExternalId).IsUnique();
        
        modelBuilder.Entity<RoomEntity>().HasOne(x => x.Hotel).WithMany(x => x.Rooms).HasForeignKey(x => x.HotelId);
        modelBuilder.Entity<RoomEntity>().HasOne(x => x.TypeOfRoom).WithMany(x => x.Rooms).HasForeignKey(x => x.TypeOfRoomId);
        modelBuilder.Entity<RoomEntity>().Property(x => x.Status).HasConversion<int>().IsRequired();
        
        modelBuilder.Entity<RoomEntity>().Property(x => x.Number).IsRequired().HasMaxLength(5);
        modelBuilder.Entity<RoomEntity>().HasIndex(x => new { x.HotelId, x.Number }).IsUnique();

        // RoomImages
        modelBuilder.Entity<RoomImageEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<RoomImageEntity>().HasIndex(x => x.ExternalId).IsUnique();
        
        modelBuilder.Entity<RoomImageEntity>().HasOne(x => x.Room)
            .WithMany(x => x.RoomImages)
            .HasForeignKey(x => x.RoomId);
        
        modelBuilder.Entity<RoomImageEntity>().Property(x => x.ImageUrl).IsRequired().HasMaxLength(500);
        modelBuilder.Entity<RoomImageEntity>().Property(x => x.Description).HasMaxLength(500);
        modelBuilder.Entity<RoomImageEntity>().Property(x => x.DisplayOrder).IsRequired().HasDefaultValue(1);
        modelBuilder.Entity<RoomImageEntity>().HasCheckConstraint("CK_RoomImage_DisplayOrder", "\"DisplayOrder\" > 0");

            
        // TypesOfRooms 
        modelBuilder.Entity<TypeOfRoomEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<TypeOfRoomEntity>().HasIndex(x => x.ExternalId).IsUnique();
        
        modelBuilder.Entity<TypeOfRoomEntity>().Property(x => x.Status).HasConversion<int>().IsRequired();
        
        modelBuilder.Entity<TypeOfRoomEntity>().Property(x => x.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<TypeOfRoomEntity>().Property(x => x.Description).HasMaxLength(1000);
        modelBuilder.Entity<TypeOfRoomEntity>().Property(x => x.PricePerDay).IsRequired().HasPrecision(10, 2);
        modelBuilder.Entity<TypeOfRoomEntity>().HasCheckConstraint("CK_TypeOfRooms_PricePerDay", "\"PricePerDay\" > 0");
        modelBuilder.Entity<TypeOfRoomEntity>().Property(x => x.RoomsCount).IsRequired();
        modelBuilder.Entity<TypeOfRoomEntity>().HasCheckConstraint("CK_TypeOfRoom_RoomsCount", "\"RoomsCount\" > 0");
        modelBuilder.Entity<TypeOfRoomEntity>().Property(x => x.Area).IsRequired().HasPrecision(8, 2);
        modelBuilder.Entity<TypeOfRoomEntity>().HasCheckConstraint("CK_TypeOfRoom_Area", "\"Area\" > 0");
        modelBuilder.Entity<TypeOfRoomEntity>().Property(x => x.AvailabilityBalcony).IsRequired().HasDefaultValue(false);
        modelBuilder.Entity<TypeOfRoomEntity>().Property(x => x.Amenities).HasMaxLength(500);

        // Bookings
        modelBuilder.Entity<BookingEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<BookingEntity>().HasIndex(x => x.ExternalId).IsUnique();
        
        modelBuilder.Entity<BookingEntity>().HasOne(x => x.User).WithMany(x => x.Bookings).HasForeignKey(x => x.UserId);
        modelBuilder.Entity<BookingEntity>().Property(x => x.Status).HasConversion<int>().IsRequired();
        modelBuilder.Entity<BookingEntity>().HasOne(x => x.TypeOfRoom).WithMany(x => x.Bookings).HasForeignKey(x => x.TypeOfRoomId);
       
        modelBuilder.Entity<BookingEntity>().Property(x => x.CheckInDate).IsRequired();
        modelBuilder.Entity<BookingEntity>().Property(x => x.CheckOutDate).IsRequired();
        modelBuilder.Entity<BookingEntity>().HasCheckConstraint("CK_Booking_CheckOutAfterCheckIn", "\"CheckOutDate\" > \"CheckInDate\"");
        modelBuilder.Entity<BookingEntity>().Property(x => x.GuestsCount).IsRequired();
        modelBuilder.Entity<BookingEntity>().HasCheckConstraint("CK_Booking_GuestsCount", "\"GuestsCount\" > 0");
        modelBuilder.Entity<BookingEntity>().Property(x => x.TotalPrice).IsRequired().HasPrecision(10, 2);
        modelBuilder.Entity<BookingEntity>().HasCheckConstraint("CK_Booking_TotalPrice", "\"TotalPrice\" > 0");
        modelBuilder.Entity<BookingEntity>().Property(x => x.DateCreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
        modelBuilder.Entity<BookingEntity>().HasCheckConstraint("CK_Booking_DateCreatedAt_NotFuture", "\"DateCreatedAt\" <= CURRENT_TIMESTAMP");
        modelBuilder.Entity<BookingEntity>().Property(x => x.SpecialRequests).HasMaxLength(1000);
        
        // Announcements
        modelBuilder.Entity<AnnouncementEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<AnnouncementEntity>().HasIndex(x => x.ExternalId).IsUnique();
        
        modelBuilder.Entity<AnnouncementEntity>().HasOne(x => x.Hotel).WithMany(x => x.Announcements).HasForeignKey(x => x.HotelId);
        modelBuilder.Entity<AnnouncementEntity>().HasOne(x => x.User).WithMany(x => x.Announcements).HasForeignKey(x => x.UserId);
        modelBuilder.Entity<AnnouncementEntity>().Property(x => x.Status).HasConversion<int>().IsRequired();
        
        modelBuilder.Entity<AnnouncementEntity>().Property(x => x.Title).IsRequired().HasMaxLength(150);
        modelBuilder.Entity<AnnouncementEntity>().Property(x => x.Text).IsRequired().HasMaxLength(1000);
        modelBuilder.Entity<AnnouncementEntity>().Property(x => x.PublishedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
        modelBuilder.Entity<AnnouncementEntity>().Property(x => x.StartDate).IsRequired();
        modelBuilder.Entity<AnnouncementEntity>().Property(x => x.EndDate).IsRequired();
        modelBuilder.Entity<AnnouncementEntity>().HasCheckConstraint("CK_News_EndDateAfterStartDate", "\"EndDate\" >= \"StartDate\"");
        
        
        // Reviews
        modelBuilder.Entity<ReviewEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ReviewEntity>().HasIndex(x => x.ExternalId).IsUnique();
        
        modelBuilder.Entity<ReviewEntity>().HasOne(x => x.Hotel).WithMany(x => x.Reviews).HasForeignKey(x => x.HotelId);
        modelBuilder.Entity<ReviewEntity>().HasOne(x => x.User).WithMany(x => x.Reviews).HasForeignKey(x => x.UserId);
        modelBuilder.Entity<ReviewEntity>().Property(x => x.Status).HasConversion<int>().IsRequired();
        
        modelBuilder.Entity<ReviewEntity>().Property(x => x.Text).IsRequired().HasMaxLength(1000);
        modelBuilder.Entity<ReviewEntity>().Property(x => x.Rating).IsRequired();
        modelBuilder.Entity<ReviewEntity>().HasCheckConstraint("CK_Review_Rating", "\"Rating\" BETWEEN 1 AND 5");
        modelBuilder.Entity<ReviewEntity>().Property(x => x.PublishedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
        
    }
}