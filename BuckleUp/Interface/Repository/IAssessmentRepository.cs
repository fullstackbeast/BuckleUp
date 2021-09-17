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
           public List<Assessment> FindAllCourseAssessment(Guid courseId);
           public Assessment FindAssessmentAndQuestionsById(Guid id);
           public Assessment FindAssessmentAndQuestionsWithStudentsById(Guid id);
           
           public Assessment FindAssessmentAndGroupsWithStudentsById(Guid id);
           
           public Assessment FindAssessmentAndStudentsById(Guid id);
           
    }
}