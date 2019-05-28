using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Vatebra.DataAccessLayer.Entities
{
    public class BooksBorrowed:BaseEntity
    {
        //BookId, BorrowedById, ApprovedByid, Amount, dateBorrowed, dueReturnedDate, comments
        [ForeignKey("bookId")]
        public virtual Books books{ get; set; }
        public string ApprovedById { get; set; }
        public DateTime dateBorrowed { get; set; }
        public DateTime dueReturnedDate { get; set; }
        public string comments { get; set; }
    }
}
