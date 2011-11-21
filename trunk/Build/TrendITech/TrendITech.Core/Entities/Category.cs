using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace TrendITech.Core.Entities
{
    [Serializable]
    [Table(Name = "categorys")]
    public class Category
    {
        [Column(CanBeNull = false, Name = "pkid", AutoSync = AutoSync.OnInsert, IsDbGenerated = true, IsPrimaryKey = true)]
        public int Pkid { get; private set; }

        [Column(CanBeNull = false, Name = "name")]
        public string Name { get; set; }

        [Column(CanBeNull = true, Name = "description")]
        public string Desc { get; set; }

        [Column(CanBeNull = false, Name = "isactive")]
        public bool IsActive { get; set; }

        [Column(CanBeNull = false, Name = "createddate")]
        public DateTime CreatedDate { get; set; }

        //private EntityRef<Products> _product;
        //[Association(Storage = "_product", IsForeignKey = true, ThisKey = "pkid", OtherKey = "categoryidfk")]
        //public Products Product
        //{
        //    get { return this._product.Entity; }
        //    set { this._product.Entity = value; }
        //}

    }
}
