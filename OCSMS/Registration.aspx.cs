using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace OCSMS
{
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        static String otp;
        protected void Page_Load(object sender, EventArgs e)
        {
            LblMsg.Visible = false;
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            if (TbFirstName.Text == "" || TbLastName.Text == "" || TbEmailID.Text == "" || TbContactNo.Text == "" || TbPassword.Text == "" || RbtMale.Checked == false && RbtFemale.Checked == false)
            {
                LblMsg.ForeColor = System.Drawing.Color.Red;
                LblMsg.Text = "Please Fill All The Details!";
                LblMsg.Visible = true;
            }
            else
            {
                if (TbOTP.Text == otp)
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("PCheckUser", con);
                        cmd.Parameters.AddWithValue("@EmailID", TbEmailID.Text);
                        cmd.Parameters.AddWithValue("@UserType",DdUser.SelectedItem.ToString());
                        cmd.CommandType = CommandType.StoredProcedure;
                        int result = (Int32)cmd.ExecuteScalar();
                        con.Close();
                        if (result >= 1)
                        {
                            LblMsg.ForeColor = System.Drawing.Color.Red;
                            LblMsg.Text = "Email ID Already Registered!";
                            LblMsg.Visible = true;
                            clearall();
                        }
                        else
                        {
                            String Gender = "";
                            if (RbtMale.Checked == true)
                                Gender = "M";
                            if (RbtFemale.Checked == true)
                                Gender = "F";
                            DateTime dt = DateTime.Today;
                            String UType = DdUser.SelectedItem.ToString();
                            try
                            {
                                con.Open();
                                cmd = new SqlCommand("PRegistration", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@FirstName", TbFirstName.Text);
                                cmd.Parameters.AddWithValue("@LastName", TbLastName.Text);
                                cmd.Parameters.AddWithValue("@Gender", Gender);
                                cmd.Parameters.AddWithValue("@EmailID", TbEmailID.Text);
                                cmd.Parameters.AddWithValue("@ContactNo", TbContactNo.Text);
                                cmd.Parameters.AddWithValue("@Password", TbPassword.Text);
                                cmd.Parameters.AddWithValue("@UserType", UType);
                                cmd.Parameters.AddWithValue("@RegistrationDate", dt);
                                cmd.ExecuteNonQuery();
                                con.Close();
                                LblMsg.ForeColor = System.Drawing.Color.Green;
                                LblMsg.Text = "Registered Successfully!";
                                LblMsg.Visible = true;
                                clearall();
                            }
                            catch (Exception ex)
                            {
                                Response.Write(ex);
                            }
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                }
                else
                {
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    LblMsg.Text = "Incorrect OTP!";
                    LblMsg.Visible = true;
                }
            }
        }
        void clearall()
        {
            TbFirstName.Text = "";
            TbLastName.Text = "";
            RbtMale.Checked = false;
            RbtFemale.Checked = false;
            TbEmailID.Text = "";
            TbContactNo.Text = "";
            TbPassword.Text = "";
            TbOTP.Text = "";
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            LblMsg.Visible = false;
            clearall();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
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
                msg.Subject = "Online Computer Shop - Registration";
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