using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OCSMS
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["validuser"] = null;
            Session["email"] = null;
            if (Session["avaliduser"] != null && Session["avaliduser"].ToString() == "true")
            {
                Response.Redirect("AddProduct.aspx");
            }
            LblMsg.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            LblMsg.Visible = false;
            TbUsername.Text = "";
            TbPassword.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TbUsername.Text == "" || TbPassword.Text == "")
            {
                LblMsg.ForeColor = System.Drawing.Color.Red;
                LblMsg.Text = "Please Fill All The Details!";
                LblMsg.Visible = true;
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("PLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailID", TbUsername.Text);
                    cmd.Parameters.AddWithValue("@UserType", "Admin");
                    cmd.Parameters.AddWithValue("@Password", TbPassword.Text);
                    int result = (Int32)cmd.ExecuteScalar();
                    con.Close();
                    if (result >= 1)
                    {
                        Session["avaliduser"] = "true";
                        Session["aemail"] = TbUsername.Text;
                        Response.Redirect("AddProduct.aspx");
                    }
                    else
                    {
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                        LblMsg.Text = "Invalid Username/Password";
                        LblMsg.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        protected void LbSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void LbLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void LbAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void LbForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }

        protected void LbChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }
    }
}