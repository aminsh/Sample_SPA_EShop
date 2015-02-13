using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
