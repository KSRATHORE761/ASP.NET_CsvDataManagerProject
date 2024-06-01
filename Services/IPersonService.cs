using CsvDataManager.Models;

namespace CsvDataManager.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Persons>> GetAllAsync();
        Task<Persons> GetByIdAsync(int id);
        Task<bool> ImportCsvAsync(IFormFile file);
        Task<bool> UpdateAsync(Persons data);
        Task<bool> DeleteAsync(int id);
        Task DeleteAllAsync();
    }
}
