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
    public class InventoryRepository : IInventoryRepository
    {
        private DataContext _dc;
        private Table<Inventory> _table;

        #region Class Constructor

        public InventoryRepository()
        {
            _dc = new DataContext(ConfigurationManager.ConnectionStrings["trenditechEntities"].ConnectionString);
            _table = _dc.GetTable<Inventory>();
        }

        #endregion


        #region Implementation of IBaseRepository<Inventory>

        public bool Create(Inventory createObject, out int id)
        {
            try
            {
                _table.InsertOnSubmit(createObject);
                _dc.SubmitChanges();

                id = createObject.Pkid;
                return true;
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                id = 0;
                return false;
            }

        }

        public void Delete(Inventory deleteObject)
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

        public void Update(Inventory updateObject)
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

        public bool IfExists(Inventory existsObject)
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

        public Inventory Get(int id, bool onlyActive)
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

        public IEnumerable<Inventory> GetAll(bool onlyActive)
        {
            try
            {
                return _table.Where(t => t.IsActive == onlyActive).OrderBy(t => t.ModelNo);
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Inventory> GetByPage(int pageNumber, int pageSize, bool onlyActive)
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

        public IEnumerable<Inventory> GetByPage<TKey>(int pageNumber, int pageSize, Enumerations.SortBy sortBy, Func<Inventory, TKey> sortFunc, bool onlyActive)
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


        #region Implementation of IProductsRepostory

        public Inventory GetByModelNo(string modelNo)
        {
            try
            {
                return (Inventory)_table.Select(t => t.ModelNo == modelNo);
                //return true;
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return null;
            }
        }


        #endregion
    }
}
