using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Areas.Manage.ViewModels
{
    public class AddAdminUpdateViewModel
    {
        public string UserId { get; set; }
        [Required]
        [StringLength(maximumLength: 25)]
        public string UserName { get; set; }
        [Required]
        public string Role { get; set; }

        [StringLength(maximumLength: 20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
