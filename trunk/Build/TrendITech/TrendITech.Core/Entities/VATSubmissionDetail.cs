using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace TrendITech.Core.Entities
{

    [Serializable]
    [Table(Name = "vatsubmission_detail")]
    public class VATSubmissionDetail
    {
        [Column(CanBeNull = false, Name = "pkid", AutoSync = AutoSync.OnInsert, IsDbGenerated = true, IsPrimaryKey = true)]
        public int Pkid { get; private set; }

        [Column(CanBeNull = false, Name = "vatsubmissionfkid")]
        public int VatSubmissionfkid { get; set; }

        [Column(CanBeNull = false, Name = "settlementid")]
        public string Settlementid { get; set; }

        [Column(CanBeNull = false, Name = "transactiontype")]
        public string Transactiontype { get; set; }

        [Column(CanBeNull = false, Name = "orderid")]
        public string Orderid { get; set; }

        [Column(CanBeNull = false, Name = "saleprice")]
        public double Saleprice { get; set; }

        [Column(CanBeNull = false, Name = "amazonfee")]
        public double Amazonfee { get; set; }

        [Column(CanBeNull = false, Name = "totalamount")]
        public double TotalAmount { get; set; }

        [Column(CanBeNull = false, Name = "vatamt")]
        public double VatAmt { get; set; }

        [Column(CanBeNull = false, Name = "reclaimvatamt")]
        public double ReclaimVatAmt { get; set; }

        [Column(CanBeNull = false, Name = "purchasecost")]
        public double PurchaseCost { get; set; }

        [Column(CanBeNull = false, Name = "netamount")]
        public double NetAmount { get; set; }

        [Column(CanBeNull = true, Name = "fullfilmentby")]
        public string Fullfilmentby { get; set; }

        [Column(CanBeNull = true, Name = "purchaseddate")]
        public DateTime Purchaseddate { get; set; }

        [Column(CanBeNull = false, Name = "isactive")]
        public bool IsActive { get; set; }

        [Column(CanBeNull = false, Name = "createddate")]
        public DateTime CreatedDate { get; set; }

    }
}
