using System;
using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface IStudentRepository
    {
        public Student Add(Student student);
        public Student FindById(Guid id);
        public Student FindByEmail(string email);
        public Student FindStudentWithTeachersById(Guid id);
        public List<Student> ListAll();
    }
}