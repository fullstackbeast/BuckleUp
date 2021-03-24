using System;
using System.Collections.Generic;
using BuckleUp.Interface.Repository;
using BuckleUp.Interface.Service;
using BuckleUp.Models;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentService _studentService;
        private readonly ICourseRepository _courseRepository;

        public TeacherService(ITeacherRepository teacherRepository, IStudentService studentService, ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            _studentService = studentService;
            _teacherRepository = teacherRepository;
        }

        public Teacher AddTeacher(Teacher teacher)
        {
            teacher.Id = Guid.NewGuid();
            teacher.Role = "Teacher";

            return _teacherRepository.Add(teacher);
        }
        public Teacher AddStudent(Guid teacherId, Student student)
        {
            Teacher teacher = _teacherRepository.FindById(teacherId);

            TeacherStudent teacherStudent = new TeacherStudent
            {
                TeacherId = teacher.Id,
                Teacher = teacher,
                StudentId = student.Id,
                Student = student
            };

            teacher.TeacherStudents.Add(teacherStudent);
            _teacherRepository.Update(teacher);

            return teacher;
        }

        public Teacher FindById(Guid id)
        {
            return _teacherRepository.FindById(id);
        }

        public List<Teacher> ListAll()
        {
            return _teacherRepository.ListAll();
        }

        public Teacher GetTeacherWithStudents(Guid id)
        {
            return _teacherRepository.FindTeacherWithStudentsById(id);
        }

        public Teacher GetTeacherWithCourses(Guid id)
        {
            return _teacherRepository.FindTeacherWithCoursesById(id);
        }

        public Teacher GetTeacherWithStudentsAndCourses(Guid id)
        {
            return _teacherRepository.FindTeacherWithStudentsAndCoursesById(id);
        }

        public Teacher AddCourse(Guid teacherId, string title)
        {
            Course course = new Course
            {
                Id = Guid.NewGuid(),
                Title = title,
                TeacherId = teacherId
            };

            _courseRepository.Add(course);

            return _teacherRepository.FindById(teacherId);
        }
    }
}