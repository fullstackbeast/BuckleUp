using System.Linq;
using BuckleUp.Interface.Repository;
using BuckleUp.Models;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDBContext _context;

        public AuthRepository(AppDBContext context)
        {
            _context = context;
        }

        public User Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(us => us.Email==email && us.Password == password);
        }
    }
}