using System;
using System.Collections.Generic;
using System.Linq;
using BuckleUp.Interface.Repository;
using BuckleUp.Models;
using BuckleUp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuckleUp.Domain.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDBContext _context;
        public StudentRepository(AppDBContext appDBContext)
        {
            _context = appDBContext;
        }

        public Student Add(Student student)
        {
            _context.Students.Add(student);
            _context.Users.Add(new User
            {
                Id = student.Id,
                Email = student.Email,
                Password = student.Password,
                Type = "Student"
            });
            _context.SaveChanges();
            return student;
        }

        public Student FindByEmail(string email)
        {
            return _context.Students.FirstOrDefault(stud => stud.Email == email);
        }

        public Student FindById(Guid id)
        {
            return _context.Students.Find(id);
        }

        public Student FindStudentWithTeachersById(Guid id)
        {
            return _context.Students
            .Include(stud => stud.TeacherStudents)
            .ThenInclude(tchstd => tchstd.Teacher).FirstOrDefault(tch=> tch.Id == id);
        }
        public Student FindStudentWithTeacherCoursesById(Guid id)
        {
            return _context.Students
            .Include(stud => stud.TeacherStudents)
            .ThenInclude(tchstd => tchstd.Teacher)
            .ThenInclude(tch => tch.Courses)
            .Include(stud => stud.StudentCourses)
            .ThenInclude(stdcou => stdcou.Course)
            .FirstOrDefault(tch=> tch.Id == id);
        }

        public List<Student> ListAll()
        {
            return _context.Students.ToList();
        }

        public Student FindStudentWithCoursesById(Guid id)
        {
             return _context.Students
            .Include(stud => stud.StudentCourses)
            .ThenInclude(stdcou => stdcou.Course).FirstOrDefault(tch=> tch.Id == id);
        }

        public Student Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return student;
        }
    }
}