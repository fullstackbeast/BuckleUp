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
        public Student GetStudentWithTeacherCoursesById (Guid id);
        public Student Enroll (Guid id, Guid courseID);

        public List<Student> ListAll();
         
    }
}