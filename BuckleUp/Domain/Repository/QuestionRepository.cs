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

        public Question[] AddMany(Question[] questions)
        {
            _context.AddRange(questions);
            _context.SaveChanges();
            return questions;
        }
    }
}