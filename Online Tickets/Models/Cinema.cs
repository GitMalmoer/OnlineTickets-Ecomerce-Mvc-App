using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Online_Tickets.Data;
using Online_Tickets.Data.Base;

namespace Online_Tickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }


        [DisplayName("Cinema Logo")]
        [Required(ErrorMessage = "Logo is required")]
        public string Logo { get; set; }


        [DisplayName("Cinema Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30,MinimumLength = 3,ErrorMessage = "The name must be between 3 and 30")]
        public string Name { get; set; }


        [DisplayName("Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(50,MinimumLength = 5,ErrorMessage = "The length must be between 5 and 50")]
        public string Description { get; set; }

        //relations
        public List<Movie> Movies { get; set; }

    }
}
