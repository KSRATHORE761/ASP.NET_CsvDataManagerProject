using System.Numerics;
using System.ComponentModel.DataAnnotations;

namespace CsvDataManager.Models
{
    public class Persons
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 20 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 20 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Age is required.")]
        public int? Age { get; set; }
        [Required]
        [RegularExpression("^[MF]$", ErrorMessage = "Please enter 'M' or 'F'.")]
        public char? Gender { get; set; }
        [Required(ErrorMessage = "Mobile Number is required.")]
        public long Mobile { get; set; }
        [Required(ErrorMessage = "IsActive Number is required.")]
        public bool IsActive { get; set; }
    }
}
