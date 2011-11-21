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
    public partial class Products : System.Web.UI.UserControl
    {

        private readonly ProductsRepository _productRep = new ProductsRepository();
        private readonly CategoryRepository _cateRep = new CategoryRepository();
        private readonly Core.Entities.Products _localClass = new Core.Entities.Products();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadProducts();
                    LoadCategories();
                }

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

                _localClass.ModelNo = txtModel.Text;
                _localClass.Size = txtSize.Text;
                _localClass.Name = txtName.Text;
                _localClass.CategoryID = int.Parse(ddlCategory.SelectedValue);
                _localClass.PicUrl = txtImageUrl.Text;
                _localClass.AmazonSku = txtAmazonSku.Text;
                _localClass.CreatedDate = DateTime.Now;
                //localProducts.IsActive = chkActive.Checked;
                _localClass.CreatedDate = Convert.ToDateTime(txtDate.Text);
                literalMsg.Text = _productRep.Create(_localClass, out id) ? string.Format("<div class='success'>Your product id {0} added successfully</div>", id) : string.Format("<div class='error'>Error occurs when creating product. Please try again later.</div>");
                if (id > 0)
                {
                    LoadProducts();
                    LoadCategories();
                }
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
                txtModel.Text = "";
                txtSize.Text = "";
                txtName.Text = "";
                ddlCategory.SelectedIndex = 0;
                txtImageUrl.Text = "";
                txtAmazonSku.Text = "";
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

        private void LoadProducts()
        {
            try
            {
                var products = _productRep.GetAll(true);
                repItemCollection.DataSource = products;
                repItemCollection.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _cateRep.GetAll(true);
                ddlCategory.Items.Clear();
                foreach (var category in categories)
                {
                    ddlCategory.Items.Add(new ListItem(category.Name, category.Pkid.ToString()));
                }
                ddlCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}