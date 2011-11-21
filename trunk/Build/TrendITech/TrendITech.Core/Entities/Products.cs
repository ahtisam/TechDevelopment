using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace TrendITech.Core.Entities
{
    [Serializable]
    [Table(Name = "products")]
    public class Products
    {
        [Column(CanBeNull = false, AutoSync = AutoSync.OnInsert, IsDbGenerated = true, IsPrimaryKey = true)]
        public int PkId { get; set; }
        [Column(CanBeNull = true, Name = "categoryidfk")]
        public int CategoryID { get; set; }

        [Column(CanBeNull = false, Name = "model_no")]
        public string ModelNo { get; set; }
        
        [Column(CanBeNull = true, Name = "size")]
        public string Size { get; set; }
        
        [Column(CanBeNull = true, Name = "name")]
        public string Name { get; set; }

        [Column(CanBeNull = false, Name = "cost")]
        public double Cost { get; set; }

        [Column(CanBeNull = true, Name = "picture_url")]
        public string PicUrl { get; set; }
        
        [Column(CanBeNull = true, Name = "amazonsku")]
        public string AmazonSku { get; set; }
        
        [Column(CanBeNull = true, Name = "createddate")]
        public DateTime? CreatedDate { get; set; }

        private EntityRef<Category> _Category;
        [Association(Name = "categoryidfk", Storage = "_Category", IsForeignKey = true, ThisKey = "CategoryID", OtherKey = "Pkid")]
        public Category Category
        {
            get { return _Category.Entity; } //return from c in _ActProp where (c.value != null) select c;
            set { this._Category.Entity = value; }
        }
    }
}
