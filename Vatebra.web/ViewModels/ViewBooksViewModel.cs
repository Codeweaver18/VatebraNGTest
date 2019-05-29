using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vatebra.web.ViewModels
{
    public class ViewBooksViewModel
    {

       
        [Display(Name = "Name")]
        public string bookName { get; set; }

       
        [Display(Name = "Title")]
        public string bookTitle { get; set; }

        [Display(Name = "Author")]
        public string BookAuthor { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Free Subscription ?")]
        public string isfree { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }


        [Display(Name = "Total Copies")]
        public string copies { get; set; }
    }
}
