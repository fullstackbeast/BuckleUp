using System;
using BuckleUp.Interface.Repository;
using BuckleUp.Models;
using BuckleUp.Models.Entities;

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

        public Course FindById(Guid id)
        {
            return _context.Courses.Find(id);
        }

        public Course Update(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
            return course;
        }
    }
}