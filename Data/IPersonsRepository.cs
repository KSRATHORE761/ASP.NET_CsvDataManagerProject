using CsvDataManager.Models;

namespace CsvDataManager.Data
{
    public interface IPersonsRepository
    {
        Task<IEnumerable<Persons>> GetAllAsync();
        Task<Persons> GetByIdAsync(int id);
        Task AddAsync(Persons data);
        Task<bool> UpdateAsync(Persons data);
        Task<bool> DeleteAsync(int id);
        Task DeleteAllAsync();
    }
}
