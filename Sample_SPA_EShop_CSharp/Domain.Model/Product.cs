using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
    }
}
