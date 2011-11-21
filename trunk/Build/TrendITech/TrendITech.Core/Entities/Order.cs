using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace TrendITech.Core.Entities
{
    [Serializable]
    [Table(Name = "orders")]
    public class Order
    {

        [Column(CanBeNull = false, Name = "pkid", AutoSync = AutoSync.OnInsert, IsDbGenerated = true, IsPrimaryKey = true)]
        public int PkId { get; set; }
        [Column(CanBeNull = false, Name = "ordercreateddate")]
        public DateTime CreatedDate { get; set; }
        [Column(CanBeNull = false, Name = "orderexpecteddate")]
        public DateTime ExpectedDate { get; set; }
        [Column(CanBeNull = false, Name = "totalamount")]
        public double TotalAmt { get; set; }
        [Column(CanBeNull = false, Name = "totalitems")]
        public int TotalItems { get; set; }
        [Column(CanBeNull = false, Name = "orderstatus_fkid")]
        public int StatusID { get; set; }
        [Column(CanBeNull = true, Name = "note_ref")]
        public string RefNotes { get; set; }
        [Column(CanBeNull = true, Name = "shippingno")]
        public string ShippingNo { get; set; }
        [Column(CanBeNull = true, Name = "shippmentthroughbank")]
        public bool ShippmentThroughBank { get; set; }
        [Column(CanBeNull = true, Name = "bankcharges")]
        public bool BankCharges { get; set; }
        [Column(CanBeNull = true, Name = "freight")]
        public double Fregith { get; set; }
        [Column(CanBeNull = true, Name = "paidvatamount")]
        public double PaidVatAmt { get; set; }
        [Column(CanBeNull = true, Name = "shippingdate")]
        public DateTime ShippingDate { get; set; }
        [Column(CanBeNull = true, Name = "totalshippingitems")]
        public int TotalShippedItems { get; set; }
        [Column(CanBeNull = true, Name = "totalshippingamount")]
        public double TotalShippedAmt { get; set; }
        [Column(CanBeNull = true, Name = "advance")]
        public double Advance { get; set; }
        [Column(CanBeNull = true, Name = "advancebankcharges")]
        public double AdvanceBankCharges { get; set; }
        [Column(CanBeNull = true, Name = "invoiceno")]
        public string InvoiceNo { get; set; }
        [Column(CanBeNull = true, Name = "orderhistory")]
        public string History { get; set; }
        [Column(CanBeNull = true, Name = "receiveditems")]
        public int TotalReceivedItems { get; set; }
        [Column(CanBeNull = true, Name = "receivedamount")]
        public Double TotalReceivedAmt { get; set; }
        [Column(CanBeNull = true, Name = "receiveddate")]
        public DateTime ReceivedDate { get; set; }

        private EntitySet<OrderItemsDetail> _OrderItemDetails;
        [Association(Storage = "_OrderItemDetails", IsForeignKey = true, ThisKey = "PkId", OtherKey = "OrderIdFk")]
        public EntitySet<OrderItemsDetail> ActivityProperties
        {
            get { return this._OrderItemDetails; } //return from c in _ActProp where (c.value != null) select c;
            set { this._OrderItemDetails.Assign(value); }
        }

    }
}
