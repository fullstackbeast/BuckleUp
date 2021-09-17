using System;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface ICourseRepository
    {
         public Course Add (Course course);

         public Course FindById(Guid id);

         public void Delete(Guid id);
         
         public Course FindWithAssessmentsById(Guid id);

         public Course Update (Course course);
    }
}