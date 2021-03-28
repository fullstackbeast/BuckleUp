using System;

namespace BuckleUp.Models.Entities
{
    public class QuizQuestion: Question
    {
        public Guid QuizId {get; set;}
        public Quiz Quiz {get; set;}
        
    }
}