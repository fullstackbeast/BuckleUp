using System;
using System.Collections.Generic;
using BuckleUp.Interface.Repository;
using BuckleUp.Interface.Service;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public Teacher AddTeacher(Teacher teacher)
        {
            teacher.Id = Guid.NewGuid();
            teacher.Role = "Teacher";

            return _teacherRepository.Add(teacher);
        }

        public Teacher FindById(Guid id)
        {
            return _teacherRepository.FindById(id);
        }

        public List<Teacher> ListAll()
        {
            return _teacherRepository.ListAll();
        }
    }
}