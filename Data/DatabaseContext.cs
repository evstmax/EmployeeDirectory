using System;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectory.Data
{
    public class DatabaseContext : DbContext

    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Бухгалтерия"
                },

            new Department
            {
                Id = 2,
                Name = "Отдел продаж"
            },
            new Department
                {
                    Id = 3,
                    Name = "Отдел IT"
                }

                );


            builder.Entity<Position>().HasData(
                new Position
                {
                    Id = 1,
                    Name = "Менеджер",
                    Salary = 20000
                },
                new Position
                {
                    Id = 2,
                    Name = "Инженер",
                    Salary = 10000
                },
            new Position
                {
                    Id = 3,
                    Name = "Бухгалтер",
                    Salary = 40000
                }
            );

            builder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Patronymic = "Иванович",
                    BirthDate = new DateTime(1985,02,03),
                    EmploymentDate = new DateTime(2000 , 02 , 03),
                    PositionId = 1,
                    //Position = null,
                    DepartmentId = 2,
                    //Department = null,
                    Email = "ivan@mail.ru",
                    Phone = "89085149822"
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Евгений",
                    LastName = "Соловьев",
                    Patronymic = "Генадьевич",
                    BirthDate = new DateTime(1985 , 02 , 03),
                    EmploymentDate = new DateTime(2000 , 02 , 03),
                    PositionId = 2,
                    //Position = null,
                    DepartmentId = 3,
                    //Department = null,
                    Email = "evg@mail.ru",
                    Phone = "89085949822"
                }
                

                );

        }

    }
}
