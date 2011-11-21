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
    public class TempVatCalcRepository : ITempVatCalcRepository
    {

        private DataContext _dc;
        private Table<TempVatCalc> _table;

        #region Class Constructor

        public TempVatCalcRepository()
        {
            _dc = new DataContext(ConfigurationManager.ConnectionStrings["trenditechEntities"].ConnectionString);
            _table = _dc.GetTable<TempVatCalc>();
        }

        #endregion

        #region Implementation of IBaseRepository<TempVatCalc>

        public bool Create(TempVatCalc createObject, out int id)
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

        public void Delete(TempVatCalc deleteObject)
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

        public void DeleteAll()
        {
            try
            {
                //_table.DeleteOnSubmit(deleteObject);
                _dc.ExecuteCommand("TRUNCATE TABLE tempVAT;");
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
            }
        }

        public void Update(TempVatCalc updateObject)
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

        public bool IfExists(TempVatCalc existsObject)
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
            throw new NotImplementedException();
        }

        public TempVatCalc Get(int id, bool onlyActive)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TempVatCalc> GetAll(bool onlyActive)
        {
            try
            {
                return _table.Where(t => t.IsActive == onlyActive).OrderBy(t =>t.Orderid);
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                throw new Exception("Error Occurs when load categories from table.");
            }
        }

        public IEnumerable<TempVatCalc> GetByPage(int pageNumber, int pageSize, bool onlyActive)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TempVatCalc> GetByPage<TKey>(int pageNumber, int pageSize, Enumerations.SortBy sortBy, Func<TempVatCalc, TKey> sortFunc, bool onlyActive)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
