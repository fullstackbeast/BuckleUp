using System;
using System.Collections.Generic;
using System.Linq;
using BuckleUp.Interface.Repository;
using BuckleUp.Interface.Service;
using BuckleUp.Models;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAssessmentRepository _assessmentRepository;

        public StudentService(IStudentRepository studentRepository, IAssessmentRepository assessmentRepository)
        {
            _assessmentRepository = assessmentRepository;
            _studentRepository = studentRepository;
        }

        public Student AddNewStudent(Student student)
        {
            return _studentRepository.Add(student);
        }

        public Student Enroll(Guid id, Guid courseId)
        {
            Student student = _studentRepository.FindStudentWithCoursesAndAssessmentById(id);

            StudentCourse alreadyEnrolledCourse = student.StudentCourses
                                .FirstOrDefault(stdcou => stdcou.CourseId.Equals(courseId));
            
            if(alreadyEnrolledCourse!=null && !alreadyEnrolledCourse.IsEnrolled){

                List<StudentCourse> studentCourses = student.StudentCourses.ToList();
                studentCourses.Remove(alreadyEnrolledCourse);

                alreadyEnrolledCourse.IsEnrolled = true;

                studentCourses.Add(alreadyEnrolledCourse);

                student.StudentCourses = studentCourses;

                return _studentRepository.Update(student);
            }

            StudentCourse studentCourse = new StudentCourse
            {
                StudentId = id,
                CourseId = courseId,
                IsEnrolled = true
            };
            student.StudentCourses.Add(studentCourse);

            List<Assessment> courseAssessments = _assessmentRepository.FindAllCourseAssessment(courseId);

            foreach (var assessment in courseAssessments)
            {
                StudentAssessment studentAssessment = new StudentAssessment
                {
                    StudentId = id,
                    AssessmentId = assessment.Id
                };
                student.StudentAssessments.Add(studentAssessment);
            }

            _studentRepository.Update(student);

            return student;
        }

        public Student UnEnroll(Guid id, StudentCourse studentCourse)
        {
              Student student = _studentRepository.FindStudentWithCoursesById(id);
              List<StudentCourse> studentCourses = student.StudentCourses.ToList();

              studentCourses.Remove(studentCourse);

              studentCourse.IsEnrolled = false;
              
              studentCourses.Add(studentCourse);
              
              student.StudentCourses = studentCourses;
              
              return _studentRepository.Update(student);
        }

        public Student FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Student FindById(Guid id)
        {
            return _studentRepository.FindById(id);
        }

        public List<Student> GetAllStudentOfferingACourse(Guid courseId)
        {

            return _studentRepository.FindAllStudentOfferingACourse(courseId);
        }

        public Student GetStudentWithTeacherCoursesAndAssessmentsById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentWithTeacherCoursesById(Guid id)
        {
            return _studentRepository.FindStudentWithTeacherCoursesById(id);
        }

        public Student GetStudentWithTeachers(Guid id)
        {
            return _studentRepository.FindStudentWithTeachersById(id);
        }

        public List<Student> ListAll()
        {
            throw new NotImplementedException();
        }

        public Student RegisterAssessmentPerformance(Guid id, Guid assessmentId, int score, int numberOfQuestionsWhenTaken)
        {
            Student student = _studentRepository.FindStudentWithCoursesAndAssessmentById(id);

            StudentAssessment studentAssessment = student.StudentAssessments.FirstOrDefault(
                stdass => stdass.AssessmentId.Equals(assessmentId)
            );

            studentAssessment.HasTaken = true;
            studentAssessment.score = score;

            return _studentRepository.Update(student);
        }
        public Student UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentWithAssessments(Guid id)
        {
            return _studentRepository.FindStudentWithAssessmentsById(id);
        }

        public Student GetEnrolledCourseAssessments(Guid id)
        {
            Student student = _studentRepository.FindStudentWithCoursesAndAssessmentById(id);
            List<StudentAssessment> studentAssessments = student.StudentAssessments.ToList();

            foreach (var stdAss in student.StudentAssessments)
            {
                StudentCourse studentCourse = student.StudentCourses
                .FirstOrDefault(stdcou => stdcou.CourseId.Equals(stdAss.Assessment.CourseId));

                if (!studentCourse.IsEnrolled || studentCourse==null) studentAssessments.Remove(stdAss);
            }

            student.StudentAssessments = studentAssessments;

            return student;
        }
    }
}