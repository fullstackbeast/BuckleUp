using System;
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

        public Course FindById(Guid id)
        {
            return _context.Courses.Find(id);
        }
        
        public void Delete(Guid id)
        {
            var course = _context.Courses.Find(id);
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }

        public Course FindWithAssessmentsById(Guid id)
        {
            return _context.Courses
                .Include(c => c.Assessments)
                .FirstOrDefault(c => c.Id.Equals(id));
        }

        public Course Update(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
            return course;
        }
    }
}