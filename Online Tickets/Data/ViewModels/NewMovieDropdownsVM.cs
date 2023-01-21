using System.Collections.Generic;
using Online_Tickets.Models;

namespace Online_Tickets.Data.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public List<Producer> Producers { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Cinema> Cinemas { get; set; }

        public NewMovieDropdownsVM()
        {
            Producers = new List<Producer>();
            Actors = new List<Actor>();
            Cinemas = new List<Cinema>();
        }

    }
}
