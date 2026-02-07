using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Seed;

namespace Infrastructure.Context
{
    public class AppCtx : DbContext
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<City> Cities { get; set; }

        public AppCtx(DbContextOptions<AppCtx> opt) : base(opt)
        {
        }

        public async Task SeedDatabaseAsync()
        {
            await DatabaseSeeder.SeedAsync(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Keys

            //User
            modelBuilder.Entity<Branch>().HasKey(x => x.Id);

            modelBuilder.Entity<City>().HasKey(x => x.Id);

            #endregion

            #region Branch

            modelBuilder.Entity<Branch>().Property(x => x.Id).HasMaxLength(100);

            modelBuilder.Entity<Branch>()
                        .OwnsOne(e => e.BranchAddressInfo,
                                 opt =>
                                 {
                                     opt.Property(x => x.Address).HasColumnName(nameof(BranchAddressInfo.Address))
                                                                 .HasMaxLength(50)
                                                                 .IsRequired();

                                     opt.Property(x => x.District).HasColumnName(nameof(BranchAddressInfo.District))
                                                                  .HasMaxLength(50); 

                                 });

            modelBuilder.Entity<Branch>()
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


            modelBuilder.Entity<Branch>()
                        .OwnsOne(e => e.BranchIDInfo,
                                 opt =>
                                 {
                                     opt.Property(x => x.Name).HasColumnName(nameof(BranchIdentificationInfo.Name))
                                                              .HasMaxLength(100)
                                                              .IsRequired();

                                     opt.Property(x => x.Code).HasColumnName(nameof(BranchIdentificationInfo.Code))
                                                              .HasMaxLength(100)
                                                              .IsRequired();


                                     opt.Property(x => x.Status).HasColumnName(nameof(BranchIdentificationInfo.Status))
                                                                .IsRequired();

                                     opt.HasIndex(x => x.Code);
                                 });

            modelBuilder.Entity<Branch>()
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

            modelBuilder.Entity<Branch>()
                        .HasOne(e => e.City)
                        .WithMany(e => e.Branches)
                        .HasForeignKey(e => e.CityId)
                        .IsRequired();
            #endregion

            #region City

            modelBuilder.Entity<City>().Property(x => x.NameAr).HasMaxLength(50);
            modelBuilder.Entity<City>().Property(x => x.NameEn).HasMaxLength(50);

            
            #endregion

            #region Mapping




            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
