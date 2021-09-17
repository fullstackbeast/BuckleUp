using System;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models
{
    public class StudentGroup
    {
        public Guid StudentId {get; set;}
        public Student Student {get; set;}
        
        public Guid GroupId {get; set;}
        public Group Group {get; set;}
    }
}