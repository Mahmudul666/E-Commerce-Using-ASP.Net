using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Easy_Shopping
{
    public partial class viewbrands : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string xmlString = File.ReadAllText(Server.MapPath(@".\xml\tblBrands.xml"));

            // Define the contents of the XML controls
            Xml1.DocumentContent = xmlString;

            // Specify the XSL file to be used for transformation.
            //Xml1.TransformSource = Server.MapPath(@".\xsl\products.xslt");
            Xml1.TransformSource = Server.MapPath(@"./XSLT/BrandXSLT.xslt");
        }
    }
}