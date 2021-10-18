using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.ViewModels
{
    public class UserUpdateViewModel
    {
        [Required]
        [StringLength(maximumLength: 25)]
        public string UserName { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string FullName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }
}
