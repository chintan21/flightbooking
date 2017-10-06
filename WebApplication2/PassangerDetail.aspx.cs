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
    public partial class PassangerDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var queryStrings = (Request.QueryString.ToString());
            var arr = queryStrings.Split('&');

            String aid1 = HttpUtility.UrlDecode(arr[0]);
            String aid2 = HttpUtility.UrlDecode(arr[1]);
            String dt = HttpUtility.UrlDecode(arr[2]);
            String rdt = HttpUtility.UrlDecode(arr[3]);
            String adt = HttpUtility.UrlDecode(arr[4]);
            String cld = HttpUtility.UrlDecode(arr[5]);
            String cls = HttpUtility.UrlDecode(arr[6]);
            int type = Convert.ToInt32(HttpUtility.UrlDecode(arr[7]));
            int price=0;

            String aid3;
            String aid4;
            String mid1;
            String mid2;
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();

            String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;

            SqlConnection con = new SqlConnection(constring);
            con.Open();

            SqlDataAdapter adp = new SqlDataAdapter("select flights.src_airp,flights.dest_airp,flights.dept_time,flights.arr_time,Seats.Tot_seat,Seats.Price,Seats.D_lug,Seats.E_lug,Seats.E_lug_price from flights,Seats where flights.fid='" + aid1 + "' and Seats.fid=flights.fid and seat_class='"+cls.FirstOrDefault()+"' ", con);
            adp.Fill(dt1);

            adp.SelectCommand = new SqlCommand("select flights.src_airp, flights.dest_airp, flights.dept_time, flights.arr_time, Seats.Tot_seat, Seats.Price, Seats.D_lug, Seats.E_lug, Seats.E_lug_price from flights, Seats where flights.fid = '" + aid2 + "' and Seats.fid = flights.fid and seat_class = '"+cls.FirstOrDefault()+"'", con);
            adp.Fill(dt2);

            String src = dt1.Rows[0]["src_airp"].ToString();
            String dest = dt1.Rows[0]["dest_airp"].ToString();
            String dept1 = dt1.Rows[0]["dept_time"].ToString();
            String dept2 = dt2.Rows[0]["dept_time"].ToString();
            String arv1 = dt1.Rows[0]["arr_time"].ToString();
            String arv2 = dt2.Rows[0]["arr_time"].ToString();

            int t1 = Convert.ToInt32(dt1.Rows[0]["Tot_seat"].ToString());
            int t2 = Convert.ToInt32(dt2.Rows[0]["Tot_seat"].ToString());
           

            Label1.Text = "Round Trip(" + cls + ")";
            Label16.Text = dt;
            Label25.Text = rdt;
            Label40.Text = adt;
            Label42.Text = cld;
            Label10.Text = dept1;
            Label23.Text = dept2;
            if (type == 3)
            {
                Label4.Text = aid1;
                Label22.Text = aid2;

                price = Convert.ToInt32(Convert.ToInt32(dt1.Rows[0]["Price"].ToString()) + Convert.ToInt32(dt2.Rows[0]["Price"].ToString()));

                Label12.Text = dt1.Rows[0]["arr_time"].ToString();
                Label24.Text = dt2.Rows[0]["arr_time"].ToString();
                Label20.Text = Convert.ToString(Convert.ToInt32(dt1.Rows[0]["D_lug"].ToString())*Convert.ToInt32(adt))+" Kg";
                Label5.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0]["D_lug"].ToString()) * Convert.ToInt32(adt))+" Kg";

                int e1 = Convert.ToInt32(dt1.Rows[0]["E_lug"].ToString()) * Convert.ToInt32(adt);
                int e2 = Convert.ToInt32(dt2.Rows[0]["E_lug"].ToString()) * Convert.ToInt32(adt);

                if(e1<=e2)
                {
                    Label7.Text = Convert.ToString(e1)+" Kg";
                }
                else
                {
                    Label7.Text = Convert.ToString(e2)+" Kg";
                }

                Label13.Text = Convert.ToString(Convert.ToInt32(dt1.Rows[0]["E_lug_price"].ToString())+Convert.ToInt32(dt2.Rows[0]["E_lug_price"].ToString()));

                Label2.Text = src + " to " + dest;
                Label21.Text = dest + " to " + src;

                dt1.Reset();
                dt2.Reset();

                adp.SelectCommand = new SqlCommand("select booked from Seat_booked where fid='" + aid1 + "' and class='" + cls.FirstOrDefault() + "' and bdate='" + dt + "'", con);
                adp.Fill(dt1);

                adp.SelectCommand = new SqlCommand("select booked from Seat_booked where fid='" + aid2 + "' and class='" + cls.FirstOrDefault() + "' and bdate='" + rdt + "'", con);
                adp.Fill(dt2);

                int cdt1 = dt1.Rows.Count;
                int cdt2 = dt2.Rows.Count;

                if(cdt1>0 && cdt2>0)
                {
                    int tb1 = Convert.ToInt32(dt1.Rows[0]["booked"].ToString());
                    int tb2 = Convert.ToInt32(dt2.Rows[0]["booked"].ToString());

                    if (t1-tb1 <= t2-tb2)
                    {
                        Label44.Text = Convert.ToString(t1-tb1);
                    }
                    else
                    {
                        Label44.Text = Convert.ToString(t2-tb2);
                    }
                }

                else if(cdt1==0 && cdt2> 0)
                {
                    int tb2 = Convert.ToInt32(dt2.Rows[0]["booked"].ToString());
                    int x = 0;
                    adp.InsertCommand = new SqlCommand("insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)", con);

                    adp.InsertCommand.Parameters.Add("@fid", SqlDbType.VarChar).Value = aid1;
                    adp.InsertCommand.Parameters.Add("@class", SqlDbType.Char).Value = Convert.ToChar(cls.FirstOrDefault());
                    adp.InsertCommand.Parameters.Add("@bdate", SqlDbType.VarChar).Value = dt;
                    adp.InsertCommand.Parameters.Add("@booked", SqlDbType.Int).Value = x;

                    adp.InsertCommand.ExecuteNonQuery();
          

                    if (t1 <= t2 - tb2)
                    {
                        Label44.Text = Convert.ToString(t1);
                    }
                    else
                    {
                        Label44.Text = Convert.ToString(t2 - tb2);
                    }
                }
                else if(cdt1>0 && cdt2==0)
                {
                    int tb1 = Convert.ToInt32(dt1.Rows[0]["booked"].ToString());

                    int x = 0;
                    adp.InsertCommand = new SqlCommand("insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)", con);

                    adp.InsertCommand.Parameters.Add("@fid", SqlDbType.VarChar).Value = aid2;
                    adp.InsertCommand.Parameters.Add("@class", SqlDbType.Char).Value = Convert.ToChar(cls.FirstOrDefault());
                    adp.InsertCommand.Parameters.Add("@bdate", SqlDbType.VarChar).Value = rdt;
                    adp.InsertCommand.Parameters.Add("@booked", SqlDbType.Int).Value = x;

                    adp.InsertCommand.ExecuteNonQuery();


                    if (t1 - tb1 <= t2)
                    {
                        Label44.Text = Convert.ToString(t1 - tb1);
                    }
                    else
                    {
                        Label44.Text = Convert.ToString(t2);
                    }
                }

                else
                {
                    int x = 0;
                    adp.InsertCommand = new SqlCommand("insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)", con);

                    adp.InsertCommand.Parameters.Add("@fid", SqlDbType.VarChar).Value = aid1;
                    adp.InsertCommand.Parameters.Add("@class", SqlDbType.Char).Value = Convert.ToChar(cls.FirstOrDefault());
                    adp.InsertCommand.Parameters.Add("@bdate", SqlDbType.VarChar).Value = dt;
                    adp.InsertCommand.Parameters.Add("@booked", SqlDbType.Int).Value = x;

                    adp.InsertCommand.ExecuteNonQuery();

                    adp.InsertCommand = new SqlCommand("insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)", con);

                    adp.InsertCommand.Parameters.Add("@fid", SqlDbType.VarChar).Value = aid2;
                    adp.InsertCommand.Parameters.Add("@class", SqlDbType.Char).Value = Convert.ToChar(cls.FirstOrDefault());
                    adp.InsertCommand.Parameters.Add("@bdate", SqlDbType.VarChar).Value = rdt;
                    adp.InsertCommand.Parameters.Add("@booked", SqlDbType.Int).Value = x;

                    adp.InsertCommand.ExecuteNonQuery();

                    if (t1 <= t2 )
                    {
                        Label44.Text = Convert.ToString(t1);
                    }
                    else
                    {
                        Label44.Text = Convert.ToString(t2);
                    }
                }

                dt1.Reset();
                dt2.Reset();
            }

            if(type==2)
            {
                aid3 = HttpUtility.UrlDecode(arr[8]);
                mid1 = HttpUtility.UrlDecode(arr[9]);
                Label4.Text = aid1 + "," + aid3;
                Label22.Text = aid2;

               

                adp.SelectCommand = new SqlCommand("select flights.src_airp,flights.dest_airp,flights.dept_time,flights.arr_time,Seats.Tot_seat,Seats.Price,Seats.D_lug,Seats.E_lug,Seats.E_lug_price from flights,Seats where flights.fid='" + aid3 + "' and Seats.fid=flights.fid and seat_class='" + cls.FirstOrDefault() + "' ", con);
                adp.Fill(dt3);

                price = Convert.ToInt32((Convert.ToInt32(dt1.Rows[0]["Price"].ToString()) + Convert.ToInt32(dt3.Rows[0]["Price"].ToString()))*0.6  + Convert.ToInt32(dt2.Rows[0]["Price"].ToString()));

                dest = dt3.Rows[0]["dest_airp"].ToString();

                Label2.Text = src + " to " + dest + " via " + mid1;
                Label21.Text = dest + " to " + src;

                Label12.Text = dt3.Rows[0]["arr_time"].ToString();
                Label24.Text = arv2;

                Label20.Text = dt1.Rows[0]["D_lug"].ToString() + " Kg," + dt3.Rows[0]["D_lug"].ToString() + " Kg";
                Label5.Text = dt2.Rows[0]["D_lug"].ToString() + " Kg";

                int e1 = Convert.ToInt32(dt1.Rows[0]["E_lug"].ToString());
                int e2 = Convert.ToInt32(dt2.Rows[0]["E_lug"].ToString());
                int e3 = Convert.ToInt32(dt3.Rows[0]["E_lug"].ToString());

                int e4 = Math.Min(e1, Math.Min(e2, e3));
                Label7.Text = Convert.ToString(e4)+" Kg";

                Label13.Text = Convert.ToString(Convert.ToInt32(dt1.Rows[0]["E_lug_price"].ToString())*0.6 + Convert.ToInt32(dt2.Rows[0]["E_lug_price"].ToString()) + Convert.ToInt32(dt3.Rows[0]["E_lug_price"].ToString())*0.5);

               
               int t3=Convert.ToInt32(dt3.Rows[0]["Tot_seat"].ToString());

                dt1.Reset();
                dt2.Reset();
                dt3.Reset();

                adp.SelectCommand = new SqlCommand("select booked from Seat_booked where fid='" + aid1 + "' and class='" + cls.FirstOrDefault() + "' and bdate='" + dt + "'", con);
                adp.Fill(dt1);

                adp.SelectCommand = new SqlCommand("select booked from Seat_booked where fid='" + aid2 + "' and class='" + cls.FirstOrDefault() + "' and bdate='" + rdt + "'", con);
                adp.Fill(dt2);

                adp.SelectCommand = new SqlCommand("select booked from Seat_booked where fid='" + aid3 + "' and class='" + cls.FirstOrDefault() + "' and bdate='" + dt + "'", con);
                adp.Fill(dt3);

                int cdt1 = dt1.Rows.Count;
                int cdt2 = dt2.Rows.Count;
                int cdt3 = dt3.Rows.Count;
                int x = 0;

                if (cdt1!=0)
                {
                    t1 = t1 - Convert.ToInt32(dt1.Rows[0]["booked"].ToString());
                }
                else
                {
                   
                    adp.InsertCommand = new SqlCommand("insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)", con);

                    adp.InsertCommand.Parameters.Add("@fid", SqlDbType.VarChar).Value = aid1;
                    adp.InsertCommand.Parameters.Add("@class", SqlDbType.Char).Value = Convert.ToChar(cls.FirstOrDefault());
                    adp.InsertCommand.Parameters.Add("@bdate", SqlDbType.VarChar).Value = dt;
                    adp.InsertCommand.Parameters.Add("@booked", SqlDbType.Int).Value = x;

                    adp.InsertCommand.ExecuteNonQuery();
                }

                if (cdt2 != 0)
                {
                    t2 = t2 - Convert.ToInt32(dt2.Rows[0]["booked"].ToString());
                }
                else
                {

                    adp.InsertCommand = new SqlCommand("insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)", con);

                    adp.InsertCommand.Parameters.Add("@fid", SqlDbType.VarChar).Value = aid2;
                    adp.InsertCommand.Parameters.Add("@class", SqlDbType.Char).Value = Convert.ToChar(cls.FirstOrDefault());
                    adp.InsertCommand.Parameters.Add("@bdate", SqlDbType.VarChar).Value = rdt;
                    adp.InsertCommand.Parameters.Add("@booked", SqlDbType.Int).Value = x;

                    adp.InsertCommand.ExecuteNonQuery();
                }

                if (cdt3 != 0)
                {
                    t3 = t3 - Convert.ToInt32(dt3.Rows[0]["booked"].ToString());
                }
                else
                {

                    adp.InsertCommand = new SqlCommand("insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)", con);

                    adp.InsertCommand.Parameters.Add("@fid", SqlDbType.VarChar).Value = aid3;
                    adp.InsertCommand.Parameters.Add("@class", SqlDbType.Char).Value = Convert.ToChar(cls.FirstOrDefault());
                    adp.InsertCommand.Parameters.Add("@bdate", SqlDbType.VarChar).Value = dt;
                    adp.InsertCommand.Parameters.Add("@booked", SqlDbType.Int).Value = x;

                    adp.InsertCommand.ExecuteNonQuery();
                }

                Label44.Text = Convert.ToString(Math.Min(t1, Math.Min(t2,t3)));

                dt1.Reset();
                dt2.Reset();
                dt3.Reset();
            }

            if (type==1)
            {
                mid2 = HttpUtility.UrlDecode(arr[9]);
                aid4 = HttpUtility.UrlDecode(arr[8]);
                Label4.Text = aid1;
                Label22.Text = aid2 + "," + aid4;

                Label2.Text = src + " to " + dest;
                Label21.Text=dest+" to "+src+" via " + mid2;

                Label12.Text = arv1;

                adp.SelectCommand = new SqlCommand("select flights.src_airp,flights.dest_airp,flights.dept_time,flights.arr_time,Seats.Tot_seat,Seats.Price,Seats.D_lug,Seats.E_lug,Seats.E_lug_price from flights,Seats where flights.fid='" + aid4 + "' and Seats.fid=flights.fid and seat_class='" + cls.FirstOrDefault() + "' ", con);
                adp.Fill(dt3);

                price = Convert.ToInt32((Convert.ToInt32(dt2.Rows[0]["Price"].ToString())  + Convert.ToInt32(dt3.Rows[0]["Price"].ToString())) * 0.6 + Convert.ToInt32(dt1.Rows[0]["Price"].ToString()));


                Label24.Text = dt3.Rows[0]["arr_time"].ToString();

                Label5.Text = dt2.Rows[0]["D_lug"].ToString() + " Kg," + dt3.Rows[0]["D_lug"].ToString() + " Kg";
                Label20.Text = dt1.Rows[0]["D_lug"].ToString() + " Kg";

                int e1 = Convert.ToInt32(dt1.Rows[0]["E_lug"].ToString());
                int e2 = Convert.ToInt32(dt2.Rows[0]["E_lug"].ToString());
                int e3 = Convert.ToInt32(dt3.Rows[0]["E_lug"].ToString());

                int e4 = Math.Min(e1, Math.Min(e2, e3));
                Label7.Text = Convert.ToString(e4) + " Kg";

                Label13.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0]["E_lug_price"].ToString()) * 0.6 + Convert.ToInt32(dt1.Rows[0]["E_lug_price"].ToString()) + Convert.ToInt32(dt3.Rows[0]["E_lug_price"].ToString()) * 0.5);
                int t3=Convert.ToInt32(dt3.Rows[0]["Tot_seat"].ToString());

                dt1.Reset();
                dt2.Reset();
                dt3.Reset();

                adp.SelectCommand = new SqlCommand("select booked from Seat_booked where fid='" + aid1 + "' and class='" + cls.FirstOrDefault() + "' and bdate='" + dt + "'", con);
                adp.Fill(dt1);

                adp.SelectCommand = new SqlCommand("select booked from Seat_booked where fid='" + aid2 + "' and class='" + cls.FirstOrDefault() + "' and bdate='" + rdt + "'", con);
                adp.Fill(dt2);

                adp.SelectCommand = new SqlCommand("select booked from Seat_booked where fid='" + aid4 + "' and class='" + cls.FirstOrDefault() + "' and bdate='" + rdt + "'", con);
                adp.Fill(dt3);

                int cdt1 = dt1.Rows.Count;
                int cdt2 = dt2.Rows.Count;
                int cdt3 = dt3.Rows.Count;
                
                int x = 0;

                if (cdt1 != 0)
                {
                    t1 = t1 - Convert.ToInt32(dt1.Rows[0]["booked"].ToString());
                }
                else
                {

                    adp.InsertCommand = new SqlCommand("insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)", con);

                    adp.InsertCommand.Parameters.Add("@fid", SqlDbType.VarChar).Value = aid1;
                    adp.InsertCommand.Parameters.Add("@class", SqlDbType.Char).Value = Convert.ToChar(cls.FirstOrDefault());
                    adp.InsertCommand.Parameters.Add("@bdate", SqlDbType.VarChar).Value = dt;
                    adp.InsertCommand.Parameters.Add("@booked", SqlDbType.Int).Value = x;

                    adp.InsertCommand.ExecuteNonQuery();
                }

                if (cdt2 != 0)
                {
                    t2 = t2 - Convert.ToInt32(dt2.Rows[0]["booked"].ToString());
                }
                else
                {

                    adp.InsertCommand = new SqlCommand("insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)", con);

                    adp.InsertCommand.Parameters.Add("@fid", SqlDbType.VarChar).Value = aid2;
                    adp.InsertCommand.Parameters.Add("@class", SqlDbType.Char).Value = Convert.ToChar(cls.FirstOrDefault());
                    adp.InsertCommand.Parameters.Add("@bdate", SqlDbType.VarChar).Value = rdt;
                    adp.InsertCommand.Parameters.Add("@booked", SqlDbType.Int).Value = x;

                    adp.InsertCommand.ExecuteNonQuery();
                }

                if (cdt3 != 0)
                {
                    t3 = t3 - Convert.ToInt32(dt3.Rows[0]["booked"].ToString());
                }
                else
                {

                    adp.InsertCommand = new SqlCommand("insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)", con);

                    adp.InsertCommand.Parameters.Add("@fid", SqlDbType.VarChar).Value = aid4;
                    adp.InsertCommand.Parameters.Add("@class", SqlDbType.Char).Value = Convert.ToChar(cls.FirstOrDefault());
                    adp.InsertCommand.Parameters.Add("@bdate", SqlDbType.VarChar).Value = rdt;
                    adp.InsertCommand.Parameters.Add("@booked", SqlDbType.Int).Value = x;

                    adp.InsertCommand.ExecuteNonQuery();
                }

                Label44.Text = Convert.ToString(Math.Min(t1, Math.Min(t2, t3)));

                dt1.Reset();
                dt2.Reset();
                dt3.Reset();


            }

            if (type==0)
            {
                aid3 = HttpUtility.UrlDecode(arr[8]);
                aid4 = HttpUtility.UrlDecode(arr[9]);

                mid1 = HttpUtility.UrlDecode(arr[10]);
                mid2 = HttpUtility.UrlDecode(arr[11]);

                Label4.Text = aid1 + "," + aid3;
                Label22.Text = aid2 + "," + aid4;

                src = dt1.Rows[0]["src_airp"].ToString();
                dest = dt2.Rows[0]["src_airp"].ToString();

                Label2.Text = src + " to " + dest + " via " + mid1;
                Label21.Text = dest + " to " + src + " via " + mid2;

                adp.SelectCommand = new SqlCommand("select flights.src_airp,flights.dest_airp,flights.dept_time,flights.arr_time,Seats.Tot_seat,Seats.Price,Seats.D_lug,Seats.E_lug,Seats.E_lug_price from flights,Seats where flights.fid='" + aid3 + "' and Seats.fid=flights.fid and seat_class='" + cls.FirstOrDefault() + "' ", con);
                adp.Fill(dt3);

                adp.SelectCommand = new SqlCommand("select flights.src_airp,flights.dest_airp,flights.dept_time,flights.arr_time,Seats.Tot_seat,Seats.Price,Seats.D_lug,Seats.E_lug,Seats.E_lug_price from flights,Seats where flights.fid='" + aid4 + "' and Seats.fid=flights.fid and seat_class='" + cls.FirstOrDefault() + "' ", con);
                adp.Fill(dt4);

                price = Convert.ToInt32(Convert.ToInt32(dt1.Rows[0]["Price"].ToString()) * 0.6 + Convert.ToInt32(dt3.Rows[0]["Price"].ToString()) * 0.6 + Convert.ToInt32(dt2.Rows[0]["Price"].ToString())*0.6 + Convert.ToInt32(dt4.Rows[0]["Price"].ToString()) * 0.6);


                Label12.Text = dt3.Rows[0]["arr_time"].ToString();
                Label24.Text = dt4.Rows[0]["arr_time"].ToString();

                Label5.Text = dt2.Rows[0]["D_lug"].ToString() + " Kg," + dt4.Rows[0]["D_lug"].ToString() + " Kg";
                Label20.Text = dt1.Rows[0]["D_lug"].ToString() + " Kg,"+ dt3.Rows[0]["D_lug"].ToString() + " Kg";

                int e1 = Convert.ToInt32(dt1.Rows[0]["E_lug"].ToString());
                int e2 = Convert.ToInt32(dt2.Rows[0]["E_lug"].ToString());
                int e3 = Convert.ToInt32(dt3.Rows[0]["E_lug"].ToString());
                int e4 = Convert.ToInt32(dt4.Rows[0]["E_lug"].ToString());

                int e5 = Math.Min(Math.Min(e1,e4), Math.Min(e2, e3));
                Label7.Text = Convert.ToString(e5) + " Kg";

                Label13.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0]["E_lug_price"].ToString()) * 0.6 + Convert.ToInt32(dt1.Rows[0]["E_lug_price"].ToString())*0.6 + Convert.ToInt32(dt3.Rows[0]["E_lug_price"].ToString()) * 0.6 + Convert.ToInt32(dt4.Rows[0]["E_lug_price"].ToString()) * 0.6);
                int t3 = Convert.ToInt32(dt3.Rows[0]["Tot_seat"].ToString());
                int t4 = Convert.ToInt32(dt4.Rows[0]["Tot_seat"].ToString());

                dt1.Reset();
                dt2.Reset();
                dt3.Reset();
                dt4.Reset();

                adp.SelectCommand = new SqlCommand("select booked from Seat_booked where fid='" + aid1 + "' and class='" + cls.FirstOrDefault() + "' and bdate='" + dt + "'", con);
                adp.Fill(dt1);

                adp.SelectCommand = new SqlCommand("select booked from Seat_booked where fid='" + aid2 + "' and class='" + cls.FirstOrDefault() + "' and bdate='" + dt + "'", con);
                adp.Fill(dt2);

                adp.SelectCommand = new SqlCommand("select booked from Seat_booked where fid='" + aid3 + "' and class='" + cls.FirstOrDefault() + "' and bdate='" + rdt + "'", con);
                adp.Fill(dt3);

                adp.SelectCommand = new SqlCommand("select booked from Seat_booked where fid='" + aid4 + "' and class='" + cls.FirstOrDefault() + "' and bdate='" + rdt + "'", con);
                adp.Fill(dt4);

                int cdt1 = dt1.Rows.Count;
                int cdt2 = dt2.Rows.Count;
                int cdt3 = dt3.Rows.Count;
                int cdt4 = dt4.Rows.Count;

                int x = 0;

                if (cdt1 != 0)
                {
                    t1 = t1 - Convert.ToInt32(dt1.Rows[0]["booked"].ToString());
                }
                else
                {

                    adp.InsertCommand = new SqlCommand("insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)", con);

                    adp.InsertCommand.Parameters.Add("@fid", SqlDbType.VarChar).Value = aid1;
                    adp.InsertCommand.Parameters.Add("@class", SqlDbType.Char).Value = Convert.ToChar(cls.FirstOrDefault());
                    adp.InsertCommand.Parameters.Add("@bdate", SqlDbType.VarChar).Value = dt;
                    adp.InsertCommand.Parameters.Add("@booked", SqlDbType.Int).Value = x;

                    adp.InsertCommand.ExecuteNonQuery();
                }

                if (cdt2 != 0)
                {
                    t2 = t2 - Convert.ToInt32(dt2.Rows[0]["booked"].ToString());
                }
                else
                {

                    adp.InsertCommand = new SqlCommand("insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)", con);

                    adp.InsertCommand.Parameters.Add("@fid", SqlDbType.VarChar).Value = aid2;
                    adp.InsertCommand.Parameters.Add("@class", SqlDbType.Char).Value = Convert.ToChar(cls.FirstOrDefault());
                    adp.InsertCommand.Parameters.Add("@bdate", SqlDbType.VarChar).Value = dt;
                    adp.InsertCommand.Parameters.Add("@booked", SqlDbType.Int).Value = x;

                    adp.InsertCommand.ExecuteNonQuery();
                }

                if (cdt3 != 0)
                {
                    t3 = t3 - Convert.ToInt32(dt3.Rows[0]["booked"].ToString());
                }
                else
                {

                    adp.InsertCommand = new SqlCommand("insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)", con);

                    adp.InsertCommand.Parameters.Add("@fid", SqlDbType.VarChar).Value = aid3;
                    adp.InsertCommand.Parameters.Add("@class", SqlDbType.Char).Value = Convert.ToChar(cls.FirstOrDefault());
                    adp.InsertCommand.Parameters.Add("@bdate", SqlDbType.VarChar).Value = rdt;
                    adp.InsertCommand.Parameters.Add("@booked", SqlDbType.Int).Value = x;

                    adp.InsertCommand.ExecuteNonQuery();
                }

                if (cdt4 != 0)
                {
                    t4 = t4 - Convert.ToInt32(dt3.Rows[0]["booked"].ToString());
                }
                else
                {

                    adp.InsertCommand = new SqlCommand("insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)", con);

                    adp.InsertCommand.Parameters.Add("@fid", SqlDbType.VarChar).Value = aid4;
                    adp.InsertCommand.Parameters.Add("@class", SqlDbType.Char).Value = Convert.ToChar(cls.FirstOrDefault());
                    adp.InsertCommand.Parameters.Add("@bdate", SqlDbType.VarChar).Value = rdt;
                    adp.InsertCommand.Parameters.Add("@booked", SqlDbType.Int).Value = x;

                    adp.InsertCommand.ExecuteNonQuery();
                }

                Label44.Text = Convert.ToString(Math.Min(Math.Min(t1,t4), Math.Min(t2, t3)));

                dt1.Reset();
                dt2.Reset();
                dt3.Reset();
                dt4.Reset();

            }

            Debug.WriteLine(price);
            Session["price"] = price;
        }
    }
}