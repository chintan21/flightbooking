using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication2
{
    public partial class PassangerDetail : System.Web.UI.Page
    {
        static int type;
        int adt, cld;
        protected void Page_Load(object sender, EventArgs e)
        {
            var queryStrings = (Request.QueryString.ToString());
            var arr = queryStrings.Split('&');

            String aid1 = HttpUtility.UrlDecode(arr[0]);
            String aid2 = HttpUtility.UrlDecode(arr[1]);
            String dt = HttpUtility.UrlDecode(arr[2]);
            String rdt = HttpUtility.UrlDecode(arr[3]);
            adt = Convert.ToInt32(HttpUtility.UrlDecode(arr[4]));
            cld = Convert.ToInt32(HttpUtility.UrlDecode(arr[5]));
            String cls = HttpUtility.UrlDecode(arr[6]);
            type = Convert.ToInt32(HttpUtility.UrlDecode(arr[7]));
            int price=0;

            Session["Class"] = cls;
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

            if (Session["user"] != null)
            {
                String user = Session["user"].ToString();
                String user1 = "I am" + user;
                Debug.WriteLine(user1);
                SqlDataAdapter adp3 = new SqlDataAdapter("select mobileno from signup where email='" + user + "' ", con);
                adp3.Fill(dt2);
                TextBox24.Text = dt2.Rows[0]["mobileno"].ToString();
                dt2.Reset();
            }

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
            Label40.Text = Convert.ToString(adt);
            Label42.Text = Convert.ToString(cld);
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

            if (adt < 6)
            {
                a6.Visible = false;
                TextBox19.Enabled = false;
                TextBox17.Enabled = false;
                TextBox18.Enabled = false;
                DropDownList11.Enabled = false;
                DropDownList12.Enabled = false;

                if (adt < 5)
                {
                    a5.Visible = false;
                    TextBox16.Enabled = false;
                    TextBox14.Enabled = false;
                    TextBox15.Enabled = false;
                    DropDownList9.Enabled = false;
                    DropDownList10.Enabled = false;

                    if (adt < 4)
                    {
                        a4.Visible = false;
                        TextBox13.Enabled = false;
                        TextBox11.Enabled = false;
                        TextBox12.Enabled = false;
                        DropDownList7.Enabled = false;
                        DropDownList8.Enabled = false;

                        if (adt < 3)
                        {
                            a3.Visible = false;
                            TextBox10.Enabled = false;
                            TextBox8.Enabled = false;
                            TextBox9.Enabled = false;
                            DropDownList5.Enabled = false;
                            DropDownList6.Enabled = false;

                            if (adt < 2)
                            {
                                a2.Visible = false;
                                TextBox7.Enabled = false;
                                TextBox5.Enabled = false;
                                TextBox6.Enabled = false;
                                DropDownList3.Enabled = false;
                                DropDownList4.Enabled = false;
                            }
                        }
                    }


                }
            }

            if (cld < 2)
            {
                c2.Visible = false;
                TextBox23.Enabled = false;
                TextBox22.Enabled = false;
                DropDownList14.Enabled = false;

                if (cld < 1)
                {
                    tchild.Visible = false;
                    TextBox11.Enabled = false;
                    TextBox20.Enabled = false;
                    DropDownList13.Enabled = false;
                    
                }
            }

            Label18.Text = "₹" + Session["price"];
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                TextBox1.Text = "0";

            }
         
                Label18.Text= "₹" + Convert.ToString(Convert.ToInt32(Session["price"])+(Convert.ToInt32(TextBox1.Text) * Convert.ToInt32(Label13.Text)));
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Name");
            dt.Columns.Add("Age");
            dt.Columns.Add("Gender");
            dt.Columns.Add("ID Card Type");
            dt.Columns.Add("ID Card No.");

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Name");
            dt1.Columns.Add("Age");
            dt1.Columns.Add("Gender");

            if (adt > 0)
            {
                DataRow row = dt.NewRow();
                row[0] = TextBox2.Text;
                row[1] = TextBox3.Text;
                row[2] = DropDownList1.SelectedValue;
                row[3] = DropDownList2.SelectedValue;
                row[4] = TextBox4.Text;

                dt.Rows.Add(row);


                if (adt > 1)
                {
                    DataRow row1 = dt.NewRow();
                    row1[0] = TextBox5.Text;
                    row1[1] = TextBox6.Text;
                    row1[2] = DropDownList3.SelectedValue;
                    row1[3] = DropDownList4.SelectedValue;
                    row1[4] = TextBox7.Text;

                    dt.Rows.Add(row1);

                    if (adt > 2)
                    {
                        DataRow row2 = dt.NewRow();
                        row2[0] = TextBox8.Text;
                        row2[1] = TextBox9.Text;
                        row2[2] = DropDownList5.SelectedValue;
                        row2[3] = DropDownList6.SelectedValue;
                        row2[4] = TextBox10.Text;

                        dt.Rows.Add(row2);


                        if (adt > 3)
                        {
                            DataRow row3 = dt.NewRow();
                            row3[0] = TextBox11.Text;
                            row3[1] = TextBox12.Text;
                            row3[2] = DropDownList7.SelectedValue;
                            row3[3] = DropDownList8.SelectedValue;
                            row3[4] = TextBox13.Text;

                            dt.Rows.Add(row3);

                            if (adt > 4)
                            {
                                DataRow row4 = dt.NewRow();
                                row4[0] = TextBox14.Text;
                                row4[1] = TextBox15.Text;
                                row4[2] = DropDownList9.SelectedValue;
                                row4[3] = DropDownList10.SelectedValue;
                                row4[4] = TextBox16.Text;

                                dt.Rows.Add(row4);

                                if (adt > 5)
                                {
                                    DataRow row5 = dt.NewRow();
                                    row5[0] = TextBox17.Text;
                                    row5[1] = TextBox18.Text;
                                    row5[2] = DropDownList11.SelectedValue;
                                    row5[3] = DropDownList12.SelectedValue;
                                    row5[4] = TextBox19.Text;

                                    dt.Rows.Add(row5);


                                }
                            }
                        }

                    }
                }
            }

            if (cld > 0)
            {
                DataRow row = dt1.NewRow();
                row[0] = TextBox20.Text;
                row[1] = TextBox21.Text;
                row[2] = DropDownList13.SelectedValue;
                dt1.Rows.Add(row);
                if (cld > 1)
                {
                    DataRow row1 = dt1.NewRow();

                    row1[0] = TextBox22.Text;
                    row1[1] = TextBox23.Text;
                    row1[2] = DropDownList14.SelectedValue;
                    dt1.Rows.Add(row1);
                }
            }

            Session["temp_adt"] = dt;
            Session["temp_cld"] = dt1;
            Session["e_luggage"] = TextBox1.Text;
            Session["e_lug_price"] = Label13.Text;



            bool isHuman = example.Validate(txtCaptcha.Text);
            txtCaptcha.Text = null;
            if (!isHuman)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Incorrect Captcha')", true);

            }
            else
            {
                String url = (String.Format("Payment.aspx?{0}&{1}&{2}&{3}&{4}&{5}", HttpUtility.UrlEncode(Label2.Text + "_" + Label21.Text), HttpUtility.UrlEncode(Label16.Text+"_"+Label25.Text), HttpUtility.UrlEncode(Label4.Text+"_"+Label22.Text), HttpUtility.UrlEncode(TextBox24.Text),HttpUtility.UrlEncode("round"),HttpUtility.UrlEncode(Convert.ToString(type))));
                Response.Redirect(url);
            }

          
        }
    }
}