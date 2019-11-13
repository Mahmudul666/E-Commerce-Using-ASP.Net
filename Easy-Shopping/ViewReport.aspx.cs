using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Easy_Shopping
{
    public partial class ViewReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int yearSelected = Convert.ToInt32(DropDownList1.Text);

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString);
            try
            {
                con.Open();
                string query = "SELECT year(DateOfPurchase) AS y, month(DateOfPurchase) AS m, sum(TotalPayed) AS totalTransaction FROM tblPurchase WHERE year(DateOfPurchase)=" + yearSelected + " GROUP BY year(DateOfPurchase), month(DateOfPurchase)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();

                // Create a new, empty document
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                System.Xml.XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);

                // Create and insert a new element
                System.Xml.XmlNode JSChart = doc.CreateElement("JSChart");
                doc.AppendChild(JSChart);

                // Create a nested element (with an attribute)
                System.Xml.XmlNode dataset = doc.CreateElement("dataset");
                System.Xml.XmlAttribute productAttribute = doc.CreateAttribute("type");
                productAttribute.Value = "line";
                dataset.Attributes.Append(productAttribute);

                while (dr.Read())
                {
                    System.Xml.XmlNode dataXML = doc.CreateElement("data");

                    System.Xml.XmlAttribute dataAttribute1 = doc.CreateAttribute("unit");
                    dataAttribute1.Value = dr["m"].ToString();
                    dataXML.Attributes.Append(dataAttribute1);

                    System.Xml.XmlAttribute dataAttribute2 = doc.CreateAttribute("value");
                    dataAttribute2.Value = dr["totalTransaction"].ToString();
                    dataXML.Attributes.Append(dataAttribute2);

                    dataset.AppendChild(dataXML);
                }

                JSChart.AppendChild(dataset);

                // Create a nested element (with an attribute)
                System.Xml.XmlNode optionset = doc.CreateElement("optionset");
                //optionset.Attributes.Append(productAttribute);

                System.Xml.XmlNode option1 = doc.CreateElement("option");
                System.Xml.XmlAttribute set1 = doc.CreateAttribute("set");
                set1.Value = "setAxisColor";
                option1.Attributes.Append(set1);
                System.Xml.XmlAttribute value1 = doc.CreateAttribute("value");
                value1.Value = "'#656565'";
                option1.Attributes.Append(value1);
                optionset.AppendChild(option1);

                System.Xml.XmlNode option2 = doc.CreateElement("option");
                System.Xml.XmlAttribute set2 = doc.CreateAttribute("set");
                set2.Value = "setAxisNameColor";
                option2.Attributes.Append(set2);
                System.Xml.XmlAttribute value2 = doc.CreateAttribute("value");
                value2.Value = "'#4A4A4A'";
                option2.Attributes.Append(value2);
                optionset.AppendChild(option2);

                System.Xml.XmlNode option3 = doc.CreateElement("option");
                System.Xml.XmlAttribute set3 = doc.CreateAttribute("set");
                set3.Value = "setAxisNameFontSize";
                option3.Attributes.Append(set3);
                System.Xml.XmlAttribute value3 = doc.CreateAttribute("value");
                value3.Value = "10";
                option3.Attributes.Append(value3);
                optionset.AppendChild(option3);

                System.Xml.XmlNode option4 = doc.CreateElement("option");
                System.Xml.XmlAttribute set4 = doc.CreateAttribute("set");
                set4.Value = "setAxisNameX";
                option4.Attributes.Append(set4);
                System.Xml.XmlAttribute value4 = doc.CreateAttribute("value");
                value4.Value = "'Months'";
                option4.Attributes.Append(value4);
                optionset.AppendChild(option4);

                System.Xml.XmlNode option5 = doc.CreateElement("option");
                System.Xml.XmlAttribute set5 = doc.CreateAttribute("set");
                set5.Value = "setAxisNameY";
                option5.Attributes.Append(set5);
                System.Xml.XmlAttribute value5 = doc.CreateAttribute("value");
                value5.Value = "'Profits'";
                option5.Attributes.Append(value5);
                optionset.AppendChild(option5);

                System.Xml.XmlNode option6 = doc.CreateElement("option");
                System.Xml.XmlAttribute set6 = doc.CreateAttribute("set");
                set6.Value = "setAxisPaddingBottom";
                option6.Attributes.Append(set6);
                System.Xml.XmlAttribute value6 = doc.CreateAttribute("value");
                value6.Value = "60";
                option6.Attributes.Append(value6);
                optionset.AppendChild(option6);

                System.Xml.XmlNode option7 = doc.CreateElement("option");
                System.Xml.XmlAttribute set7 = doc.CreateAttribute("set");
                set7.Value = "setAxisPaddingLeft";
                option7.Attributes.Append(set7);
                System.Xml.XmlAttribute value7 = doc.CreateAttribute("value");
                value7.Value = "180";
                option7.Attributes.Append(value7);
                optionset.AppendChild(option7);

                System.Xml.XmlNode option8 = doc.CreateElement("option");
                System.Xml.XmlAttribute set8 = doc.CreateAttribute("set");
                set8.Value = "setAxisPaddingRight";
                option8.Attributes.Append(set8);
                System.Xml.XmlAttribute value8 = doc.CreateAttribute("value");
                value8.Value = "170";
                option8.Attributes.Append(value8);
                optionset.AppendChild(option8);

                System.Xml.XmlNode option9 = doc.CreateElement("option");
                System.Xml.XmlAttribute set9 = doc.CreateAttribute("set");
                set9.Value = "setAxisPaddingTop";
                option9.Attributes.Append(set9);
                System.Xml.XmlAttribute value9 = doc.CreateAttribute("value");
                value9.Value = "65";
                option9.Attributes.Append(value9);
                optionset.AppendChild(option9);

                System.Xml.XmlNode option10 = doc.CreateElement("option");
                System.Xml.XmlAttribute set10 = doc.CreateAttribute("set");
                set10.Value = "setAxisValuesColor";
                option10.Attributes.Append(set10);
                System.Xml.XmlAttribute value10 = doc.CreateAttribute("value");
                value10.Value = "'#656565'";
                option10.Attributes.Append(value10);
                optionset.AppendChild(option10);

                System.Xml.XmlNode option11 = doc.CreateElement("option");
                System.Xml.XmlAttribute set11 = doc.CreateAttribute("set");
                set11.Value = "setGrid";
                option11.Attributes.Append(set11);
                System.Xml.XmlAttribute value11 = doc.CreateAttribute("value");
                value11.Value = "true";
                option11.Attributes.Append(value11);
                optionset.AppendChild(option11);

                System.Xml.XmlNode option12 = doc.CreateElement("option");
                System.Xml.XmlAttribute set12 = doc.CreateAttribute("set");
                set12.Value = "setLineColor";
                option12.Attributes.Append(set12);
                System.Xml.XmlAttribute value12 = doc.CreateAttribute("value");
                value12.Value = "'#8638D5'";
                option12.Attributes.Append(value12);
                optionset.AppendChild(option12);

                System.Xml.XmlNode option13 = doc.CreateElement("option");
                System.Xml.XmlAttribute set13 = doc.CreateAttribute("set");
                set13.Value = "setShowYValues";
                option13.Attributes.Append(set13);
                System.Xml.XmlAttribute value13 = doc.CreateAttribute("value");
                value13.Value = "true";
                option13.Attributes.Append(value13);
                optionset.AppendChild(option13);

                System.Xml.XmlNode option14 = doc.CreateElement("option");
                System.Xml.XmlAttribute set14 = doc.CreateAttribute("set");
                set14.Value = "setTitle";
                option14.Attributes.Append(set14);
                System.Xml.XmlAttribute value14 = doc.CreateAttribute("value");
                value14.Value = "'" + yearSelected + "'";
                option14.Attributes.Append(value14);
                optionset.AppendChild(option14);

                System.Xml.XmlNode option15 = doc.CreateElement("option");
                System.Xml.XmlAttribute set15 = doc.CreateAttribute("set");
                set15.Value = "setTitleColor";
                option15.Attributes.Append(set15);
                System.Xml.XmlAttribute value15 = doc.CreateAttribute("value");
                value15.Value = "'#505050'";
                option15.Attributes.Append(value15);
                optionset.AppendChild(option15);

                System.Xml.XmlNode option16 = doc.CreateElement("option");
                System.Xml.XmlAttribute set16 = doc.CreateAttribute("set");
                set16.Value = "setSize";
                option16.Attributes.Append(set16);
                System.Xml.XmlAttribute value16 = doc.CreateAttribute("value");
                value16.Value = "1000, 521";
                option16.Attributes.Append(value16);
                optionset.AppendChild(option16);

                System.Xml.XmlNode option17 = doc.CreateElement("option");
                System.Xml.XmlAttribute set17 = doc.CreateAttribute("set");
                set17.Value = "setTextPaddingBottom";
                option17.Attributes.Append(set17);
                System.Xml.XmlAttribute value17 = doc.CreateAttribute("value");
                value17.Value = "20";
                option17.Attributes.Append(value17);
                optionset.AppendChild(option17);

                System.Xml.XmlNode option18 = doc.CreateElement("option");
                System.Xml.XmlAttribute set18 = doc.CreateAttribute("set");
                set18.Value = "setTextPaddingLeft";
                option18.Attributes.Append(set18);
                System.Xml.XmlAttribute value18 = doc.CreateAttribute("value");
                value18.Value = "120";
                option18.Attributes.Append(value18);
                optionset.AppendChild(option18);

                System.Xml.XmlNode option19 = doc.CreateElement("option");
                System.Xml.XmlAttribute set19 = doc.CreateAttribute("set");
                set19.Value = "setTextPaddingTop";
                option19.Attributes.Append(set19);
                System.Xml.XmlAttribute value19 = doc.CreateAttribute("value");
                value19.Value = "15";
                option19.Attributes.Append(value19);
                optionset.AppendChild(option19);

                JSChart.AppendChild(optionset);

                // Save the document
                doc.Save(Server.MapPath(@".\xml\data.xml"));

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }
        }
    }
}