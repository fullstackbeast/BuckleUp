using System;
using System.Collections.Generic;
using System.Linq;
using BuckleUp.Interface.Repository;
using BuckleUp.Interface.Service;
using BuckleUp.Models;
using BuckleUp.Models.Entities;
using BuckleUp.Models.ViewModels;

namespace BuckleUp.Domain.Service
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;

        public AssessmentService(IAssessmentRepository assessmentRepository, IStudentService studentService, IGroupService groupService)
        {
            _studentService = studentService;
            _groupService = groupService;
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

        public Assessment AssignToGroup(Guid assessmentId, Guid groupId)
        {
            var assessment = _assessmentRepository.FindAssessmentAndGroupsWithStudentsById(assessmentId);
            var group = _groupService.GetGroupWithStudentsAndAssessmentsById(groupId);
            
            
            if (assessment == null)
            {
                return null;
            }

            if (
                assessment.GroupAssessments
                    .FirstOrDefault(ga =>
                        ga.AssessmentId.Equals(assessmentId)
                        && ga.GroupId.Equals(groupId)) == null)
            {
                assessment.GroupAssessments.Add(new GroupAssessment
                {
                    AssessmentId = assessmentId,
                    GroupId = groupId
                });

                foreach (var studentGroup in group.StudentGroups)
                {
                    studentGroup.Student.StudentAssessments.Add(new StudentAssessment
                    {
                        StudentId = studentGroup.Student.UserId,
                        AssessmentId = assessmentId,
                        HasTaken = false
                    });
                
                    //_studentService.UpdateStudent(studentGroup.Student);
                }
                
                _groupService.UpdateGroup(group);
            }
            
            return _assessmentRepository.Update(assessment);
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