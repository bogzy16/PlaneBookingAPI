using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AirportTutorBooking.Models;


namespace AirportTutorBooking.Data
{
    public class PlanesTableConfiguration : IEntityTypeConfiguration<PlanesModel>
    {
        public void Configure(EntityTypeBuilder<PlanesModel> builder)
        {
            builder.ToTable("Planes");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("int").IsRequired();
            builder.Property(p => p.Name).HasColumnType("nvarchar(max)").HasDefaultValue("Shut Down Maintenance");
            builder.Property(p => p.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("CONVERT(date, GETDATE())");
            builder.Property(p => p.isActive).HasColumnType("bit").HasDefaultValue(1);

            builder.HasOne(p => p.Airports).WithMany(c => c.AirportPlanes);
        }
    }
}
