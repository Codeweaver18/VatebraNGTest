using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Vatebra.DataAccessLayer.Entities
{
   public class BookCopies:BaseEntity
    {
        //Bookid, yearPublished, abstract, description, versionCopyName
        [ForeignKey("bookId")]
        public virtual Books Books { get; set; }
        public DateTime yearPublished { get; set; }
        public string bookAbstract { get; set; }
        public string description{ get; set; }
        public string versionTitle { get; set; }
    }
}
