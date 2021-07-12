using ShoppingBasket.Common.Models.Total;
using System.Collections.Generic;

namespace ShoppingBasket.Models.Total
{
    public class Total : ITotal
    {
        public decimal Price { get; set; }
        public IList<ITotalItem> TotalItems { get; }
    }
}
