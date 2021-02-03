using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrulliManager.Database
{
    public class TrulliContext : DbContext
    {
        public TrulliContext( DbContextOptions<TrulliContext> options)
            : base(options)
        {

        }

        public DbSet<Models.Property> Properties { get; set; }
        public DbSet<Models.Trullo> Trulli { get; set; }

    }
}
