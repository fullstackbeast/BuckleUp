using System;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class RemoveStudentVM
    {
        public Teacher Teacher {get; set;}

        public Guid StudentId { get; set; }
    }
}