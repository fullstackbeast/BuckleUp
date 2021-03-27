using System.Collections.Generic;

namespace BuckleUp.Models.Entities
{
    public class Player : BaseEntity
    {
        public Player()
        {
            QuizPlayers = new List<QuizPlayer>();
        }

        public string Name {get; set;}
        public ICollection<QuizPlayer> QuizPlayers { get; set; }
    }
}