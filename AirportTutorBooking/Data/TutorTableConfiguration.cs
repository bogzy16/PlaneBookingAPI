using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AirportTutorBooking.Models;

namespace AirportTutorBooking.Data
{
    public class TutorTableConfiguration : IEntityTypeConfiguration<TutorsModel>
    {
        public void Configure(EntityTypeBuilder<TutorsModel> builder)
        {
            builder.ToTable("Tutors");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("int").IsRequired();
            builder.Property(p => p.FirstName).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(p => p.LastName).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(p => p.Password).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(p => p.Mobile).HasColumnType("nvarchar(max)");
            builder.Property(p => p.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("CONVERT(date, GETDATE())");
            builder.Property(p => p.isActive).HasColumnType("bit").HasDefaultValue(1);

            builder.HasOne(p => p.Airports).WithMany(c => c.AirportTutors);
            builder.HasMany(p => p.Schedules).WithOne(c => c.Tutor);
        }
    }
}
