using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class AssessmentResultVM
    {
        public AssessmentQuestion [] Questions {get; set;}

        public List<string> Answers {get; set;}
    }
}