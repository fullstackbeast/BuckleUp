using BuckleUp.Models.Entities;

namespace BuckleUp.Models.ViewModels
{
    public class RegisterQuizVM
    {
        public Quiz Quiz {get; set;}
        public string PlayerUsername {get; set;}
        public bool UseLoggedInUserName {get; set;}
    }
}