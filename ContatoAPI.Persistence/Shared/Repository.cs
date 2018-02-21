using ContatoAPI.Application.Interfaces;
using ContatoAPI.Domain.Common;
using ContatoAPI.Persistence.Shared;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;

namespace ContatoAPI.Persistence.Shared
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly IDatabaseContext _databaseContext;

        public Repository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task Add(T entity)
        {
            await _databaseContext.Collection<T>().InsertOneAsync(entity);                  
        }

        public async Task<List<T>> GetAll()
        {
            return await _databaseContext.Collection<T>().Find(_ => true).ToListAsync();                                  
        }

        public async Task<List<T>> GetByFilters(List<Expression<Func<T, bool>>> filter, int page, int take)
        {
            IFindFluent<T,T> consulta;

            if (filter.Any())
            {
                Expression<Func<T, bool>> filterCombinado;
                filterCombinado = filter.First();

                for (int i = 1; i < filter.Count; i++)
                    filterCombinado = filterCombinado.And(filter[i]);

                consulta = _databaseContext.Collection<T>().Find(GetCombinedFilters(filter)); 
            }
            else
                consulta = _databaseContext.Collection<T>().Find(x => true); 

            var skip = 0;
            if (page > 1)
                skip = (page - 1) * take;

            return await consulta.Skip(skip).Limit(take).ToListAsync(); 
        }

        public async Task<T> Get(string id)
        {
            try
            {
                ObjectId _id;
                var convert = ObjectId.TryParse(id, out _id);
                if (!convert)
                    return null;

                var result = await _databaseContext.Collection<T>().Find(Builders<T>.Filter.Where(x => x.id == _id)).ToListAsync();
                if (result.Any())
                    return result.SingleOrDefault();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }
        
        public async Task Update(T entity)
        {
            var filter = Builders<T>.Filter.Eq(x => x.id, entity.id);
            await _databaseContext.Collection<T>().ReplaceOneAsync(filter, entity);                
        }
        

        public async Task Remove(T entity)
        {
            await _databaseContext.Collection<T>().DeleteOneAsync<T>(x => x.id.Equals(entity.id));
        }

        private Expression<Func<T, bool>> GetCombinedFilters(IEnumerable<Expression<Func<T, bool>>> filters)
        {
            Expression<Func<T, bool>> combinedFilter = filters.First();
            var filtersArray = filters.ToArray();
            for (int i = 1; i < filtersArray.Length; i++)
                combinedFilter = combinedFilter.And(filtersArray[i]);

            return combinedFilter;
        }

    }    
}
