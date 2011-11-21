using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Configuration;
using TrendITech.Core.Repository.Interface;
using TrendITech.Core.Entities;
using TrendITech.Core.Utilities;

namespace TrendITech.Core.Repository
{
    public class ProductsRepository : IProductsRepository
    {

        private DataContext _dc;
        private Table<Products> _table;

        #region Class Constructor

        public ProductsRepository()
        {
            _dc = new DataContext(ConfigurationManager.ConnectionStrings["trenditechEntities"].ConnectionString);
            _table = _dc.GetTable<Products>();
        }

        #endregion

        #region Implementation of IBaseRepository<Products>

        public bool Create(Products createObject, out int id)
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

        public void Delete(Products deleteObject)
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

        public void Update(Products updateObject)
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

        public bool IfExists(Products existsObject)
        {
            try
            {
                //throw new NotImplementedException();
                var exists = _table.Select(t => t.ModelNo == existsObject.ModelNo && t.Name == existsObject.Name && t.Category == existsObject.Category && t.PicUrl == existsObject.PicUrl);
                return true; //exists != null;
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return false;
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
                return false;
            }
        }

        public Products Get(int id, bool onlyActive)
        {
            try
            {
                return (Products)_table.Select(t => t.PkId == id);
                //return true;
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return null;
            }
        }

        public IEnumerable<Products> GetAll(bool onlyActive)
        {
            try
            {
                return _table.Where(t => t.ModelNo != null);
                //return true;
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return null;
            }
        }

        public IEnumerable<Products> GetByPage(int pageNumber, int pageSize, bool onlyActive)
        {
            try
            {
                return GetAll(onlyActive).Skip((pageNumber - 1) * pageSize).Take(pageSize);
                //return true;
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return null;
            }
        }

        public IEnumerable<Products> GetByPage<TKey>(int pageNumber, int pageSize, Enumerations.SortBy sortBy, Func<Products, TKey> sortFunc, bool onlyActive)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IProductsRepostory

        public Products GetByModelNo(string modelNo)
        {
            try
            {
                return _table.Where(t => t.ModelNo == modelNo) as Products;
                //return true;
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return null;
            }
        }

        public Products GetBySku(string sku)
        {
            try
            {
                return _table.Where(t => t.AmazonSku == sku).SingleOrDefault();
                //return true;
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return null;
            }
        }

        public IEnumerable<Products> GetByCategory(Category category)
        {
            try
            {
                throw new NotImplementedException();
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
