using System;
using System.Collections.Generic;
using System.Linq;
using BuckleUp.Interface.Repository;
using BuckleUp.Models;
using BuckleUp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuckleUp.Domain.Repository
{
    public class CourseRepository : ICourseRepository 
       {
        private readonly AppDBContext _context;
        public CourseRepository(AppDBContext context)
        {
            _context = context;
        }

        public Course Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;

        }

        public List<Course> FindAllCoursesByTeacher(Guid teacherID)
        {
            return _context.Courses.Where(cou => cou.TeacherId == teacherID).ToList();
        }

        public Course FindById(Guid id)
        {
            return _context.Courses.Find(id);
        }
    }
}