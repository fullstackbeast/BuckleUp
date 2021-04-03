using System;
using System.Collections.Generic;
using BuckleUp.Models;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Service
{
    public interface IStudentService
    {
        public Student AddNewStudent(Student student);
        public Student FindById(Guid id);
        public Student GetEnrolledCourseAssessments(Guid id);
        public Student FindByEmail(String email);
        public Student GetStudentWithTeachers(Guid id);
        public Student GetStudentWithAssessments(Guid id);
        public Student GetStudentWithTeacherCoursesById(Guid id);
        public Student GetStudentWithTeacherCoursesAndAssessmentsById(Guid id);
        public Student Enroll(Guid id, Guid courseID);
        public Student UnEnroll(Guid id, StudentCourse studentCourse);
        public Student RegisterAssessmentPerformance(Guid id, Guid assessmentId, int score, int numberOfQuestionsWhenTaken);
        public List<Student> GetAllStudentOfferingACourse(Guid courseId);
        public Student UpdateStudent(Student student);
        public List<Student> ListAll();
    }
}