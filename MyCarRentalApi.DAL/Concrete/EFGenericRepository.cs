using Microsoft.EntityFrameworkCore;
using MyCarRentalApi.DAL.Context;
using MyCarRentalApi.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.DAL.Concrete
{
    public class EFGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyCarRentalApiDbContext _context;

        private DbSet<T> table = null;

        public EFGenericRepository(MyCarRentalApiDbContext dbContext)
        {
            _context = dbContext;
            table = _context.Set<T>();
        }
        
        public async Task DeleteAsync(object id)
        {
            T existing = await table.FindAsync(id);

            table.Remove(existing);
        }

       public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
           return await table.FindAsync(id);
        }

        public async Task InsertAsync(T obj)
        {
            await table.AddAsync(obj);
        }

        public async Task SaveAsync()
        {
            _context.SaveChangesAsync();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}