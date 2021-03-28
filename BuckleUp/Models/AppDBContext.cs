using BuckleUp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuckleUp.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // Configuring Many to many relationship between Teacher and Student
            modelBuilder.Entity<TeacherStudent>()
            .HasKey(Ts => new {Ts.TeacherId, Ts.StudentId});
            
            modelBuilder.Entity<TeacherStudent>()
            .HasOne(Ts => Ts.Teacher)
            .WithMany(Tch => Tch.TeacherStudents)
            .HasForeignKey(Ts => Ts.TeacherId);
            
            modelBuilder.Entity<TeacherStudent>()
            .HasOne(Ts => Ts.Student)
            .WithMany(Std => Std.TeacherStudents)
            .HasForeignKey(Ts => Ts.StudentId);


            // Configuring Many to many relationship between Student and Course
            modelBuilder.Entity<StudentCourse>()
            .HasKey(Sc => new {Sc.StudentId, Sc.CourseId});
            
            modelBuilder.Entity<StudentCourse>()
            .HasOne(Sc => Sc.Student)
            .WithMany(Std => Std.StudentCourses)
            .HasForeignKey(Sc => Sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
            .HasOne(Sc => Sc.Course)
            .WithMany(Cou => Cou.StudentCourses)
            .HasForeignKey(Sc => Sc.CourseId);


            // Configuring Many to many relationship between Student and Assessment
            modelBuilder.Entity<StudentAssessment>()
            .HasKey(Sa => new {Sa.StudentId, Sa.AssessmentId});
            
            modelBuilder.Entity<StudentAssessment>()
            .HasOne(Sa => Sa.Student)
            .WithMany(Std => Std.StudentAssessments)
            .HasForeignKey(Sa => Sa.StudentId);

            modelBuilder.Entity<StudentAssessment>()
            .HasOne(Sa => Sa.Assessment)
            .WithMany(Ass => Ass.StudentAssessments)
            .HasForeignKey(Sa => Sa.AssessmentId);

            // Configuring Many to many relationship between Quiz and Player
            modelBuilder.Entity<QuizPlayer>()
            .HasKey(Qp => new {Qp.QuizId, Qp.PlayerId});
            
            modelBuilder.Entity<QuizPlayer>()
            .HasOne(Qp => Qp.Quiz)
            .WithMany(Qz => Qz.QuizPlayers)
            .HasForeignKey(Qp => Qp.QuizId);

            modelBuilder.Entity<QuizPlayer>()
            .HasOne(Qp => Qp.Player)
            .WithMany(ply => ply.QuizPlayers)
            .HasForeignKey(Qp => Qp.PlayerId);
            
        }

        public DbSet<User> Users {get; set;}
        public DbSet<Teacher> Teachers {get; set;}
        public DbSet<Student> Students {get; set;}
        public DbSet<Course> Courses {get; set;}
        public DbSet<Assessment> Assessments {get; set;}
        public DbSet<Role> Roles {get; set;}
        public DbSet<AssessmentQuestion> AssessmentQuestions {get; set;}
        public DbSet<QuizQuestion> QuizQuestions {get; set;}

        public DbSet<Quiz> Quizzes {get; set;}
        public DbSet<Player> Players {get; set;}
        public DbSet<PersonalUser> PersonalUsers {get; set;}
    }
}