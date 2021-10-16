using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class HeaderFooterData
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string Location { get; set; }
        [Required]
        [StringLength(maximumLength: 70)]
        public string Number { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string LogoPart1 { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string LogoPart2 { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Twitter { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Facebook { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Google { get; set; }
    }
}
