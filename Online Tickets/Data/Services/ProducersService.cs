using Online_Tickets.Data.Base;
using Online_Tickets.Models;

namespace Online_Tickets.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer> , IProducersService 
    {
        public ProducersService(AppDbContext context) : base(context)
        {
            
        }
    }
}
