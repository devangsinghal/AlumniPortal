using AlumniPortal.Domain.Entities;
using AlumniPortal.EFCore.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlumniPortal.EFCore
{
    public class APContext:IdentityDbContext
    {
        public APContext(DbContextOptions<APContext> options) : base(options)
        {
        }

        public DbSet<AlumniPersonalDetails> AlumniPersonalDetails { get; set; }

        public DbSet<AlumniAddress> AlumniAddress { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AlumniPersonalDetailsConfiguration());
            builder.ApplyConfiguration(new AlumniAddressConfiguration());
        }
    }
}
