using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrendITech.Core.Entities;
using TrendITech.Core.Repository;

namespace TrendITech.UI.usercontrols.reporting
{
    public partial class VATCalculation : System.Web.UI.UserControl
    {
        private readonly AmazonTransactionsV2Repository _amazonTransactions = new AmazonTransactionsV2Repository();

        private readonly VATSubmissionDetailRepository _submissionDetailRepository = new VATSubmissionDetailRepository();

        private readonly VATSubmissionRepository _submissionRepository = new VATSubmissionRepository();

        private readonly TempVatCalcRepository _tempVatCalcRep = new TempVatCalcRepository();

        public double TotalSalePrice { get; set; }
        public double TotalFee { get; set; }
        public double TotalAmount { get; set; }
        public double TotalVat { get; set; }
        public double TotalPurchasedCost { get; set; }
        public double TotalNetAmount { get; set; }
        public double TotalReclaimVat { get; set; }
        public int TotalItemSold { get; set; }
        public int TotalItemReclaim { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtVATPercentage.Text = ConfigurationManager.AppSettings["VATPercentage"];
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            lblTotalAmt.Text = Math.Round(TotalAmount, 2).ToString();
            lblTotalPrice.Text = Math.Round(TotalSalePrice, 2).ToString();
            lblTotalFee.Text = Math.Round(TotalFee, 2).ToString();
            lblTotalVAT.Text = Math.Round(TotalVat, 2).ToString();
            lblTotalPurchasedCost.Text = Math.Round(TotalPurchasedCost, 2).ToString();
            lblTotalNetAmt.Text = Math.Round(TotalNetAmount, 2).ToString();
            lblReclaimVAT.Text = Math.Round(TotalReclaimVat, 2).ToString();
            lblTotalItemSold.Text = TotalItemSold.ToString();
            lblTotalItemReclaim.Text = TotalItemReclaim.ToString();
        }

        protected void btnLoadVatReport_Click(object sender, EventArgs e)
        {
            var result = _amazonTransactions.CalculateVAT(Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text), Convert.ToDouble(txtVATPercentage.Text));
            lstVAT.DataSource = result;
            lstVAT.DataBind();
            lblRecordCount.Text = lstVAT.Items.Count.ToString();
        }

        protected void lstVAT_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var dataItem = (ListViewDataItem)e.Item;
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var lblItemSalePrice = (Label)e.Item.FindControl("lblItemSalePrice");
                var lblItemFee = (Label)e.Item.FindControl("lblItemFee");
                var lblItemAmt = (Label)e.Item.FindControl("lblItemAmt");
                var lblItemVat = (Label)e.Item.FindControl("lblItemVAT");
                var lblItemPurchasedCost = (Label)e.Item.FindControl("lblItemPurchasedCost");
                var lblItemNetAmount = (Label)e.Item.FindControl("lblItemNetAmount");
                var lblReclaimVat = (Label)e.Item.FindControl("lblReclaimVAT");
                
                var lblTransactionType = (Label)e.Item.FindControl("lblTransactionType");

                switch (lblTransactionType.Text.ToLower())
                {
                    case "order":
                        TotalItemSold++;
                        break;
                    case "adjustment":
                        TotalItemReclaim++;
                        break;
                }

                TotalSalePrice += Convert.ToDouble(lblItemSalePrice.Text);
                TotalFee += Convert.ToDouble(lblItemFee.Text);
                TotalAmount += Convert.ToDouble(lblItemAmt.Text);
                TotalVat += Convert.ToDouble(lblItemVat.Text);
                TotalPurchasedCost += Convert.ToDouble(lblItemPurchasedCost.Text);
                TotalNetAmount += Convert.ToDouble(lblItemNetAmount.Text);
                TotalReclaimVat += Convert.ToDouble(lblReclaimVat.Text);
            }

        }

        protected void btnSaveVatCalc_Click(object sender, EventArgs e)
        {
            try
            {
                var vatSubmission = new VATSubmission
                                        {
                                            StartDate = Convert.ToDateTime(txtStartDate.Text),
                                            EndDate = Convert.ToDateTime(txtEndDate.Text),
                                            VatPercentage = Convert.ToDouble(txtVATPercentage.Text),
                                            TotalSaleprice = Convert.ToDouble(lblTotalPrice.Text),
                                            Totalfee = Convert.ToDouble(lblTotalFee.Text),
                                            TotalAmount = Convert.ToDouble(lblTotalAmt.Text),
                                            VatAmount = Convert.ToDouble(lblTotalVAT.Text),
                                            PurchaseCost = Convert.ToDouble(lblTotalPurchasedCost.Text),
                                            NetAmount = Convert.ToDouble(lblTotalNetAmt.Text),
                                            ReclaimVatAmount = Convert.ToDouble(lblReclaimVAT.Text),
                                            IsActive = true,
                                            CreatedDate = DateTime.Now,
                                            TotalItemReclaim = string.IsNullOrEmpty(lblTotalItemReclaim.Text) ? 0 : Convert.ToInt16(lblTotalItemReclaim.Text),
                                            TotalItemSold = string.IsNullOrEmpty(lblTotalItemSold.Text) ? 0 : Convert.ToInt16(lblTotalItemSold.Text),
                                            VatPaidToHMRevenue = string.IsNullOrEmpty(lblPaidVatHMRevenue.Text) ? 0 : Convert.ToInt16(lblPaidVatHMRevenue.Text)
                                        };
                var VatSubmissionid = 0;
                _submissionRepository.Create(vatSubmission, out VatSubmissionid);

                if (VatSubmissionid > 0)
                {
                    var results = _tempVatCalcRep.GetAll(true);
                    foreach (var vc in results)
                    {
                        var vatSubmissionDetail = new VATSubmissionDetail
                                                {
                                                    Settlementid = vc.Settlementid,
                                                    Transactiontype = vc.Transactiontype,
                                                    Orderid = vc.Orderid,
                                                    Saleprice = vc.Saleprice,
                                                    Amazonfee = vc.Amazonfee,
                                                    TotalAmount = vc.TotalAmount,
                                                    VatAmt = vc.Transactiontype.ToLower() == "adjustment" ? 0 : Math.Round(vc.VatAmt, 2),
                                                    PurchaseCost = vc.PurchasedCost,
                                                    NetAmount = vc.Transactiontype.ToLower() == "adjustment" ? 0 : Math.Round(vc.NetAmount, 2),
                                                    
                                                    ReclaimVatAmt = vc.Transactiontype.ToLower() == "adjustment" ? Math.Round(vc.ReclaimVatAmt, 2) : 0,
                                                    Fullfilmentby = string.IsNullOrEmpty(vc.Fullfilmentby) ? vc.Transactiontype.ToLower() == "other-transaction" ? "other-transaction" : "Marchent" : vc.Fullfilmentby,
                                                    Purchaseddate = vc.Purchaseddate,
                                                    CreatedDate = DateTime.Now,
                                                    IsActive = true,
                                                    VatSubmissionfkid = VatSubmissionid
                                                };
                        var id = 0;
                        _submissionDetailRepository.Create(vatSubmissionDetail, out id);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}