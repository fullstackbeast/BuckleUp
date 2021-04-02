using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class QuizRoomVM
    {
        public string PlayerUsername { get; set; }
        public string CreatorName {get; set;}
        public Quiz Quiz {get; set;} 
        public bool IsQuizCreator { get; set;} = false;
        public ICollection<QuizPlayer> Players{get; set;}
        public bool PlayerHasPlayed {get; set;} = false;
        public int PlayerScore {get; set;}
        public ICollection<QuizPlayer> FinishedPlayers{get; set;}
    }
}