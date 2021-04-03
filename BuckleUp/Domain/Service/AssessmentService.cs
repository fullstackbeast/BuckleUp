using System;
using System.Collections.Generic;
using BuckleUp.Interface.Repository;
using BuckleUp.Interface.Service;
using BuckleUp.Models;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Service
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IStudentService _studentService;
        public AssessmentService(IAssessmentRepository assessmentRepository, IStudentService studentService)
        {
            _studentService = studentService;
            _assessmentRepository = assessmentRepository;
        }



        public Assessment GetAssessmentAndQuestionsById(Guid id)
        {
            return _assessmentRepository.FindAssessmentAndQuestionsById(id);
        }

        public Assessment GetById(Guid id)
        {
            return _assessmentRepository.FindById(id);
        }

        public Assessment AddAssessmentToStudents(Assessment assessment)
        {
            List<Student> studentOfferingCourse = _studentService.GetAllStudentOfferingACourse(assessment.CourseId);

            foreach (var student in studentOfferingCourse)
            {
                StudentAssessment studentAssessment = new StudentAssessment
                {
                    StudentId = student.UserId,
                    AssessmentId = assessment.Id
                };
                assessment.StudentAssessments.Add(studentAssessment);
            }

            _assessmentRepository.Update(assessment);

            return assessment;
        }

        public Assessment Add(Assessment assessment)
        {
            foreach (var assessmentQuestion in assessment.Questions)
            {
                assessmentQuestion.AssessmentId = Guid.NewGuid();
            }

            _assessmentRepository.Add(assessment);

            return assessment;
        }

        public List<Assessment> GetAllCourseAssessment(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public Assessment GetAssessmentAndQuestionsWithStudentsById(Guid id)
        {
            return _assessmentRepository.FindAssessmentAndQuestionsWithStudentsById(id);
        }
    }
}