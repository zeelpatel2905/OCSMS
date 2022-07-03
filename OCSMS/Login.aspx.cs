using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace OCSMS
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["avaliduser"] = null;
            if (Session["validuser"] != null && Session["validuser"].ToString() == "true")
            {
                Response.Redirect("CustomerHomepage.aspx");
            }
            LblMsg.Visible = false;
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (TbEmailID.Text == "" || TbPassword.Text == "")
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
                    cmd.Parameters.AddWithValue("@EmailID", TbEmailID.Text);
                    cmd.Parameters.AddWithValue("@UserType", "Customer");
                    cmd.Parameters.AddWithValue("@Password", TbPassword.Text);
                    cmd.CommandType = CommandType.StoredProcedure;
                    int result = (Int32)cmd.ExecuteScalar();
                    if (result == 1)
                    {
                        Session["validuser"] = "true";
                        Session["email"] = TbEmailID.Text;
                        Response.Redirect("CustomerHomepage.aspx");
                    }
                    else
                    {
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                        LblMsg.Text = "Invalid Email ID/Password!";
                        LblMsg.Visible = true;
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }

        void clearall()
        {
            TbEmailID.Text = "";
            TbPassword.Text = "";
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            LblMsg.Visible = false;
            clearall();
        }

        protected void LbForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }

        protected void LbChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
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