using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name of the car is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price of the car is required!")]
        [Range(0.1, Double.MaxValue, ErrorMessage = "Min price value is 0.1!")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Renter of the car is required!")]
        public int? RenterId { get; set; }

        [ForeignKey("RenterId")]
        public Renter? Renter { get; set; }
    }
}
