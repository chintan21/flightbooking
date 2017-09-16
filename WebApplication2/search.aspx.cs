using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        

            if (Request.QueryString.Count > 0)
            {
                var queryStrings = (Request.QueryString.ToString());
                var arrQueryStrings = queryStrings.Split('&');

                String src = arrQueryStrings[0];
                String dest = arrQueryStrings[1];
                String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;

                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                DataTable dt1 = new DataTable();
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();

                SqlDataAdapter adp = new SqlDataAdapter("Select airport from distance where "+src+"<=500  and "+src+" >0", con);
                adp.Fill(dt1);
               

                dt.Reset();
                SqlDataAdapter adp2 = new SqlDataAdapter("select * from flights where src_airp='" + src + "' and dest_airp='" + dest +"' ", con);
               adp2.Fill(dt);
                String mid;
              
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    mid = (dt1.Rows[i]["airport"]).ToString();
                   
                    adp.SelectCommand = new SqlCommand("select * from flights where src_airp='"+src+"' and dest_airp='"+mid+"'",con);
                    adp.Fill(dt3);
                    adp.SelectCommand = new SqlCommand("select * from flights where src_airp='" + mid + "' and dest_airp='" + dest + "'",con);
                    adp.Fill(dt2);
                    if (dt2.Rows.Count != 0 && dt3.Rows.Count != 0)
                    {
                        dt3.Merge(dt2);
                        dt4.Merge(dt3);
                        dt2.Reset();
                        dt3.Reset();
                       
                       
                    }
                   
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();

                GridView2.DataSource = dt4;
                GridView2.DataBind();
            }
          
        }

    
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
            
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            
            TextBox1.Text = Calendar1.SelectedDate.ToString("dd-MM-yyyy");
            Calendar1.Visible = false;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}