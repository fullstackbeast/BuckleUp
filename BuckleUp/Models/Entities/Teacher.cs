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

        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<TeacherStudent> TeacherStudents { get; set; }
        public IEnumerable<Assessment> Assessments { get; set; }
    }
}