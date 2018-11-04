using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class ClientDto
    {
        public ClientDto()
        {
            ClientId = Guid.NewGuid();
            Active = true;

            Addresses = new List<AddressDto>();
        }

        [Key]
        public Guid ClientId { get; set; }

        [Required(ErrorMessage = "Provide the name")]
        [MaxLength(150, ErrorMessage = "Provide a name with maximum of 150 characters")]
        [MinLength(2, ErrorMessage = "Provide a name with minimun of 2 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provide the CPF")]
        [RegularExpression("([0-9]{11})", ErrorMessage = "Please provide a valida  CPF number")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Provide the e-mail")]
        [MaxLength(100, ErrorMessage = "Provide an e-mail with maximum of 150 characters")]
        [EmailAddress(ErrorMessage = "Provide a valid e-mail")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Provide the date of birth")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegistryDate { get; set; }

        [ScaffoldColumn(false)]
        public bool Active { get; set; }

        public ICollection<AddressDto> Addresses { get; set; }
    }
}
