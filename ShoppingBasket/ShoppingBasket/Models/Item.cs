using ShoppingBasket.Common.Models;
using System;

namespace ShoppingBasket.Models
{
    public class Item : IItem
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid HashCode { get; set; }

        public Item()
        {
            HashCode = Guid.NewGuid();
        }

        public bool Equals(IItem other)
        {
            return HashCode == other.HashCode;
        }
    }
}
