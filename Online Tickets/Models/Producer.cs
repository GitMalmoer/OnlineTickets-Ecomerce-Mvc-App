using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Online_Tickets.Data.Base;

namespace Online_Tickets.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Profile Picture")]
        [Required(ErrorMessage = "Profile picture is required")]
        public string ProfilePictureURL { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "The Name is required")]
        [StringLength(30,MinimumLength = 3,ErrorMessage = "The name length must be between 3 and 30 letters")]
        public string FullName { get; set; }

        [DisplayName("Biography")]
        [Required(ErrorMessage = "The Biography is required")]
        [StringLength(100,MinimumLength = 5 , ErrorMessage = "The biography must be between 5 and 100 letters")]
        public string Bio { get; set; }

        //relations
        public List<Movie> Movies { get; set; }


    }
}
