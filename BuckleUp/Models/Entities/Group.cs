using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using BuckleUp.Models.ViewModels;

namespace BuckleUp.Models.Entities
{
    public class Group : BaseEntity
    {
        public Group()
        {
            StudentGroups = new List<StudentGroup>();
            GroupAssessments = new List<GroupAssessment>();
        }

        public string Name { get; set; }
        
        public Teacher Teacher { get; set; }
        
        public Guid TeacherId { get; set; }
        
        public ICollection<StudentGroup> StudentGroups {get; set;}
        
        public ICollection<GroupAssessment> GroupAssessments {get; set;}

    }
}