using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace OCSMS
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        static String otp;
        static int result;
        protected void Page_Load(object sender, EventArgs e)
        {
            LblMsg.Visible = false;
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (TbEmailID.Text == "" || TbOTP.Text == "" || TbNPassword.Text == "" || DdUType.SelectedItem.ToString()=="Select Type")
            {
                LblMsg.ForeColor = System.Drawing.Color.Red;
                LblMsg.Text = "Please Fill All The Details!";
                LblMsg.Visible = true;
            }
            else
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("PCheckUser", con);
                cmd1.Parameters.AddWithValue("@EmailID", TbEmailID.Text);
                cmd1.Parameters.AddWithValue("@UserType", DdUType.SelectedItem.ToString());
                cmd1.CommandType = CommandType.StoredProcedure;
                result = (Int32)cmd1.ExecuteScalar();
                con.Close();
                if (result >= 1)
                {
                    if (TbOTP.Text.Equals(otp))
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("PForgotPassword", con);
                            cmd.Parameters.AddWithValue("@EmailID", TbEmailID.Text);
                            cmd.Parameters.AddWithValue("@Password", TbNPassword.Text);
                            cmd.Parameters.AddWithValue("@UserType", DdUType.SelectedItem.ToString());
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.ExecuteNonQuery();
                            con.Close();
                            LblMsg.ForeColor = System.Drawing.Color.Green;
                            LblMsg.Text = "Password Updated Successfully!";
                            LblMsg.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex);
                        }
                    }
                    else
                    {
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                        LblMsg.Text = "Incorrect OTP";
                        LblMsg.Visible = true;
                    }
                }
                else
                {
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    LblMsg.Text = "Email ID Not Registered!";
                    LblMsg.Visible = true;
                }
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            clearall();
        }
        void clearall()
        {
            TbEmailID.Text = "";
            TbOTP.Text = "";
            TbNPassword.Text = "";
        }

        protected void BtnSendOTP_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();
                otp = random.Next(100001, 999999).ToString();
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("18bmiit083@gmail.com", "Zeelpatel29052000");
                smtp.EnableSsl = true;
                MailMessage msg = new MailMessage();
                msg.Subject = "Online Computer Shop - Forget Password";
                msg.Body = "Dear " + TbEmailID.Text + " Your OTP for registration is " + otp + "\n\n\nThanks & Regards \nOnline Computer Shop";
                msg.To.Add(TbEmailID.Text);
                msg.From = new MailAddress("<18bmiit083@gmail.com>");
                try
                {
                    smtp.Send(msg);
                    LblMsg.ForeColor = System.Drawing.Color.Green;
                    LblMsg.Text = "OTP Send Successfully!";
                    LblMsg.Visible = true;
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}