using System;
using System.Collections.Generic;
using BuckleUp.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BuckleUp.Models.ViewModels
{
    public class EnrollVM
    {

        public Guid TeacherId {get; set;}
        public Guid CourseId {get; set;}

        public Student Student {get; set;}
        public IEnumerable<SelectListItem> TeacherSelectList { get; set;}

        public ICollection<Course> TeacherCourses { get; set;}
    }
}