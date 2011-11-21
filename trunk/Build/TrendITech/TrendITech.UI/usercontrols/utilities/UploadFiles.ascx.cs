using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrendITech.UI.usercontrols.utilities
{
    public partial class UploadFiles : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {

            var savePath = MapPath("~/AppData/ProcessedBatchFiles/" + System.IO.Path.GetFileName(e.FileName));
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "size", "top.$get(\"" + lblFileSize.ClientID + "\").innerHTML = 'Uploaded size: " + AsyncFileUpload1.FileBytes.Length.ToString() + "';", true);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "name", "top.$get(\"" + lblFileName.ClientID + "\").innerHTML = 'Uploaded Name: " + AsyncFileUpload1.FileName + "';", true);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "location", "top.$get(\"" + lblFileStoreLocation.ClientID + "\").innerHTML = 'Store location : " + savePath + "';", true);

            AsyncFileUpload1.SaveAs(savePath);

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "image", "top.$get(\"" + Image1.ClientID + "\").src = '/AppData/ProcessedBatchFiles/" + System.IO.Path.GetFileName(e.FileName) + "';", true);
            System.Threading.Thread.Sleep(2000);

        }
    }
}