using System;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models
{
    public class StudentCourse
    {
        public Guid StudentId {get; set;}
        public Student Student {get; set;}

        
        public Guid CourseId {get; set;}
        public Course Course {get; set;}

        public bool IsEnrolled {get; set;} = true;
        
    }
}