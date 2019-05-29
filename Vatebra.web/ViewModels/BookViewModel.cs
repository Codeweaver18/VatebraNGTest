using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vatebra.web.ViewModels
{
    public class BookViewModel
    {
        [Required]
        [Display(Name ="Name")]
        public string bookName { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string bookTitle { get; set; }
        [Required]
        [Display(Name = "Author")]
        public string BookAuthor { get; set; }
    }
}
