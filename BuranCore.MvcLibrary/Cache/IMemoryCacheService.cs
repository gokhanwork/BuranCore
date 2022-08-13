using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buran.Core.MvcLibrary.Cache
{
    public interface IMemoryCacheService
    {
        List<T> GetList<T>() where T : class;

        void Load<T>(List<T> value) where T : class;

        T GetItem<T>(int id) where T : class;

        void RemoveItem<T>(T item) where T : class;

        void Update<T>(T item) where T : class;

        void Insert<T>(T item) where T : class;
    }
}
