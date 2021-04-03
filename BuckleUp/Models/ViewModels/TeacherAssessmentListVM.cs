using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class TeacherAssessmentListVM
    {
        public TeacherAssessmentListVM()
        {
            Courses = new List<Course>();
        }

        public Teacher Teacher {get; set;}
        public List<Course> Courses {get; set;}
    }
}