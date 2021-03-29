using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class PlayQuizVM
    {
        public Question [] Questions {get; set;}
        public string PlayerName { get; set; }
    }
}