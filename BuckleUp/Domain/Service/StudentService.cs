using System.Linq;
using System;
using System.Collections.Generic;
using BuckleUp.Interface.Repository;
using BuckleUp.Interface.Service;
using BuckleUp.Models;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAssessmentRepository _assessmentRepository;

        public StudentService(IStudentRepository studentRepository, IAssessmentRepository assessmentRepository)
        {
            _assessmentRepository = assessmentRepository;
            _studentRepository = studentRepository;
        }

        public Student AddStudent(Student student)
        {
            student.Id = Guid.NewGuid();
            student.Role = "Student";

            return _studentRepository.Add(student);
        }

        public Student Enroll(Guid id, Guid courseId)
        {
            Student student = _studentRepository.FindStudentWithCoursesAndAssessmentById(id);

            StudentCourse studentCourse = new StudentCourse
            {
                StudentId = id,
                CourseId = courseId
            };
            student.StudentCourses.Add(studentCourse);

            List<Assessment> courseAssessments = _assessmentRepository.FindAllCourseAssessment(courseId);

            foreach (var assessment in courseAssessments)
            {
                StudentAssessment studentAssessment = new StudentAssessment
                {
                    StudentId = id,
                    AssessmentId = assessment.Id
                };
                student.StudentAssessments.Add(studentAssessment);
            }

            _studentRepository.Update(student);

            return student;

        }
        public Student UnEnroll(Guid id, StudentCourse studentCourse)
        {
            Student student = _studentRepository.FindStudentWithTeacherCoursesAndAssessmentById(id);
            List<StudentAssessment> studentAssessments =  student.StudentAssessments
                .Where(stdass => !(stdass.Assessment.CourseId.Equals(studentCourse.CourseId)))
                .ToList();

            student.StudentAssessments = studentAssessments;

            student.StudentCourses.Remove(studentCourse);

            _studentRepository.Update(student);

            return student;
        }

        public Student FindByEmail(string email)
        {
            return _studentRepository.FindByEmail(email);
        }

        public Student FindById(Guid id)
        {
            return _studentRepository.FindById(id);
        }

        public Student GetStudentWithTeacherCoursesById(Guid id)
        {
            return _studentRepository.FindStudentWithTeacherCoursesById(id);
        }

        public Student GetStudentWithTeachers(Guid id)
        {
            return _studentRepository.FindStudentWithTeachersById(id);
        }

        public List<Student> ListAll()
        {
            return _studentRepository.ListAll();
        }

        public Student UpdateStudent(Student student)
        {
            return _studentRepository.Update(student);
        }

        public List<Student> GetAllStudentOfferingACourse(Guid courseId)
        {
            return _studentRepository.FindAllStudentOfferingACourse(courseId);
        }

        public Student GetStudentWithTeacherCoursesAndAssessmentsById(Guid id)
        {
            return _studentRepository.FindStudentWithTeacherCoursesAndAssessmentById(id);
        }
    }
}