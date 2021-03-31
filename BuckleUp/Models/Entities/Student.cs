using System;
using System.Collections.Generic;
namespace BuckleUp.Models.Entities
{
    public class Student
    {

         public Student() 
        {
            StudentAssessments = new List<StudentAssessment>();
            TeacherStudents = new List<TeacherStudent>();
            StudentCourses = new List<StudentCourse>();
        }
        public User User {get; set;}
        public Guid UserId {get; set;} 
        public ICollection<TeacherStudent> TeacherStudents {get; set;}
        public ICollection<StudentCourse> StudentCourses {get; set;}
        public ICollection<StudentAssessment> StudentAssessments {get; set;}

    }
}