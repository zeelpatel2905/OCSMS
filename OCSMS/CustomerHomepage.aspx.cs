using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OCSMS
{
    public partial class CustomerHomepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["search"]!=null)
            {
                TbSearch.Text = Session["search"].ToString();
                Session["search"] = null;
            }
            if (Session["validuser"]==null)
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            TextBox txtbox = (TextBox)(e.Item.FindControl("TbQty"));
            if (txtbox.Text != "")
            {
                Session["add"] = "true";
                Response.Redirect("AddtoCart.aspx?id=" + e.CommandArgument.ToString() + "&Quantity=" + txtbox.Text);
            }
            else
            {
                Response.Redirect("CustomerHomepage.aspx");
            }
        }

        protected void TbSearch_TextChanged(object sender, EventArgs e)
        {
            Session["search"] = null;
            Session["search"] = TbSearch.Text;
            Response.Redirect("CustomerHomepage.aspx");
        }
    }
}