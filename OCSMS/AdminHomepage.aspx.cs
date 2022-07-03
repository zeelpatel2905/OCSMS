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
    public partial class AdminHomepage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["avaliduser"] != null && Session["avaliduser"].ToString() == "true")
            {
                try
                {
                    SqlDataAdapter adp = new SqlDataAdapter("select * from TblProduct", con);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    GvProduct.DataSource = dt;
                    GvProduct.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
            else
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }

        protected void GvProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Image"]);
                (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
            }
        }

        
    }
}