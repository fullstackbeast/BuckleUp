using System;
using System.Collections.Generic;
using BuckleUp.Models;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface ITeacherRepository
    {

        public Teacher Add (Teacher teacher);
        public Teacher FindById(Guid id);
        public List<Teacher> ListAll();

        public Teacher Update(Teacher teacher);

        public Teacher FindTeacherWithStudentsById(Guid id);
        public Teacher FindTeacherWithCoursesById(Guid id);
        public Teacher FindTeacherWithAssessmentsById(Guid id);
        public Teacher FindTeacherWithStudentsAndCoursesById(Guid id);
        public Teacher FindTeacherWithStudentsAndCoursesAndAssessmentsById(Guid id);


        
    }
}