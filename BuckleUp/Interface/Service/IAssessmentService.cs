using System;
using System.Collections.Generic;
using BuckleUp.Models;
using BuckleUp.Models.Entities;
using BuckleUp.Models.ViewModels;

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

        public void DeleteAssessment(Guid id);

        public Assessment AssignToGroup(Guid assessmentId, Guid groupId);

        public Assessment UnAssignFromGroup(Guid assessmentId, Guid groupId);
    }
}