using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Renter
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FullName of the Renter is required!")]
        public string FullName { get; set; }
    }
}
