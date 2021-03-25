using System;
using System.Collections.Generic;
using BuckleUp.Models;
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
        public Student UnEnroll (Guid id, StudentCourse studentCourse);

        public Student UpdateStudent(Student student);

        public List<Student> ListAll();
         
    }
}