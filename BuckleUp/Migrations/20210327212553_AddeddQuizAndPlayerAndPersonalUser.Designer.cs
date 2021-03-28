﻿// <auto-generated />
using System;
using BuckleUp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BuckleUp.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20210327212553_AddeddQuizAndPlayerAndPersonalUser")]
    partial class AddeddQuizAndPlayerAndPersonalUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BuckleUp.Models.Entities.Assessment", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("CourseId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("StopTime")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("TeacherId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("BuckleUp.Models.Entities.Course", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("TeacherId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("BuckleUp.Models.Entities.PersonalUser", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("PersonalUsers");
                });

            modelBuilder.Entity("BuckleUp.Models.Entities.Player", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BuckleUp.Models.Entities.Question", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("AssessmentId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("CorrectOption")
                        .HasColumnType("text");

                    b.Property<string>("Option1")
                        .HasColumnType("text");

                    b.Property<string>("Option2")
                        .HasColumnType("text");

                    b.Property<string>("Option3")
                        .HasColumnType("text");

                    b.Property<string>("Option4")
                        .HasColumnType("text");

                    b.Property<string>("QuestionText")
                        .HasColumnType("text");

                    b.Property<byte[]>("QuizId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.HasIndex("AssessmentId");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("BuckleUp.Models.Entities.Quiz", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("CreatorId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("PersonalUserId")
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PersonalUserId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("BuckleUp.Models.Entities.QuizPlayer", b =>
                {
                    b.Property<byte[]>("QuizId")
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("PlayerId")
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("QuizId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("QuizPlayer");
                });

            modelBuilder.Entity("BuckleUp.Models.Entities.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BuckleUp.Models.Entities.Student", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("BuckleUp.Models.Entities.Teacher", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("BuckleUp.Models.Entities.User", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BuckleUp.Models.StudentAssessment", b =>
                {
                    b.Property<byte[]>("StudentId")
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("AssessmentId")
                        .HasColumnType("varbinary(16)");

                    b.Property<bool>("HasTaken")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("NumberOfQuestionsWhenTaken")
                        .HasColumnType("int");

                    b.Property<int>("score")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "AssessmentId");

                    b.HasIndex("AssessmentId");

                    b.ToTable("StudentAssessment");
                });

            modelBuilder.Entity("BuckleUp.Models.StudentCourse", b =>
                {
                    b.Property<byte[]>("StudentId")
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("CourseId")
                        .HasColumnType("varbinary(16)");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("BuckleUp.Models.TeacherStudent", b =>
                {
                    b.Property<byte[]>("TeacherId")
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("StudentId")
                        .HasColumnType("varbinary(16)");

                    b.HasKey("TeacherId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("TeacherStudent");
                });

            modelBuilder.Entity("BuckleUp.Models.Entities.Assessment", b =>
                {
                    b.HasOne("BuckleUp.Models.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuckleUp.Models.Entities.Teacher", "Teacher")
                        .WithMany("Assessments")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BuckleUp.Models.Entities.Course", b =>
                {
                    b.HasOne("BuckleUp.Models.Entities.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BuckleUp.Models.Entities.Question", b =>
                {
                    b.HasOne("BuckleUp.Models.Entities.Assessment", "Assessment")
                        .WithMany("Questions")
                        .HasForeignKey("AssessmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuckleUp.Models.Entities.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BuckleUp.Models.Entities.Quiz", b =>
                {
                    b.HasOne("BuckleUp.Models.Entities.PersonalUser", null)
                        .WithMany("Quizzes")
                        .HasForeignKey("PersonalUserId");
                });

            modelBuilder.Entity("BuckleUp.Models.Entities.QuizPlayer", b =>
                {
                    b.HasOne("BuckleUp.Models.Entities.Player", "Player")
                        .WithMany("QuizPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuckleUp.Models.Entities.Quiz", "Quiz")
                        .WithMany("QuizPlayers")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BuckleUp.Models.StudentAssessment", b =>
                {
                    b.HasOne("BuckleUp.Models.Entities.Assessment", "Assessment")
                        .WithMany("StudentAssessments")
                        .HasForeignKey("AssessmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuckleUp.Models.Entities.Student", "Student")
                        .WithMany("StudentAssessments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BuckleUp.Models.StudentCourse", b =>
                {
                    b.HasOne("BuckleUp.Models.Entities.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuckleUp.Models.Entities.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BuckleUp.Models.TeacherStudent", b =>
                {
                    b.HasOne("BuckleUp.Models.Entities.Student", "Student")
                        .WithMany("TeacherStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuckleUp.Models.Entities.Teacher", "Teacher")
                        .WithMany("TeacherStudents")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}