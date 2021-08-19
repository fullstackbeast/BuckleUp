using System;
using System.Linq;
using BuckleUp.Interface.Repository;
using BuckleUp.Interface.Service;
using BuckleUp.Models;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Service
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;

        public GroupService(IGroupRepository groupRepository, ITeacherService teacherService, IStudentService studentService)
        {
            _groupRepository = groupRepository;
            _teacherService = teacherService;
            _studentService = studentService;
        }

        public Group AddGroup(string name, Guid teacherId)
        {
            return _groupRepository.AddGroup(new Group
            {
                Name = name,
                TeacherId = teacherId
            });
            
            
        }

        public Group UpdateGroup(Group @group)
        {
            return _groupRepository.UpdateGroup(group);
        }

        public Group AddStudent(Guid groupId, Guid studentId)
        {
            var group = _groupRepository.FindWithStudentsAndAssessmentsBy(groupId);

            var teacher = _teacherService.GetTeacherWithStudents(group.TeacherId);
            
            // checks if student is subscribed to teacher
            var teacherStudent = teacher.TeacherStudents.FirstOrDefault(ts =>
                ts.StudentId.Equals(studentId) && ts.TeacherId.Equals(group.TeacherId));

            if (teacherStudent != null)
            {
                var student = _studentService.GetStudentWithAssessments(studentId);
                
                var newStudentGroup = new StudentGroup
                {
                    GroupId = group.Id,
                    StudentId = studentId
                };
                
                group.StudentGroups.Add(newStudentGroup);

                foreach (var groupAssessment in group.GroupAssessments)
                {
                    student.StudentAssessments.Add(new StudentAssessment
                    {
                        AssessmentId = groupAssessment.AssessmentId,
                        StudentId = studentId,
                        HasTaken = false
                    });
                }
                
                _studentService.UpdateStudent(student);
                return _groupRepository.UpdateGroup(group);
            }
            

            return null;
        }

        public Group GetGroupWithStudentsAndAssessmentsById(Guid id)
        {
            return _groupRepository.FindWithStudentsAndAssessmentsBy(id);
        }

        public Group RemoveStudent(Guid groupId, Guid studentId)
        {

            var group = _groupRepository.FindWithStudentsAndAssessmentsBy(groupId);
            var student = _studentService.GetStudentWithAssessments(studentId);

            foreach (var groupAssessment in group.GroupAssessments.ToList())
            {

                foreach (var studentAssessment in student.StudentAssessments.ToList())
                {
                    if (studentAssessment.AssessmentId.Equals(groupAssessment.AssessmentId))
                    {
                        student.StudentAssessments.Remove(studentAssessment);
                    }
                }
                
            }

            foreach (var studentGroup in group.StudentGroups.ToList())
            {
                if (studentGroup.StudentId.Equals(studentId))
                {
                    group.StudentGroups.Remove(studentGroup);
                }
            }

            _studentService.UpdateStudent(student);
            _groupRepository.UpdateGroup(group);


            return group;
        }
    }
}