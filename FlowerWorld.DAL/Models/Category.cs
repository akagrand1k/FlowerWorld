using System.Collections.Generic;

namespace FlowerWorld.DAL.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public virtual ICollection<Product> FK_Product { get; set; }
    }
}