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
        private readonly IGroupRepository _groupService;

        public AssessmentService(IAssessmentRepository assessmentRepository, IStudentService studentService,
            IGroupRepository groupService)
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

        public void DeleteAssessment(Guid id)
        {
            var assessment = _assessmentRepository.FindAssessmentAndGroupsWithStudentsById(id);
            
            foreach (var assessmentGroup in assessment.GroupAssessments.ToList().Where(assessmentGroup => assessmentGroup.AssessmentId.Equals(id)))
            {
                assessment.GroupAssessments.Remove(assessmentGroup);
            }

            foreach (var studentAssessment in assessment.StudentAssessments.ToList().Where(studentAssessment => studentAssessment.AssessmentId.Equals(id)))
            {
                assessment.StudentAssessments.Remove(studentAssessment);
            }

            _assessmentRepository.Update(assessment);
            _assessmentRepository.Delete(assessment);
        }

        public Assessment AssignToGroup(Guid assessmentId, Guid groupId)
        {
            var assessment = _assessmentRepository.FindAssessmentAndStudentsById(assessmentId);
            var group = _groupService.FindWithStudentsCourseAndAssessmentsBy(groupId);


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
                    if (studentGroup.Student.StudentCourses
                        .FirstOrDefault(sc => sc.CourseId.Equals(assessment.CourseId)
                                              && sc.StudentId.Equals(studentGroup.Student.UserId)) != null)
                    {
                        if (assessment.StudentAssessments.FirstOrDefault(
                            sa => sa.AssessmentId.Equals(assessmentId)
                                  && sa.StudentId.Equals(studentGroup.Student.UserId)
                        ) == null)
                        {
                            studentGroup.Student.StudentAssessments.Add(new StudentAssessment
                            {
                                StudentId = studentGroup.Student.UserId,
                                AssessmentId = assessmentId,
                                HasTaken = false
                            });
                        }
                    }


                    //_studentService.UpdateStudent(studentGroup.Student);
                }

                _groupService.UpdateGroup(group);
            }

            return _assessmentRepository.Update(assessment);
        }

        public Assessment UnAssignFromGroup(Guid assessmentId, Guid groupId)
        {
            var assessment = _assessmentRepository.FindAssessmentAndStudentsById(assessmentId);
            var group = _groupService.FindWithStudentsAndAssessmentsBy(groupId);


            if (assessment == null)
            {
                return null;
            }


            var studs = new List<Student>();

            foreach (var groupAssessment in assessment.GroupAssessments.ToList())
            {
                foreach (var studentGroup in groupAssessment.Group.StudentGroups)
                {
                    studs.Add(studentGroup.Student);
                }
            }

            foreach (var s in studs)
            {
                var studassessment = s.StudentAssessments
                    .FirstOrDefault(sa => sa.AssessmentId.Equals(assessmentId));
                s.StudentAssessments.Remove(studassessment);
            }


            foreach (var groupAssessment in assessment.GroupAssessments.ToList())
            {
                if (groupAssessment.AssessmentId.Equals(assessmentId) && groupAssessment.GroupId.Equals(groupId))
                {
                    assessment.GroupAssessments.Remove(groupAssessment);
                }
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