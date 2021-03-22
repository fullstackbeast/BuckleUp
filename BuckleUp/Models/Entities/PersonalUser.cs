using System;
using System.Collections.Generic;

namespace BuckleUp.Models.Entities
{
    public class PersonalUser
    {
         public PersonalUser()
        {
            Quizzes = new List<Quiz>();
        }

        public List<Quiz> Quizzes {get; set;}
        public DateTime DateOfBirth {get; set;}
    }
}