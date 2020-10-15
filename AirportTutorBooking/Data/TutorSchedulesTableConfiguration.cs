using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AirportTutorBooking.Models;

namespace AirportTutorBooking.Data
{
    public class TutorSchedulesTableConfiguration : IEntityTypeConfiguration<TutorSchedulesModel>
    {
        public void Configure(EntityTypeBuilder<TutorSchedulesModel> builder)
        {
            builder.ToTable("TutorSchedules");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("int").IsRequired();
            builder.Property(p => p.TutorId).HasColumnType("int").IsRequired();
            builder.Property(p => p.PlaneId).HasColumnType("int").IsRequired();
            builder.Property(p => p.AirportId).HasColumnType("int").IsRequired();
            builder.Property(p => p.AvailableDate).HasColumnType("datetime").HasDefaultValueSql("CONVERT(date, GETDATE())");
            builder.Property(p => p.isAvailable).HasColumnType("bit").HasDefaultValue(1);

            builder.HasOne(p => p.Tutor).WithMany(c => c.Schedules);
        }
    }
}
