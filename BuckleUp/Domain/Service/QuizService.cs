using System;
using System.Collections.Generic;
using BuckleUp.Interface.Repository;
using BuckleUp.Interface.Service;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Service
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IPlayerRepository _playerRepository;
        public QuizService(IQuizRepository quizRepository, IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
            _quizRepository = quizRepository;
        }

        public Quiz AddPlayerToQuiz(string link, Player player)
        {
            _playerRepository.Add(player);

            Quiz quiz = _quizRepository.FindQuizWithPlayersByLink(link);

            quiz.QuizPlayers.Add(new QuizPlayer
            {
                QuizId = quiz.Id,
                PlayerId = player.Id
            });

            _quizRepository.Update(quiz);

            return quiz;
        }

        public Quiz GetByLink(string link)
        {
            return _quizRepository.FindByLink(link);
        }

        public Quiz Create(Guid creatorId, string creatorRole, List<QuizQuestion> questions)
        {
            string link = generateLink();

            Quiz newQuiz = new Quiz
            {
                Id = Guid.NewGuid(),
                CreatorId = creatorId,
                CreatorRole = creatorRole,
                status = "unplayed",
                Questions = questions,
                Link = link
            };

            return _quizRepository.Add(newQuiz);
        }


        public Quiz StartQuiz(Guid id)
        {
            throw new NotImplementedException();
        }

        public string generateLink()
        {
            Guid guid = Guid.NewGuid();

            string link = string.Empty;

            string[] guidparts = guid.ToString().Split("-");

            foreach (string p in guidparts)
            {
                link += p.Substring(0, 2);
            }

            return link;
        }

        public List<Quiz> GetAllGuizByCreatorId(Guid creatorId)
        {
            return _quizRepository.FindAllQuizByCreatorId(creatorId);
        }

        public Quiz GetQuizWithPlayersByLink(string link)
        {
            return _quizRepository.FindQuizWithPlayersByLink(link);
        }
    }
}