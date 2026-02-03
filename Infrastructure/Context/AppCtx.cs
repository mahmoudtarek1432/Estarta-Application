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
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

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
            modelBuilder.Entity<Employee>().HasKey(x => x.Id);


            modelBuilder.Entity<Employee>().HasMany(x => x.Salaries)
                                       .WithOne(x => x.Employee)
                                       .HasForeignKey(x => x.UserId)
                                       ;
           //Salary

            modelBuilder.Entity<Salary>().HasKey(x => x.Id);



            #endregion

            #region Value Object
            modelBuilder.Entity<Employee>()
                        .OwnsOne(e => e.UserCivilInfo,
                                 opt =>
                                 {
                                     opt.Property(x => x.NationalNumber).HasColumnName(nameof(CivilInfo.NationalNumber));
                                     opt.HasIndex(x => x.NationalNumber);
                                 });

            modelBuilder.Entity<Employee>()
                        .OwnsOne(e => e.UserAccountInfo,
                                 opt =>
                                 {
                                     opt.Property(x => x.UserName).HasColumnName(nameof(AccountInfo.UserName));
                                     opt.Property(x => x.Email).HasColumnName(nameof(AccountInfo.Email));
                                     opt.Property(x => x.PhoneNumber).HasColumnName(nameof(AccountInfo.PhoneNumber));
                                 });

            modelBuilder.Entity<Salary>()
                        .OwnsOne(e => e.issueDate,
                                 opt =>
                                 {
                                     opt.Property(x => x.Month).HasColumnName(nameof(IssueDate.Month));
                                     opt.Property(x => x.Year).HasColumnName(nameof(IssueDate.Year));
                                 });
            #endregion

            #region Mapping

            modelBuilder.Entity<Salary>().Ignore(e => e.SummerMonthList);

            // Configure optional 1-1 relationship between User and Employee
            modelBuilder.Entity<User>()
                .HasOne(u => u.Employee)
                .WithOne(e => e.User)
                .HasForeignKey<Employee>(e => e.UserId)
                .IsRequired(false);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
