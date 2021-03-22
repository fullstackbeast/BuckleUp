using System.Collections.Generic;

namespace BuckleUp.Models.Entities
{
    public class Course : BaseEntity
    {
        public Course()
        {
            StudentCourses = new List<StudentCourse>();
            Assessments = new List<Assessment>();
        }

        public string Title { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<Assessment> Assessments{get; set;}
        public IEnumerable<StudentCourse> StudentCourses{get; set;}



    }
}