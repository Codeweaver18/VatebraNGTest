using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vatebra.web.ViewModels
{
    public class addBookCopiesViewModel
    {

        [Display(Name = "Year Published")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime yearPublished { get; set; }
        [Display(Name = "Abstract")]
        [Required]
        public string bookAbstract { get; set; }
        [Display(Name = "Description")]
        [Required]
        public string description { get; set; }
        [Display(Name = "Vertion Title")]
        [Required]
        public string versionTitle { get; set; }
        public string bookId { get; set; }
    }
}
