using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace TrendITech.Core.Entities
{
    [Serializable]
    [Table(Name = "menutypes")]
    public class MenuTypes
    {
        [Column(CanBeNull = false, Name = "pkid", IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, IsDbGenerated = true)]
        public int ID { get; set; }
        [Column(CanBeNull = false, Name = "name")]
        public string Name { get; set; }
        [Column(CanBeNull = true, Name = "description")]
        public string Desc { get; set; }
        [Column(CanBeNull = false, Name = "isactive")]
        public bool IsActive { get; set; }
        [Column(CanBeNull = false, Name = "createddate")]
        public DateTime CreatedDate { get; set; }
    }
}
