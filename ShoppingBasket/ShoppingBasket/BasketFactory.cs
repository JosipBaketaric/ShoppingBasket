using ShoppingBasket.Common;

namespace ShoppingBasket
{
    /// <summary>
    /// Factory for creating basket.
    /// Basket is created as singleton
    /// </summary>
    public class BasketFactory : IBasketFactory
    {
        private IBasket Basket;

        public BasketFactory(IBasket basket)
        {
            Basket = basket;
        }

        public IBasket GetBasket()
        {
            return this.Basket;
        }

    }
}
