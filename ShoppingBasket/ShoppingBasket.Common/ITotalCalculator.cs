using ShoppingBasket.Common.Models;
using System.Collections.Generic;

namespace ShoppingBasket.Common
{
    public interface ITotalCalculator
    {
        decimal Calculate(IBasket basket, IEnumerable<IDiscount> discounts);
    }
}
