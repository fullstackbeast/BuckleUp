using System;
using System.Collections.Generic;
using System.Linq;
using BuckleUp.Interface.Repository;
using BuckleUp.Models;
using BuckleUp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuckleUp.Domain.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDBContext _context;
        public TeacherRepository(AppDBContext appDBContext)
        {
            _context = appDBContext;
        }

        public Teacher Add(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.Users.Add(new User
            {
                Id = teacher.Id,
                Email = teacher.Email,
                Password = teacher.Password,
                Type = "Teacher"
            });
            _context.SaveChanges();
            return teacher;
        }



        public Teacher FindById(Guid id)
        {
            return _context.Teachers.Find(id);
        }

        public Teacher FindTeacherWithCoursesById(Guid id)
        {
            return _context.Teachers
            .Include(tch => tch.Courses)
            .FirstOrDefault(tch => tch.Id == id);
        }

        public Teacher FindTeacherWithStudentsAndCoursesById(Guid id)
        {
            return _context.Teachers
            .Include(tch => tch.Courses)
           .Include(tch => tch.TeacherStudents)
           .ThenInclude(tchstd => tchstd.Student).FirstOrDefault(tch => tch.Id == id);
        }

        public Teacher FindTeacherWithStudentsById(Guid id)
        {
            return _context.Teachers
           .Include(tch => tch.TeacherStudents)
           .ThenInclude(tchstd => tchstd.Student).FirstOrDefault(tch => tch.Id == id);
        }

        public List<Teacher> ListAll()
        {
            return _context.Teachers.ToList();
        }

        public Teacher Update(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
            return teacher;
        }
    }
}