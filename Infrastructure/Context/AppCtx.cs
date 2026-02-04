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

        public AppCtx(DbContextOptions<AppCtx> opt) : base(opt)
        {
        }

        public async Task SeedDatabaseAsync()
        {
            await DatabaseSeeder.SeedAsync(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region indexing

            //User
            modelBuilder.Entity<Branch>().HasKey(x => x.Id);
            modelBuilder.Entity<Branch>().HasKey(x => x.BranchIDInfo.Code);


            #endregion

            #region Value Object
            modelBuilder.Entity<Branch>()
                        .OwnsOne(e => e.BranchAddressInfo,
                                 opt =>
                                 {
                                     opt.Property(x => x.Address).HasColumnName(nameof(BranchAddressInfo.Address));
                                     opt.Property(x => x.District).HasColumnName(nameof(BranchAddressInfo.District));

                                 });

            modelBuilder.Entity<Branch>()
                        .OwnsOne(e => e.BranchContactInfo,
                                 opt =>
                                 {
                                     opt.Property(x => x.ManagerContact).HasColumnName(nameof(BranchContactInfo.ManagerContact));
                                     opt.Property(x => x.ManagerName).HasColumnName(nameof(BranchContactInfo.ManagerName));
                                     opt.Property(x => x.PhoneNumber).HasColumnName(nameof(BranchContactInfo.PhoneNumber));
                                 });


            modelBuilder.Entity<Branch>()
                        .OwnsOne(e => e.BranchIDInfo,
                                 opt =>
                                 {
                                     opt.Property(x => x.Name).HasColumnName(nameof(BranchIdentificationInfo.Name));
                                     opt.Property(x => x.Code).HasColumnName(nameof(BranchIdentificationInfo.Code));
                                     opt.Property(x => x.Status).HasColumnName(nameof(BranchIdentificationInfo.Status));
                                 });

            modelBuilder.Entity<Branch>()
                        .OwnsOne(e => e.BranchServiceRestrictions,
                                 opt =>
                                 {
                                     opt.Property(x => x.DisableVouchers).HasColumnName(nameof(BranchServiceRestrictions.DisableVouchers));
                                     opt.Property(x => x.DisableCollection).HasColumnName(nameof(BranchServiceRestrictions.DisableCollection));
                                     opt.Property(x => x.DisableRefund).HasColumnName(nameof(BranchServiceRestrictions.DisableRefund));
                                     opt.Property(x => x.DisablePartialRefund).HasColumnName(nameof(BranchServiceRestrictions.DisablePartialRefund));
                                 });
            #endregion

            #region Mapping


           

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
