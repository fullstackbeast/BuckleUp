using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class TeacherListVM
    {
        public TeacherListVM()
        {
            Teachers = new List<User>();
        }

        public Student Student {get; set;}
        public List<User> Teachers {get; set;}
    }
}