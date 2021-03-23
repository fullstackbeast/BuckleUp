namespace BuckleUp.Models.Entities
{
    public class User : BaseEntity
    {        
        public string Email { get; set; }

        public string Password { get; set; }
        public string Type { get; set; }
        
        
    }
}