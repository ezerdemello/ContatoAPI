using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ContatoAPI.Domain.Common;

namespace ContatoAPI.Application.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task Add(T entity);

        Task<List<T>> GetAll();

        Task<List<T>> GetByFilters(List<Expression<Func<T, bool>>> filter, int page, int take);

        Task<T> Get(string id);
        
        Task Update(T entity);

        Task Remove(T entity);
    }

}