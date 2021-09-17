using System;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models
{
    public class GroupAssessment
    {
        public Guid AssessmentId {get; set;}
        public Assessment Assessment {get; set;}
        
        public Guid GroupId {get; set;}
        public Group Group {get; set;}
    }
}