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
    public partial class Menu : System.Web.UI.UserControl
    {
        private readonly MenuTypesRepository _menuTypeRep = new MenuTypesRepository();
        private readonly MenuRepository _menuRep = new MenuRepository();
        private readonly Core.Entities.Menu _localClass = new Core.Entities.Menu();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadMenus();
                    LoadMenuTypes();
                    LoadMenuParentItems();
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
                _localClass.MenuTypeID = int.Parse(ddlMenuType.SelectedValue);
                _localClass.ParentID = int.Parse(ddlParent.SelectedValue);
                _localClass.Name = txtName.Text;
                _localClass.Desc = txtDesc.Text;
                _localClass.Url = txtUrl.Text;
                _localClass.IsActive = chkActive.Checked;
                _localClass.CreatedDate = DateTime.Now;
                literalMsg.Text = _menuRep.Create(_localClass, out id) ? string.Format("<div class='success'>Your Menu id {0} added successfully</div>", id) : string.Format("<div class='error'>Error occurs when creating Menu. Please try again later.</div>");
                if (id > 0)
                {
                    LoadMenus();
                    LoadMenuTypes();
                    LoadMenuParentItems();
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
                ddlMenuType.SelectedIndex = 0;
                ddlParent.SelectedIndex = 0;
                txtName.Text = "";
                txtDesc.Text = "";
                txtUrl.Text = "";
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

        private void LoadMenus()
        {
            try
            {
                var menus = _menuRep.GetAll(true);
                repItemCollection.DataSource = menus;
                repItemCollection.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void LoadMenuTypes()
        {
            try
            {
                var menuTypes = _menuTypeRep.GetAll(true);
                ddlMenuType.Items.Clear();
                foreach (var menuType in menuTypes)
                {
                    ddlMenuType.Items.Add(new ListItem(menuType.Name, menuType.ID.ToString()));
                }
                ddlMenuType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void LoadMenuParentItems()
        {
            try
            {
                var parentItems = _menuRep.GetAllParentItems(true);
                ddlParent.Items.Clear();
                ddlParent.Items.Add(new ListItem("-none-", "0"));
                foreach (var parentItem in parentItems)
                {
                    ddlParent.Items.Add(new ListItem(parentItem.Name, parentItem.ID.ToString()));
                }
                ddlParent.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion


    }
}