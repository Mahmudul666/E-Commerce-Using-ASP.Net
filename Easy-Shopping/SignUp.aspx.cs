﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Easy_Shopping
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

            }
        }

        protected void btSignup_Click(object sender, EventArgs e)
        {

            if (tbUname.Text != "" & tbPass.Text != "" && tbName.Text != "" && tbEmail.Text != "" && tbCPass.Text != "")
            {
                if (tbPass.Text == tbCPass.Text)
                {
                    String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("insert into Users values('" + tbUname.Text + "','" + tbPass.Text + "','" + tbEmail.Text + "','" + tbName.Text + "','A')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        lblMsg.Text = "Registration Successfull";
                        //lblMsg.ForeColor = Color.Green;
                        Response.Redirect("~/Signin.aspx");
                    }
                }
                else
                {
                    //lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = "Passwords do not match";
                }
            }
            else
            {
                //lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "All Fields Are Mandatory";

            }
        }
    }
}