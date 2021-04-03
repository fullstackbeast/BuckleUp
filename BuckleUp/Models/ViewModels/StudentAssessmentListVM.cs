using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class StudentAssessmentListVM
    {
        public StudentAssessmentListVM()
        {
            Assessments = new List<Assessment>();
        }

        public Student Student{get; set;}

        public List<Assessment> Assessments {get; set;}
    }
}