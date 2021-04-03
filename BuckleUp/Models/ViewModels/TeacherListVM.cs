using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class StudentListVM
    {
        public StudentListVM()
        {
            Students = new List<User>();
        }

        public Teacher Teacher {get; set;}
        public List<User> Students {get; set;}
    }
}