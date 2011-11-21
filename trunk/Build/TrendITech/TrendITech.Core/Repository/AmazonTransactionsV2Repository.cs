using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using TrendITech.Core.Repository.Interface;
using TrendITech.Core.Entities;
using TrendITech.Core.Utilities;

namespace TrendITech.Core.Repository
{
    public class AmazonTransactionsV2Repository : IAmazonTransactionV2Repostory
    {

        #region Members

        private readonly DataContext _dc;
        private readonly Table<AmazonTransactionsV2> _Transactions;

        #endregion

        #region Constructor

        public AmazonTransactionsV2Repository()
        {
            try
            {
                _dc = new DataContext(ConfigurationManager.ConnectionStrings["trenditechEntities"].ConnectionString);

#if DEBUG
                _dc.Log = new DebuggerWriter();
#endif

                _Transactions = _dc.GetTable<AmazonTransactionsV2>();
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
            }

        }

        #endregion

        #region Implementation of IAmazonTransactionV2Rep

        public Int64 AddTransaction(AmazonTransactionsV2 transactionV2)
        {
            try
            {
                _Transactions.InsertOnSubmit(transactionV2);
                _dc.SubmitChanges();

                return transactionV2.Id;

            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return 0;
            }
        }

        public bool CheckIfExists(Int64 settlementid)
        {
            try
            {
                return _Transactions.Any(
                        t =>
                        t.Settlementid == settlementid);

            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return false;
            }
        }

        public IEnumerable<AmazonTransactionsV2> LoadTransactions()
        {
            try
            {
                return _Transactions.OrderBy(t => t.Id).Select(t => t);
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return null;
            }
        }

        public IEnumerable<AmazonTransactionsV2> ListTransactions(int pagenumber, int pagesize)
        {
            try
            {
                return LoadTransactions().Skip((pagenumber - 1) * pagesize).Take(pagesize);
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return null;
            }
        }

        public void DeleteTransaction(AmazonTransactionsV2 transactionsV2)
        {
            try
            {
                _Transactions.InsertOnSubmit(transactionsV2);
                _dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
            }
        }

        public void DeleteTransactionsList(IList<AmazonTransactionsV2> transactionsV2S)
        {
            try
            {

            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
            }
        }

        public IEnumerable<AmazonTransactionsV2> GetTransactionByStatementId(int statementId)
        {
            try
            {
                return _Transactions.Where(t => t.Settlementid == statementId).Select(t => t);
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return null;
            }
        }

        public IEnumerable<AmazonTransactionsV2> GetTransactionByGivenDates(DateTime startDate, DateTime endDate)
        {
            try
            {
                return _Transactions.Where(t => t.Posteddate >= startDate && t.Posteddate < endDate).Select(t => t);
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return null;
            }
        }

        public IEnumerable<AmazonTransactionsV2> GetTransactionByAmountDescAndDates(DateTime startDate, DateTime endDate, params string[] amountDescription)
        {
            try
            {
                return _Transactions.Where(t => t.Posteddate >= startDate && t.Posteddate < endDate && ((IEnumerable<string>)amountDescription).Contains(t.Amountdescription)).Select(t => t);
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return null;
            }
        }

        public IEnumerable<AmazonTransactionsV2> GetTransactionByOrderId(string orderId)
        {
            try
            {
                return _Transactions.Where(t => t.Orderid == orderId).Select(t => t);
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return null;
            }
        }

        public IEnumerable<AmazonTransactionsV2> GetTransactionByFullfilmentId(string fullfilmentId)
        {
            try
            {
                return _Transactions.Where(t => t.Fulfillmentid == fullfilmentId).Select(t => t);
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return null;
            }
        }

        public IEnumerable<AmazonTransactionsV2> GetTransactionByTransactionType(string transactionType)
        {
            try
            {
                return _Transactions.Where(t => t.Transactiontype == transactionType).Select(t => t);
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return null;
            }
        }


        public IEnumerable<TempVatCalc> CalculateVAT(DateTime startDate, DateTime endDate, double vatPerAmt)
        {
            try
            {
                var allTransactions =
                    _Transactions.Where(
                        t => t.Orderid != null && t.Transactiontype.ToLower() == "order" || t.Transactiontype.ToLower() == "adjustment").OrderBy(t => t.Orderid).Select(t => t).OrderBy(t => t.Posteddate).Select(t => t).Where(t => t.Posteddate >= startDate && t.Posteddate <= endDate);


                //var allTransactions =
                //    _Transactions.Where(
                //        t =>t.Orderid != null &&
                //        (t.Posteddate >= startDate && t.Posteddate <= endDate)).OrderBy
                //        (t => t.Orderid).Select(t => t).OrderBy(t => t.Posteddate).Select(t => t);//.GroupBy( g => new {g.Orderid, g.CreatedDate}).select(g => g.orderID);

                //var icount = allTransactions.Count();

                //var allTransactions =
                //    _Transactions.Where(
                //        t =>
                //        t.Orderid == "026-0454378-6061926").OrderBy(t => t.Orderid).Select(t => t).OrderBy(t => t.Posteddate).Select(t => t);

                long settlementID = 0;
                var orderID = string.Empty;
                var fullfilmentBy = string.Empty;
                var transactionType = string.Empty;
                var purrchasedDate = new DateTime();
                double salePrice = 0;
                double amazonFee = 0;
                double totalAmt = 0;
                double costPrice = 0;
                double netAmt = 0;
                double vatAmt = 0;
                double purchasedCost = 0;
                var count = 0;
                var vatCalcRepository = new TempVatCalcRepository();
                vatCalcRepository.DeleteAll();
                TempVatCalc vatCalc;
                var productsRepository = new ProductsRepository();
                Products products;
                foreach (var v2 in allTransactions)
                {


                    #region assigning values at the first time)

                    if (count == 0)
                    {
                        settlementID = v2.Settlementid;
                        orderID = v2.Orderid;
                        fullfilmentBy = v2.Fulfillmentid;
                        transactionType = v2.Transactiontype;
                        if (v2.Posteddate != null) purrchasedDate = (DateTime)v2.Posteddate;
                        products = productsRepository.GetBySku(v2.Sku);
                        purchasedCost = products.Cost;
                    }

                    #endregion

                    #region Inserting Record and assigning values

                    try
                    {


                        if (v2.Orderid != orderID || v2.Transactiontype != transactionType)
                        {
                            totalAmt = salePrice - amazonFee;
                            var vatPercentaage = vatPerAmt > 0 ? vatPerAmt : Convert.ToDouble(ConfigurationManager.AppSettings["VATPercentage"]);

                            vatAmt = (totalAmt / 100) * vatPercentaage;
                            vatCalc = new TempVatCalc
                                          {
                                              Settlementid = settlementID.ToString(),
                                              Transactiontype = transactionType,
                                              Orderid = orderID,
                                              Saleprice = salePrice,
                                              Amazonfee = amazonFee,
                                              TotalAmount = totalAmt,
                                              VatAmt = transactionType.ToLower() == "adjustment" ? 0 : Math.Round(vatAmt, 2),
                                              //VatAmt = Math.Round(vatAmt, 2),
                                              ReclaimVatAmt =
                                                  transactionType.ToLower() == "adjustment" ? Math.Round(vatAmt, 2) : 0,
                                              PurchasedCost = purchasedCost,
                                              NetAmount =
                                              transactionType.ToLower() == "adjustment" ? 0 :
                                              Math.Round((totalAmt - vatAmt) - purchasedCost, 2),
                                              Fullfilmentby = string.IsNullOrEmpty(fullfilmentBy) ? transactionType.ToLower() == "other-transaction" ? "other-transaction" : "Marchent" : fullfilmentBy,
                                              Purchaseddate = purrchasedDate,
                                              CreatedDate = DateTime.Now,
                                              IsActive = true
                                          };
                            var id = 0;
                            vatCalcRepository.Create(vatCalc, out id);

                            settlementID = v2.Settlementid;
                            orderID = v2.Orderid;
                            fullfilmentBy = v2.Fulfillmentid;
                            transactionType = v2.Transactiontype;
                            if (v2.Posteddate != null) purrchasedDate = (DateTime)v2.Posteddate;
                            salePrice = 0;
                            amazonFee = 0;
                            netAmt = 0;
                            totalAmt = 0;
                            products = productsRepository.GetBySku(v2.Sku);
                            purchasedCost = products.Cost;
                            //count = 0;
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    #endregion

                    #region Loop the same order id and calculate the amount

                    try
                    {


                        switch (v2.Amounttype.ToLower())
                        {
                            case "itemfees":
                                if (string.IsNullOrEmpty(v2.Fulfillmentid))
                                {
                                    if (v2.Amountdescription.ToLower() == "shipping" && v2.Transactiontype.ToLower() == "order")
                                    {
                                        salePrice += Math.Abs(v2.Amount);
                                        break;
                                    }
                                }
                                amazonFee += Math.Abs(v2.Amount);
                                break;
                            case "itemprice":
                                salePrice += Math.Abs(v2.Amount);
                                break;
                            case "promotion":
                                amazonFee += Math.Abs(v2.Amount);
                                break;
                            case "other-transaction":
                                if (v2.Amountdescription.ToLower() == "storage fee")
                                    amazonFee += Math.Abs(v2.Amount);
                                break;
                            case "shipmentfees":
                                amazonFee += Math.Abs(v2.Amount);
                                break;
                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    #endregion

                    count++;
                }

                return vatCalcRepository.GetAll(true);

            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return null;
            }
        }

        #endregion

        #region Implementation of IBaseRepository<AmazonTransactionsV2>

        public bool Create(AmazonTransactionsV2 createObject, out int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(AmazonTransactionsV2 deleteObject)
        {
            throw new NotImplementedException();
        }

        public void Update(AmazonTransactionsV2 updateObject)
        {
            throw new NotImplementedException();
        }

        public bool IfExists(AmazonTransactionsV2 existsObject)
        {
            throw new NotImplementedException();
        }

        public bool ExistsByProperty(string propertyName, object value)
        {
            throw new NotImplementedException();
        }

        public AmazonTransactionsV2 Get(int id, bool onlyActive)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AmazonTransactionsV2> GetAll(bool onlyActive)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AmazonTransactionsV2> GetByPage(int pageNumber, int pageSize, bool onlyActive)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AmazonTransactionsV2> GetByPage<TKey>(int pageNumber, int pageSize, Enumerations.SortBy sortBy, Func<AmazonTransactionsV2, TKey> sortFunc, bool onlyActive)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
