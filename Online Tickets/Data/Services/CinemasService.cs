using Online_Tickets.Data.Base;
using Online_Tickets.Models;

namespace Online_Tickets.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema> , ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        {
            
        }
    }
}
