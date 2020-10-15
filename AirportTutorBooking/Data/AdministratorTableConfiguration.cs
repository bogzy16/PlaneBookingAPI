using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AirportTutorBooking.Models;


namespace AirportTutorBooking.Data
{
    public class AdministratorTableConfiguration : IEntityTypeConfiguration<AdministratorsModel>
    {
        public void Configure(EntityTypeBuilder<AdministratorsModel> builder)
        {
            builder.ToTable("Administrators");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("int").IsRequired();
            builder.Property(p => p.FirstName).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(p => p.LastName).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(p => p.Password).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(p => p.isActive).HasColumnType("bit").HasDefaultValue(1);
            builder.Property(p => p.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("CONVERT(date, GETDATE())");
        }
    }
}
