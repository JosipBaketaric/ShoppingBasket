namespace ShoppingBasket.Common.Models.Total
{
    public interface ITotalItem
    {
        IItem Item { get; set; }
        decimal Price { get; set; }
        decimal PriceWithDiscount { get; set; }
        IDiscount Discount { get; set; }
    }
}
