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

    public partial class Mybooking : System.Web.UI.Page
    {
         static int index;

        protected void Page_Load(object sender, EventArgs e)
        {
            String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            DataTable dt = new DataTable();

            String email = Session["user"].ToString();
            SqlDataAdapter adp = new SqlDataAdapter("select book_payment.booking_id,one_or_round,adults,price,book_air.one_aid,book_air.round_aid,class,dept_date,return_date,round_type from book_payment,book_air where email='" + email+"' and book_air.booking_id=book_payment.booking_id", con);
            adp.Fill(dt);

            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            dt1.Columns.Add("Booking_ID");
            dt1.Columns.Add("Trip_type");
            dt1.Columns.Add("Flight No");
            dt1.Columns.Add("Source");
            dt1.Columns.Add("Destination");
            dt1.Columns.Add("Adults");
            dt1.Columns.Add("Travel Class");
            dt1.Columns.Add("Departure Date");
            dt1.Columns.Add("Return Date");
            dt1.Columns.Add("Price");

           for(int i=0;i<dt.Rows.Count;i++)
            {
                DataRow dr = dt.Rows[i];
                dt1.Rows.Add();
                dt1.Rows[i]["Booking_ID"] = dr["booking_id"].ToString();
                if(dr["one_or_round"].ToString()=="O")
                {
                    dt1.Rows[i]["Flight No"] = dr["one_aid"].ToString();

                    dt1.Rows[i]["Trip_type"] = "One Way";
                    var a = dr["one_aid"].ToString().Split(',');

                    if (a.Length == 1)
                    {
                        dt2.Reset();
                        adp.SelectCommand = new SqlCommand("select src_airp,dest_airp from flights where fid='" + a[0].ToString() + "'", con);
                        adp.Fill(dt2);
                        DataRow dr1 = dt2.Rows[0];

                        dt1.Rows[i]["Source"] = dr1["src_airp"].ToString();
                        dt1.Rows[i]["Destination"] = dr1["dest_airp"].ToString();
                    }
                    else
                    {
                        dt2.Reset();
                        adp.SelectCommand = new SqlCommand("select src_airp,dest_airp from flights where fid='" + a[0].ToString() + "'", con);
                        adp.Fill(dt2);
                        adp.SelectCommand = new SqlCommand("select src_airp,dest_airp from flights where fid='" + a[1].ToString() + "'", con);
                        adp.Fill(dt2);
                        DataRow dr1 = dt2.Rows[0];

                        dt1.Rows[i]["Source"] = dr1["src_airp"].ToString();
                        dr1 = dt2.Rows[1];
                        dt1.Rows[i]["Destination"] = dr1["dest_airp"].ToString();

                    }



                }
                else
                {
                    dt1.Rows[i]["Flight No"] = dr["round_aid"].ToString();
                    dt1.Rows[i]["Trip_type"] = "Round trip";
                    dt1.Rows[i]["Return Date"] = dr["return_date"].ToString();
                    var a = dr["round_aid"].ToString().Split(',');

                  

                   if((dr["round_type"].ToString()=="0") || (dr["round_type"].ToString() == "2"))
                    {
                        dt2.Reset();
                        adp.SelectCommand = new SqlCommand("select src_airp,dest_airp from flights where fid='" + a[0].ToString() + "'", con);
                        adp.Fill(dt2);
                        adp.SelectCommand = new SqlCommand("select src_airp,dest_airp from flights where fid='" + a[1].ToString() + "'", con);
                        adp.Fill(dt2);
                        DataRow dr1 = dt2.Rows[0];

                        dt1.Rows[i]["Source"] = dr1["src_airp"].ToString();
                        dr1 = dt2.Rows[1];
                        dt1.Rows[i]["Destination"] = dr1["dest_airp"].ToString();

                    }

                    if((dr["round_type"].ToString()=="1") || (dr["round_type"].ToString() == "3"))
                    {
                        dt2.Reset();
                        adp.SelectCommand = new SqlCommand("select src_airp,dest_airp from flights where fid='" + a[0].ToString() + "'", con);
                        adp.Fill(dt2);
                        DataRow dr1 = dt2.Rows[0];
                        dt1.Rows[i]["Source"] = dr1["src_airp"].ToString();
                        dt1.Rows[i]["Destination"] = dr1["dest_airp"].ToString();
                    }

    
                }

                if (dr["class"].ToString()=="E")
                {
                    dt1.Rows[i]["Travel Class"] = "Economy";
                }
                else
                {
                    dt1.Rows[i]["Travel Class"] = "Buisness";
                }

                dt1.Rows[i]["Departure Date"] = dr["dept_date"].ToString();
                dt1.Rows[i]["Return Date"] = dr["return_date"].ToString();
                dt1.Rows[i]["Adults"] = dr["adults"].ToString();
                dt1.Rows[i]["Price"] = "₹"+dr["price"].ToString();


            }
            DataView view = dt1.DefaultView;
            view.Sort = "Booking_ID DESC";
            dt1 = view.ToTable();

            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            index = Convert.ToInt32(e.CommandArgument);
            GridView1.Rows[index].BackColor = Color.Red;

          
        }

        public void OnConfirm(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(index+1))
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    Debug.WriteLine(GridView1.Rows[index].Cells[1].Text);

                    Decimal bkid = Convert.ToDecimal(GridView1.Rows[index].Cells[1].Text);
                    String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;
                    SqlConnection con = new SqlConnection(constring);
                    con.Open();

                    if (GridView1.Rows[index].Cells[2].Text == "One Way")
                    {
                        var a = (GridView1.Rows[index].Cells[3].Text).Split(',');
                        SqlDataAdapter adp = new SqlDataAdapter();

                        if (a.Length == 1)
                        {
                            adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked-'" + Convert.ToInt32(GridView1.Rows[index].Cells[6].Text) + "' where fid='" + a[0] + "' and bdate='" + GridView1.Rows[index].Cells[8].Text + "' and  class='" + Convert.ToChar((GridView1.Rows[index].Cells[7].Text).FirstOrDefault()) + "' ", con);
                            adp.UpdateCommand.ExecuteNonQuery();
                        }

                        if (a.Length == 2)
                        {
                            adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked-'" + Convert.ToInt32(GridView1.Rows[index].Cells[6].Text) + "' where fid='" + a[0] + "' and bdate='" + GridView1.Rows[index].Cells[8].Text + "' and  class='" + Convert.ToChar((GridView1.Rows[index].Cells[7].Text).FirstOrDefault()) + "' ", con);
                            adp.UpdateCommand.ExecuteNonQuery();
                            adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked-'" + Convert.ToInt32(GridView1.Rows[index].Cells[6].Text) + "' where fid='" + a[1] + "' and bdate='" + GridView1.Rows[index].Cells[8].Text + "' and  class='" + Convert.ToChar((GridView1.Rows[index].Cells[7].Text).FirstOrDefault()) + "' ", con);
                            adp.UpdateCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        var a = (GridView1.Rows[index].Cells[3].Text).Split(',');
                        SqlDataAdapter adp = new SqlDataAdapter();

                        if (a.Length == 2)
                        {
                            adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked-'" + Convert.ToInt32(GridView1.Rows[index].Cells[6].Text) + "' where fid='" + a[0] + "' and bdate='" + GridView1.Rows[index].Cells[8].Text + "' and  class='" + Convert.ToChar((GridView1.Rows[index].Cells[7].Text).FirstOrDefault()) + "' ", con);
                            adp.UpdateCommand.ExecuteNonQuery();
                            adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked-'" + Convert.ToInt32(GridView1.Rows[index].Cells[6].Text) + "' where fid='" + a[1] + "' and bdate='" + GridView1.Rows[index].Cells[9].Text + "' and  class='" + Convert.ToChar((GridView1.Rows[index].Cells[7].Text).FirstOrDefault()) + "' ", con);
                            adp.UpdateCommand.ExecuteNonQuery();
                        }
                        if (a.Length == 4)
                        {
                            adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked-'" + Convert.ToInt32(GridView1.Rows[index].Cells[6].Text) + "' where fid='" + a[0] + "' and bdate='" + GridView1.Rows[index].Cells[8].Text + "' and  class='" + Convert.ToChar((GridView1.Rows[index].Cells[7].Text).FirstOrDefault()) + "' ", con);
                            adp.UpdateCommand.ExecuteNonQuery();
                            adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked-'" + Convert.ToInt32(GridView1.Rows[index].Cells[6].Text) + "' where fid='" + a[1] + "' and bdate='" + GridView1.Rows[index].Cells[8].Text + "' and  class='" + Convert.ToChar((GridView1.Rows[index].Cells[7].Text).FirstOrDefault()) + "' ", con);
                            adp.UpdateCommand.ExecuteNonQuery();
                            adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked-'" + Convert.ToInt32(GridView1.Rows[index].Cells[6].Text) + "' where fid='" + a[2] + "' and bdate='" + GridView1.Rows[index].Cells[9].Text + "' and  class='" + Convert.ToChar((GridView1.Rows[index].Cells[7].Text).FirstOrDefault()) + "' ", con);
                            adp.UpdateCommand.ExecuteNonQuery();
                            adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked-'" + Convert.ToInt32(GridView1.Rows[index].Cells[6].Text) + "' where fid='" + a[3] + "' and bdate='" + GridView1.Rows[index].Cells[9].Text + "' and  class='" + Convert.ToChar((GridView1.Rows[index].Cells[7].Text).FirstOrDefault()) + "' ", con);
                            adp.UpdateCommand.ExecuteNonQuery();
                        }

                        if (a.Length == 3)
                        {
                            adp.SelectCommand = new SqlCommand("select round_type from book_air where booking_id='" + bkid + "'", con);
                            DataTable dt5 = new DataTable();
                            adp.Fill(dt5);

                            DataRow dr = dt5.Rows[0];

                            if(dr["round_type"].ToString()=="1")
                            {
                                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked-'" + Convert.ToInt32(GridView1.Rows[index].Cells[6].Text) + "' where fid='" + a[0] + "' and bdate='" + GridView1.Rows[index].Cells[8].Text + "' and  class='" + Convert.ToChar((GridView1.Rows[index].Cells[7].Text).FirstOrDefault()) + "' ", con);
                                adp.UpdateCommand.ExecuteNonQuery();
                                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked-'" + Convert.ToInt32(GridView1.Rows[index].Cells[6].Text) + "' where fid='" + a[1] + "' and bdate='" + GridView1.Rows[index].Cells[9].Text + "' and  class='" + Convert.ToChar((GridView1.Rows[index].Cells[7].Text).FirstOrDefault()) + "' ", con);
                                adp.UpdateCommand.ExecuteNonQuery();
                                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked-'" + Convert.ToInt32(GridView1.Rows[index].Cells[6].Text) + "' where fid='" + a[2] + "' and bdate='" + GridView1.Rows[index].Cells[9].Text + "' and  class='" + Convert.ToChar((GridView1.Rows[index].Cells[7].Text).FirstOrDefault()) + "' ", con);
                                adp.UpdateCommand.ExecuteNonQuery();
                            }
                            if(dr["round_type"].ToString()=="2")
                            {
                                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked-'" + Convert.ToInt32(GridView1.Rows[index].Cells[6].Text) + "' where fid='" + a[0] + "' and bdate='" + GridView1.Rows[index].Cells[8].Text + "' and  class='" + Convert.ToChar((GridView1.Rows[index].Cells[7].Text).FirstOrDefault()) + "' ", con);
                                adp.UpdateCommand.ExecuteNonQuery();
                                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked-'" + Convert.ToInt32(GridView1.Rows[index].Cells[6].Text) + "' where fid='" + a[1] + "' and bdate='" + GridView1.Rows[index].Cells[8].Text + "' and  class='" + Convert.ToChar((GridView1.Rows[index].Cells[7].Text).FirstOrDefault()) + "' ", con);
                                adp.UpdateCommand.ExecuteNonQuery();
                                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked-'" + Convert.ToInt32(GridView1.Rows[index].Cells[6].Text) + "' where fid='" + a[2] + "' and bdate='" + GridView1.Rows[index].Cells[9].Text + "' and  class='" + Convert.ToChar((GridView1.Rows[index].Cells[7].Text).FirstOrDefault()) + "' ", con);
                                adp.UpdateCommand.ExecuteNonQuery();
                            }

                        }

                    }

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from book_air where booking_id='" + bkid + "' ";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "delete from [book_payment] where booking_id='" + bkid + "'";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "delete from [book_person] where booking_id='" + bkid + "'";
                    cmd.ExecuteNonQuery();

                   
                    Response.Redirect("Mybooking.aspx");

                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a ticket..')", true);

            }
        }

      
    }
}