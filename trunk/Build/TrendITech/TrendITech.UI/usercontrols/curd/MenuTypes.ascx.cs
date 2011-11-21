using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrendITech.Core.Repository;

namespace TrendITech.UI.usercontrols.curd
{
    public partial class MenuTypes : System.Web.UI.UserControl
    {
        private readonly MenuTypesRepository _menuTypeRep = new MenuTypesRepository();
        private readonly Core.Entities.MenuTypes _localClass = new Core.Entities.MenuTypes();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadMenuTypes();
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
                _localClass.Name = txtName.Text;
                _localClass.Desc = txtDesc.Text;
                _localClass.IsActive = chkActive.Checked;
                _localClass.CreatedDate = DateTime.Now;
                literalMsg.Text = _menuTypeRep.Create(_localClass, out id) ? string.Format("<div class='success'>Your menu type id {0} added successfully</div>", id) : string.Format("<div class='error'>Error occurs when creating menu type. Please try again later.</div>");
                if (id > 0)
                {
                    LoadMenuTypes();
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
                txtName.Text = "";
                txtDesc.Text = "";
                chkActive.Checked = false;
                txtDate.Text = DateTime.Now.ToString();
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

        private void LoadMenuTypes()
        {
            try
            {
                var menus = _menuTypeRep.GetAll(true);
                repItemCollection.DataSource = menus;
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