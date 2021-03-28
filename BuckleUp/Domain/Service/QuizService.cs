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
        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public Quiz AddPlayerToQuiz(string link, Player player)
        {
            throw new NotImplementedException();
        }

        public Quiz Create(Guid creatorId, List<QuizQuestion> questions)
        {
            string link = generateLink();

            Quiz newQuiz = new Quiz{
                Id = Guid.NewGuid(),
                CreatorId = creatorId,
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

        public string generateLink(){
            Guid guid = Guid.NewGuid();

            string link = string.Empty;

            string [] guidparts = guid.ToString().Split("-");

            foreach(string p in guidparts){
                link += p.Substring(0,2);
            }

            return link;
        }

        public List<Quiz> GetAllGuizByCreatorId(Guid creatorId)
        {
            return _quizRepository.FindAllQuizByCreatorId(creatorId);
        }
    }
}