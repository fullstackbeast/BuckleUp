using System;
using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Service
{
    public interface ITeacherService
    {

        public Teacher AddTeacher (Teacher teacher);

        public Teacher FindById(Guid id);

        public List<Teacher> ListAll();
         
    }
}