using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class TeacherCourseListVM
    {
        public TeacherCourseListVM()
        {
            Courses = new List<Course>();
        }

        public List<Course> Courses {get; set;}
    }
}