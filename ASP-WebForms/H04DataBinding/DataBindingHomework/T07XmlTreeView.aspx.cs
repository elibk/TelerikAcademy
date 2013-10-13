using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBindingHomework
{
    public partial class T07XmlTreeView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void TreeViewXml_SelectedNodeChanged(object sender, EventArgs e)
        {
            
            var value = this.TreeViewXml.SelectedNode.Value;

            this.displayBlock.InnerText = value;

        }
    }
}