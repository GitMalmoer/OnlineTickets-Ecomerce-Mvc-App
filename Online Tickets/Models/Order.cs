using System.ComponentModel.DataAnnotations;

namespace Online_Tickets.Models
{
    public class Order
    {
        [Key] 
        public int Id { get; set; }

        public string Email { get; set; }
        public string UserId { get; set; }
    }
}
