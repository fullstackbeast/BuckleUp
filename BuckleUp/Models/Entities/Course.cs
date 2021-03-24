using System;
using System.Collections.Generic;

namespace BuckleUp.Models.Entities
{
    public class Course : BaseEntity
    {
        public Course()
        {
            StudentCourses = new List<StudentCourse>();
        }

        public string Title { get; set; }
        public Teacher Teacher { get; set; }
        public Guid TeacherId {get; set;}
        public IEnumerable<StudentCourse> StudentCourses{get; set;}



    }
}