using System;
using System.Collections.Generic;

namespace BuckleUp.Models.Entities
{
    public class Quiz : BaseEntity
    {
        public Quiz()
        {
            Questions = new List<QuizQuestion>();
            QuizPlayers = new List<QuizPlayer>();
        }

        public User User {get; set;}
        public Guid UserId {get; set;}
        public string CreatorRole { get; set; }
        public string Link { get; set; }
        public ICollection<QuizQuestion> Questions { get; set; }
        public ICollection<QuizPlayer> QuizPlayers { get; set; }
        public string status { get; set; }
        public bool ShowPlayerResult { get; set; } = false;

    }
}