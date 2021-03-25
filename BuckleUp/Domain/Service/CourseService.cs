using System;
using BuckleUp.Interface.Repository;
using BuckleUp.Interface.Service;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Course GetCourseById(Guid id)
        {
            return _courseRepository.FindById(id);
        }

        public Course GetCourseDetailsWithAllStudents(Guid courseId)
        {
            return _courseRepository.FindCourseDetailsWithAllStudents(courseId);
        }
    }
}