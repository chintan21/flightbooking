using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
       static int count = 0;
        static int count2 = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
           

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
            String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;

            SqlConnection con = new SqlConnection(constring);
            con.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("select * from login", con);

            adp.Fill(dt);

            String a = TextBox7.Text;
            String a1 = TextBox8.Text;
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if((dt.Rows[i]["email"].ToString())==a)
                {
                    count++;
                    if (dt.Rows[i]["password"].ToString()==a1)
                    {
                        Debug.WriteLine("You have successfully login");
                        //Label2.Text = a;
                        Debug.WriteLine(a);
                        String url = (String.Format("Default_login.aspx?user={0}",a));
                        
                        Response.Redirect(url,false);






                        break;
                       
                    }
                    else
                    {
                        Debug.WriteLine("You have entered wrong password");
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
                Label3.Visible = false;
                Label4.Visible = false;
                Label2.Visible = true;
            }


        }

           
}
}