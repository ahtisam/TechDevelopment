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
    public class VATSubmissionRepository : IVATSubmissionRepository
    {
        private DataContext _dc;
        private Table<VATSubmission> _table;

        #region Class Constructor

        public VATSubmissionRepository()
        {
            _dc = new DataContext(ConfigurationManager.ConnectionStrings["trenditechEntities"].ConnectionString);
            _table = _dc.GetTable<VATSubmission>();
        }

        #endregion

        #region Implementation of IBaseRepository<VATSubmission>

        public bool Create(VATSubmission createObject, out int id)
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

        public void Delete(VATSubmission deleteObject)
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

        public void Update(VATSubmission updateObject)
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

        public bool IfExists(VATSubmission existsObject)
        {
            throw new NotImplementedException();
        }

        public bool ExistsByProperty(string propertyName, object value)
        {
            throw new NotImplementedException();
        }

        public VATSubmission Get(int id, bool onlyActive)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VATSubmission> GetAll(bool onlyActive)
        {
            try
            {
                return _table.Where(t => t.IsActive == onlyActive);
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                throw new Exception("Error Occurs when load categories from table.");
            }
        }

        public IEnumerable<VATSubmission> GetByPage(int pageNumber, int pageSize, bool onlyActive)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VATSubmission> GetByPage<TKey>(int pageNumber, int pageSize, Enumerations.SortBy sortBy, Func<VATSubmission, TKey> sortFunc, bool onlyActive)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
