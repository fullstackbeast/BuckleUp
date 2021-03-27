using System;

namespace BuckleUp.Models.Entities
{
    public class QuizPlayer
    {
        public Quiz Quiz {get; set;}
        public Guid QuizId{get; set;}

        public Player Player{get; set;}
        public Guid PlayerId{ get; set;}

        public int Score{ get; set;}
    }
}