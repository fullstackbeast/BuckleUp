using System;
using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Service
{
    public interface IQuizService
    { 
         public Quiz Create(Guid creatorId, List<QuizQuestion> question);
         public Quiz AddPlayerToQuiz(string link, Player player);
         public List<Quiz> GetAllGuizByCreatorId(Guid creatorId);
         public Quiz StartQuiz(Guid id);
    }
}