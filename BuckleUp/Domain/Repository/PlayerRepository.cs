using BuckleUp.Interface.Repository;
using BuckleUp.Models;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDBContext _context;
        public PlayerRepository(AppDBContext context)
        {
            _context = context;
        }

        public Player Add(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return player;
        }
    }
}