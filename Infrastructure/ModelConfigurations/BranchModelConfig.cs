using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ModelConfigurations
{
    public partial class DBConfigurationBuilder
    {

        public DBConfigurationBuilder BranchModelConfig()
        {
            _builder.Entity<Branch>().HasKey(x => x.Id);

            _builder.Entity<Branch>().Property(x => x.Id).HasMaxLength(100);

            _builder.Entity<Branch>()
                        .OwnsOne(e => e.BranchAddressInfo,
                                 opt =>
                                 {
                                     opt.Property(x => x.Address).HasColumnName(nameof(BranchAddressInfo.Address))
                                                                 .HasMaxLength(50)
                                                                 .IsRequired();

                                     opt.Property(x => x.District).HasColumnName(nameof(BranchAddressInfo.District))
                                                                  .HasMaxLength(50);

                                 });

            _builder.Entity<Branch>()
                        .OwnsOne(e => e.BranchContactInfo,
                                 opt =>
                                 {
                                     opt.Property(x => x.ManagerContact).HasColumnName(nameof(BranchContactInfo.ManagerContact))
                                                                        .HasMaxLength(50);

                                     opt.Property(x => x.ManagerName).HasColumnName(nameof(BranchContactInfo.ManagerName))
                                                                     .HasMaxLength(50);

                                     opt.Property(x => x.PhoneNumber).HasColumnName(nameof(BranchContactInfo.PhoneNumber))
                                                                     .HasMaxLength(50)
                                                                     .IsRequired()
;
                                 });


            _builder.Entity<Branch>()
                        .OwnsOne(e => e.BranchIDInfo,
                                 opt =>
                                 {
                                     opt.Property(x => x.Name).HasColumnName(nameof(BranchIdentificationInfo.Name))
                                                              .HasMaxLength(100)
                                                              .IsRequired();

                                     opt.Property(x => x.Code).HasColumnName(nameof(BranchIdentificationInfo.Code))
                                                              .HasMaxLength(50)
                                                              .IsRequired();


                                     opt.Property(x => x.Status).HasColumnName(nameof(BranchIdentificationInfo.Status))
                                                                .IsRequired();

                                     opt.HasIndex(x => x.Code);
                                 });

            _builder.Entity<Branch>()
                        .OwnsOne(e => e.BranchServiceRestrictions,
                                 opt =>
                                 {
                                     opt.Property(x => x.DisableVouchers).HasColumnName(nameof(BranchServiceRestrictions.DisableVouchers))
                                                                         .HasDefaultValue(false);

                                     opt.Property(x => x.DisableCollection).HasColumnName(nameof(BranchServiceRestrictions.DisableCollection))
                                                                           .HasDefaultValue(false);

                                     opt.Property(x => x.DisableRefund).HasColumnName(nameof(BranchServiceRestrictions.DisableRefund))
                                                                       .HasDefaultValue(false);

                                     opt.Property(x => x.DisablePartialRefund).HasColumnName(nameof(BranchServiceRestrictions.DisablePartialRefund))
                                                                              .HasDefaultValue(false);
                                 });

            _builder.Entity<Branch>()
                        .HasOne(e => e.City)
                        .WithMany(e => e.Branches)
                        .HasForeignKey(e => e.CityId)
                        .IsRequired(true);

            return this;
        }
    }
}
