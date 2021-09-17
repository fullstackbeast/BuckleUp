using System;
using System.Security.Cryptography.X509Certificates;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Service
{
    public interface IGroupService
    {
        public Group AddGroup(string name, Guid teacherId);
        
        public Group UpdateGroup(Group group);

        public Group AddStudent(Guid groupId, Guid studentId);
        
        public void DeleteGroup(Guid groupId);
        
        public Group GetGroupWithStudentsAndAssessmentsById(Guid id);

        public Group RemoveStudent(Guid groupId, Guid studentId);

        public Group FindWithStudentsCourseAndAssessmentsBy(Guid id);
    }
}