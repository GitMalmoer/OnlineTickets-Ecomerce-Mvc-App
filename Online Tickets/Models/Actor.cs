using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Online_Tickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Profile Picture")]
        [Required(ErrorMessage = "The Profile Picture URL is required")]
        public string ProfilePictureURL { get; set; }
        [DisplayName("Full Name")]
        [Required(ErrorMessage = "The Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The full name must be between 3 and 50")]
        public string FullName { get; set; }
        [DisplayName("Biography")]
        [Required(ErrorMessage = "The Biography is required")]
        public string Bio { get; set; }

        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
