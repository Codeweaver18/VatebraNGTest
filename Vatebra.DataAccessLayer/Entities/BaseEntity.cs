using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Vatebra.DataAccessLayer.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime dateCreated { get; set; } = DateTime.Now;
        public DateTime dateModified { get; set; } = DateTime.Now;
        public bool isActive { get; set; } = true;
    }
}
