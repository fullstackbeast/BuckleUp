using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Service
{
    public interface IQuestionService
    {

        public AssessmentQuestion[] AddManyAssessmentQuestions(AssessmentQuestion[] questions);
        public QuizQuestion[] AddManyQuizQuestions(QuizQuestion[] questions);

        public bool IsRightAnswer(Question question, string option);
         
    }
}