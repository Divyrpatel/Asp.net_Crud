﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.DataAccess;

#nullable disable

namespace Project.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Project.Models.City", b =>
                {
                    b.Property<int>("City_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("City_Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State_Id")
                        .HasColumnType("int");

                    b.Property<int>("State_Id1")
                        .HasColumnType("int");

                    b.HasKey("City_Id");

                    b.HasIndex("State_Id");

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("Project.Models.Person", b =>
                {
                    b.Property<int>("Person_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Person_Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("City_Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("State_Id")
                        .HasColumnType("int");

                    b.HasKey("Person_Id");

                    b.HasIndex("City_Id");

                    b.HasIndex("State_Id");

                    b.ToTable("Persons", (string)null);
                });

            modelBuilder.Entity("Project.Models.State", b =>
                {
                    b.Property<int>("State_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("State_Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("State_Id");

                    b.ToTable("States", (string)null);
                });

            modelBuilder.Entity("Project.Models.City", b =>
                {
                    b.HasOne("Project.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("State_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("Project.Models.Person", b =>
                {
                    b.HasOne("Project.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("City_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("State_Id");

                    b.Navigation("City");

                    b.Navigation("State");
                });
#pragma warning restore 612, 618
        }
    }
}
