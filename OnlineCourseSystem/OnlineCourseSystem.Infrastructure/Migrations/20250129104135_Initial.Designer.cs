﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineCourseSystem.Infrastructure.Data;

#nullable disable

namespace OnlineCourseSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250129104135_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineCourseSystem.Infrastructure.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Course's identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Course's description");

                    b.Property<int>("EnrolledStudents")
                        .HasColumnType("int")
                        .HasComment("Course's enrolled students");

                    b.Property<int>("MaxStudents")
                        .HasColumnType("int")
                        .HasComment("Course's max students");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Course's name");

                    b.HasKey("Id");

                    b.ToTable("Courses", t =>
                        {
                            t.HasComment("Represents the Course entity");
                        });
                });

            modelBuilder.Entity("OnlineCourseSystem.Infrastructure.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Student's identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Student's email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Student's first name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Student's last name");

                    b.HasKey("Id");

                    b.ToTable("Students", t =>
                        {
                            t.HasComment("Represents the Student entity");
                        });
                });

            modelBuilder.Entity("OnlineCourseSystem.Infrastructure.Models.StudentCourse", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasComment("Course's identifier");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasComment("Student's identifier");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2")
                        .HasComment("Student enrollment date");

                    b.Property<string>("Progress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Student progress");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourses", t =>
                        {
                            t.HasComment("Represents the Student Course mapping entity");
                        });
                });

            modelBuilder.Entity("OnlineCourseSystem.Infrastructure.Models.StudentCourse", b =>
                {
                    b.HasOne("OnlineCourseSystem.Infrastructure.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OnlineCourseSystem.Infrastructure.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("OnlineCourseSystem.Infrastructure.Models.Course", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("OnlineCourseSystem.Infrastructure.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
