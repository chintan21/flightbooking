using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace WebApplication2
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_preLoad(object sender,EventArgs e)
        {
            var queryStrings = (Request.QueryString.ToString());
            var arrQueryStrings = queryStrings.Split('&');

            String src = arrQueryStrings[0];
            String dest = arrQueryStrings[1];
            String dt = arrQueryStrings[2];
            
            
            Label2.Text = " " + src + " to " + dest;
            Label2.Visible = true;
            Label4.Text = " " + dt ;
            Label4.Visible = true;

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString.Count > 0)
            {
                var queryStrings = (Request.QueryString.ToString());
                var arrQueryStrings = queryStrings.Split('&');

                String src = arrQueryStrings[0];
                String dest = arrQueryStrings[1];
                String cls1 = arrQueryStrings[3];
                char cls = cls1.FirstOrDefault();

                Label2.Text=" "+src + " to " + dest;
                Label2.Visible = true;

                String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;

                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                DataTable dt1 = new DataTable();
                DataTable dt = new DataTable();   //Direct flight
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();
                DataTable dt6 = new DataTable();
               

                dt4.Columns.Add("Flight_ID");
                dt4.Columns.Add("Airline");
                dt4.Columns.Add("Source");
               
                dt4.Columns.Add("Destination");
                dt4.Columns.Add("Departure");
                dt4.Columns.Add("Arrival");
                dt4.Columns.Add("Price");

                dt5.Columns.Add("Flight_ID");
                dt5.Columns.Add("Airline");
                dt5.Columns.Add("Source");

                dt5.Columns.Add("Destination");
                dt5.Columns.Add("Departure");
                dt5.Columns.Add("Arrival");
                dt5.Columns.Add("Price");







                SqlDataAdapter adp = new SqlDataAdapter("Select airport from distance where " + src + "<=500  and " + src + " >0", con);
                adp.Fill(dt6);

                adp.SelectCommand = new SqlCommand("Select airport from distance where " + dest + "<=500 and " + dest + ">0", con);
                adp.Fill(dt6);
                String midc;

               
                for (int i=0;i<dt6.Rows.Count;i++)
                {
                    int cnt=0;
                    
                    
                    midc = dt6.Rows[i].ToString();

                    for(int j=i+1;j<dt6.Rows.Count;i++)
                    {
                        if(dt6.Rows[j].ToString()==midc)
                        {
                            cnt++;
                            break;
                        }

                    }
                    
                    if (cnt==0)
                    {

                        DataRow dr = dt6.Rows[i];
                        dr.Delete();
                        dt6.AcceptChanges();
                    }
                    
                    
                    
                }

                dt.Reset();
                SqlDataAdapter adp2 = new SqlDataAdapter("select flights.fid as Flight_ID,air_id as Airline,src_airp as Source,dest_airp as Destination,dept_time as Departure,arr_time as Arrival,Price from flights,Seats where src_airp='" + src + "' and dest_airp='" + dest + "' and Seats.fid=flights.fid and Seats.seat_class='"+cls+"' and Seats.Tot_seat > 0 ", con);
                adp2.Fill(dt);
                String mid;
                int count = 0;
                dt4.Reset();
           

                for (int i = 0; i < dt6.Rows.Count; i++)
                {
                   
                        mid = (dt6.Rows[i]["airport"]).ToString();

                        adp.SelectCommand = new SqlCommand("select flights.fid as Flight_ID,air_id as Airline,src_airp as Source,dest_airp as Destination,dept_time as Departure,arr_time as Arrival,Price from flights,Seats where src_airp='" + src + "' and dest_airp='" + mid + "' and Seats.fid=flights.fid and Seats.seat_class='" + cls + "' ", con);
                        adp.Fill(dt2);
                        adp.SelectCommand = new SqlCommand("select flights.fid as Flight_ID,air_id as Airline,src_airp as Source,dest_airp as Destination,dept_time as Departure,arr_time as Arrival,Price from flights,Seats where src_airp='" + mid + "' and dest_airp='" + dest + "' and Seats.fid=flights.fid and Seats.seat_class='" + cls + "' ", con);
                        adp.Fill(dt3);
                    
                        if (dt2.Rows.Count != 0 && dt3.Rows.Count != 0)
                    {
                        dt4 = dt2.Clone();
                        dt4 = dt3.Clone();
                        int a1 = dt2.Rows.Count;
                        int a2 = dt3.Rows.Count;

                       
                      
                        for (int a = 0; a < a1; a++)
                        {
                            for (int b = 0; b < a2; b++)
                            {
                                DateTime time1 = Convert.ToDateTime(dt2.Rows[a]["Arrival"].ToString());
                                DateTime time2 = Convert.ToDateTime(dt3.Rows[b]["Departure"].ToString());

                                int result = DateTime.Compare(time1, time2);

                                

                                if (result < 0)
                                {
                                    int a11 = Convert.ToInt32(dt2.Rows[a]["Price"].ToString());
                                    int  a12 = Convert.ToInt32(dt3.Rows[b]["Price"].ToString());

                                    a11 = Convert.ToInt32((a11 + a12) * 0.6);

                                    dt2.Rows[a]["Price"] = a11;
                                    dt3.Rows[b]["Price"] =DBNull.Value;

                                    dt2.AcceptChanges();
                                    dt3.AcceptChanges();

                                    dt4.ImportRow(dt2.Rows[a]);

                                    dt4.ImportRow(dt3.Rows[b]);
                                    //dt4.ImportRow(dt3.Rows[b]);

                                  
                                    count++;




                                }


                            }
                        }
                    }

                    foreach(DataRow dr in dt4.Rows)
                    {
                        
                       dt5.Rows.Add(dr.ItemArray);
                    }
                    
                        dt2.Reset();
                        dt3.Reset();
                    dt4.Reset();
                    
                }
                    Debug.WriteLine("No. of options with 1 stop:{0}", count);

               


                GridView1.DataSource = dt;
                    GridView1.DataBind();

                    GridView2.DataSource = dt5;
                    GridView2.DataBind();

                int k = 0;


                while (k < GridView2.Rows.Count)
                {


                    if (k % 2 != 0)
                    {

                        GridView2.Rows[k].Cells[0].Text = " ";
                        GridView2.Rows[k].Cells[0].ToolTip = "This flight is connected with above flight, so this alone can't be booked";
                    }

                    k = k + 1;
                }



            }

            }

        protected void GridView1_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Debug.WriteLine(index);
            Response.Redirect("Passanger_detail.aspx");

        }

        protected void GridView2_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Debug.WriteLine(index);
            Response.Redirect("Passanger_detail.aspx");

        }

        protected void Button1_Click(object sender,EventArgs e)
        {
            string qs = HttpContext.Current.Request.Url.AbsoluteUri;
            var a = qs.Split('&');
            var b = a[0].Split('?');

            String url = (String.Format("Default.aspx?{0}&{1}&{2}", b[1],a[1],a[2]));

            Response.Redirect(url);
            
            
        }

    }

    }


