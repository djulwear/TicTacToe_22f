﻿// <auto-generated />
using System;
using ConsoleAppDb.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleAppDb.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("ConsoleAppDb.Domain.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ConsoleAppDb.Domain.Homework", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("AverageGrade")
                        .HasColumnType("REAL");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Homeworks");
                });

            modelBuilder.Entity("ConsoleAppDb.Domain.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("ConsoleAppDb.Domain.PersonCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("FinalGrade")
                        .HasColumnType("REAL");

                    b.Property<double?>("HomeworkAverageGrade")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsStudent")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonCourses");
                });

            modelBuilder.Entity("ConsoleAppDb.Domain.PersonCourseHomework", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Grade")
                        .HasColumnType("REAL");

                    b.Property<int>("HomeworkId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonCourseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HomeworkId");

                    b.HasIndex("PersonCourseId");

                    b.ToTable("PersonCourseHomeworks");
                });

            modelBuilder.Entity("ConsoleAppDb.Domain.Homework", b =>
                {
                    b.HasOne("ConsoleAppDb.Domain.Course", "Course")
                        .WithMany("Homeworks")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ConsoleAppDb.Domain.PersonCourse", b =>
                {
                    b.HasOne("ConsoleAppDb.Domain.Course", "Course")
                        .WithMany("PersonCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleAppDb.Domain.Person", "Person")
                        .WithMany("PersonCourses")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("ConsoleAppDb.Domain.PersonCourseHomework", b =>
                {
                    b.HasOne("ConsoleAppDb.Domain.Homework", "Homework")
                        .WithMany()
                        .HasForeignKey("HomeworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleAppDb.Domain.PersonCourse", "PersonCourse")
                        .WithMany()
                        .HasForeignKey("PersonCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Homework");

                    b.Navigation("PersonCourse");
                });

            modelBuilder.Entity("ConsoleAppDb.Domain.Course", b =>
                {
                    b.Navigation("Homeworks");

                    b.Navigation("PersonCourses");
                });

            modelBuilder.Entity("ConsoleAppDb.Domain.Person", b =>
                {
                    b.Navigation("PersonCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
