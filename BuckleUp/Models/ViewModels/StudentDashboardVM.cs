using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class StudentDashboardVM
    {
        public Student Student {get; set;}
        public List<Quiz> Quizzes {get; set;}
    }
}