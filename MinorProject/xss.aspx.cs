﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace MinorProject
{
    public partial class xss : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                }
            }
            catch (Exception ex) { }

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string feedback = txtfeedback.Text.Trim();

                string connString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string sql = @"insert into feedback values(@articleText)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@articleText", feedback);
                cmd.ExecuteNonQuery();
                conn.Close();
                lblerror.Text = "Feedback Sent Successfully";
            }

            catch (Exception ex)
            {
                lblerror.Text = ex.Message.ToString();
            }
            finally
            {
                txtfeedback.Text = "";
            }

        }
    }
}