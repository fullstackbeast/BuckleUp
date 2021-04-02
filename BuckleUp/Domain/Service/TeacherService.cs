using System;
using System.Linq;
using BuckleUp.Interface.Repository;
using BuckleUp.Interface.Service;
using BuckleUp.Models;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IAssessmentService _assessmentService;
        private readonly IStudentService _studentService;
        public TeacherService(ITeacherRepository teacherRepository, IStudentService studentService, ICourseRepository courseRepository, IAssessmentService assessmentService)
        {
            _studentService = studentService;
            _assessmentService = assessmentService;
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
        }


        public Teacher AddNewTeacher(Teacher teacher)
        {
            return _teacherRepository.Add(teacher);
        }

        public Teacher AddStudent(Guid teacherId, Student student)
        {
            Teacher teacher = _teacherRepository.FindById(teacherId);

            TeacherStudent teacherStudent = new TeacherStudent
            {
                TeacherId = teacher.UserId,
                Teacher = teacher,
                StudentId = student.UserId,
                Student = student,
                Status = "active"
            };

            teacher.TeacherStudents.Add(teacherStudent);
            _teacherRepository.Update(teacher);

            return teacher;
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

        public Teacher FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Teacher RemoveStudent(Guid teacherId, Student student)
        {
            Teacher teacher = _teacherRepository.FindTeacherWithStudentsAndCoursesById(teacherId);

            TeacherStudent studentToRemove = teacher.TeacherStudents.FirstOrDefault(tchstd => tchstd.StudentId == student.UserId);

            teacher.TeacherStudents.Remove(studentToRemove);

            foreach (var course in teacher.Courses)
            {
                StudentCourse studentCourse = student.StudentCourses.FirstOrDefault(stdcou => stdcou.CourseId == course.Id);

                student.StudentCourses.Remove(studentCourse);
            }

            _studentService.UpdateStudent(student);
            _teacherRepository.Update(teacher);

            return teacher;
        }

        public Teacher AddAssessment(Guid teacherId, Assessment assessment)
        {
            throw new NotImplementedException();

        }

        public Teacher DeleteCourse(Guid courseId, Guid teacherId)
        {
            throw new NotImplementedException();
        }

        public Teacher GetTeacherWithStudents(Guid id)
        {
            throw new NotImplementedException();
        }

        public Teacher GetTeacherWithCourses(Guid id)
        {
            return _teacherRepository.FindTeacherWithCoursesById(id);
        }

        public Teacher GetTeacherWithStudentsAndCourses(Guid id)
        {
            return _teacherRepository.FindTeacherWithStudentsAndCoursesById(id);
        }
    }
}