using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Tickets.Models;

namespace Online_Tickets.Data.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext _context;

        public ActorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetById(int actorId)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(a => a.Id == actorId);
            return actor;
        }

        public async Task AddActorAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task<Actor> UpdateAsync(int id,Actor actor)
        {
            //newActor.ActorId = id;
            _context.Update(actor);
            await _context.SaveChangesAsync();
            return actor;
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }
    }
}
