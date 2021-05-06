using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HumanResourcesDepartment.Models;

namespace HumanResourcesDepartment.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BusinessTrip> BusinessTrips { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dismissal> Dismissals { get; set; }
        public DbSet<LaborСontract> LaborСontracts { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<SickLeave> SickLeaves { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<Vacation> Vacations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
