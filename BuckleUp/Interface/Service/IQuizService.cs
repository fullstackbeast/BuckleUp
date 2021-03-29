using System;
using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Service
{
    public interface IQuizService
    {
        public Quiz Create(Guid creatorId, string creatorRole, List<QuizQuestion> question);
        public Quiz GetByLink(string link);
        public Quiz GetQuizWithQuestions(string link);
        public Quiz AddPlayerToQuiz(string link, Player player);
        public Quiz GetQuizWithPlayersByLink(string link);
        public List<Quiz> GetAllGuizByCreatorId(Guid creatorId);
        public Quiz SetPlayerScore(string link, Guid playerId, int score);
        public Quiz StartQuiz(string link);
        public Player GetPlayerById(Guid id);
    }
}