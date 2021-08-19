using System;
using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class TeacherGroupListVM
    {
        public TeacherGroupListVM()
        {
            Groups = new List<Group>();
        }
        public List<Group> Groups {get; set;}
    }
}