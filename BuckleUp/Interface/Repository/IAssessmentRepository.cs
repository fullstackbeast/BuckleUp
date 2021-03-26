using System;
using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface IAssessmentRepository
    {
           public Assessment Add(Assessment assessment);
           public Assessment Update(Assessment assessment);
           public Assessment Delete(Assessment assessment);
           public Assessment FindById(Guid id);
           public Assessment FindAssessmentAndQuestionsById(Guid id);
           public List<Assessment> FindAllTeacherAssessment(Guid teacherId);
           public List<Assessment> FindAllCourseAssessment(Guid courseId);
           public List<Assessment> FindAllStudentAssessment(Guid studentId);
           
    }
}