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
    public partial class ChangePassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["avaliduser"] == null && Session["validuser"] == null)
            {
                Response.Redirect("index.aspx");
            }
            LblMsg.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TbEmailID.Text == "" || TbOPassword.Text == "" || TbNpassword.Text == "")
            {
                LblMsg.ForeColor = System.Drawing.Color.Red;
                LblMsg.Text = "Please Fill All The Details!";
                LblMsg.Visible = true;
            }
            else
            {
                if (TbNpassword.Text == TbOPassword.Text)
                {
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    LblMsg.Text = "New Password Must Be Different!";
                    LblMsg.Visible = true;
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("PLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailID", TbEmailID.Text);
                    string who="";
                    if(Session["avaliduser"]!=null)
                    {
                        who="Admin";
                    }
                    if(Session["validuser"]!=null)
                    {
                        who="Customer";
                    }
                    cmd.Parameters.AddWithValue("@UserType", who);
                    cmd.Parameters.AddWithValue("@Password", TbOPassword.Text);
                    int result = (Int32)cmd.ExecuteScalar();
                    con.Close();
                    if (result >= 1)
                    {
                        con.Open();
                        cmd = new SqlCommand("PForgotPassword", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmailID", TbEmailID.Text);
                        cmd.Parameters.AddWithValue("@Password", TbNpassword.Text);
                        cmd.Parameters.AddWithValue("@UserType", who);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        LblMsg.ForeColor = System.Drawing.Color.Green;
                        LblMsg.Text = "Password Changed Successfully!";
                        LblMsg.Visible = true;
                    }
                    else
                    {
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                        LblMsg.Text = "Incorrect Email ID/Old Password!";
                        LblMsg.Visible = true;
                    }
                }
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            LblMsg.Visible = false;
            clearall();
        }
        void clearall()
        {
            TbEmailID.Text = "";
            TbOPassword.Text = "";
            TbNpassword.Text = "";
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
    }
}