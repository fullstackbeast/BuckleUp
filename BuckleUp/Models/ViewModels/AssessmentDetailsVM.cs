using System;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class AssessmentDetailsVM
    {
        public Assessment Assessment { get; set; }
        public Guid StudentId {get; set;}
        public Guid TeacherId {get; set;}
    }
}