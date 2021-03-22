using System.Linq;
using System;
using System.Collections.Generic;
namespace BuckleUp.Models.Entities
{
    public class Assessment : BaseEntity
    {
        public Assessment()
        {
            StudentAssessments = new List<StudentAssessment>();
        }

        
        public DateTime StartTime {get; set;}
        public DateTime StopTime {get; set;}  
        public Course Course{get; set;}      
        public Teacher Teacher{get; set;}
        public IEnumerable<StudentAssessment> StudentAssessments {get; set;}
    }
}