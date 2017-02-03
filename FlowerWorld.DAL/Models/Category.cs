using System.Collections.Generic;

namespace FlowerWorld.DAL.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string smallPath { get; set; }
        public string largePath { get; set; }

        public virtual ICollection<Product> FK_Product { get; set; }
    }
}