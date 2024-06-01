using System.ComponentModel.DataAnnotations;

namespace CsvDataManager.Models
{
    public class ImportModel
    {
        [Required(ErrorMessage = "Please upload a file")]
        [FileExtensions(Extensions = "csv", ErrorMessage = "Only csv files are allowed")]   
        public IFormFile File { get; set; }
    }
}
