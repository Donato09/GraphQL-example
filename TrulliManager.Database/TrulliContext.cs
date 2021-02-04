using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrulliManager.Database.Models;

namespace TrulliManager.Database
{
    public class TrulliContext : DbContext
    {
        public TrulliContext( DbContextOptions<TrulliContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Trullo> Trulli { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trullo>();

            modelBuilder.Entity<Property>()
                .HasMany(t => t.Trulli)
                .WithOne(t => t.Property);
        }

    }
}
