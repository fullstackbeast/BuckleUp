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
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student AddNewStudent(Student student)
        {
            return _studentRepository.Add(student);
        }

        public Student Enroll(Guid id, Guid courseID)
        {
            throw new NotImplementedException();
        }

        public Student FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Student FindById(Guid id)
        {
           return _studentRepository.FindById(id);
        }

         public List<Student> GetAllStudentOfferingACourse(Guid courseId)
        {
            
            return _studentRepository.FindAllStudentOfferingACourse(courseId);
        }

        public Student GetStudentWithTeacherCoursesAndAssessmentsById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentWithTeacherCoursesById(Guid id)
        {
             return _studentRepository.FindStudentWithTeacherCoursesById(id);
        }

        public Student GetStudentWithTeachers(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Student> ListAll()
        {
            throw new NotImplementedException();
        }

        public Student RegisterAssessmentPerformance(Guid id, Guid assessmentId, int score, int numberOfQuestionsWhenTaken)
        {
            throw new NotImplementedException();
        }

        public Student UnEnroll(Guid id, StudentCourse studentCourse)
        {
            throw new NotImplementedException();
        }

        public Student UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}