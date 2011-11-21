using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TrendITech.Core.Repository;
using TrendITech.Core.Utilities;

namespace TrendITech.UI.usercontrols.curd
{
    public partial class Order : System.Web.UI.UserControl
    {
        private readonly ProductsRepository _productRep = new ProductsRepository();
        private readonly CategoryRepository _cateRep = new CategoryRepository();
        private readonly Core.Entities.Products _product = new Core.Entities.Products();
        private readonly OrderRepository _orderRep = new OrderRepository();
        private readonly OrderItemsDetailRepository _orderDetailRep = new OrderItemsDetailRepository();
        private readonly Core.Entities.Order _localClass = new Core.Entities.Order();
        private readonly InventoryRepository _invRep = new InventoryRepository();
        private readonly Core.Entities.Inventory _inventory = new Core.Entities.Inventory();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                this.BindListView();
            }
            //if (!IsPostBack)
            //SetInitialRow();

        }

        //private void SetInitialRow()
        //{

        //    //DataTable dt = new DataTable();
        //    //DataRow dr = null;

        //    ////Create DataTable columns
        //    //dt.Columns.Add(new DataColumn("Select", typeof(Button)));
        //    //dt.Columns.Add(new DataColumn("Image", typeof(Image)));
        //    //dt.Columns.Add(new DataColumn("ModelNo", typeof(TextBox)));
        //    //dt.Columns.Add(new DataColumn("Price", typeof(TextBox)));
        //    //dt.Columns.Add(new DataColumn("Quantity", typeof(TextBox)));
        //    //dt.Columns.Add(new DataColumn("Comments", typeof(string)));

        //    ////Create Row for each columns
        //    //dr = dt.NewRow();
        //    //var btnAdd = new Button();
        //    //var btnRemove = new Button();
        //    //btnAdd.Text = "Add";
        //    //btnRemove.Text = "Remove";
        //    //var img = new Image();
        //    //var txtItemModel = new TextBox();
        //    //var txtItemPrice = new TextBox {Text = "0.00"};
        //    //var txtItemQty = new TextBox {Text = "0"};
        //    //var txtComment = new TextBox();
        //    //txtRefNote.TextMode = TextBoxMode.MultiLine;
        //    //dr["Select"] = btnAdd;
        //    //dr["Image"] = img;
        //    //dr["ModelNo"] = txtItemModel;
        //    //dr["Price"] = txtItemPrice;
        //    //dr["Quantity"] = txtItemQty;
        //    //dr["Comments"] = txtComment;
        //    //dt.Rows.Add(dr);

        //    ////Store the DataTable in ViewState for future reference
        //    //ViewState["CurrentTable"] = dt;


        //    List<int> dataSource = new List<int>();
        //    for (int i = 0; i < 1; i++)
        //    {
        //        dataSource.Add(i);
        //    }


        //    //Bind the Repeater with the DataTable
        //    repItemCollection.DataSource = dataSource;
        //    repItemCollection.DataBind();

        //}

        //private void AddNewRow()
        //{

        //    int rowIndex = 0;
        //    if (ViewState["CurrentTable"] != null)
        //    {

        //        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        //        DataRow drCurrentRow = null;

        //        if (dtCurrentTable.Rows.Count > 0)
        //        {
        //            for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
        //            {
        //                //extract the TextBox values
        //                TextBox tbName = (TextBox)repItemCollection.Items[rowIndex].FindControl("TXTName");
        //                TextBox tbComments = (TextBox)repItemCollection.Items[rowIndex].FindControl("TXTComments");

        //                //Create new row in DataTable and set its values
        //                drCurrentRow = dtCurrentTable.NewRow();

        //                drCurrentRow["RowNumber"] = i + 1;
        //                dtCurrentTable.Rows[i - 1]["Name"] = tbName.Text;
        //                dtCurrentTable.Rows[i - 1]["Comments"] = tbComments.Text;
        //                rowIndex++;

        //            }

        //            //add the new row to the current DataTable
        //            dtCurrentTable.Rows.Add(drCurrentRow);
        //            //store the current DataTable in ViewState
        //            ViewState["CurrentTable"] = dtCurrentTable;
        //            //rebind the Repeater with the updated DataTable
        //            repItemCollection.DataSource = dtCurrentTable;
        //            repItemCollection.DataBind();
        //        }
        //    }
        //    else
        //    {
        //        Response.Write("ViewState is null");

        //    }
        //    //Set Previous Data on Postbacks
        //    SetPreviousData();
        //}

        //private void SetPreviousData()
        //{
        //    int rowIndex = 0;
        //    if (ViewState["CurrentTable"] != null)
        //    {
        //        DataTable dt = (DataTable)ViewState["CurrentTable"];
        //        if (dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {

        //                TextBox tbName = (TextBox)repItemCollection.Items[rowIndex].FindControl("TXTName");
        //                TextBox tbComments = (TextBox)repItemCollection.Items[rowIndex].FindControl("TXTComments");

        //                //Disable previous rows
        //                if (i < dt.Rows.Count - 1)
        //                {
        //                    tbName.Enabled = false;
        //                    tbComments.Enabled = false;
        //                }
        //                else
        //                {
        //                    tbName.Enabled = true;
        //                    tbComments.Enabled = true;
        //                }

        //                tbName.Text = dt.Rows[i]["Name"].ToString();
        //                tbComments.Text = dt.Rows[i]["Comments"].ToString();
        //                rowIndex++;
        //            }
        //        }
        //    }
        //}

        //protected void repItemCollection_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    switch (e.CommandName)
        //    {
        //        case "Create":
        //            var dataSource = new List<int>();
        //            for (var i = 0; i < repItemCollection.Items.Count + 1; i++)
        //            {
        //                dataSource.Add(i);
        //            }
        //            repItemCollection.DataSource = dataSource;
        //            repItemCollection.DataBind();
        //            break;

        //        case "Delete":

        //            break;
        //    }
        //}

        //protected void repItemCollection_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:
        //            {
        //                var img = (Image)e.Item.FindControl("img");
        //                var ddlModel = (DropDownList)e.Item.FindControl("ddlModel");
        //                var txtCost = (TextBox)e.Item.FindControl("txtCost");
        //                var txtQty = (TextBox)e.Item.FindControl("txtQty");
        //                var txtComment = (TextBox)e.Item.FindControl("txtComment");

        //                if (string.IsNullOrEmpty(img.ImageUrl))
        //                    LoadModel(ddlModel);
        //                if (string.IsNullOrEmpty(txtCost.Text))
        //                    txtCost.Text = "0.00";
        //                if (string.IsNullOrEmpty(txtQty.Text))
        //                    txtQty.Text = "0";
        //                if (string.IsNullOrEmpty(txtComment.Text))
        //                    txtComment.Text = "";
        //            }
        //            break;
        //    }
        //}

        private void BindListView()
        {
            //create an enumerable range based on the current count
            var dataSource = this.GetDataSource();

            //bind the listview
            this.lvDynamicTextboxes.DataSource = dataSource;
            this.lvDynamicTextboxes.DataBind();
            count = 0;
        }

        private void UpdateDataSource()
        {
            List<OrderDetailsDs> lstDataSource = new List<OrderDetailsDs>();
            var Id = 0;
            foreach (var item in this.lvDynamicTextboxes.Items)
            {
                if (item is ListViewDataItem)
                {

                    var btnRemove = (Button)item.FindControl("btnRemove");
                    var btnAdd = (Button)item.FindControl("btnAdd");
                    var img = (Image)item.FindControl("Img");
                    var active = (HiddenField)item.FindControl("Active");
                    var ddlModel = (DropDownList)item.FindControl("ddlModel");
                    var txtCost = (TextBox)item.FindControl("txtCost");
                    var txtQty = (TextBox)item.FindControl("txtQty");
                    var txtComment = (TextBox)item.FindControl("txtComment");
                    var ds = new OrderDetailsDs
                                         {
                                             ID = Id,
                                             ImgUrl = img.ImageUrl,
                                             ModelVal = ddlModel.SelectedValue,
                                             ItemCost = txtCost.Text,
                                             ItemQty = txtQty.Text,
                                             ItemComment = txtComment.Text,
                                             IsActive = int.Parse(active.Value) > 0
                                         };
                    lstDataSource.Add(ds);
                    Id++;
                }
            }
            this.SetDataSource(lstDataSource);
        }

        private void IncrementTextboxCount()
        {
            var lstDataSource = GetDataSource();
            var Id = lstDataSource.Count;
            var dataSource = new OrderDetailsDs
                                 {
                                     ID = Id,
                                     ImgUrl = "",
                                     ModelVal = "0",
                                     ItemCost = "0.00",
                                     ItemQty = "0",
                                     ItemComment = "",
                                     IsActive = true
                                 };
            lstDataSource.Add(dataSource);
            this.SetDataSource(lstDataSource);
        }

        private List<OrderDetailsDs> GetDataSource()
        {
            List<OrderDetailsDs> lstDataSource = null;

            if (ViewState["DataSource"] != null)
            {
                lstDataSource = (List<OrderDetailsDs>)ViewState["DataSource"];
            }
            else
            {
                lstDataSource = new List<OrderDetailsDs>();
                var ds = new OrderDetailsDs
                                     {
                                         ID = 0,
                                         ImgUrl = "",
                                         ModelVal = "0",
                                         ItemCost = "0.00",
                                         ItemQty = "0",
                                         ItemComment = "",
                                         IsActive = true
                                     };
                lstDataSource.Add(ds);
                ViewState["DataSource"] = lstDataSource;
                //count = lstDataSource.Count;
            }

            return lstDataSource;
        }

        private void SetDataSource(List<OrderDetailsDs> dataSource)
        {
            ViewState["DataSource"] = dataSource;
        }

        protected void btnAddTextBox_Click(object sender, EventArgs e)
        {
            this.UpdateDataSource();
            this.IncrementTextboxCount();
            this.BindListView();
        }

        protected void lvDynamicTextboxes_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (!(e.Item is ListViewDataItem)) return;
            var btnRemove = (Button)e.Item.FindControl("btnRemove");
            var btnAdd = (Button)e.Item.FindControl("btnAdd");
            var classID = (HiddenField)e.Item.FindControl("classID");
            var img = (Image)e.Item.FindControl("Img");
            var ddlModel = (DropDownList)e.Item.FindControl("ddlModel");
            var txtCost = (TextBox)e.Item.FindControl("txtCost");
            var txtQty = (TextBox)e.Item.FindControl("txtQty");
            var txtComment = (TextBox)e.Item.FindControl("txtComment");
            var smallImg = (HtmlAnchor)e.Item.FindControl("smallImg");
            LoadModel(ddlModel);
            var lstDs = (List<OrderDetailsDs>)ViewState["DataSource"];

            var icount = 0;
            foreach (var orderDetailsDse in lstDs)
            {
                if (icount == count)
                {
                    if (!orderDetailsDse.IsActive)
                        btnRemove.Enabled = false;
                    classID.Value = orderDetailsDse.ID.ToString();
                    img.ImageUrl = orderDetailsDse.ImgUrl;
                    smallImg.HRef = orderDetailsDse.ImgUrl.Replace("thumbs/","");
                    ddlModel.SelectedValue = orderDetailsDse.ModelVal;
                    txtCost.Text = orderDetailsDse.ItemCost;
                    txtQty.Text = orderDetailsDse.ItemQty;
                    txtComment.Text = orderDetailsDse.ItemComment;
                }
                icount++;
            }
            count++;
        }

        #region Read/Load Category

        private void LoadModel(ListControl ddl)
        {
            try
            {
                ddl.Items.Clear();
                var products = _productRep.GetAll(true);
                ddl.DataSource = products;
                ddl.DataTextField = "ModelNo";
                ddl.DataValueField = "Pkid";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("-- Select --", "0"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        protected void lvDynamicTextboxes_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            

            switch (e.CommandName)
            {
                case "Create":
                    var img = (Image)e.Item.FindControl("Img");
                    var ddlModel = (DropDownList)e.Item.FindControl("ddlModel");
                    var txtCost = (TextBox)e.Item.FindControl("txtCost");
                    var txtQty = (TextBox)e.Item.FindControl("txtQty");
                    var smallImg = (HtmlAnchor)e.Item.FindControl("smallImg");

                    if (ddlModel.SelectedIndex > 0)
                    {
                        LoadImage(ddlModel.SelectedItem.Text, img);
                        smallImg.HRef = img.ImageUrl;
                        //LoadCost(ddlModel.SelectedItem.Text, txtCost);
                    }
                    UpdateDataSource();
                    IncrementTextboxCount();
                    BindListView();
                    break;
                case "Remove":
                    var classID = (HiddenField)e.Item.FindControl("classID");
                    if (!string.IsNullOrEmpty(classID.Value))
                    {
                        UpdateDataSource(int.Parse(classID.Value));
                        BindListView();
                    }
                    break;
                case "Load":
                    img = (Image)e.Item.FindControl("Img");
                    ddlModel = (DropDownList)e.Item.FindControl("ddlModel");
                    txtCost = (TextBox)e.Item.FindControl("txtCost");
                    txtQty = (TextBox)e.Item.FindControl("txtQty");
                    smallImg = (HtmlAnchor)e.Item.FindControl("smallImg");
                    if (ddlModel.SelectedIndex > 0)
                    {
                        LoadImage(ddlModel.SelectedItem.Text, img);
                        smallImg.HRef = img.ImageUrl;
                        //LoadCost(ddlModel.SelectedItem.Text, txtCost);
                    }
                    txtQty.Text = "1";
                    UpdateDataSource();
                    BindListView();
                    break;
            }
        }
        
        private void LoadImage(string modelNo, Image img)
        {
            var products = _productRep.GetAll(true);
            foreach (var product in products.Where(product => product.ModelNo == modelNo))
            {
                img.ImageUrl = product.PicUrl;
            }
        }

        private void LoadCost(string id, TextBox cost)
        {
           var inventory =  _invRep.GetByModelNo(id);
            var priceCost = Convert.ToDouble(inventory.Cost);
            cost.Text = priceCost.ToString();
        }
        
        private void UpdateDataSource(int id)
        {
            List<OrderDetailsDs> lstDataSource = new List<OrderDetailsDs>();
            if (lvDynamicTextboxes.Items.Count <= 1) return;
            var Id = 0;
            foreach (var item in this.lvDynamicTextboxes.Items)
            {
                if (item is ListViewDataItem)
                {

                    var btnRemove = (Button)item.FindControl("btnRemove");
                    var btnAdd = (Button)item.FindControl("btnAdd");
                    var img = (Image)item.FindControl("Img");
                    var classID = (HiddenField)item.FindControl("classID");
                    var active = (HiddenField)item.FindControl("Active");
                    var ddlModel = (DropDownList)item.FindControl("ddlModel");
                    var txtCost = (TextBox)item.FindControl("txtCost");
                    var txtQty = (TextBox)item.FindControl("txtQty");
                    var txtComment = (TextBox)item.FindControl("txtComment");
                    var ds = new OrderDetailsDs();

                    ds.ID = Id;
                    ds.ImgUrl = img.ImageUrl;
                    ds.ModelVal = ddlModel.SelectedValue;
                    ds.ItemCost = txtCost.Text;
                    ds.ItemQty = txtQty.Text;
                    ds.ItemComment = txtComment.Text;
                    ds.IsActive = int.Parse(active.Value) > 0;

                    if (int.Parse(classID.Value) != id)
                        lstDataSource.Add(ds);
                    Id++;
                }
            }
            this.SetDataSource(lstDataSource);
        }

        public int count { get; set; }

        //protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.lvDynamicTextboxes_ItemCommand(lvDynamicTextboxes, new ListViewCommandEventArgs(null, sender, new CommandEventArgs("Load", null)));

        //}

    }

}