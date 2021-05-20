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
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<SickLeave> SickLeaves { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().HasData(
                new Post[]
                {
                    new Post { Id = 1, PostName = "Директор"},
                    new Post { Id = 2, PostName = "Менеджер"},
                    new Post { Id = 3, PostName = "Главный бухгалтер"},
                    new Post { Id = 4, PostName = "Бухгалтер"},
                    new Post { Id = 5, PostName = "Агент по продажам"},
                    new Post { Id = 6, PostName = "Снабженец"}
                });
            modelBuilder.Entity<Department>().HasData(
                new Department[]
                {
                    new Department { Id = 1, Name = "Администрация"},
                    new Department { Id = 2, Name = "Бухгалтерия"},
                    new Department { Id = 3, Name = "Отдел снабжения"},
                    new Department { Id = 4, Name = "Основное производство"},
                    new Department { Id = 5, Name = "Отдел сбыта"}
                });

        }


    }
}
