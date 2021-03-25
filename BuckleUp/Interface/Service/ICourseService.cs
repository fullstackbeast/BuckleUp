using System;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Service
{
    public interface ICourseService
    {
        public Course GetCourseById(Guid id);
         public Course GetCourseDetailsWithAllStudents(Guid courseId); 
    }
}