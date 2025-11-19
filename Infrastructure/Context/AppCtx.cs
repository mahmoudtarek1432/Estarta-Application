using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class AppCtx : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        public AppCtx(DbContextOptions opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region indexing

            //User
            modelBuilder.Entity<User>().HasKey(x => x.Id);

            modelBuilder.Entity<User>().HasIndex(x => x.UserCivilInfo.NationalNumber);

            modelBuilder.Entity<User>().HasMany(x => x.Salaries)
                                       .WithOne(x => x.User)
                                       .HasForeignKey(x => x.UserId)
                                       ;
           //Salary

            modelBuilder.Entity<Salary>().HasKey(x => x.Id);



            #endregion

            #region Value Object
            modelBuilder.Entity<User>()
                        .OwnsOne(e => e.UserCivilInfo,
                                 opt =>
                                 {
                                     opt.Property(x => x.NationalNumber).HasColumnName(nameof(CivilInfo.NationalNumber));
                                 });

            modelBuilder.Entity<User>()
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
