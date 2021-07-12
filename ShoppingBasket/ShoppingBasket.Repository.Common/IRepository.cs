using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Repository.Common
{
    public interface IRepository
    {
        IQueryable<T> Query<T>() where T : IModel;
        int Add<T>(T entity) where T : IModel;
        int Update<T>(T entity) where T : IModel;
        int Delete<T>(T entity) where T : IModel;
        int Delete<T>(Guid id) where T : IModel;
    }
}
