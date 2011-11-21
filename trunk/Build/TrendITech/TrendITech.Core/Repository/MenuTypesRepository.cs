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
    public class MenuTypesRepository : IMenuTypesRepository
    {
        private DataContext _dc;
        private Table<MenuTypes> _table;

        #region Class Constructor

        public MenuTypesRepository()
        {
            _dc = new DataContext(ConfigurationManager.ConnectionStrings["trenditechEntities"].ConnectionString);
            _table = _dc.GetTable<MenuTypes>();
        }
        
        #endregion

        #region Implementation of IBaseRepository<MenuTypes>

        public bool Create(MenuTypes createObject, out int id)
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

        public void Delete(MenuTypes deleteObject)
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

        public void Update(MenuTypes updateObject)
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

        public bool IfExists(MenuTypes existsObject)
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

        public MenuTypes Get(int id, bool onlyActive)
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

        public IEnumerable<MenuTypes> GetAll(bool onlyActive)
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

        public IEnumerable<MenuTypes> GetByPage(int pageNumber, int pageSize, bool onlyActive)
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

        public IEnumerable<MenuTypes> GetByPage<TKey>(int pageNumber, int pageSize, Enumerations.SortBy sortBy, Func<MenuTypes, TKey> sortFunc, bool onlyActive)
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
