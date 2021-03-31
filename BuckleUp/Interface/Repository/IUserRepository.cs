using System;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface IUserRepository
    {
        public User Add (User user);
        public User FindById (Guid id);
        public User FindByEmail(string email);
    }
}