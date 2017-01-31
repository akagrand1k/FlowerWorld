using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWorld.DAL.Models
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string smallPath { get; set; }
        public string largePath { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public virtual ICollection<Order> FK_Order { get; set; }
    }
}