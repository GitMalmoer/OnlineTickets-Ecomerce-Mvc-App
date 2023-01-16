﻿using Online_Tickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Online_Tickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T:class, IEntityBase , new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
