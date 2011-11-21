using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrendITech.UI.usercontrols.utilities
{
    public partial class LoadAppDataFile : System.Web.UI.UserControl
    {
        //private string _selectedFile;
        public string SelectedFilePath
        {
            get { return hdnfldSelectFilePath.Value; }
            set { hdnfldSelectFilePath.Value = value; }
        }

        public string SelectedFile
        {
            get { return hdnfldSelectFile.Value; }
            set { hdnfldSelectFile.Value = value; }
        }

        private string Location;
        
        protected void Page_Load(object sender, EventArgs e){
            
            Location = Server.MapPath("~/AppData/ProcessedBatchFiles/");
            if (IsPostBack) return;
            LoadAllFiles();
        }

        protected void LoadAllFiles()
        {

            //FIND ALL FILES IN FOLDER
            var dir = new DirectoryInfo(Location);
            ddlFileExtentions.Items.Clear();
            foreach (var f in dir.GetFiles("*.*"))
            {
                //LOAD FILES
                if (!ddlFileExtentions.Items.Contains(new ListItem( f.Extension, f.Extension)))
                    ddlFileExtentions.Items.Add(new ListItem(f.Extension, f.Extension));
                //ListViewItem lSingleItem = listView1.Items.Add(f.Name);
                ////SUB ITEMS
                //lSingleItem.SubItems.Add(Convert.ToString(f.Length));
                //lSingleItem.SubItems.Add(f.Extension);
            } 
        }

        protected void LoadSelectedExtensionFiles(string extension)
        {
            var dir = new DirectoryInfo(Location);
            rdoBtnLstFiles.Items.Clear();
            foreach (var f in dir.GetFiles("*" + extension))
            {
                rdoBtnLstFiles.Items.Add(new ListItem(f.Name + " Size : " + f.Length, Location + f.Name));
            }
        }

        protected void btnLoadSelectedFile_Click(object sender, EventArgs e)
        {
            LoadSelectedExtensionFiles(ddlFileExtentions.SelectedItem.Value);
        }

        protected void rdoBtnLstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedFile = rdoBtnLstFiles.SelectedItem.Text;
            SelectedFilePath = rdoBtnLstFiles.SelectedItem.Value;
        }

    }
}