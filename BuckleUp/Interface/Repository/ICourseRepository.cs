using System.Collections.Generic;
using System;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface ICourseRepository
    {

        public Course Add(Course course);

        public Course FindById(Guid id);

        public List<Course> FindAllCoursesByTeacher(Guid teacherID); 

    }
}