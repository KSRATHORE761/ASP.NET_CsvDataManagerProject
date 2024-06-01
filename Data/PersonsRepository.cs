using CsvDataManager.Models;
using Microsoft.EntityFrameworkCore;

namespace CsvDataManager.Data
{
    public class PersonsRepository : IPersonsRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Persons>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Persons> GetByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }
        public async Task AddAsync(Persons data)
        {
            await _context.Persons.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = await _context.Persons.FindAsync(id);
            if (data == null) return false;

            _context.Persons.Remove(data);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Persons data)
        {
            _context.Persons.Update(data);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task DeleteAllAsync()
        {
            var data = await _context.Persons.ToListAsync();
            if(data == null) return;
            _context.RemoveRange(data);
            await _context.SaveChangesAsync();
        }
    }
}
