using System;
using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class StudentCourseListVM
    {
        public StudentCourseListVM()
        {
            Courses = new List<Course>();
        }

        public List<Course> Courses {get; set;}
        public Guid TeacherId {get; set;}
        public Guid CourseId {get; set;}
        public int SourceId {get; set;}
    }
}