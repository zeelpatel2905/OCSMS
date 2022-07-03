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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["avaliduser"]!=null)
                {
                    BtnLogout.Visible = true;
                }
                if (Session["email"]!=null && Session["email"].ToString().Contains("@gmail.com"))
                {
                    LblEmail.Text = Session["email"].ToString();
                    LblEmail.Visible = true;
                    BtnLogout.Visible = true;
                    LbCart.Visible = true;
                    LbCP.Visible = true;
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select UserID from TblUser where EmailID='" + Session["email"].ToString() + "'", con);
                        int userID = Convert.ToInt32(cmd.ExecuteScalar());
                        SqlDataAdapter adp = new SqlDataAdapter("select P.Name,P.Manufacturer,P.Color,P.Price,C.Quantity,C.TotalAmount from TblProduct P inner join TblCart C on C.ProductID=P.ProductID where C.UserID='" + userID + "'", con);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        LbCart.Text = LbCart.Text + "(" + dt.Rows.Count.ToString() + ")";
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Session["validuser"] = null;
            Session["avaliduser"] = null;
            Session["email"] = null;
            BtnLogout.Visible = false;
            LblEmail.Visible = false;
            Response.Redirect("index.aspx");
        }

        protected void LbCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddtoCart.aspx");
        }

        protected void LbFP_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }
    }
}