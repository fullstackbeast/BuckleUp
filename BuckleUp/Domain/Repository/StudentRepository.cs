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
        public StudentRepository(AppDBContext context)
        {
            _context = context;
        }
        public Student Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }
        
        public Student Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return student;
        }

        public List<Student> FindAllStudentOfferingACourse(Guid courseId)
        {
            List<Student> students = _context.Students
            .Include(stud => stud.StudentCourses).ToList();

            List<Student> studentOffering = new List<Student>();

            foreach (var student in students)
            {

                foreach (var stdcou in student.StudentCourses)
                {
                    if (stdcou.CourseId == courseId)
                    {
                        studentOffering.Add(student);
                    }
                }
            }

            return studentOffering;
        }

        public Student FindById(Guid id)
        {
            return _context.Students.Find(id);
        }

        public Student FindStudentWithCoursesAndAssessmentById(Guid id)
        {
             return _context.Students
            .Include(stud => stud.StudentCourses)
            .ThenInclude(stdcou => stdcou.Course)
            .Include(std => std.StudentAssessments)
            .ThenInclude(stdAss => stdAss.Assessment)
            .Include(stud => stud.StudentGroups)
            .ThenInclude(stdgrp => stdgrp.Group)
            .FirstOrDefault(std=> std.UserId == id);
        }

        public Student FindStudentWithCoursesById(Guid id)
        {
            return _context.Students
            .Include(std => std.StudentCourses)
            .ThenInclude(stdcou => stdcou.Course)
            .FirstOrDefault(std => std.UserId.Equals(id));
        }

        public Student FindStudentWithTeacherCoursesById(Guid id)
        {
            return _context.Students
            .Include(stud => stud.TeacherStudents)
            .ThenInclude(tchstd => tchstd.Teacher)
            .ThenInclude(tch => tch.Courses)
            .Include(stud => stud.StudentCourses)
            .ThenInclude(stdcou => stdcou.Course)
            .FirstOrDefault(std => std.UserId == id);
        }


        public Student FindStudentWithTeachersById(Guid id)
        {
            return _context.Students
            .Include(stud => stud.TeacherStudents)
            .ThenInclude(tchstd => tchstd.Teacher).FirstOrDefault(tch => tch.UserId == id);
        }

        public Student FindStudentWithAssessmentsById(Guid id)
        {
            return _context.Students
            .Include(std => std.StudentAssessments)
            .ThenInclude(stdass => stdass.Assessment)
            .Include(st => st.StudentCourses)
            .FirstOrDefault(std => std.UserId.Equals(id));
        }
    }

}