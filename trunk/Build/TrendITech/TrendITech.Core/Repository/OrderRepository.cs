using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Text;
using TrendITech.Core.Entities;
using TrendITech.Core.Repository.Interface;
using TrendITech.Core.Utilities;

namespace TrendITech.Core.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private DataContext _dc;
        private Table<Order> _table;

        #region Class Constructor

        public OrderRepository()
        {
            _dc = new DataContext(ConfigurationManager.ConnectionStrings["trenditechEntities"].ConnectionString);
            _table = _dc.GetTable<Order>();
        }
        
        #endregion

        #region Implementation of IBaseRepository<Order>

        public bool Create(Order createObject, out int id)
        {
            try
            {
                _table.InsertOnSubmit(createObject);
                _dc.SubmitChanges();

                id = createObject.PkId;
                return true;
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                id = 0;
                return false;
            }
        }

        public void Delete(Order deleteObject)
        {
            try
            {
                _table.DeleteOnSubmit(deleteObject);
                _dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
            }
        }

        public void Update(Order updateObject)
        {
            try
            {
                _table.InsertOnSubmit(updateObject);
                _dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
            }
        }

        public bool IfExists(Order existsObject)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                throw new NotImplementedException();
            }
        }

        public bool ExistsByProperty(string propertyName, object value)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                throw new NotImplementedException();
            }
        }

        public Order Get(int id, bool onlyActive)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Order> GetAll(bool onlyActive)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                throw new NotImplementedException();
            } 
        }

        public IEnumerable<Order> GetByPage(int pageNumber, int pageSize, bool onlyActive)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Order> GetByPage<TKey>(int pageNumber, int pageSize, Enumerations.SortBy sortBy, Func<Order, TKey> sortFunc, bool onlyActive)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                throw new NotImplementedException();
            }
        }

        #endregion
        
    }
}
