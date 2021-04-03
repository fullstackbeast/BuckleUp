using System.Collections.Generic;
using System;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface IStudentRepository
    {
        public Student Add(Student student);
        public Student Update(Student student);
        public Student FindById(Guid id);
        public List<Student> FindAllStudentOfferingACourse(Guid courseId);
        public Student FindStudentWithTeacherCoursesById(Guid id);
        public Student FindStudentWithTeachersById(Guid id);
        public Student FindStudentWithCoursesById(Guid id);
        public Student FindStudentWithAssessmentsById(Guid id);
        public Student FindStudentWithCoursesAndAssessmentById(Guid id);
    }
}