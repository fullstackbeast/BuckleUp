using BuckleUp.Interface.Repository;
using BuckleUp.Models;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDBContext _context;
        public QuestionRepository(AppDBContext context)
        {
            _context = context;
        }


        public AssessmentQuestion[] AddManyAssessmentQuestion(AssessmentQuestion[] questions)
        {
            _context.AssessmentQuestions.AddRange(questions);
            _context.SaveChanges();
            return questions;
        }

        public QuizQuestion[] AddManyQuizQuestion(QuizQuestion[] questions)
        {
            _context.QuizQuestions.AddRange(questions);
            _context.SaveChanges();
            return questions;
        }
    }
}