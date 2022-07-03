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
    public partial class AddtoCart : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            LblNo.Visible = false;
            if (Session["validuser"] != null && Session["validuser"].ToString() == "true")
            {
                int id=Convert.ToInt32(Request.QueryString["id"]);
                int qty = Convert.ToInt32(Request.QueryString["Quantity"]);
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select Price from TblProduct where ProductID='"+id+"'",con);
                    int price=Convert.ToInt32(cmd.ExecuteScalar());
                    int total =price * qty;
                    cmd = new SqlCommand("select UserID from TblUser where EmailID='"+Session["email"].ToString()+"'",con);
                    int userID = Convert.ToInt32(cmd.ExecuteScalar());
                    if (Session["add"]!=null)
                    {
                        cmd = new SqlCommand("select count(*) from TblCart where ProductID='" + id + "' ", con);
                        int a = Convert.ToInt32(cmd.ExecuteScalar());
                        if (a == 0)
                        {
                            cmd = new SqlCommand("insert into TblCart (ProductID,UserID,Quantity,TotalAmount) values ('" + id + "','" + userID + "','" + qty + "','" + total + "')", con);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd=new SqlCommand("Update TblCart set Quantity=Quantity+'"+qty+"' where UserID='"+userID+"'",con);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    SqlDataAdapter adp = new SqlDataAdapter("select C.CartID,P.Name,P.Image,P.Manufacturer,P.Color,P.Price,C.Quantity,C.TotalAmount from TblProduct P inner join TblCart C on C.ProductID=P.ProductID where C.UserID='" + userID + "'", con);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    cmd = new SqlCommand("select sum(TotalAmount) from TblCart where UserID='"+userID+"'",con);
                    LblTotal.Text="Total Amount: "+cmd.ExecuteScalar().ToString();
                    int TotalItem=dt.Rows.Count;
                    if (TotalItem < 1)
                    {
                        LblNo.Text = "Your cart is empty";
                        LblNo.Visible = true;
                    }
                    Session["totalitem"] = TotalItem;
                    Session["add"] =null;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void BtnCS_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHomepage.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32((sender as LinkButton).CommandArgument);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from TblCart where CartID='" + cid + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("AddtoCart.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Image"]);
                (e.Row.FindControl("Image2") as Image).ImageUrl = imageUrl;
            }
        }
    }
}