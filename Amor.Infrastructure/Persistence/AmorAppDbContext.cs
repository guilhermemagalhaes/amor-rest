using Amor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Infrastructure.Persistence
{
    public class AmorAppDbContext : DbContext
    {
        public AmorAppDbContext(DbContextOptions<AmorAppDbContext> options) : base(options)
        { }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventParticipants> EventParticipants { get; set; }
        public virtual DbSet<Homeless> Homeless { get; set; }
        public virtual DbSet<Ong> Ongs { get; set; }
        public virtual DbSet<LegalPerson> LegalPerson { get; set; }
        public virtual DbSet<PhysicalPerson> PhysicalPerson { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Supporter> Supporters { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<PersonPhoto> PersonPhotos { get; set; }
        public virtual DbSet<EventPhoto> EventPhotos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().Property(x => x.Latitude).HasPrecision(12, 9);
            modelBuilder.Entity<Address>().Property(x => x.Longitude).HasPrecision(12, 9);
            base.OnModelCreating(modelBuilder);
        }
    }
}
