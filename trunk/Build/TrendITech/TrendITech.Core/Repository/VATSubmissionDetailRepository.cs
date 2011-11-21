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
    public class VATSubmissionDetailRepository : IVATSubmissionDetailRepository
    {
        private DataContext _dc;
        private Table<VATSubmissionDetail> _table;

        #region Class Constructor

        public VATSubmissionDetailRepository()
        {
            _dc = new DataContext(ConfigurationManager.ConnectionStrings["trenditechEntities"].ConnectionString);
            _table = _dc.GetTable<VATSubmissionDetail>();
        }
        #endregion

        #region Implementation of IBaseRepository<VATSubmissionDetail>

        public bool Create(VATSubmissionDetail createObject, out int id)
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

        public void Delete(VATSubmissionDetail deleteObject)
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

        public void Update(VATSubmissionDetail updateObject)
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

        public bool IfExists(VATSubmissionDetail existsObject)
        {
            throw new NotImplementedException();
        }

        public bool ExistsByProperty(string propertyName, object value)
        {
            throw new NotImplementedException();
        }

        public VATSubmissionDetail Get(int id, bool onlyActive)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VATSubmissionDetail> GetAll(bool onlyActive)
        {
            try
            {
                return _table.Where(t => t.IsActive == onlyActive).OrderBy(t => t.Orderid);
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                throw new Exception("Error Occurs when load categories from table.");
            }
        }

        public IEnumerable<VATSubmissionDetail> GetByPage(int pageNumber, int pageSize, bool onlyActive)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VATSubmissionDetail> GetByPage<TKey>(int pageNumber, int pageSize, Enumerations.SortBy sortBy, Func<VATSubmissionDetail, TKey> sortFunc, bool onlyActive)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
