using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class OrderDetail : EntityBase
    {
        public Product Product { get; set; }
        public int UnitPrice { get; set; }
        public int Qty { get; set; }
    }
}
