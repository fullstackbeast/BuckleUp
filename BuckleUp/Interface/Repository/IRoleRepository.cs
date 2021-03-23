using System.Collections.Generic;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface IRoleRepository
    {

        public Role Add (Role role);

        public List<Role> ListAll();
        
    }
}