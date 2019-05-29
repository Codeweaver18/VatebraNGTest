using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vatebra.web.ViewModels
{
    public class BorrowedBooksViewModel
    {
        public string ApprovedById { get; set; }
        public DateTime dateBorrowed { get; set; }
        public DateTime dueReturnedDate { get; set; }
        public string comments { get; set; }
    }
}
