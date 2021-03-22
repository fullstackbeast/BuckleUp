using System;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models
{
    public class StudentAssessment
    {
        public Guid StudentId {get; set;}
        public Student Student{get; set;}

        public Guid AssessmentId {get; set;}
        public Assessment Assessment{get; set;}
    }
}