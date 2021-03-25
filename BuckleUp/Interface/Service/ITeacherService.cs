using System;
using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Service
{
    public interface ITeacherService
    {

        public Teacher AddTeacher(Teacher teacher);

        public Teacher FindById(Guid id);

        public List<Teacher> ListAll();
        public Teacher AddStudent(Guid teacherId, Student student);
        public Teacher RemoveStudent(Guid teacherId, Student student);
        public Teacher AddCourse(Guid teacherId, string title);
        public Teacher DeleteCourse(Guid courseId, Guid teacherId);
        public Teacher GetTeacherWithStudents(Guid id);
        public Teacher GetTeacherWithCourses(Guid id);
        public Teacher GetTeacherWithStudentsAndCourses(Guid id);

    }
}