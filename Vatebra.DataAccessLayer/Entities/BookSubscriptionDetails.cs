using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Vatebra.DataAccessLayer.Entities
{
   public class BookSubscriptionDetails:BaseEntity
    {
       
        [ForeignKey("bookId")]
        public virtual Books Books { get; set; }
        public string Description { get; set; }
        public string isfree { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
  

    }
}
