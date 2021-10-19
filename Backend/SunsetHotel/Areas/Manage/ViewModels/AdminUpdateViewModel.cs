using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Areas.Manage.ViewModels
{
    public class AdminUpdateViewModel
    {
        public string UserName { get; set; }
        [StringLength(maximumLength: 20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(maximumLength: 20)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [StringLength(maximumLength: 20)]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
    }
}
