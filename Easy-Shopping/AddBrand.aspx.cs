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
    public partial class AddBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrandsRptr();
            }
        }
        private void BindBrandsRptr()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("select * from tblBrands", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dtBrands = new DataTable();
                        sda.Fill(dtBrands);
                        rptrBrands.DataSource = dtBrands;
                        rptrBrands.DataBind();
                    }

                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                //SqlCommand cmd = new SqlCommand("insert into tblBrands values('" + txtBrandName.Text + "')", con);
                string query = "INSERT INTO tblBrands(Name) VALUES" +
                    "(@Name)";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtBrandName.Text);
                //cmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();

                string strSQL = "SELECT * FROM tblBrands";
                SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);
                DataSet ds = new DataSet("Brands");
                dt.Fill(ds, "BrandsId");
                ds.WriteXml(Server.MapPath(@".\xml\tblBrands.xml"));
                txtBrandName.Text = string.Empty;


                
            }
            BindBrandsRptr();
        }
    }
}