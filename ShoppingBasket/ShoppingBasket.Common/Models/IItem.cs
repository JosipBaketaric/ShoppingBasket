using System;

namespace ShoppingBasket.Common.Models
{
    public interface IItem : IModel, IEquatable<IItem>
    {
        string Name { get; set; }
        string Code { get; set; }
        Guid HashCode { get; set; }
    }
}
