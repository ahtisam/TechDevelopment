using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrendITech.Core.Entities;
using TrendITech.Core.Repository;

namespace TrendITech.UI.usercontrols.curd
{
    public partial class Category : System.Web.UI.UserControl
    {
        private readonly CategoryRepository _cateRep = new CategoryRepository();
        private readonly Core.Entities.Category _localClass = new Core.Entities.Category();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    LoadCategories();

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
                _localClass.Name = txtName.Text;
                _localClass.Desc = txtDesc.Text;
                _localClass.IsActive = chkActive.Checked;
                _localClass.CreatedDate = Convert.ToDateTime(txtDate.Text);
                literalMsg.Text = _cateRep.Create(_localClass, out id) ? string.Format("<div class='success'>Your category id {0} added successfully</div>", id) : string.Format("<div class='error'>Error occurs when creating category. Please try again later.</div>");
                if (id > 0)
                    LoadCategories();
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
                txtName.Text= "";
                txtDesc.Text = "";
                chkActive.Checked = true;
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

        private void LoadCategories()
        {
            try
            {
                var categories =  _cateRep.GetAll(true);
                repItemCollection.DataSource = categories;
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