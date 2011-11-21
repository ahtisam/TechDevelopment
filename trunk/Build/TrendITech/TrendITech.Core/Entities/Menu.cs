using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace TrendITech.Core.Entities
{
    [Serializable]
    [Table(Name = "menu")]
    public class Menu
    {
        [Column(CanBeNull = false, Name = "pkid",IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, IsDbGenerated = true)]
        public int ID { get; set; }
        [Column(CanBeNull = true, Name = "parentid")]
        public int ParentID { get; set; }
        [Column(CanBeNull = false, Name = "menutypeid")]
        public int MenuTypeID { get; set; }
        [Column(CanBeNull = false, Name = "name")]
        public string Name { get; set; }
        [Column(CanBeNull = false, Name = "url")]
        public string Url { get; set; }
        [Column(CanBeNull = true, Name = "description")]
        public string Desc { get; set; }
        [Column(CanBeNull = false, Name = "isactive")]
        public bool IsActive { get; set; }
        [Column(CanBeNull = false, Name = "createddate")]
        public DateTime CreatedDate { get; set; }


        private EntityRef<MenuTypes> _MenuTypes;
        [Association(Name = "menutypeid", Storage = "_MenuTypes", IsForeignKey = true, ThisKey = "MenuTypeID", OtherKey = "ID")]
        public MenuTypes menuType
        {
            get { return _MenuTypes.Entity; } //return from c in _ActProp where (c.value != null) select c;
            set { this._MenuTypes.Entity = value; }
        }

    }
}
