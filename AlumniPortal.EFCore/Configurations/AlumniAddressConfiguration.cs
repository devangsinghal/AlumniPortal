using AlumniPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlumniPortal.EFCore.Configurations
{
    public class AlumniAddressConfiguration : IEntityTypeConfiguration<AlumniAddress>
    {
        public void Configure(EntityTypeBuilder<AlumniAddress> builder)
        {
            builder.HasIndex(x => x.AddressId);
            builder.HasKey(x => x.AddressId);
            builder.Property(x => x.AddressLine1).HasColumnType("nvarchar(250)");
            builder.Property(x => x.AddressLine2).HasColumnType("nvarchar(250)");
            builder.Property(x => x.City).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Country).HasColumnType("nvarchar(50)");
            builder.Property(x => x.ZipCode).HasColumnType("nvarchar(20)");
            builder.Property(x => x.LandMark).HasColumnType("nvarchar(100)");
            builder.Property(x => x.State).HasColumnType("nvarchar(50)");
            builder.Property(x => x.CreatedBy).HasColumnType("nvarchar(250)");
            builder.Property(x => x.UpdatedBy).HasColumnType("nvarchar(250)");
            builder.Property(x => x.CreatedDate).HasColumnType("datetime");
            builder.Property(x => x.UpdatedDate).HasColumnType("datetime");
            builder.Property(x => x.DeletedAt).HasColumnType("datetime");
        }
    }
}
