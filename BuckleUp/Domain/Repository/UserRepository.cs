using System;
using System.Linq;
using BuckleUp.Interface.Repository;
using BuckleUp.Models;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _context;
        public UserRepository(AppDBContext context)
        {
            _context = context;
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User FindByEmail(string email)
        {
            return _context.Users.FirstOrDefault(user => user.Email.Equals(email));
        }

        public User FindById(Guid id)
        {
            return _context.Users.Find(id);
        }
    }
}