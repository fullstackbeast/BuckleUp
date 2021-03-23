using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface IAuthRepository
    {
         public User Login (string email, string password);
    }
}