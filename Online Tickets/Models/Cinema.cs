using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Online_Tickets.Models
{
    public class Cinema
    {
        [Key]
        public int CinemaId { get; set; }
        [DisplayName("Cinema Logo")]
        public string Logo { get; set; }
        [DisplayName("Cinema Name")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }

        //relations
        public List<Movie> Movies { get; set; }

    }
}
