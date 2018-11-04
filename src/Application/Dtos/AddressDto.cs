using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class AddressDto
    {
        [Key]
        public Guid AddressId { get; set; }

        [ScaffoldColumn(false)]
        public Guid ClientId { get; set; }

        [Required(ErrorMessage = "Provide the Street")]
        [MaxLength(150, ErrorMessage = "Provide a street name with maximum of 150 characters")]
        [MinLength(2, ErrorMessage = "Provide a street name with minimun of 2 characters")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Provide the Number")]
        [MinLength(2, ErrorMessage = "Provide a number with minimun of 2 characters")]
        public string Number { get; set; }

        [MaxLength(100, ErrorMessage = "Provide a complement with maximum of 100 characters")]
        public string Complement { get; set; }

        [Required(ErrorMessage = "Provide the Neighborhood")]
        [MaxLength(50, ErrorMessage = "Provide a neighborhood with maximum of 50 characters")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "Provide the ZipCode")]
        [DisplayName("Zip code")]
        [RegularExpression("([0-9]{8})", ErrorMessage = "Please provide a valid Zip code number with 8 characters")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Provide the City")]
        [MaxLength(150, ErrorMessage = "Provide a city name with maximum of 150 characters")]
        [MinLength(2, ErrorMessage = "Provide a city name with minimun of 2 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Provide the State")]
        [MaxLength(150, ErrorMessage = "Provide a state name with maximum of 150 characters")]
        [MinLength(2, ErrorMessage = "Provide a state name with minimun of 2 characters")]
        public string State { get; set; }
    }
}
