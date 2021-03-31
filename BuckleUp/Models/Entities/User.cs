namespace BuckleUp.Models.Entities
{
    public class User : Details
    {        
        public string Type { get; set; }

        public Teacher Teacher {get; set;}
        public Student Student {get; set;}
 
    }
}