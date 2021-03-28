using System;
using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface IQuizRepository
    {
         public Quiz Add(Quiz quiz);
         public Quiz FindById(Guid id);
         public Quiz FindByLink(string link);
         public Quiz Update(Quiz quiz);
         public Quiz FindQuizWithPlayersByLink(string link);
         public List<Quiz> FindAllQuizByCreatorId(Guid id);
         
    }
}