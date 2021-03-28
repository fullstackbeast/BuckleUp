using BuckleUp.Interface.Repository;
using BuckleUp.Interface.Service;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Service
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public AssessmentQuestion[] AddManyAssessmentQuestions(AssessmentQuestion[] questions)
        {
            return _questionRepository.AddManyAssessmentQuestion(questions);
        }

        public QuizQuestion[] AddManyQuizQuestions(QuizQuestion[] questions)
        {
            return _questionRepository.AddManyQuizQuestion(questions);
        }

        public bool IsRightAnswer(Question question, string option)
        {
           return question.CorrectOption.Equals(option);
        }
    }
}