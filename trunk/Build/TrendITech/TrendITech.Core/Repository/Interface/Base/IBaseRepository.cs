using System;
using System.Collections.Generic;
using System.Linq;

namespace TrendITech.Core.Repository.Interface.Base
{
    public interface IBaseRepository<T>
    {

        #region CURD functions

        bool Create(T createObject, out int id);
        void Delete(T deleteObject);
        void Update(T updateObject);
        bool IfExists(T existsObject);
        bool ExistsByProperty(string propertyName, object value);

        T Get(int id, bool onlyActive = true);
        IEnumerable<T> GetAll(bool onlyActive = true);
        IEnumerable<T> GetByPage(int pageNumber, int pageSize, bool onlyActive = true);
        IEnumerable<T> GetByPage<TKey>(int pageNumber, int pageSize, Enumerations.SortBy sortBy, Func<T, TKey> sortFunc, bool onlyActive = true);

        #endregion
    }
}
