using System;
using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface ITeacherRepository
    {

        public Teacher Add (Teacher teacher);
        public Teacher FindById(Guid id);
        public List<Teacher> ListAll();
        
    }
}