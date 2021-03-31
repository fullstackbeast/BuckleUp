using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Service
{
    public interface IUserService
    {
         public User Add (User user);

         public User Login(string email, string password);
    }
}