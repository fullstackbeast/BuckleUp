using System.Collections.Generic;
using System.Linq;
using BuckleUp.Interface.Repository;
using BuckleUp.Models;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDBContext _context;
        public RoleRepository (AppDBContext appDBContext)
        {
            _context = appDBContext;
        }

        public Role Add(Role role)
        {
             _context.Roles.Add(role);
             _context.SaveChanges();
             return role;
        }

        public List<Role> ListAll()
        {
            return _context.Roles.ToList();
        }
    }
}