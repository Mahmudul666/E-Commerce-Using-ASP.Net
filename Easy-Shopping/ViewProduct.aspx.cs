using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Easy_Shopping
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string xmlString = File.ReadAllText(Server.MapPath(@".\xml\tblProducts.xml"));


            Xml1.DocumentContent = xmlString;


            Xml1.TransformSource = Server.MapPath(@"./XSLT/ViewProductXSLT.xslt");
        }
    }
}