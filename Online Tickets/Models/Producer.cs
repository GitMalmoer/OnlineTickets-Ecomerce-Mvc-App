using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Online_Tickets.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Profile Picture")]
        public string ProfilePictureURL { get; set; }
        [DisplayName("Name")]
        public string FullName { get; set; }
        [DisplayName("Biography")]
        public string Bio { get; set; }

        //relations
        public List<Movie> Movies { get; set; }


    }
}
