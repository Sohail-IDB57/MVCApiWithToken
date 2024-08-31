using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam_MD.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}