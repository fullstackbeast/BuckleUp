using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class QuestionOptionDisplayVM
    {

        public Question [] questions {get; set;}

        public string[] selectedAnswer {get; set;}
    }
}