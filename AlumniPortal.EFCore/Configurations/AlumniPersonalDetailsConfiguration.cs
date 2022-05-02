using AlumniPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlumniPortal.EFCore.Configurations
{
    public class AlumniPersonalDetailsConfiguration : IEntityTypeConfiguration<AlumniPersonalDetails>
    {
        public void Configure(EntityTypeBuilder<AlumniPersonalDetails> builder)
        {
            builder.HasIndex(x => x.AlumniId);
            builder.HasKey(x => x.AlumniId);
            builder.Property(x => x.EmailAddress).HasColumnType("nvarchar(250)");
            builder.Property(x => x.AlternateEmailAddress).HasColumnType("nvarchar(250)");
            builder.Property(x => x.Mobile).HasColumnType("nvarchar(15)");
            builder.Property(x => x.AlternateMobile).HasColumnType("nvarchar(15)");
            builder.Property(x => x.EmployeeCode).HasColumnType("int");
            builder.Property(x => x.CreatedBy).HasColumnType("nvarchar(250)");
            builder.Property(x => x.UpdatedBy).HasColumnType("nvarchar(250)");
            builder.Property(x => x.CreatedDate).HasColumnType("datetime");
            builder.Property(x => x.UpdatedDate).HasColumnType("datetime");
            builder.Property(x => x.DeletedAt).HasColumnType("datetime");
            builder.HasOne(x => x.AlumniAddress)
                 .WithOne(y => y.AlumniPersonalDetail)
                 .HasForeignKey<AlumniAddress>(x => x.AddressId);
        }
    }
}
