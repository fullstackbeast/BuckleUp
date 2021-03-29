using System;
using System.Collections.Generic;
using System.Linq;
using BuckleUp.Interface.Repository;
using BuckleUp.Models;
using BuckleUp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuckleUp.Domain.Repository
{
    public class QuizRepository : IQuizRepository
    {
        private readonly AppDBContext _context;
        public QuizRepository(AppDBContext context)
        {
            _context = context;
        }

        public Quiz Add(Quiz quiz)
        {
            _context.Quizzes.Add(quiz);
            _context.SaveChanges();
            return quiz;
        }

        public List<Quiz> FindAllQuizByCreatorId(Guid id)
        {
            return _context.Quizzes.Where(qz => qz.CreatorId.Equals(id)).ToList();
        }

        public Quiz FindById(Guid id)
        {
            return _context.Quizzes.Find(id);
        }

        public Quiz FindByLink(string link)
        {
            return _context.Quizzes.FirstOrDefault(qz => qz.Link.Equals(link));
        }

        public Quiz FindQuizWithPlayersByLink(string link)
        {
            return _context.Quizzes
            .Include(qz => qz.QuizPlayers)
            .ThenInclude(qzply => qzply.Player)
            .FirstOrDefault(qz => qz.Link.Equals(link));
        }

        public Quiz FindQuizWithQuestionsAndPlayersByLink(string link)
        {
            throw new NotImplementedException();
        }

        public Quiz FindQuizWithQuestionsByLink(string link)
        {
            return _context.Quizzes.Include(q => q.Questions)
            .FirstOrDefault(q => q.Link.Equals(link));
        }

        public Quiz Update(Quiz quiz)
        {
            _context.Quizzes.Update(quiz);
            _context.SaveChanges();
            return quiz;
        }
    }
}