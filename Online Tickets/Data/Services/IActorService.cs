using System.Collections.Generic;
using System.Threading.Tasks;
using Online_Tickets.Models;

namespace Online_Tickets.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetById(int actorId);
        Task AddActorAsync(Actor actor);
        Task<Actor> UpdateAsync(int id, Actor actor);
        Task DeleteAsync(int id);
    }
}
