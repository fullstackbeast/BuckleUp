using System;
using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface IGroupRepository
    {
        public Group AddGroup(Group group);
        
        public Group UpdateGroup(Group group);

        public void DeleteGroup(Guid id);
        
        public List<Group> GetAll();

        public Group FindById(Guid id);
        
        public Group FindWithStudentsBy(Guid id);
        
        public Group FindWithStudentsAndAssessmentsBy(Guid id);
        
    }
}