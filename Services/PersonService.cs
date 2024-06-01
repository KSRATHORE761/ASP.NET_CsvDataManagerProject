using CsvDataManager.Data;
using CsvDataManager.Models;

namespace CsvDataManager.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonsRepository _repository;
        public PersonService(IPersonsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ImportCsvAsync(IFormFile file)
        {
            await DeleteAllAsync();
            using (var stream = new StreamReader(file.OpenReadStream()))
            {
                string headerLine = await stream.ReadLineAsync();
                string line;
                while ((line = await stream.ReadLineAsync()) != null)
                {
                    var values = line.Split(',');
                    // Validate the data
                    //if (values.Length != 7 || !int.TryParse(values[0], out int id) || string.IsNullOrEmpty(values[1]) || string.IsNullOrEmpty(values[2]))
                    //{
                    //    // Log the error and skip this line
                    //   // _logger.LogWarning("Invalid data found in CSV: {line}", line);
                    //    continue;
                    //}
                    //if (values.Length != 6) continue; // Handle invalid lines

                    var data = new Persons
                    {
                        Id = Convert.ToInt32(values[0]),    
                        FirstName = values[1],
                        LastName = values[2],
                        Age = ConvertStringToInt(values[3]),
                        Gender = ConvertStringToChar(values[4]),
                        Mobile = (long)ConvertStringToInt(values[5]),
                        IsActive= Convert.ToBoolean((values[6] == "TRUE" || values[6] == "true" || values[6] =="True" || values[6] =="YES" || values[6] == "Yes") ? true : false),
                    };
                    await _repository.AddAsync(data);
                }
            }

            return true;
        }

        public async Task<bool> UpdateAsync(Persons data)
        {
            return await _repository.UpdateAsync(data);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task DeleteAllAsync()
        {
            await _repository.DeleteAllAsync();
        }
        public async Task<IEnumerable<Persons>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Persons> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public int? ConvertStringToInt(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            return 0;
        }

        public char? ConvertStringToChar(string input)
        {
            if(input=="M" || input == "F")
            {
                return char.Parse(input);  
            }
            return ' ';
        }
    }
}
