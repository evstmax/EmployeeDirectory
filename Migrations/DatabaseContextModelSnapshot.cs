﻿// <auto-generated />
using System;
using EmployeeDirectory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeDirectory.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeDirectory.Data.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Бухгалтерия"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Отдел продаж"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Отдел IT"
                        });
                });

            modelBuilder.Entity("EmployeeDirectory.Data.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<bool>("Dismissed")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1985, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 2,
                            Dismissed = false,
                            Email = "ivan@mail.ru",
                            EmploymentDate = new DateTime(2000, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Иван",
                            LastName = "Иванов",
                            Patronymic = "Иванович",
                            Phone = "89085149822",
                            PositionId = 1
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1985, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 3,
                            Dismissed = false,
                            Email = "evg@mail.ru",
                            EmploymentDate = new DateTime(2000, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Евгений",
                            LastName = "Соловьев",
                            Patronymic = "Генадьевич",
                            Phone = "89085949822",
                            PositionId = 2
                        });
                });

            modelBuilder.Entity("EmployeeDirectory.Data.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Менеджер",
                            Salary = 20000m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Инженер",
                            Salary = 10000m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Бухгалтер",
                            Salary = 40000m
                        });
                });

            modelBuilder.Entity("EmployeeDirectory.Data.Employee", b =>
                {
                    b.HasOne("EmployeeDirectory.Data.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeDirectory.Data.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("EmployeeDirectory.Data.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EmployeeDirectory.Data.Position", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
