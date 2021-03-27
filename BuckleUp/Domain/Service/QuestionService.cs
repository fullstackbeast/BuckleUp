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

        public Question[] AddMany(Question[] questions)
        {
            _questionRepository.AddMany(questions);
            return questions;
        }

        public bool IsRightAnswer(Question question, string option)
        {
           return question.CorrectOption.Equals(option);
        }
    }
}