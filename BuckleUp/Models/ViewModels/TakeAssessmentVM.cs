using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class TakeAssessmentVM
    {
        

        public AssessmentQuestion [] questions {get; set;}

        public List<string> selectedAnswer {get; set;}
        
    }
}