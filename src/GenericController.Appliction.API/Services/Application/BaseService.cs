using GenericController.Appliction.API.Context;
using GenericController.Appliction.API.Models;
using GenericController.Appliction.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GenericController.Appliction.API.Services.Application
{
    public class BaseService<T> : IBaseService<T> where T : BaseModel
    {
        private readonly SQLServerContext _context;

        public BaseService(SQLServerContext context)
        {
            this._context = context;
        }

        public List<T> GetAll()
        {
            return _context
                .Set<T>()
                .AsNoTracking()
                .ToList();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>()
                .SingleOrDefaultAsync(entity => entity.Id == id);
        }

        public Task<int> Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task<int> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
            return _context.SaveChangesAsync();
        }
        public Task<int> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }
    }
}
