using System;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models
{
    public class TeacherStudent
    {
        public Guid TeacherId{get; set;}
        public Teacher Teacher {get; set;}

        public Guid StudentId{get; set;}
        public Student Student{get; set;}
        
    }
}