using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AirportTutorBooking.Models;

namespace AirportTutorBooking.Data
{
    public class BookingTableConfiguration : IEntityTypeConfiguration<BookingsModel>
    {
        public void Configure(EntityTypeBuilder<BookingsModel> builder)
        {
            builder.ToTable("Bookings");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("int").IsRequired();
            builder.Property(p => p.Status).HasColumnType("nvarchar(max)").HasDefaultValue("open");
            builder.Property(p => p.BookedDate).HasColumnType("datetime").HasDefaultValueSql("CONVERT(date, GETDATE())");
        }
    }
}
