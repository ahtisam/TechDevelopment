using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace TrendITech.Core.Entities
{
    [Serializable]
    [Table(Name = "inventory")]
    public class Inventory
    {
        [Column(CanBeNull = false, Name = "pkid", AutoSync = AutoSync.OnInsert, IsDbGenerated = true, IsPrimaryKey = true)]
        public int Pkid { get; private set; }

        [Column(CanBeNull = false, Name = "model_no")]
        public string ModelNo { get; set; }

        [Column(CanBeNull = false, Name = "qty")]
        public int Qty { get; set; }

        [Column(CanBeNull = false, Name = "cost")]
        public decimal Cost { get; set; }

        [Column(CanBeNull = false, Name = "journalid")]
        public int JournalId { get; set; }

        [Column(CanBeNull = false, Name = "isactive")]
        public bool IsActive { get; set; }

        [Column(CanBeNull = true, Name = "createddate")]
        public DateTime CreatedDate { get; set; }

    }
}
