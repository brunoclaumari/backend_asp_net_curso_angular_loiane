﻿// <auto-generated />
using APICourse.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APICourse.Migrations
{
    [DbContext(typeof(CourseContext))]
    partial class CourseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("APICourse.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("PK_Id_tbCourse");

                    b.ToTable("tbCourse");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "back-end",
                            Name = "Java"
                        },
                        new
                        {
                            Id = 2,
                            Category = "back-end",
                            Name = "C sharp"
                        },
                        new
                        {
                            Id = 3,
                            Category = "front-end",
                            Name = "Angular"
                        },
                        new
                        {
                            Id = 4,
                            Category = "front-end",
                            Name = "React JS"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
