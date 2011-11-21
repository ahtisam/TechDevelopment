using System;
using System.Data.Linq.Mapping;
using TrendITech.Core.Entities.Interface;

namespace TrendITech.Core.Entities
{
    [Serializable]
    [Table(Name = "amazon_transactions_v2")]
    public class AmazonTransactionsV2 : IAmamzonTransactionV2Int
    {
        [Column(CanBeNull = false, Name = "id", AutoSync = AutoSync.OnInsert, IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column(CanBeNull = true, Name = "settlementid")]
        public long Settlementid { get; set; }

        [Column(CanBeNull = true, Name = "settlementstartdate")]
        public DateTime? Settlementstartdate { get; set; }

        [Column(CanBeNull = true, Name = "settlementenddate")]
        public DateTime? Settlementenddate { get; set; }

        [Column(CanBeNull = true, Name = "depositdate")]
        public DateTime? Depositdate { get; set; }

        [Column(CanBeNull = true, Name = "totalamount")]
        public Double Totalamount { get; set; }

        [Column(CanBeNull = true, Name = "currency")]
        public string Currency { get; set; }

        [Column(CanBeNull = true, Name = "transactiontype")]
        public string Transactiontype { get; set; }

        [Column(CanBeNull = true, Name = "orderid")]
        public string Orderid { get; set; }

        [Column(CanBeNull = true, Name = "merchantorderid")]
        public string Merchantorderid { get; set; }

        [Column(CanBeNull = true, Name = "adjustmentid")]
        public string Adjustmentid { get; set; }

        [Column(CanBeNull = true, Name = "shipmentid")]
        public string Shipmentid { get; set; }

        [Column(CanBeNull = true, Name = "marketplacename")]
        public string Marketplacename { get; set; }

        [Column(CanBeNull = true, Name = "amounttype")]
        public string Amounttype { get; set; }

        [Column(CanBeNull = true, Name = "amountdescription")]
        public string Amountdescription { get; set; }

        [Column(CanBeNull = true, Name = "amount")]
        public Double Amount { get; set; }

        [Column(CanBeNull = true, Name = "fulfillmentid")]
        public string Fulfillmentid { get; set; }

        [Column(CanBeNull = true, Name = "posteddate")]
        public DateTime? Posteddate { get; set; }

        [Column(CanBeNull = true, Name = "posteddatetime")]
        public DateTime? Posteddatetime { get; set; }

        [Column(CanBeNull = true, Name = "orderitemcode")]
        public string Orderitemcode { get; set; }

        [Column(CanBeNull = true, Name = "merchantorderitemid")]
        public string Merchantorderitemid { get; set; }

        [Column(CanBeNull = true, Name = "merchantadjustmentitemid")]
        public string Merchantadjustmentitemid { get; set; }

        [Column(CanBeNull = true, Name = "sku")]
        public string Sku { get; set; }

        [Column(CanBeNull = true, Name = "quantitypurchased")]
        public int Quantitypurchased { get; set; }

        [Column(CanBeNull = true, Name = "promotionid")]
        public string Promotionid { get; set; }

        [Column(CanBeNull = true, Name = "createddate")]
        public DateTime CreatedDate { get; set; }
    }
}
