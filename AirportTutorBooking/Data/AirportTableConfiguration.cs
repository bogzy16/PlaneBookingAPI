using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AirportTutorBooking.Models;

namespace AirportTutorBooking.Data
{
    public class AirportTableConfiguration : IEntityTypeConfiguration<AirportsModel>
    {
        public void Configure(EntityTypeBuilder<AirportsModel> builder)
        {
            builder.ToTable("Airports");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("int").IsRequired();
            builder.Property(p => p.Name).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(p => p.Address).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(p => p.isActive).HasColumnType("bit").HasDefaultValue(1);
            builder.Property(p => p.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("CONVERT(date, GETDATE())");

            builder.HasMany(p => p.AirportPlanes).WithOne(c => c.Airports);
            builder.HasMany(p => p.AirportTutors).WithOne(c => c.Airports);
            builder.HasMany(p => p.AirportMaintenanceSchedules).WithOne(c => c.Airports);
        }
    }
}
