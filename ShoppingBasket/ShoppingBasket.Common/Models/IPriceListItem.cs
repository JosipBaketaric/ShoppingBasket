namespace ShoppingBasket.Common.Models
{
    public interface IPriceListItem : IModel
    {
        IItem Item { get; set; }
        decimal Price { get; set; }
        IPriceList PriceList { get; set; }
    }
}
