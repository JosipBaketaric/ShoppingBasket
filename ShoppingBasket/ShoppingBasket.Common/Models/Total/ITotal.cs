using System.Collections.Generic;

namespace ShoppingBasket.Common.Models.Total
{
    public interface ITotal
    {
        decimal Price { get; set; }
        IList<ITotalItem> TotalItems { get; }
    }
}
