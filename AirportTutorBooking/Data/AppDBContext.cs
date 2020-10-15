using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AirportTutorBooking.Models;

namespace AirportTutorBooking.Data
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<PlanesModel> Planes { get; set; }
        public DbSet<AirportsModel> Airports { get; set; }
        public DbSet<TutorsModel> Tutors { get; set; }
        public DbSet<StudentsModel> Students { get; set; }
        public DbSet<AdministratorsModel> Administrators { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AdministratorTableConfiguration());
            builder.ApplyConfiguration(new AirportTableConfiguration());
            builder.ApplyConfiguration(new BookingTableConfiguration());
            builder.ApplyConfiguration(new MaintenancSchedulesTableConfigration());
            builder.ApplyConfiguration(new PlanesTableConfiguration());
            builder.ApplyConfiguration(new StudentTableConfiguration());
            builder.ApplyConfiguration(new TutorSchedulesTableConfiguration());
            builder.ApplyConfiguration(new TutorTableConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
