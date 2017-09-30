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
    
    public partial class Passanger_detail : System.Web.UI.Page
    {
        Boolean inter;
        protected void Page_Load(object sender, EventArgs e)
        {
            var queryStrings = (Request.QueryString.ToString());
            var a = queryStrings.Split('&');
            String id = HttpUtility.UrlDecode(a[0]);
            String src = HttpUtility.UrlDecode(a[1]);
            String dest = HttpUtility.UrlDecode(a[2]);
           String dt = HttpUtility.UrlDecode(a[3]);
            int adt = Convert.ToInt32(HttpUtility.UrlDecode(a[4]));
            int cld = Convert.ToInt32(HttpUtility.UrlDecode(a[5]));
            String cls = HttpUtility.UrlDecode(a[6]);
            inter = Convert.ToBoolean(HttpUtility.UrlDecode(a[7]));
            String id1="0";


            String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();

            String way;
            if (inter == false)
            {
                way = src + " to " + dest;
                Label2.Text = way;
                Label4.Text = id;
                SqlDataAdapter adp1 = new SqlDataAdapter("select dept_time,arr_time from flights where fid='" + id + "'", con);
                adp1.Fill(dt2);
                Label10.Text = dt2.Rows[0]["dept_time"].ToString();
                Label12.Text = dt2.Rows[0]["arr_time"].ToString();
                dt2.Reset();
                adp1.SelectCommand = new SqlCommand("select price from Seats where fid='" + id + "' and seat_class='" + cls.FirstOrDefault()+"'", con);
                adp1.Fill(dt2);
                int prc = Convert.ToInt32(dt2.Rows[0]["price"].ToString());
                Label14.Text = Convert.ToString(prc * adt);
                dt2.Reset();
            }
           
           else
            {
                id1 = HttpUtility.UrlDecode(a[8]);
              String  mid = HttpUtility.UrlDecode(a[9]);
                way = src + " to " + dest + " via " + mid;
                Label2.Text = way;
                Label4.Text = id+","+id1;
                SqlDataAdapter adp1 = new SqlDataAdapter("select dept_time from flights where fid='" + id + "'", con);
                adp1.Fill(dt2);
                Label10.Text = dt2.Rows[0]["dept_time"].ToString();
                dt2.Reset();
                adp1.SelectCommand = new SqlCommand("select arr_time from flights where fid='" + id1 + "'", con);
                adp1.Fill(dt2);
                Label12.Text = dt2.Rows[0]["arr_time"].ToString();
                dt2.Reset();
                adp1.SelectCommand = new SqlCommand("select price from Seats where fid='" + id+"' and seat_class='"+cls.FirstOrDefault()+"'" , con);
                adp1.Fill(dt2);
                adp1.SelectCommand = new SqlCommand("select price from Seats where fid='" + id1 + "' and seat_class='" + cls.FirstOrDefault() + "'", con);
                adp1.Fill(dt3);
                int prc = Convert.ToInt32(((Convert.ToInt32(dt2.Rows[0]["price"].ToString()) + (Convert.ToInt32(dt3.Rows[0]["price"].ToString()))))*0.6);
                Label14.Text = Convert.ToString(prc * adt);
                dt2.Reset();
                dt3.Reset();
            }


            if(adt<6)
            {
                TextBox16.Enabled = false;
                TextBox17.Enabled = false;
                TextBox18.Enabled = false;
                DropDownList11.Enabled = false;
                DropDownList12.Enabled = false;

                if (adt < 5)
                {
                    TextBox13.Enabled = false;
                    TextBox14.Enabled = false;
                    TextBox15.Enabled = false;
                    DropDownList9.Enabled = false;
                    DropDownList10.Enabled = false;

                    if(adt<4)
                    {
                        TextBox10.Enabled = false;
                        TextBox11.Enabled = false;
                        TextBox12.Enabled = false;
                        DropDownList7.Enabled = false;
                        DropDownList8.Enabled = false;

                        if(adt<3)
                        {
                            TextBox7.Enabled = false;
                            TextBox8.Enabled = false;
                            TextBox9.Enabled = false;
                            DropDownList5.Enabled = false;
                            DropDownList6.Enabled = false;

                            if(adt<2)
                            {
                                TextBox4.Enabled = false;
                                TextBox5.Enabled = false;
                                TextBox6.Enabled = false;
                                DropDownList3.Enabled = false;
                                DropDownList4.Enabled = false;
                            }
                        }
                    }

                
                }
            }

            if(cld<2)
            {
                TextBox21.Enabled = false;
                TextBox22.Enabled = false;
                DropDownList14.Enabled = false;

                if(cld<1)
                {
                    TextBox19.Enabled = false;
                    TextBox20.Enabled = false;
                    DropDownList13.Enabled = false;
                }
            }
          
            
           
           
            Label16.Text = dt;
            Label6.Text = Convert.ToString(adt);
            Label8.Text = Convert.ToString(cld);


           
            char cls1 = cls.FirstOrDefault();



            if (inter == false)
            {

                SqlDataAdapter adp = new SqlDataAdapter("select booked from Seat_booked where fid='" + id + "' and class='" + cls1 + "' and bdate='" + dt + "'", con);
                adp.Fill(dt2);



                if (dt2.Rows.Count > 0)
                {
                    int bk = Convert.ToInt32(dt2.Rows[0]["booked"].ToString());
                    dt2.Reset();
                    adp.SelectCommand = new SqlCommand("select Tot_seat,D_lug from Seats where fid='" + id + "' and seat_class='" + cls1 + "'", con);
                    adp.Fill(dt2);
                    int tot = Convert.ToInt32(dt2.Rows[0]["Tot_seat"].ToString());
                    int lug = Convert.ToInt32(dt2.Rows[0]["D_lug"].ToString());
                    Label18.Text = Convert.ToString(tot - bk);
                    Label20.Text = Convert.ToString(lug * adt) + " Kg";

                }
                else
                {
                    adp.SelectCommand = new SqlCommand("select Tot_seat,D_lug from Seats where fid='" + id + "' and seat_class='" + cls1 + "'", con);
                    adp.Fill(dt2);
                    Label18.Text = dt2.Rows[0]["Tot_seat"].ToString();
                    int lug = Convert.ToInt32(dt2.Rows[0]["D_lug"].ToString());
                    Label20.Text = Convert.ToString((lug * adt)) + " Kg";

                    int c = 0;

                    String ab = "insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)";
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = con,
                        CommandType = CommandType.Text,
                        CommandText = ab
                    };
                    cmd.Parameters.AddWithValue("@fid", id);
                    cmd.Parameters.AddWithValue("@class", cls1);
                    cmd.Parameters.AddWithValue("@bdate", dt);
                    cmd.Parameters.AddWithValue("@booked", c);
                    cmd.ExecuteNonQuery();
                    dt2.Reset();
                }

            }

            if(inter==true)
            {
                Debug.WriteLine(id);
                Debug.WriteLine(id1);
                SqlDataAdapter adp = new SqlDataAdapter("select Tot_seat,D_lug from Seats where fid='" + id + "' and seat_class='" + cls1 + "'", con);
                adp.Fill(dt2);
                int tot1 = Convert.ToInt32(dt2.Rows[0]["Tot_seat"].ToString());
                int lug1 = Convert.ToInt32(dt2.Rows[0]["D_lug"].ToString());
                dt2.Reset();

                SqlDataAdapter adp1 = new SqlDataAdapter("select Tot_seat,D_lug from Seats where fid='" + id1 + "' and seat_class='" + cls1 + "'", con);
                adp1.Fill(dt2);
                int tot2 = Convert.ToInt32(dt2.Rows[0]["Tot_seat"].ToString());
                int lug2 = Convert.ToInt32(dt2.Rows[0]["D_lug"].ToString());

                Label20.Text = Convert.ToString(lug1*adt) + " Kg, " + Convert.ToString(lug2*adt) + " Kg";

                dt2.Reset();
                dt3.Reset();

                adp.SelectCommand=new SqlCommand("select booked from Seat_booked where fid='" + id + "' and class='" + cls1 + "' and bdate='" + dt + "'", con);
                adp.Fill(dt2);
                
                

                adp1.SelectCommand=new SqlCommand("select booked from Seat_booked where fid='" + id1 + "' and class='" + cls1 + "' and bdate='" + dt + "'", con);
                adp1.Fill(dt3);

                

              

                if (dt2.Rows.Count>0 && dt3.Rows.Count>0)
                {
                    int bk1 = Convert.ToInt32(dt2.Rows[0]["booked"].ToString());
                    int bk2 = Convert.ToInt32(dt3.Rows[0]["booked"].ToString());
                    if ((tot1 - bk1) >= (tot2 - bk2))
                    {
                        Label18.Text = Convert.ToString((tot2 - bk2));
                    }
                    else
                    {
                        Label18.Text = Convert.ToString((tot1 - bk1));
                    }

                    dt2.Reset();
                    dt3.Reset();



                }
                else if(dt2.Rows.Count>0)
                {
                    int bk1 = Convert.ToInt32(dt2.Rows[0]["booked"].ToString());

                    if (tot2>(tot1-bk1))
                    {
                        Label18.Text = Convert.ToString(tot1 - bk1);
                    }
                    else
                    {
                        Label18.Text = Convert.ToString(tot2);
                    }

                    int c = 0;

                    String ab = "insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)";
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = con,
                        CommandType = CommandType.Text,
                        CommandText = ab
                    };
                    cmd.Parameters.AddWithValue("@fid", id1);
                    cmd.Parameters.AddWithValue("@class", cls1);
                    cmd.Parameters.AddWithValue("@bdate", dt);
                    cmd.Parameters.AddWithValue("@booked", c);
                    cmd.ExecuteNonQuery();
                    dt2.Reset();
                }
                else if(dt3.Rows.Count>0)
                {
                    int bk2 = Convert.ToInt32(dt3.Rows[0]["booked"].ToString());

                    if (tot1 > (tot2 - bk2))
                    {
                        Label18.Text = Convert.ToString(tot2 - bk2);
                    }
                    else
                    {
                        Label18.Text = Convert.ToString(tot1);
                    }
                    int c = 0;

                    String ab = "insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)";
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = con,
                        CommandType = CommandType.Text,
                        CommandText = ab
                    };
                    cmd.Parameters.AddWithValue("@fid", id);
                    cmd.Parameters.AddWithValue("@class", cls1);
                    cmd.Parameters.AddWithValue("@bdate", dt);
                    cmd.Parameters.AddWithValue("@booked", c);
                    cmd.ExecuteNonQuery();
                    dt2.Reset();
                }
                else
                {
                    if (tot2 > tot1)
                    {
                        Label18.Text = Convert.ToString(tot1);
                    }
                    else
                    {
                        Label18.Text = Convert.ToString(tot2);
                    }

                    int c = 0;

                    String ab = "insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)";
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = con,
                        CommandType = CommandType.Text,
                        CommandText = ab
                    };
                    cmd.Parameters.AddWithValue("@fid", id);
                    cmd.Parameters.AddWithValue("@class", cls1);
                    cmd.Parameters.AddWithValue("@bdate", dt);
                    cmd.Parameters.AddWithValue("@booked", c);
                    cmd.ExecuteNonQuery();
                    dt2.Reset();

                    String ab1 = "insert into Seat_booked(fid,class,bdate,booked)values(@fid,@class,@bdate,@booked)";
                    SqlCommand cmd1 = new SqlCommand
                    {
                        Connection = con,
                        CommandType = CommandType.Text,
                        CommandText = ab1
                    };
                    cmd1.Parameters.AddWithValue("@fid", id1);
                    cmd1.Parameters.AddWithValue("@class", cls1);
                    cmd1.Parameters.AddWithValue("@bdate", dt);
                    cmd1.Parameters.AddWithValue("@booked", c);
                    cmd1.ExecuteNonQuery();
                    dt2.Reset();
                }
               
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {


            Response.Redirect("payment.aspx");
        }
    }
}