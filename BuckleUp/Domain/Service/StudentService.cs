using System;
using System.Collections.Generic;
using BuckleUp.Interface.Repository;
using BuckleUp.Interface.Service;
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

        public Student AddStudent(Student student)
        {
            student.Id = Guid.NewGuid();
            student.Role = "Student";

            return _studentRepository.Add(student);
        }

        public Student FindByEmail(string email)
        {
            return _studentRepository.FindByEmail(email);
        }

        public Student FindById(Guid id)
        {
            return _studentRepository.FindById(id);
        }

        public Student GetStudentWithTeachers(Guid id)
        {
            return _studentRepository.FindStudentWithTeachersById(id);
        }

        public List<Student> ListAll()
        {
            return _studentRepository.ListAll();
        }
    }
}