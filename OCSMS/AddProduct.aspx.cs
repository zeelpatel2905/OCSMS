using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

namespace OCSMS
{
    public partial class AddProduct : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        Byte[] imagebytes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["avaliduser"]!=null && Session["avaliduser"].ToString() == "true")
            {
                try
                {
                    SqlDataAdapter adp = new SqlDataAdapter("select * from TblProduct", con);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    GvProduct.DataSource = dt;
                    GvProduct.DataBind();
                    con.Open();
                    SqlCommand cmd;
                    if (DdType.SelectedItem.ToString() == "All")
                    {
                        cmd = new SqlCommand("select count(*) from TblProduct", con);
                    }
                    else
                    {
                        cmd = new SqlCommand("select count(*) from TblProduct where ProductType='" + DdType.SelectedItem + "'", con);
                    }
                    int totalp = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    if(DdType.SelectedItem.ToString()=="All")
                        LblTP.Text="Total Available Products: "+totalp;
                    if (DdType.SelectedItem.ToString() == "Laptop")
                        LblTP.Text = "Total Available Laptop: " + totalp;
                    if (DdType.SelectedItem.ToString() == "Mouse")
                        LblTP.Text = "Total Available Mouse: " + totalp;
                    if (DdType.SelectedItem.ToString() == "Keyboard")
                        LblTP.Text = "Total Available Keyboard: " + totalp;
                    if (DdType.SelectedItem.ToString() == "Accessories")
                        LblTP.Text = "Total Available Accessories: " + totalp;
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
                LblMsg.Visible = false;
            }
            else
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = FuImage.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(filename);
            int fileSize = postedFile.ContentLength;
            string PType = DdPType.SelectedItem.ToString();
            if (filename == "" || TbPName.Text == "" || TbQty.Text == "" || TbColor.Text == "" || TbDesc.Text == "" || TbManuF.Text == "" || TbPrice.Text == "" || PType == "Select Type")
            {
                LblMsg.ForeColor = System.Drawing.Color.Red;
                LblMsg.Text = "Please Fill All Details!";
                LblMsg.Visible = true;
            }
            else
            {
                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                    || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    Byte[] Imagebytes = binaryReader.ReadBytes((int)stream.Length);
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select * from TblProduct where Name='"+TbPName.Text+"'",con);
                        int result=Convert.ToInt32(cmd.ExecuteScalar());
                        if (result >= 1)
                        {
                            LblMsg.Visible = true;
                            LblMsg.ForeColor = System.Drawing.Color.Red;
                            LblMsg.Text = "Product Already Available!";
                        }
                        else
                        {
                            cmd = new SqlCommand("PProduct", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", TbPName.Text);
                            cmd.Parameters.AddWithValue("@ProductType", PType);
                            cmd.Parameters.AddWithValue("@Manufacturer", TbManuF.Text);
                            cmd.Parameters.AddWithValue("@Image", Imagebytes);
                            cmd.Parameters.AddWithValue("@Color", TbColor.Text);
                            cmd.Parameters.AddWithValue("@Price", TbPrice.Text);
                            cmd.Parameters.AddWithValue("@Quantity", TbQty.Text);
                            cmd.Parameters.AddWithValue("@Description", TbDesc.Text);
                            cmd.ExecuteNonQuery();
                            LblMsg.ForeColor = System.Drawing.Color.Green;
                            LblMsg.Text = "Product Added Successfully!";
                            LblMsg.Visible = true;
                            Response.Redirect("AddProduct.aspx");
                            con.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                }
                else
                {
                    LblMsg.Visible = true;
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    LblMsg.Text = "Only images can be uploaded";
                }
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

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = FuImage.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(filename);
            int fileSize = postedFile.ContentLength;
            string PType = DdPType.SelectedItem.ToString();
            string Status = "";
            if (RbtActive.Checked == true)
                Status = "1";
            if (RbtDeactive.Checked == true)
                Status = "0";
            if (filename == "" || TbPName.Text == "" || TbQty.Text == "" || TbColor.Text == "" || TbDesc.Text == "" || TbManuF.Text == "" || TbPrice.Text == "" || PType == "")
            {
                LblMsg.ForeColor = System.Drawing.Color.Red;
                LblMsg.Text = "Please Fill All Details!";
                LblMsg.Visible = true;
            }
            else
            {
                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                    || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    Byte[] Imagebytes = binaryReader.ReadBytes((int)stream.Length);

                    con.Open();
                    SqlCommand cmd = new SqlCommand("PUpdateProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", Hf_PID.Value);
                    cmd.Parameters.AddWithValue("@Name", TbPName.Text);
                    cmd.Parameters.AddWithValue("@ProductType", PType);
                    cmd.Parameters.AddWithValue("@Manufacturer", TbManuF.Text);
                    if (Imagebytes != null)
                        cmd.Parameters.AddWithValue("@Image", Imagebytes);
                    else
                        cmd.Parameters.AddWithValue("@Image", imagebytes);
                    cmd.Parameters.AddWithValue("@Color", TbColor.Text);
                    cmd.Parameters.AddWithValue("@Price", TbPrice.Text);
                    cmd.Parameters.AddWithValue("@Quantity", TbQty.Text);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Description", TbDesc.Text);
                    cmd.ExecuteNonQuery();
                    LblMsg.ForeColor = System.Drawing.Color.Green;
                    LblMsg.Text = "Product Updated Successfully!";
                    LblMsg.Visible = true;
                    //Response.Redirect("AddProduct.aspx");
                    con.Close();
                }
                else
                {
                    LblMsg.Visible = true;
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    LblMsg.Text = "Only images can be uploaded";
                }
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void TbPName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            TbPName.Text = "";
            clearall();
        }

        public void clearall()
        {
            TbColor.Text = "";
            TbDesc.Text = "";
            TbManuF.Text = "";
            TbPrice.Text = "";
            TbQty.Text = "";
            RbtActive.Checked = false;
            RbtDeactive.Checked = false;
            LblMsg.Visible = false;
            DdPType.SelectedValue = "Select Type";
            BtnUpdate.Enabled = false;
            BtnSubmit.Enabled = true;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int pid = Convert.ToInt32((sender as LinkButton).CommandArgument);
                Hf_PID.Value = pid.ToString();
                SqlDataAdapter adp = new SqlDataAdapter("select * from TblProduct where ProductID='" + pid + "'", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    TbPName.Text = dt.Rows[0][1].ToString();
                    DdPType.SelectedValue = dt.Rows[0][2].ToString();
                    TbManuF.Text = dt.Rows[0][3].ToString();
                    TbColor.Text = dt.Rows[0][5].ToString();
                    TbPrice.Text = dt.Rows[0][6].ToString();
                    TbQty.Text = dt.Rows[0][7].ToString();
                    String status = dt.Rows[0][8].ToString();
                    if (status == "1")
                    {
                        RbtDeactive.Checked = false;
                        RbtActive.Checked = true;
                    }
                    if (status == "0")
                    {
                        RbtActive.Checked = false;
                        RbtDeactive.Checked = true;
                    }
                    TbDesc.Text = dt.Rows[0][9].ToString();
                    BtnUpdate.Enabled = true;
                    BtnSubmit.Enabled = false;
                }
                else
                {
                    clearall();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            int pid = Convert.ToInt32((sender as LinkButton).CommandArgument);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from TblProduct where ProductID='" + pid + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                LblMsg.ForeColor = System.Drawing.Color.Green;
                LblMsg.Text = "Product Deleted Successfully!";
                LblMsg.Visible = true;
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void DdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd;
            if (DdType.SelectedItem.ToString() == "All")
            {
                cmd = new SqlCommand("select count(*) from TblProduct", con);
            }
            else
            {
                cmd = new SqlCommand("select count(*) from TblProduct where ProductType='" + DdType.SelectedItem + "'", con);
            }
            int totalp = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (DdType.SelectedItem.ToString() == "All")
                LblTP.Text = "Total Available Products: " + totalp;
            if (DdType.SelectedItem.ToString() == "Laptop")
                LblTP.Text = "Total Available Laptop: " + totalp;
            if (DdType.SelectedItem.ToString() == "Mouse")
                LblTP.Text = "Total Available Mouse: " + totalp;
            if (DdType.SelectedItem.ToString() == "Keyboard")
                LblTP.Text = "Total Available Keyboard: " + totalp;
            if (DdType.SelectedItem.ToString() == "Accessories")
                LblTP.Text = "Total Available Accessories: " + totalp;
        }
    }
}