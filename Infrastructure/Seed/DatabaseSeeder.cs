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
            if (await context.Employees.AnyAsync())
                return; // Prevent duplicate seeding

            var users = new List<Employee>
            {
                new Employee(new CivilInfo("joe", "doe", "NAT1001"), new AccountInfo("jdoe", "jdoe@example.com", "0791111111")),
                new Employee(new CivilInfo("asalem", "salem", "NAT1002"), new AccountInfo("asalem", "asalem@example.com", "0792222222")) {  IsActive = true },
                new Employee(new CivilInfo("rhamdan", "hamdan", "NAT1003"), new AccountInfo("rhamdan", "rhamdan@example.com", "0793333333")) {  IsActive = false },
                new Employee(new CivilInfo("lbarakat", "barakat", "NAT1004"), new AccountInfo("lbarakat", "lbarakat@example.com", "0794444444")) { IsActive = true },
                new Employee(new CivilInfo("mfaris", "faris", "NAT1005"), new AccountInfo("mfaris", "mfaris@example.com", "0795555555")) { IsActive = true },
                new Employee(new CivilInfo("nsaleh", "saleh", "NAT1006"), new AccountInfo("nsaleh", "nsaleh@example.com", "0796666666")) { IsActive = false },
                new Employee(new CivilInfo("zobeidat", "obeidat", "NAT1007"), new AccountInfo("zobeidat", "zobeidat@example.com", "0797777777")) { IsActive = true },
                new Employee(new CivilInfo("ahalaseh", "halaseh", "NAT1008"), new AccountInfo("ahalaseh", "ahalaseh@example.com", "0798888888")) { IsActive = true },
                new Employee(new CivilInfo("tkhalaf", "khalaf", "NAT1009"), new AccountInfo("tkhalaf", "tkhalaf@example.com", "0799999999")) { IsActive = false },
                new Employee(new CivilInfo("sshaheen", "shaheen", "NAT1010"), new AccountInfo("sshaheen", "sshaheen@example.com", "0781010101")) { IsActive = true },
                new Employee(new CivilInfo("tmart", "mart", "NAT1011"), new AccountInfo("tmart", "tmart@example.com", "0781099101")) {  IsActive = false },
                new Employee(new CivilInfo("aali", "ali", "NAT1012"), new AccountInfo("aali", "aali@example.com", "0781088101")) { IsActive = true }
            };

            await context.Employees.AddRangeAsync(users);
            await context.SaveChangesAsync();

            var salaries = new List<Salary>
            {
                new Salary(1, 1200, new IssueDate(2025, 1)) ,
                new Salary(1, 1300, new IssueDate(2025, 2)) ,
                new Salary(1, 1400, new IssueDate(2025, 3)),
                new Salary(1, 1500, new IssueDate(2025, 5)),
                new Salary(1, 1600, new IssueDate(2025, 6)),
                new Salary(2, 900, new IssueDate(2025, 1)) ,
                new Salary(2, 950, new IssueDate(2025, 2)),
                new Salary(2, 980, new IssueDate(2025, 3)),
                new Salary(2, 1100, new IssueDate(2025, 4)),
                new Salary(2, 1150, new IssueDate(2025, 5)),
                new Salary(3, 400, new IssueDate(2025, 1)),
                new Salary(3, 800, new IssueDate(2025, 5)),
                new Salary(4, 2000, new IssueDate(2025, 1)),
                new Salary(4, 2050, new IssueDate(2025, 2)),
                new Salary(4, 2100, new IssueDate(2025, 3)),
                new Salary(4, 2200, new IssueDate(2025, 4)),
                new Salary(4, 2300, new IssueDate(2025, 5)),
                new Salary(5, 600, new IssueDate(2025, 1)),
                new Salary(5, 700, new IssueDate(2025, 2)),
                new Salary(5, 750, new IssueDate(2025, 3)),
                new Salary(5, 850, new IssueDate(2025, 5)),
                new Salary(6, 1500, new IssueDate(2025, 11)),
                new Salary(6, 1550, new IssueDate(2025, 12)),
                new Salary(6, 1600, new IssueDate(2025, 1)),
                new Salary(6, 1650, new IssueDate(2025, 2)),
                new Salary(6, 1700, new IssueDate(2025, 3)),
                new Salary(6, 2000, new IssueDate(2025, 4)),
                new Salary(7, 1000, new IssueDate(2025, 1)),
                new Salary(7, 1100, new IssueDate(2025, 2)),
                new Salary(7, 1150, new IssueDate(2025, 3)),
                new Salary(7, 1200, new IssueDate(2025, 4)),
                new Salary(7, 1250, new IssueDate(2025, 5)),
                new Salary(7, 1350, new IssueDate(2025, 6)),
                new Salary(7, 1500, new IssueDate(2025, 7)),
                new Salary(8, 2200, new IssueDate(2025, 10)),
                new Salary(8, 2300, new IssueDate(2025, 11)),
                new Salary(8, 2400, new IssueDate(2025, 12)),
                new Salary(8, 2500, new IssueDate(2025, 1)),
                new Salary(8, 2600, new IssueDate(2025, 2)),
                new Salary(8, 2800, new IssueDate(2025, 3)),
                new Salary(9, 1700, new IssueDate(2025, 1)),
                new Salary(9, 1750, new IssueDate(2025, 2)),
                new Salary(9, 1800, new IssueDate(2025, 6)),
                new Salary(9, 1850, new IssueDate(2025, 7)),
                new Salary(9, 1900, new IssueDate(2025, 8)),
                new Salary(10, 800, new IssueDate(2025, 1)),
                new Salary(10, 850, new IssueDate(2025, 2)),
                new Salary(10, 900, new IssueDate(2025, 3)),
                new Salary(10, 950, new IssueDate(2025, 8)),
                new Salary(10, 1000, new IssueDate(2025, 9)),
                new Salary(10, 1200, new IssueDate(2025, 10))
            };

            await context.Salaries.AddRangeAsync(salaries);
            await context.SaveChangesAsync();
        }
    }
}
