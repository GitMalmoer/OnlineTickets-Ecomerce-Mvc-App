using Online_Tickets.Data.Base;
using Online_Tickets.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Online_Tickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie> , IMoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(a => a.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);
            return  movieDetails;
            
        }
    }
}
