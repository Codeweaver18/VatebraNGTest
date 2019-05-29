using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vatebra.web.ViewModels
{
    public class borowbookViewModel
    {
 
        [Display(Name = "Date Borrowed")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime dateBorrowed { get; set; }
        [Display(Name = "Date to return")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime dueReturnedDate { get; set; }
        [Display(Name = "Comments")]
        [Required]
        public string comments { get; set; }
        public string  bookid { get; set; }
        public string ApprovedById { get; set; }
    }
}
