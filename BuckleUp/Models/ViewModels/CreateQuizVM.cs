using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class CreateQuizVM
    {
        public QuizQuestion [] Questions {get; set;}
        public int NumberOfQuestions {get; set;}
    }
}