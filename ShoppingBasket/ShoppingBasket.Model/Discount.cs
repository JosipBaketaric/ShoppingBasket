using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Model
{
    public class Discount
    {
        public string Description { get; set; }
        public Func<IEnumerable<Item>,> DiscountFunc { get; set; }
    }
}
