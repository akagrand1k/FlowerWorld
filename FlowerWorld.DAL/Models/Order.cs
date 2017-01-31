using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWorld.DAL.Models
{
    public class Order : BaseEntity
    {
        public string CustomerName { get; set; }
        public string CusmomerPhone { get; set; }
        public DateTime DateOrder { get; set; }
        public int ProductId { get; set; }
        public string DesciptionOrder { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}