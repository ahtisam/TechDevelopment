using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrendITech.Core.Entities;
using TrendITech.Core.Repository;

namespace TrendITech.UI.usercontrols.curd
{
    public partial class Inventory : System.Web.UI.UserControl
    {
        private readonly InventoryRepository _invRep = new InventoryRepository();
        private readonly Core.Entities.Inventory _localClass = new Core.Entities.Inventory();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    LoadInventory();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region Create Category

        protected void imgbtnSave_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int id;
                if (!Page.IsValid) return;
                _localClass.ModelNo = txtModelNo.Text;
                _localClass.Qty = int.Parse(txtQty.Text);
                _localClass.Cost = decimal.Parse(txtCost.Text);
                _localClass.JournalId = 0;
                _localClass.CreatedDate = DateTime.Now;
                literalMsg.Text = _invRep.Create(_localClass, out id) ? string.Format("<div class='success'>Your inventory id {0} added successfully</div>", id) : string.Format("<div class='error'>Error occurs when creating inventory. Please try again later.</div>");
                if (id > 0)
                    LoadInventory();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void imgbtnReload_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                txtModelNo.Text = "";
                txtQty.Text = "0";
                txtCost.Text = "0.00";
                txtDate.Text = "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void imgbtnCancel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Update Category

        protected void imgbtnUpdate_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        protected void imgbtnUpdateCancel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Delete Category

        protected void imgbtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void imgbtnDelCancel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Read/Load Category

        private void LoadInventory()
        {
            try
            {
                var inventories = _invRep.GetAll(true);
                repItemCollection.DataSource = inventories;
                repItemCollection.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}