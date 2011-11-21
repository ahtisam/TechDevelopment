using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using TrendITech.Core;
using TrendITech.Core.Repository;
using TrendITech.Core.Entities;
using TrendITech.Core.Repository;

namespace TrendITech.UI.usercontrols.batchFiles
{
    public partial class UploadAmazonFile : System.Web.UI.UserControl
    {
        public bool result { get; set; }

        private readonly AmazonTransactionsV2Repository _amazonTransactions = new AmazonTransactionsV2Repository();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void gvCSV_DataBound(object sender, EventArgs e)
        {

        }
        
        protected void btnExecuteAmazonSatelmentFile_Click(object sender, EventArgs e)
        {
            //IEnumerable asa = _amazonTransactions.LoadTransactions();
            
            List<string> errors;
            if (string.IsNullOrEmpty(LoadAppDataFile1.SelectedFilePath)) return;
            var dt = Csv.DataSetGet(LoadAppDataFile1.SelectedFilePath, "\t", out errors);
            gvAmazonSatelemntFileProgress.DataSource = dt;
            gvAmazonSatelemntFileProgress.DataBind();
            //btnStoreAmazonTransaction.Visible = true;
            //btnExecuteAmazonSatelmentFile.Visible = false;

            if (gvAmazonSatelemntFileProgress.Rows.Count <= 0) return;
            foreach (GridViewRow settelmentId in gvAmazonSatelemntFileProgress.Rows)
            {
                try
                {
                    result = _amazonTransactions.CheckIfExists(Convert.ToInt64(settelmentId.Cells[0].Text));
                    break;
                }
                catch (Exception)
                {
                    //result = true;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Selected file type is incorrect. Please check the selceted file type and try again.";
                    return;
                }
            }

            if (result)
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Selected file records are already exists in database. Please choose the correct file and try again.";
                return;
            }
            
            InsertSettelmentRecord();
            lblStatus.ForeColor = System.Drawing.Color.Blue;
            lblStatus.Text = LoadAppDataFile1.SelectedFile + " file uploaded into database successfully.";
        }

        private void InsertSettelmentRecord()
        {
            var stringBuilder = new StringBuilder();

            AmazonTransactionsV2 v2;
            foreach (GridViewRow row in gvAmazonSatelemntFileProgress.Rows)
            {
                v2 = new AmazonTransactionsV2();
                
                if (!string.IsNullOrEmpty(row.Cells[0].Text) && row.Cells[0].Text != "&nbsp;")
                    v2.Settlementid = Convert.ToInt64(row.Cells[0].Text);
                if (!string.IsNullOrEmpty(row.Cells[1].Text) && row.Cells[1].Text != "&nbsp;")
                    v2.Settlementstartdate = Convert.ToDateTime(row.Cells[1].Text);
                if (!string.IsNullOrEmpty(row.Cells[2].Text) && row.Cells[2].Text != "&nbsp;")
                    v2.Settlementenddate = Convert.ToDateTime(row.Cells[2].Text);
                if (!string.IsNullOrEmpty(row.Cells[3].Text) && row.Cells[3].Text != "&nbsp;")
                    v2.Depositdate = Convert.ToDateTime(row.Cells[3].Text);
                if (!string.IsNullOrEmpty(row.Cells[4].Text) && row.Cells[4].Text != "&nbsp;")
                    v2.Totalamount = Convert.ToDouble(row.Cells[4].Text);
                if (!string.IsNullOrEmpty(row.Cells[5].Text) && row.Cells[5].Text != "&nbsp;")
                    v2.Currency = row.Cells[5].Text;
                if (!string.IsNullOrEmpty(row.Cells[5].Text) && row.Cells[6].Text != "&nbsp;")
                    v2.Transactiontype = row.Cells[6].Text != "&nbsp;" ? row.Cells[6].Text : null;
                if (!string.IsNullOrEmpty(row.Cells[7].Text) && row.Cells[7].Text != "&nbsp;")
                    v2.Orderid = row.Cells[7].Text != "&nbsp;" ? row.Cells[7].Text : null;
                if (!string.IsNullOrEmpty(row.Cells[8].Text) && row.Cells[8].Text != "&nbsp;")
                    v2.Merchantorderid = row.Cells[8].Text != "&nbsp;" ? row.Cells[8].Text : null;
                if (!string.IsNullOrEmpty(row.Cells[9].Text) && row.Cells[9].Text != "&nbsp;")
                    v2.Adjustmentid = row.Cells[9].Text != "&nbsp;" ? row.Cells[9].Text : null;
                if (!string.IsNullOrEmpty(row.Cells[10].Text) && row.Cells[10].Text != "&nbsp;")
                    v2.Shipmentid = row.Cells[10].Text != "&nbsp;" ? row.Cells[10].Text : null;
                if (!string.IsNullOrEmpty(row.Cells[11].Text) && row.Cells[11].Text != "&nbsp;")
                    v2.Marketplacename = row.Cells[11].Text != "&nbsp;" ? row.Cells[11].Text : null;
                if (!string.IsNullOrEmpty(row.Cells[12].Text) && row.Cells[12].Text != "&nbsp;")
                    v2.Amounttype = row.Cells[12].Text != "&nbsp;" ? row.Cells[12].Text : null;
                if (!string.IsNullOrEmpty(row.Cells[13].Text) && row.Cells[13].Text != "&nbsp;")
                    v2.Amountdescription = row.Cells[13].Text != "&nbsp;" ? row.Cells[13].Text : null;
                if (!string.IsNullOrEmpty(row.Cells[14].Text) && row.Cells[14].Text != "&nbsp;")
                    v2.Amount = Convert.ToDouble(row.Cells[14].Text);
                if (!string.IsNullOrEmpty(row.Cells[15].Text) && row.Cells[15].Text != "&nbsp;")
                    v2.Fulfillmentid = row.Cells[15].Text != "&nbsp;" ? row.Cells[15].Text : null;
                if (!string.IsNullOrEmpty(row.Cells[16].Text) && row.Cells[16].Text != "&nbsp;")
                    v2.Posteddate = Convert.ToDateTime(row.Cells[16].Text);
                if (!string.IsNullOrEmpty(row.Cells[17].Text) && row.Cells[17].Text != "&nbsp;")
                    v2.Posteddatetime = Convert.ToDateTime(row.Cells[17].Text);
                if (!string.IsNullOrEmpty(row.Cells[18].Text) && row.Cells[18].Text != "&nbsp;")
                    v2.Orderitemcode = row.Cells[18].Text != "&nbsp;" ? row.Cells[18].Text : null;
                if (!string.IsNullOrEmpty(row.Cells[19].Text) && row.Cells[19].Text != "&nbsp;")
                    v2.Merchantorderitemid = row.Cells[19].Text != "&nbsp;" ? row.Cells[19].Text : null;
                if (!string.IsNullOrEmpty(row.Cells[20].Text) && row.Cells[20].Text != "&nbsp;")
                    v2.Merchantadjustmentitemid = row.Cells[20].Text != "&nbsp;" ? row.Cells[20].Text : null;
                if (!string.IsNullOrEmpty(row.Cells[21].Text) && row.Cells[21].Text != "&nbsp;")
                    v2.Sku = row.Cells[21].Text != "&nbsp;" ? row.Cells[21].Text : null;
                if (!string.IsNullOrEmpty(row.Cells[22].Text) && row.Cells[22].Text != "&nbsp;")
                    v2.Quantitypurchased = Convert.ToInt32(row.Cells[22].Text);
                //v2.Promotionid = row.Cells[23].Text != "&nbsp;" ? row.Cells[23].Text : null;
                v2.CreatedDate = DateTime.Now;
                /* string builder */
                stringBuilder.AppendFormat("Settlementid = {0} | ", v2.Settlementid);
                stringBuilder.AppendFormat("Posteddate = {0} | ", v2.Posteddate);
                stringBuilder.AppendFormat("Orderid = {0} | ", v2.Orderid);
                stringBuilder.AppendFormat("Amounttype = {0} | ", v2.Amounttype);
                stringBuilder.AppendFormat("Amount = {0} ", v2.Amount);
                stringBuilder.Append("<br />");
                _amazonTransactions.AddTransaction(v2);
            }

            InsertedRecordsDetails.Text = stringBuilder.ToString();
        }


    }
}