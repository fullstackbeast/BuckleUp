using System;
using System.Collections.Generic;

namespace BuckleUp.Models.Entities
{
    public class Quiz : BaseEntity
    {
        public Quiz()
        {
            Questions = new List<Question>();
            QuizPlayers = new List<QuizPlayer>();
        }

        public Guid CreatorId {get; set;}
        public ICollection<Question> Questions {get; set;}
        public ICollection<QuizPlayer> QuizPlayers { get; set; }
        public string status {get; set;}
        
    }
}