using System;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class CourseDetailsVM
    {
        public Course Course {get; set;}
        public Guid TeacherId {get; set;}
        public Guid CourseId {get; set;}
       
        public Student Student {get; set;}

        public int SourceId { get; set; }
        
        
    }
}