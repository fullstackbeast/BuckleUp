using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class QuizRoomVM
    {
        public string PlayerUsername { get; set; }
        public bool IsQuizCreator { get; set;} = false;

        public ICollection<QuizPlayer> Players{get; set;}
    }
}