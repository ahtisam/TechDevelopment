using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace TrendITech.Core.Entities
{
    [Serializable]
    [Table(Name = "vatsubmission")]
    public class VATSubmission
    {
        [Column(CanBeNull = false, Name = "pkid", AutoSync = AutoSync.OnInsert, IsDbGenerated = true, IsPrimaryKey = true)]
        public int Pkid { get; private set; }

        [Column(CanBeNull = false, Name = "startdate")]
        public DateTime StartDate { get; set; }

        [Column(CanBeNull = false, Name = "enddate")]
        public DateTime EndDate { get; set; }

        [Column(CanBeNull = false, Name = "vatpercentage")]
        public double VatPercentage { get; set; }

        [Column(CanBeNull = false, Name = "totalitemsold")]
        public int TotalItemSold { get; set; }

        [Column(CanBeNull = false, Name = "totalsaleamount")]
        public double TotalSaleprice { get; set; }

        [Column(CanBeNull = false, Name = "totalfee")]
        public double Totalfee { get; set; }

        [Column(CanBeNull = false, Name = "totalamount")]
        public double TotalAmount { get; set; }

        [Column(CanBeNull = false, Name = "vatamount")]
        public double VatAmount { get; set; }
        
        [Column(CanBeNull = false, Name = "totalitemreclaim")]
        public int TotalItemReclaim { get; set; }
        
        [Column(CanBeNull = false, Name = "reclaimvatamount")]
        public double ReclaimVatAmount { get; set; }

        [Column(CanBeNull = false, Name = "totalpurchasedcost")]
        public double PurchaseCost { get; set; }

        [Column(CanBeNull = false, Name = "netamount")]
        public double NetAmount { get; set; }

        [Column(CanBeNull = false, Name = "vatpaidtohmrevenue")]
        public double VatPaidToHMRevenue { get; set; }
        
        [Column(CanBeNull = false, Name = "isactive")]
        public bool IsActive { get; set; }

        [Column(CanBeNull = false, Name = "createddate")]
        public DateTime CreatedDate { get; set; }


    }
}
