using System;
using System.Collections.Generic;
using System.Text;

namespace Vatebra.DataAccessLayer.Entities
{
   
//bookName, bookTitle, BookAuthor, PublishedYear, <ListCopies>

    public class Books:BaseEntity
    {
        public string bookName { get; set; }
        public string bookTitle { get; set; }
        public string BookAuthor { get; set; }
        public virtual IEnumerable<BookCopies> bookCopies { get; set; }
        public virtual BookSubscriptionDetails BookSubscriptionDetails { get;set }