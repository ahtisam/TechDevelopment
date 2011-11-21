using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace TrendITech.Core.Entities
{
    [Serializable]
    [Table(Name = "order_details")]
    public class OrderItemsDetail
    {
        //private EntityRef<Order> _order;
        //[Association(Storage = "_order", IsForeignKey = true, ThisKey = "OrderIdFk", OtherKey = "Pkid")]
        //public Order Order
        //{
        //    get { return this._order.Entity; }
        //    set { this._order.Entity = value; }
        //}

        [Column(CanBeNull = false, Name = "pkid", AutoSync = AutoSync.OnInsert, IsDbGenerated = true, IsPrimaryKey = true)]
        public int PkId { get; set; }
        [Column(CanBeNull = false, Name = "order_fkid")]
        public int OrderIdFk { get; set;}
        [Column(CanBeNull = false, Name = "product_fkid")]
        public int ProductIdFk { get; set; }
        [Column(CanBeNull = false, Name = "unitqty")]
        public int UnitQty { get; set; }
        [Column(CanBeNull = false, Name = "unitprice")]
        public double UnitCost { get; set; }
        [Column(CanBeNull = true, Name = "note_ref")]
        public string RefNotes { get; set; }
        [Column(CanBeNull = true, Name = "shippedunitqty")]
        public int ShippedUnitQty { get; set; }
        [Column(CanBeNull = true, Name = "shippedunitprice")]
        public double ShippedUnitCost { get; set; }
        [Column(CanBeNull = true, Name = "shippedunitcost")]
        public double ShippedUnitPrice { get; set; }
        [Column(CanBeNull = true, Name = "receivedunitqty")]
        public int ReceivedUnitQty { get; set; }
        [Column(CanBeNull = true, Name = "isactive")]
        public bool IsActive { get; set; }
        [Column(CanBeNull = true, Name = "createddate")]
        public bool CreatedDate { get; set; }
    }
}
