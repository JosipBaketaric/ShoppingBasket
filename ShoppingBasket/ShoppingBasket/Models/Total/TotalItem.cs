using ShoppingBasket.Common.Models;
using ShoppingBasket.Common.Models.Total;

namespace ShoppingBasket.Models.Total
{
    public class TotalItem : ITotalItem
    {
        public IItem Item { get; set; }
        public decimal Price { get; set; }
        public decimal PriceWithDiscount { get; set; }
        public IDiscount Discount { get; set; }
    }
}
