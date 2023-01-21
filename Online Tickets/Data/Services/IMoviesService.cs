using System.Threading.Tasks;
using Online_Tickets.Data.Base;
using Online_Tickets.Data.ViewModels;
using Online_Tickets.Models;

namespace Online_Tickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetMovieDropdownsValues();

        Task<Movie> AddNewMovie(NewMovieVM newMovieVm);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
