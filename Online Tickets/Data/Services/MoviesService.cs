using System.Linq;
using System.Reflection;
using Online_Tickets.Data.Base;
using Online_Tickets.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Tickets.Data.ViewModels;

namespace Online_Tickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
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
            return movieDetails;

        }

        public async Task<NewMovieDropdownsVM> GetMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }

        public async Task<Movie> AddNewMovie(NewMovieVM newMovieVm)
        {
            var movie = new Movie
            {
                Name = newMovieVm.Name,
                Description = newMovieVm.Description,
                CinemaId = newMovieVm.CinemaId,
                StartDate = newMovieVm.StartDate,
                EndDate = newMovieVm.EndDate,
                MovieCategory = newMovieVm.MovieCategory,
                Price = newMovieVm.Price,
                ProducerId = newMovieVm.ProducerId,
                ImageURL = newMovieVm.ImageURL,
            };

            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            // add movie actors

            foreach (var actorId in newMovieVm.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = movie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.Price = data.Price;
                dbMovie.ProducerId = data.ProducerId;
                dbMovie.ImageURL = data.ImageURL;

                await _context.SaveChangesAsync();
            }

            // remove existing actors 
            var existingActorsDb = await _context.Actors_Movies.Where(n => n.ActorId == data.Id).ToListAsync();
             _context.Actors_Movies.RemoveRange(existingActorsDb);


            // add movie actors

            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();

        }

    }
}
