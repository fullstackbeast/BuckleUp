using System;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface IPlayerRepository
    {
        public Player Add(Player player);
        public Player FindById(Guid id);
    }
}