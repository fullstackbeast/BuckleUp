using System;
using System.Collections.Generic;
namespace BuckleUp.Models.Entities
{
    public class Student : Details
    {
        public Student() 
        {
            StudentAssessments = new List<StudentAssessment>();
            TeacherStudents = new List<TeacherStudent>();
            StudentCourses = new List<StudentCourse>();
        }

        public IEnumerable<TeacherStudent> TeacherStudents {get; set;}
        public IEnumerable<StudentCourse> StudentCourses {get; set;}
        public IEnumerable<StudentAssessment> StudentAssessments {get; set;}
        public DateTime DateOfBirth {get; set;}
    }
}