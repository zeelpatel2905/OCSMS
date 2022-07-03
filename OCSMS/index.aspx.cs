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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["addproduct"] = "false";
        }

        protected void BtnAC_Click(object sender, EventArgs e)
        {

        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            TextBox txtbox = (TextBox)(e.Item.FindControl("TbQty"));
            Session["addproduct"] = "true";
            Response.Redirect("AddtoCart.aspx?id=" + e.CommandArgument.ToString() + "&Quantity=" + txtbox.Text);
        }
    }
}