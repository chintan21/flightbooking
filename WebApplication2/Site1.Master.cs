using System;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Net.Mail;

namespace WebApplication2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        static int count = 0;
        static int count2 = 0;
        static String a;
        static int count3 = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
           if(count3>0)

            {
                String temp = "taral12@gmail.com";
                if (a == temp)
                {
                    var queryStrings = (Request.QueryString.ToString());
                    var arrQueryStrings = queryStrings.Split('=');
                    Label3.Visible = false;
                    Label4.Visible = false;
                    Label2.Visible = true;
                    Session["user"] = a;
                    Button10.Visible = true;
                    Button10.Text = "Hello  " +a;
                    Button12.Visible = true;
                    Button11.Visible = true;
                    Button7.Visible = false;
                    Button6.Visible = false;
                    Button9.Visible = false;
                    Button13.Visible = true;
                    Button14.Visible = false;


                }
                else
                {
                    var queryStrings = (Request.QueryString.ToString());
                    var arrQueryStrings = queryStrings.Split('=');
                    Label3.Visible = false;
                    Label4.Visible = false;
                    Label2.Visible = true;
                    
                    Button10.Visible = true;
                    Button10.Text = "Hello, " +a;
                    Session["user"] = a;
                    Button12.Visible = true;
                    Button14.Visible = true;
                }
            }
            else
            {
                Session["user"] = null;
                Label3.Visible = true;
                Label4.Visible = true;
                Button10.Visible = false;
                Button14.Visible = false;
            }

        }

        protected void Button4_click(object sender,EventArgs e)
        {
            String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;

            SqlConnection con = new SqlConnection(constring);
            con.Open();

            String b = TextBox9.Text;
            String b1 = TextBox10.Text;
            String b2 = TextBox11.Text;
            String b3 = TextBox12.Text;
            String ab = "insert into signup(email,mobileno,password)values(@email,@mobileno,@password)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("select email from login", con);

            adp.Fill(dt);
            int count1 = 0;
            for(int i=0;i<dt.Rows.Count;i++)
            {
                if((dt.Rows[i]["email"].ToString())==b)
                {
                    count1 = count1 + 1;
                    Debug.WriteLine("Account already exists");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Account Already EXIST!!')", true);

                    break;
                    
                }
            }

            if (count1 == 0)
            {
                if (b3 == b2)
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = ab;
                    cmd.Parameters.AddWithValue("@email", b);
                    cmd.Parameters.AddWithValue("@mobileno", b1);
                    cmd.Parameters.AddWithValue("@password", b2);

                    cmd.ExecuteNonQuery();

                    String ab1 = "insert into login(email,password)values(@email,@password)";

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandText = ab1;
                    cmd1.Parameters.AddWithValue("@email", b);
                    cmd1.Parameters.AddWithValue("@password", b2);
                    cmd1.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your Account has been created!!')", true);

                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("rohandhamecha45@gmail.com");
                    mail.To.Add(b);
                    mail.Subject = "UDAAN - Online Flight Booking";
                    mail.Body = "Hello, "+(b.Split('@'))[0]+", "+"Thank you for registering to UDAAN. Your account has been succesfully created.";

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("rohandhamecha45@gmail.com", "24111974");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                }
                else
                {
                    Button4.Enabled = false;
                }
                con.Close();
            }
        }

        protected void Button3_click(object sender, EventArgs e)
        {
            String constring = ConfigurationManager.ConnectionStrings["Flight"].ConnectionString;

            SqlConnection con = new SqlConnection(constring);
            con.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("select * from login", con);

            adp.Fill(dt);

            a = TextBox7.Text;
            String a1 = TextBox8.Text;
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if((dt.Rows[i]["email"].ToString())==a)
                {
                    count++;
                    if (dt.Rows[i]["password"].ToString()==a1)
                    {
                        String temp = "taral12@gmail.com";
                        Debug.WriteLine("You have successfully login");
                        count3 += 3;
                        if (a == temp)
                        {
                            String ab = (String.Format("Admin.aspx"));
                            Response.Redirect(ab, false);
                            Label2.Text = a;
                            Label3.Visible = false;
                            Label4.Visible = false;
                            Label2.Visible = true;
                            Button7.Text = "Feedbacks";
                            Button11.Visible = true;
                            break;


                        }

                        String url = (String.Format("Default.aspx?user={0}",a));
                        Debug.WriteLine("now it is falut");
                        Response.Redirect(url, false);
                        Label2.Text = a;
                        Label3.Visible = false;
                        Label4.Visible = false;
                        Label2.Visible = true;
                        break;
                        
                       
                    }
                    else
                    {
                        Debug.WriteLine("You have entered wrong password");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have entered wrong password!!.')", true);

                        break;
                    }
                }
            }

            if (count == 0)
            {
              //  Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Account doesn't exist');", true);

                Debug.WriteLine("Account doesn't exist");
            }
            
            if(count2==1)
            {
                Debug.WriteLine("now it is falut");
                Label3.Visible = false;
                Label4.Visible = false;
                Label2.Visible = true;
            }


        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if(Button10.Visible==true)
            { 
            
            String url = (String.Format("Contact_us.aspx?user={0}", a));
            Debug.WriteLine("now it is falut");
            Label2.Text = a;
            Label3.Visible = false;
            Label4.Visible = false;
            Label2.Visible = true;
            Response.Redirect(url, false);
            }
            else
            {
                Response.Redirect("Contact_us.aspx");
            }

        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            count3 = 0;
            Response.Redirect("#");
            
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            if(Button10.Visible==true)
            {
                String url = (String.Format("Default.aspx?user={0}", a));
                Response.Redirect(url, false);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            
        }

        protected void LB1_click(object sender,EventArgs e)
        {
            Response.Redirect("Forget.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (Button10.Visible)
            {
                String url = (String.Format("Baggage.aspx?user={0}", a));
                Response.Redirect(url, false);
            }
            else
            {
                Response.Redirect("Baggage.aspx");
            }

        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            if (Button10.Visible)
            {
                String url = (String.Format("Admin.aspx?user={0}", a));
                Response.Redirect(url, false);
            }
            else
            {
                Response.Redirect("Admin.aspx");
            }
        }
    }
}