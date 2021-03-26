using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Service
{
    public interface IQuestionService
    {

        public Question[] AddMany(Question[] questions);
         
    }
}