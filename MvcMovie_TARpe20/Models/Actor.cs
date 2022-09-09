using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie_TARpe20.Models
{
    public class Actor
    {
        
        public int Id { get; set; }
        [Display(Name = "First Name")]

        [Required]
        [StringLength(25,MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


        [Required]
        [Display(Name = "Number Of Oscars")]
        public int NumberOfOscars { get; set; }

        [Required]
        [Display(Name = "Birth Place")]
        public string BirthPlace { get; set; }

        [Required]
        [Display(Name = "Networth")]
        public int NetWorth { get; set; }
    }
}
