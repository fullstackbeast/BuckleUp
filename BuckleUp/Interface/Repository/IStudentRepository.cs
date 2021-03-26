using System;
using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface IStudentRepository
    {
        public Student Add(Student student);
        public Student Update(Student student);
        public Student FindById(Guid id);
        public Student FindByEmail(string email);
        public Student FindStudentWithTeachersById(Guid id);
        public Student FindStudentWithCoursesById(Guid id);
        public Student FindStudentWithCoursesAndAssessmentById(Guid id);
        public Student FindStudentWithTeacherCoursesById(Guid id);
        public Student FindStudentWithTeacherCoursesAndAssessmentById(Guid id);
        public List<Student> FindAllStudentOfferingACourse(Guid courseId);
        public List<Student> ListAll();
    }
}