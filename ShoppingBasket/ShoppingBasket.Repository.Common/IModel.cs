using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Repository.Common
{
    public interface IModel
    {
        Guid ID { get; set; }
    }
}
