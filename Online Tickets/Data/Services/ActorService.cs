using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Tickets.Data.Base;
using Online_Tickets.Models;

namespace Online_Tickets.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>, IActorService
    {

        public ActorService(AppDbContext context) : base(context)
        {
        }
        
    }
}
