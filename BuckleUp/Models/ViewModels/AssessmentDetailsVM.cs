using System;
using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class AssessmentDetailsVM
    {
        public Assessment Assessment { get; set; }
        public Guid StudentId {get; set;}
        public Guid TeacherId {get; set;}

        public Guid GroupId { get; set; }
        
        public List<Group> Groups { get; set; }
        
        public Guid AssessmentId { get; set; }
    }
}