using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface IQuestionRepository
    {

        public AssessmentQuestion[] AddManyAssessmentQuestion(AssessmentQuestion[] questions);
        public QuizQuestion[] AddManyQuizQuestion(QuizQuestion[] questions);
        
    }
}