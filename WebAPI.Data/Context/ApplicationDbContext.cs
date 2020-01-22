using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Text;
using WebAPI.Core.Models;

namespace WebAPI.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer("DefaultConnection");

                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }

        public DbSet<EmployeesModel> EmployeesModel { get; set; }
        public DbSet<ShiftTimesModel> ShiftTimesModel { get; set; }
        public DbSet<DepartmentHistoryModel> DepartmentHistoryModel { get; set; }
        public DbSet<PersonModel> PersonModel { get; set; }



    }
}
