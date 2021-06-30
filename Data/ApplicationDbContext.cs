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
                    new Post { Id = 1, PostName = "Ректор"},
                    new Post { Id = 2, PostName = "Менеджер"},
                    new Post { Id = 3, PostName = "Главный бухгалтер"},
                    new Post { Id = 4, PostName = "Секретарь"},
                    new Post { Id = 5, PostName = "Декан"},
                    new Post { Id = 6, PostName = "Заведующий кафедрой"},
                    new Post { Id = 7, PostName = "Лаборант"},
                    new Post { Id = 8, PostName = "Проректор"},
                    new Post { Id = 9, PostName = "Бухгалтер"},
                    new Post { Id = 10, PostName = "Агент по продажам"},
                    new Post { Id = 12, PostName = "Аспирант"},
                    new Post { Id = 13, PostName = "Ассистент"},
                    new Post { Id = 14, PostName = "Ведущий научный сотрудник"},
                    new Post { Id = 15, PostName = "Главный научный сотрудник"},
                    new Post { Id = 16, PostName = "Докторант"},
                    new Post { Id = 17, PostName = "Доцент"},
                    new Post { Id = 18, PostName = "Младший научный сотрудник"},
                    new Post { Id = 19, PostName = "Научный сотрудник"},
                    new Post { Id = 20, PostName = "Преподаватель"},
                    new Post { Id = 21, PostName = "Профессор"},
                    new Post { Id = 22, PostName = "Старший преподаватель"},
                    new Post { Id = 23, PostName = "Стажер"}
                });
            modelBuilder.Entity<Department>().HasData(
                new Department[]
                {
                    new Department { Id = 1, Name = "Администрация"},
                    new Department { Id = 2, Name = "Бухгалтерия"},
                    new Department { Id = 3, Name = "Деканат ФИТИР"},
                    new Department { Id = 4, Name = "ФИТИР каф. ТМ"},
                    new Department { Id = 5, Name = "ФИТИР каф. ИСИТ"},
                    new Department { Id = 6, Name = "ФИТИР каф. АТПИП"},
                    new Department { Id = 7, Name = "ФИТИР каф. ПИНОТТ"},
                    new Department { Id = 8, Name = "Деканат ФПТ"},
                    new Department { Id = 9, Name = "ФПТ каф. МСИС(ЛП)"},
                    new Department { Id = 10, Name = "ФПТ каф. ТИЭТ"},
                    new Department { Id = 11, Name = "ФПТ каф. ПТМ(ТИМ)"},
                    new Department { Id = 12, Name = "Деканат ФД"},
                    new Department { Id = 13, Name = "ФД каф. Дизайн(комм.)"},
                    new Department { Id = 14, Name = "ФД каф. Дизайн(КиТ)"},
                    new Department { Id = 15, Name = "ФД каф. Дизайн(ВС)"}

                });

        }


    }
}
