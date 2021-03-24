using System;
using System.Collections.Generic;

namespace BuckleUp.Models.Entities
{
    public class Teacher : Details 
    {
        public Teacher()
        {
            Courses = new List<Course>();
            Assessments = new List<Assessment>();
            TeacherStudents = new List<TeacherStudent>();
        }
        public ICollection<Course> Courses { get; set; }
        public ICollection<TeacherStudent> TeacherStudents { get; set; }
        public ICollection<Assessment> Assessments { get; set; }
    }
}