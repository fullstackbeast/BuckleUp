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
            Questions = new List<AssessmentQuestion>();
            GroupAssessments = new List<GroupAssessment>();
        }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public Course Course { get; set; }
        public Guid CourseId { get; set; }
        public Teacher Teacher { get; set; }
        public Guid TeacherId { get; set; }
        public ICollection<AssessmentQuestion> Questions { get; set; }
        public ICollection<StudentAssessment> StudentAssessments { get; set; }
        
        public ICollection<GroupAssessment> GroupAssessments {get; set;}
    }
}