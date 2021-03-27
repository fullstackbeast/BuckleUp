using System;

namespace BuckleUp.Models.Entities
{
    public class Question : BaseEntity
    {

        public Guid AssessmentId {get; set;}
        public Assessment Assessment {get; set;} 
        public Guid QuizId {get; set;}
        public Quiz Quiz {get; set;}
        public string QuestionText {get; set;}
        public string Option1 { get; set;}
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string CorrectOption { get; set; }
        
    }
}