using System;
using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Service
{
    public interface IStudentService
    {

        public Student AddStudent (Student student);

        public Student FindById(Guid id);
        public Student FindByEmail(String email);
        public Student GetStudentWithTeachers(Guid id);

        public List<Student> ListAll();
         
    }
}