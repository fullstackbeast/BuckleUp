using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface IQuestionRepository
    {

        public Question[] AddMany(Question[] questions);
        
    }
}