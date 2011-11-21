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
    public class MenuRepository : IMenuRepository
    {
        private DataContext _dc;
        private Table<Menu> _table;

        #region Class Constructor

        public MenuRepository()
        {
            _dc = new DataContext(ConfigurationManager.ConnectionStrings["trenditechEntities"].ConnectionString);
            _table = _dc.GetTable<Menu>();
        }
        
        #endregion


        #region Implementation of IBaseRepository<Menu>

        public bool Create(Menu createObject, out int id)
        {
            try
            {
                _table.InsertOnSubmit(createObject);
                _dc.SubmitChanges();

                id = createObject.ID;
                return true;
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                id = 0;
                return false;
            }

        }

        public void Delete(Menu deleteObject)
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

        public void Update(Menu updateObject)
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

        public bool IfExists(Menu existsObject)
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

        public Menu Get(int id, bool onlyActive)
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

        public IEnumerable<Menu> GetAll(bool onlyActive)
        {
            try
            {
                return _table.Where(t => t.IsActive == onlyActive);
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Menu> GetAllParentItems(bool onlyActive)
        {
            try
            {
                return _table.Where(t => t.IsActive == onlyActive && t.ParentID == 0);
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Menu> GetByPage(int pageNumber, int pageSize, bool onlyActive)
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

        public IEnumerable<Menu> GetByPage<TKey>(int pageNumber, int pageSize, Enumerations.SortBy sortBy, Func<Menu, TKey> sortFunc, bool onlyActive)
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
