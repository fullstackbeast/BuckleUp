using System;
using System.Collections.Generic;
using BuckleUp.Models;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Service
{
    public interface IAssessmentService
    {
        public Assessment Add(Assessment assessment);
        public Assessment GetById(Guid id);
        public Assessment GetAssessmentAndQuestionsById(Guid id);
        public List<Assessment> GetAllCourseAssessment(Guid courseId);
        public Assessment GetAssessmentAndQuestionsWithStudentsById(Guid id);
        public Assessment AddAssessmentToStudents(Assessment assessment);
    }
}