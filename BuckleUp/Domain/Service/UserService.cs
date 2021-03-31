using BuckleUp.Interface.Repository;
using BuckleUp.Interface.Service;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Add(User user)
        {
            return _userRepository.Add(user);
        }

        public User Login(string email, string password)
        {
            User user = _userRepository.FindByEmail(email);
            if(user == null) return user;

            return (user.Password.Equals(password)) ? user : null;
        }
    }
}