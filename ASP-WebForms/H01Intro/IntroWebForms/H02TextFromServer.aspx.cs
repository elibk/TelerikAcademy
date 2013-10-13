using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntroWebForms
{
    public partial class H02TextFromServer : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var txt = this.GreetingTxt.InnerText;

            this.ServerGeneratedTxt.InnerText = txt;


            this.AssemblyLocation.Text = Assembly.GetExecutingAssembly().Location;


            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            var pathStr = Path.GetDirectoryName(path);

            this.AssemblyPath.Text = pathStr;
        }
    }
}