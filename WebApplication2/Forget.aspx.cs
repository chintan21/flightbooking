using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication2
{
    public partial class Forget : System.Web.UI.Page
    {
      static  int otp;
        static String user;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_click(object sender,EventArgs e)
        {
            int min = 1000;
            int max = 9999;

            Random rdm = new Random();

            otp = rdm.Next(min, max);

            user = TextBox1.Text;

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("rohandhamecha45@gmail.com");
            mail.To.Add(TextBox1.Text);
            mail.Subject = "UDAAN - Online Flight Booking";
            mail.Body = "Hello, " + (TextBox1.Text.Split('@'))[0] + ", " + "Your OTP is: "+otp;

            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("rohandhamecha45@gmail.com", "24111974");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);


        }

        protected void OTP_check(object sender,EventArgs e)
        {
            if(TextBox2.Text==Convert.ToString(otp))
            {
                TextBox2.Visible = false;
                Label3.Visible = true;
                Label4.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                Button3.Visible = true;

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wrong OTP!!')", true);

            }

        }

        protected void Button3_click(object sender,EventArgs e)
        {
            if(TextBox3.Text==TextBox4.Text)
            {
                String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;

                SqlConnection con = new SqlConnection(constring);
                con.Open();

                SqlDataAdapter adp = new SqlDataAdapter();

                adp.UpdateCommand = new SqlCommand("update login set password = '"+TextBox3.Text+"' where email = '" + user + "'", con);
                adp.UpdateCommand.ExecuteNonQuery();

                adp.UpdateCommand = new SqlCommand("update signup set password = '" + TextBox3.Text + "' where email = '" + user + "'", con);
                adp.UpdateCommand.ExecuteNonQuery();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your password has been changed successfully.')", true);


                Response.Redirect("Default.aspx");
                
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter the same password in both.')", true);

            }
        }
    }
}