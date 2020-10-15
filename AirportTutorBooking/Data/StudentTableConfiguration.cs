using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AirportTutorBooking.Models;

namespace AirportTutorBooking.Data
{
    public class StudentTableConfiguration : IEntityTypeConfiguration<StudentsModel>
    {
        public void Configure(EntityTypeBuilder<StudentsModel> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("int").IsRequired();
            builder.Property(p => p.FirstName).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(p => p.LastName).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(p => p.Password).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(p => p.Mobile).HasColumnType("nvarchar(max)");
            builder.Property(p => p.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("CONVERT(date, GETDATE())");
            builder.Property(p => p.isActive).HasColumnType("bit").HasDefaultValue(1);
        }
    }
}
