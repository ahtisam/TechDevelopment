using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrendITech.Core.Repository.Interface.Base;
using TrendITech.Core.Entities;

namespace TrendITech.Core.Repository.Interface
{
    public interface IAmazonTransactionV2Repostory :IBaseRepository<AmazonTransactionsV2>
    {
        #region CURD functions

        Int64 AddTransaction(AmazonTransactionsV2 transactionV2);
        IEnumerable<AmazonTransactionsV2> LoadTransactions();
        IEnumerable<AmazonTransactionsV2> ListTransactions(int pagenumber, int pagesize);
        void DeleteTransaction(AmazonTransactionsV2 transactionsV2);
        void DeleteTransactionsList(IList<AmazonTransactionsV2> transactionsV2S);
        IEnumerable<AmazonTransactionsV2> GetTransactionByStatementId(int statementId);
        IEnumerable<AmazonTransactionsV2> GetTransactionByGivenDates(DateTime startDate, DateTime endDate);
        IEnumerable<AmazonTransactionsV2> GetTransactionByAmountDescAndDates(DateTime startDate, DateTime endDate, params string[] amountDescription);
        IEnumerable<AmazonTransactionsV2> GetTransactionByOrderId(string orderId);
        IEnumerable<AmazonTransactionsV2> GetTransactionByFullfilmentId(string fullfilmentId);
        IEnumerable<AmazonTransactionsV2> GetTransactionByTransactionType(string transactionType);
        #endregion

        #region Reporting functions

        #endregion
    }
}
