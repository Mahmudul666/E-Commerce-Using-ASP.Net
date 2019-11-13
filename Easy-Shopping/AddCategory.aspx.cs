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
    public partial class AddCategory : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("select * from tblcategories", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dtBrands = new DataTable();
                        sda.Fill(dtBrands);
                        rptrCategory.DataSource = dtBrands;
                        rptrCategory.DataBind();
                    }

                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                //SqlCommand cmd = new SqlCommand("insert into tblCategories values('" + txtCatName.Text + "')", con);
                //con.Open();
                //cmd.ExecuteNonQuery();

                string query = "INSERT INTO tblcategories(CatName) VALUES" +
                    "(@CatName)";
                con.Open();
                SqlCommand cmd1 = new SqlCommand(query, con);
                cmd1.Parameters.AddWithValue("@CatName", txtCatName.Text);
                //cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();

                string strSQL = "SELECT * FROM tblCategories";
                SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);
                DataSet ds = new DataSet("tblCategories");
                dt.Fill(ds, "Categories");
                ds.WriteXml(Server.MapPath(@".\xml\tblCategories.xml"));
                txtCatName.Text = string.Empty;


            }
        }
    }
}