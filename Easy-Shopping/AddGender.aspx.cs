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
    public partial class AddGender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindBrandsRptr();
        }
        private void BindBrandsRptr()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("select * from tblGender", con))
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
                SqlCommand cmd = new SqlCommand("insert into tblGender values('" + txtGenderName.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                string strSQL = "SELECT * FROM tblGender";
                SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);
                DataSet ds = new DataSet("tblGender");
                dt.Fill(ds, "tblGender");
                ds.WriteXml(Server.MapPath(@".\xml\tblGender.xml"));
                //xtCatName.Text = string.Empty;
                txtGenderName.Text = string.Empty;
            }
            BindBrandsRptr();
        }
    }
}