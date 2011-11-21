using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrendITech.Core.Entities.Interface
{
    public interface IAmamzonTransactionV2Int
    {

        int Id { get; set; }
        long Settlementid { get; set; }
        DateTime? Settlementstartdate { get; set; }
        DateTime? Settlementenddate { get; set; }
        DateTime? Depositdate { get; set; }
        Double Totalamount { get; set; }
        string Currency { get; set; }
        string Transactiontype { get; set; }
        string Orderid { get; set; }
        string Merchantorderid { get; set; }
        string Adjustmentid { get; set; }
        string Shipmentid { get; set; }
        string Marketplacename { get; set; }
        string Amounttype { get; set; }
        string Amountdescription { get; set; }
        Double Amount { get; set; }
        string Fulfillmentid { get; set; }
        DateTime? Posteddate { get; set; }
        DateTime? Posteddatetime { get; set; }
        string Orderitemcode { get; set; }
        string Merchantorderitemid { get; set; }
        string Merchantadjustmentitemid { get; set; }
        string Sku { get; set; }
        int Quantitypurchased { get; set; }
        string Promotionid { get; set; }
    }
}
