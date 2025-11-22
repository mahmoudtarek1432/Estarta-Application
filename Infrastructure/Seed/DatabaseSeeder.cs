using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using System.Numerics;

namespace Infrastructure.Seed
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(AppCtx context)
        {
            if (await context.Employee.AnyAsync())
                return; // Prevent duplicate seeding

            var users = new List<Employee>
            {
                new Employee ( new CivilInfo("joe","doe","NAT1001"), new AccountInfo( "jdoe","jdoe@example.com","0791111111")) 
                //new User { Id = 2, Username = "asalem", NationalNumber = "NAT1002", Email = "asalem@example.com", Phone = "0792222222", IsActive = true },
                //new User { Id = 3, Username = "rhamdan", NationalNumber = "NAT1003", Email = "rhamdan@example.com", Phone = "0793333333", IsActive = false },
                //new User { Id = 4, Username = "lbarakat", NationalNumber = "NAT1004", Email = "lbarakat@example.com", Phone = "0794444444", IsActive = true },
                //new User { Id = 5, Username = "mfaris", NationalNumber = "NAT1005", Email = "mfaris@example.com", Phone = "0795555555", IsActive = true },
                //new User { Id = 6, Username = "nsaleh", NationalNumber = "NAT1006", Email = "nsaleh@example.com", Phone = "0796666666", IsActive = false },
                //new User { Id = 7, Username = "zobeidat", NationalNumber = "NAT1007", Email = "zobeidat@example.com", Phone = "0797777777", IsActive = true },
                //new User { Id = 8, Username = "ahalaseh", NationalNumber = "NAT1008", Email = "ahalaseh@example.com", Phone = "0798888888", IsActive = true },
                //new User { Id = 9, Username = "tkhalaf", NationalNumber = "NAT1009", Email = "tkhalaf@example.com", Phone = "0799999999", IsActive = false },
                //new User { Id = 10, Username = "sshaheen", NationalNumber = "NAT1010", Email = "sshaheen@example.com", Phone = "0781010101", IsActive = true },
                //new User { Id = 11, Username = "tmart", NationalNumber = "NAT1011", Email = "tmart@example.com", Phone = "0781099101", IsActive = false },
                //new User { Id = 12, Username = "aali", NationalNumber = "NAT1012", Email = "aali@example.com", Phone = "0781088101", IsActive = true }
            };

            await context.Employee.AddRangeAsync(users);
            await context.SaveChangesAsync();

            var salaries = new List<Salary>
            {
                new Salary (1,1200,new IssueDate(2025,1)){Id = 1},
                new Salary (1,1300,new IssueDate(2025,1)){Id = 2},
                new Salary (1,1300,new IssueDate(2025,1)){Id = 3},
                new Salary (1,1500,new IssueDate(2025,1)){Id = 4},
                new Salary (1,1600,new IssueDate(2025,1)){Id = 5},

                //new Salary { Id = 6, Year = 2025, Month = 1, Amount = 900, UserId = 2 },
                //new Salary { Id = 7, Year = 2025, Month = 2, Amount = 950, UserId = 2 },
                //new Salary { Id = 8, Year = 2025, Month = 3, Amount = 980, UserId = 2 },
                //new Salary { Id = 9, Year = 2025, Month = 4, Amount = 1100, UserId = 2 },
                //new Salary { Id = 10, Year = 2025, Month = 5, Amount = 1150, UserId = 2 },
                //new Salary { Id = 11, Year = 2025, Month = 1, Amount = 400, UserId = 3 },
                //new Salary { Id = 15, Year = 2025, Month = 5, Amount = 800, UserId = 3 },
                //new Salary { Id = 16, Year = 2025, Month = 1, Amount = 2000, UserId = 4 },
                //new Salary { Id = 17, Year = 2025, Month = 2, Amount = 2050, UserId = 4 },
                //new Salary { Id = 18, Year = 2025, Month = 3, Amount = 2100, UserId = 4 },
                //new Salary { Id = 19, Year = 2025, Month = 4, Amount = 2200, UserId = 4 },
                //new Salary { Id = 20, Year = 2025, Month = 5, Amount = 2300, UserId = 4 },
                //new Salary { Id = 21, Year = 2025, Month = 1, Amount = 600, UserId = 5 },
                //new Salary { Id = 22, Year = 2025, Month = 2, Amount = 700, UserId = 5 },
                //new Salary { Id = 23, Year = 2025, Month = 3, Amount = 750, UserId = 5 },
                //new Salary { Id = 25, Year = 2025, Month = 5, Amount = 850, UserId = 5 },
                //new Salary { Id = 26, Year = 2025, Month = 11, Amount = 1500, UserId = 6 },
                //new Salary { Id = 27, Year = 2025, Month = 12, Amount = 1550, UserId = 6 },
                //new Salary { Id = 28, Year = 2025, Month = 1, Amount = 1600, UserId = 6 },
                //new Salary { Id = 29, Year = 2025, Month = 2, Amount = 1650, UserId = 6 },
                //new Salary { Id = 30, Year = 2025, Month = 3, Amount = 1700, UserId = 6 },
                //new Salary { Id = 31, Year = 2025, Month = 4, Amount = 2000, UserId = 6 },
                //new Salary { Id = 32, Year = 2025, Month = 1, Amount = 1000, UserId = 7 },
                //new Salary { Id = 33, Year = 2025, Month = 2, Amount = 1100, UserId = 7 },
                //new Salary { Id = 34, Year = 2025, Month = 3, Amount = 1150, UserId = 7 },
                //new Salary { Id = 35, Year = 2025, Month = 4, Amount = 1200, UserId = 7 },
                //new Salary { Id = 36, Year = 2025, Month = 5, Amount = 1250, UserId = 7 },
                //new Salary { Id = 37, Year = 2025, Month = 6, Amount = 1350, UserId = 7 },
                //new Salary { Id = 38, Year = 2025, Month = 7, Amount = 1500, UserId = 7 },
                //new Salary { Id = 39, Year = 2025, Month = 10, Amount = 2200, UserId = 8 },
                //new Salary { Id = 40, Year = 2025, Month = 11, Amount = 2300, UserId = 8 },
                //new Salary { Id = 41, Year = 2025, Month = 12, Amount = 2400, UserId = 8 },
                //new Salary { Id = 42, Year = 2025, Month = 1, Amount = 2500, UserId = 8 },
                //new Salary { Id = 43, Year = 2025, Month = 2, Amount = 2600, UserId = 8 },
                //new Salary { Id = 44, Year = 2025, Month = 3, Amount = 2800, UserId = 8 },
                //new Salary { Id = 45, Year = 2025, Month = 1, Amount = 1700, UserId = 9 },
                //new Salary { Id = 46, Year = 2025, Month = 2, Amount = 1750, UserId = 9 },
                //new Salary { Id = 47, Year = 2025, Month = 6, Amount = 1800, UserId = 9 },
                //new Salary { Id = 48, Year = 2025, Month = 7, Amount = 1850, UserId = 9 },
                //new Salary { Id = 49, Year = 2025, Month = 8, Amount = 1900, UserId = 9 },
                //new Salary { Id = 50, Year = 2025, Month = 1, Amount = 800, UserId = 10 },
                //new Salary { Id = 51, Year = 2025, Month = 2, Amount = 850, UserId = 10 },
                //new Salary { Id = 52, Year = 2025, Month = 3, Amount = 900, UserId = 10 },
                //new Salary { Id = 53, Year = 2025, Month = 8, Amount = 950, UserId = 10 },
                //new Salary { Id = 54, Year = 2025, Month = 9, Amount = 1000, UserId = 10 },
                //new Salary { Id = 55, Year = 2025, Month = 10, Amount = 1200, UserId = 10 }
            };

            await context.Salaries.AddRangeAsync(salaries);
            await context.SaveChangesAsync();
        }
    }
}
