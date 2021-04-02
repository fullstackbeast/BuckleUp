using System;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Service
{
    public interface ITeacherService
    {
        public Teacher AddNewTeacher(Teacher teacher);
        public Teacher AddStudent(Guid teacherId, Student student);
        public Teacher AddCourse(Guid teacherId, string title);
        public Teacher FindById(Guid id);
        public Teacher RemoveStudent(Guid teacherId, Student student);
        public Teacher AddAssessment(Guid teacherId, Assessment assessment);
        public Teacher DeleteCourse(Guid courseId, Guid teacherId);
        public Teacher GetTeacherWithStudents(Guid id);
        public Teacher GetTeacherWithCourses(Guid id);
        public Teacher GetTeacherWithStudentsAndCourses(Guid id);
    }
}