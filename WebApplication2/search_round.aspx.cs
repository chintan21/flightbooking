using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Drawing;

namespace WebApplication2
{
    public partial class search_round : System.Web.UI.Page
    {
        String src;
        String dest;
        String dt;
        String rdt;
        String cls;
        String adt;
        String cld;
        int k1;
        int k2,k3,k4;

        protected void Page_Load(object sender, EventArgs e)
        {
            var queryStrings = (Request.QueryString.ToString());
            var arr = queryStrings.Split('&');

            src = arr[0];
            dest = arr[1];
            dt = arr[2];
            cls = arr[3];
            adt = arr[4];
            cld = arr[5];
            rdt = arr[6];

            Label2.Text = " " + src + " to " + dest;
            Label2.Visible = true;
            Label4.Text = " " + dt;
            Label4.Visible = true;
           
            Label12.Text = rdt;
            Label7.Text = arr[3];
            Label9.Text = adt;
            Label11.Text = cld;

          //  Label13.Text = src + " to " + dest;
           // Label14.Text = dest + " to " + src;

            DataTable dt6 = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt7 = new DataTable();

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

            String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;
             SqlConnection con = new SqlConnection(constring);
             con.Open();

            SqlDataAdapter adp = new SqlDataAdapter("Select airport from distance where " + src + "<=500  and " + src + " >0", con);
            adp.Fill(dt6);

            adp.SelectCommand = new SqlCommand("Select airport from distance where " + dest + "<=500 and " + dest + ">0", con);
            adp.Fill(dt6);

            String midc;


            for (int i = 0; i < dt6.Rows.Count; i++)
            {
                int cnt = 0;


                midc = dt6.Rows[i].ToString();

                for (int j = i + 1; j < dt6.Rows.Count; i++)
                {
                    if (dt6.Rows[j].ToString() == midc)
                    {
                        cnt++;
                        break;
                    }

                }

                if (cnt == 0)
                {

                    DataRow dr = dt6.Rows[i];
                    dr.Delete();
                    dt6.AcceptChanges();
                }

            }

            dt1.Reset();
            dt2.Reset();



           adp.SelectCommand = new SqlCommand("select flights.fid as Flight_ID,air_id as Airline,src_airp as Source,dest_airp as Destination,dept_time as Departure,arr_time as Arrival,Price from flights,Seats where src_airp='" + src + "' and dest_airp='" + dest + "' and Seats.fid=flights.fid and Seats.seat_class='" + cls.FirstOrDefault() + "' and Seats.Tot_seat > 0 ", con);
            adp.Fill(dt1);

            adp.SelectCommand = new SqlCommand("select flights.fid as Flight_ID,air_id as Airline,src_airp as Source,dest_airp as Destination,dept_time as Departure,arr_time as Arrival,Price from flights,Seats where src_airp='" + dest + "' and dest_airp='" + src + "' and Seats.fid=flights.fid and Seats.seat_class='" + cls.FirstOrDefault() + "' and Seats.Tot_seat > 0 ", con);
            adp.Fill(dt2);

            String mid;
            for (int i = 0; i < dt6.Rows.Count; i++)
            {

                mid = (dt6.Rows[i]["airport"]).ToString();

                adp.SelectCommand = new SqlCommand("select flights.fid as Flight_ID,air_id as Airline,src_airp as Source,dest_airp as Destination,dept_time as Departure,arr_time as Arrival,Price from flights,Seats where src_airp='" + src + "' and dest_airp='" + mid + "' and Seats.fid=flights.fid and Seats.seat_class='" + cls.FirstOrDefault() + "' ", con);
                adp.Fill(dt7);
                adp.SelectCommand = new SqlCommand("select flights.fid as Flight_ID,air_id as Airline,src_airp as Source,dest_airp as Destination,dept_time as Departure,arr_time as Arrival,Price from flights,Seats where src_airp='" + mid + "' and dest_airp='" + dest + "' and Seats.fid=flights.fid and Seats.seat_class='" + cls.FirstOrDefault() + "' ", con);
                adp.Fill(dt3);

                

                if (dt7.Rows.Count != 0 && dt3.Rows.Count != 0)
                {
                    dt4 = dt7.Clone();
                    dt4 = dt3.Clone();
                    int a1 = dt7.Rows.Count;
                    int a2 = dt3.Rows.Count;



                    for (int a = 0; a < a1; a++)
                    {
                        for (int b = 0; b < a2; b++)
                        {
                            DateTime time1 = Convert.ToDateTime(dt7.Rows[a]["Arrival"].ToString());
                            DateTime time2 = Convert.ToDateTime(dt3.Rows[b]["Departure"].ToString());

                            int result = DateTime.Compare(time1, time2);



                            if (result < 0)
                            {
                                int a11 = Convert.ToInt32(dt7.Rows[a]["Price"].ToString());
                                int a12 = Convert.ToInt32(dt3.Rows[b]["Price"].ToString());

                                a11 = Convert.ToInt32((a11 + a12) * 0.6);

                                dt2.Rows[a]["Price"] = a11;
                                dt3.Rows[b]["Price"] = DBNull.Value;

                                dt2.AcceptChanges();
                                dt3.AcceptChanges();

                                dt4.ImportRow(dt7.Rows[a]);

                                dt4.ImportRow(dt3.Rows[b]);
                                //dt4.ImportRow(dt3.Rows[b]);


                                //count++;




                            }


                        }
                    }
                }

                foreach (DataRow dr in dt4.Rows)
                {

                    dt5.Rows.Add(dr.ItemArray);
                }

                dt7.Reset();
                dt3.Reset();
                dt4.Reset();

            }



            k1 = dt1.Rows.Count;
            k2 = k1;

            foreach (DataRow dr in dt5.Rows)
            {
                dt1.Rows.Add(dr.ItemArray);
            }


            GridView1.DataSource = dt1;
            GridView1.DataBind();
          
           while (k1 < GridView1.Rows.Count)
            {
                if (k2 % 2 != 0)
                {

                    if (k1 % 2 == 0)
                    {

                        GridView1.Rows[k1].Cells[0].Text = " ";
                        GridView1.Rows[k1].Cells[0].ToolTip = "This flight is connected with above flight, so this alone can't be booked";
                    }
                }
                else
                {
                    if (k1 % 2 != 0)
                    {

                        GridView1.Rows[k1].Cells[0].Text = " ";
                        GridView1.Rows[k1].Cells[0].ToolTip = "This flight is connected with above flight, so this alone can't be booked";
                    }
                }

                k1 = k1 + 1;
            }

            dt3.Reset();
            dt4.Reset();
            dt5.Reset();
            dt7.Reset();

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


            for (int i = 0; i < dt6.Rows.Count; i++)
            {

                mid = (dt6.Rows[i]["airport"]).ToString();

                adp.SelectCommand = new SqlCommand("select flights.fid as Flight_ID,air_id as Airline,src_airp as Source,dest_airp as Destination,dept_time as Departure,arr_time as Arrival,Price from flights,Seats where src_airp='" + dest + "' and dest_airp='" + mid + "' and Seats.fid=flights.fid and Seats.seat_class='" + cls.FirstOrDefault() + "' ", con);
                adp.Fill(dt7);
                adp.SelectCommand = new SqlCommand("select flights.fid as Flight_ID,air_id as Airline,src_airp as Source,dest_airp as Destination,dept_time as Departure,arr_time as Arrival,Price from flights,Seats where src_airp='" + mid + "' and dest_airp='" + src + "' and Seats.fid=flights.fid and Seats.seat_class='" + cls.FirstOrDefault() + "' ", con);
                adp.Fill(dt3);



                if (dt7.Rows.Count != 0 && dt3.Rows.Count != 0)
                {
                    dt4 = dt7.Clone();
                    dt4 = dt3.Clone();
                    int a1 = dt7.Rows.Count;
                    int a2 = dt3.Rows.Count;



                    for (int a = 0; a < a1; a++)
                    {
                        for (int b = 0; b < a2; b++)
                        {
                            DateTime time1 = Convert.ToDateTime(dt7.Rows[a]["Arrival"].ToString());
                            DateTime time2 = Convert.ToDateTime(dt3.Rows[b]["Departure"].ToString());

                            int result = DateTime.Compare(time1, time2);



                            if (result < 0)
                            {
                                int a11 = Convert.ToInt32(dt7.Rows[a]["Price"].ToString());
                                int a12 = Convert.ToInt32(dt3.Rows[b]["Price"].ToString());

                                a11 = Convert.ToInt32((a11 + a12) * 0.6);

                                dt2.Rows[a]["Price"] = a11;
                                dt3.Rows[b]["Price"] = DBNull.Value;

                                dt2.AcceptChanges();
                                dt3.AcceptChanges();

                                dt4.ImportRow(dt7.Rows[a]);

                                dt4.ImportRow(dt3.Rows[b]);
                                //dt4.ImportRow(dt3.Rows[b]);


                                //count++;




                            }


                        }
                    }
                }

                foreach (DataRow dr in dt4.Rows)
                {

                    dt5.Rows.Add(dr.ItemArray);
                }

                dt7.Reset();
                dt3.Reset();
                dt4.Reset();

            }



            k3 = dt2.Rows.Count;
            k4 = k3;

            foreach (DataRow dr in dt5.Rows)
            {
                dt2.Rows.Add(dr.ItemArray);
            }


            GridView2.DataSource = dt2;
            GridView2.DataBind();

            while (k3 < GridView2.Rows.Count)
            {
                if (k4 % 2 == 0)
                {

                    if (k3 % 2 != 0)
                    {

                        GridView2.Rows[k3].Cells[0].Text = " ";
                        GridView2.Rows[k3].Cells[0].ToolTip = "This flight is connected with above flight, so this alone can't be booked";
                    }
                }
                else
                {
                    if (k3 % 2 == 0)
                    {

                        GridView2.Rows[k3].Cells[0].Text = " ";
                        GridView2.Rows[k3].Cells[0].ToolTip = "This flight is connected with above flight, so this alone can't be booked";
                    }
                }

                k3 = k3 + 1;
            }


        }

    









int index,index1;

        protected void GridView1_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
           
            index = Convert.ToInt32(e.CommandArgument);


                GridView1.Rows[index].BackColor = Color.Red;
                GridView2.Enabled = true;


           if (index >= k2)
            {
                
                GridView1.Rows[index + 1].BackColor = Color.Red;
            }
               
            
           
        }

        protected void GridView2_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            index1 = Convert.ToInt32(e.CommandArgument);
            GridView2.Rows[index].BackColor = Color.Red;

            if (index >= k4)
            {

                GridView2.Rows[index + 1].BackColor = Color.Red;
            }
            Response.Redirect("Baggage.aspx");
            
        }
    }
}