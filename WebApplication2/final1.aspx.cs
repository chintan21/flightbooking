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
    public partial class final1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            con.Open();

            var queryStrings = (Request.QueryString.ToString());
            var a = queryStrings.Split('&');
            Decimal bid = Convert.ToDecimal(a[0]);


            SqlDataAdapter adp = new SqlDataAdapter();

            if (File.Exists(Server.MapPath("Barcode.txt")))
            {
                File.Delete(Server.MapPath("BarCode.txt"));
            }
            File.WriteAllText(Server.MapPath("BarCode.txt"), Convert.ToString(bid));
            Process.Start(Server.MapPath("BarCodeGenerate.exe"));

            if (HttpUtility.UrlDecode(a[1]) == "NetBanking")
            {
               
                adp.InsertCommand = new SqlCommand("insert into book_payment(booking_id,email,mobileno,payment_mode,dc_card_no,price)values(@bid,@email,@mno,@pmode,null,@price)", con);
                adp.InsertCommand.Parameters.Add("@bid", SqlDbType.Decimal).Value = Convert.ToDecimal(a[0]);
                adp.InsertCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = Session["user"].ToString();
                adp.InsertCommand.Parameters.Add("@mno", SqlDbType.Decimal).Value = Convert.ToDecimal(a[3]);
                adp.InsertCommand.Parameters.Add("@pmode", SqlDbType.VarChar).Value = a[1].FirstOrDefault();

                adp.InsertCommand.Parameters.Add("@price", SqlDbType.Int).Value = Convert.ToInt32(HttpUtility.UrlDecode(a[2]));

                adp.InsertCommand.ExecuteNonQuery();
            }

            else
            {
                adp.InsertCommand = new SqlCommand("insert into book_payment(booking_id,email,mobileno,payment_mode,dc_card_no,price)values(@bid,@email,@mno,@pmode,@dcno,@price)", con);

                adp.InsertCommand.Parameters.Add("@bid", SqlDbType.Decimal).Value = Convert.ToDecimal(a[0]);
                adp.InsertCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = Session["user"].ToString();
                adp.InsertCommand.Parameters.Add("@mno", SqlDbType.Decimal).Value = Convert.ToDecimal(a[3]);
                adp.InsertCommand.Parameters.Add("@pmode", SqlDbType.VarChar).Value = a[1].FirstOrDefault();
                adp.InsertCommand.Parameters.Add("@dcno", SqlDbType.Decimal).Value = Convert.ToDecimal(a[6]);
                adp.InsertCommand.Parameters.Add("@price", SqlDbType.Int).Value = Convert.ToInt32(a[2]);

                adp.InsertCommand.ExecuteNonQuery();
            }

            DataTable dt1 = (DataTable)Session["temp_adt"];
            int adt = dt1.Rows.Count;

            GridView1.DataSource = dt1;
            GridView1.DataBind();



            for (int i = 0; i < adt; i++)
            {
                adp.InsertCommand = new SqlCommand("insert into book_person(booking_id,sr_no,name,age,gender,proof_type,proof_no,child)values(@bkid,@sr,@name,@age,@gender,@proof,@pfno,@cld)", con);

                adp.InsertCommand.Parameters.Add("@bkid", SqlDbType.Decimal).Value = Convert.ToDecimal(a[0]);
                adp.InsertCommand.Parameters.Add("@sr", SqlDbType.Int).Value = i + 1;
                adp.InsertCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = dt1.Rows[i]["Name"].ToString();
                adp.InsertCommand.Parameters.Add("@age", SqlDbType.Int).Value = Convert.ToInt32(dt1.Rows[i]["Age"].ToString());
                adp.InsertCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = dt1.Rows[i]["Gender"].ToString();
                adp.InsertCommand.Parameters.Add("@proof", SqlDbType.VarChar).Value = dt1.Rows[i]["ID Card Type"].ToString();
                adp.InsertCommand.Parameters.Add("@pfno", SqlDbType.Decimal).Value = dt1.Rows[i]["ID Card No."].ToString();
                adp.InsertCommand.Parameters.Add("@cld", SqlDbType.Char).Value = 'N';

                adp.InsertCommand.ExecuteNonQuery();

            }

            dt1.Reset();

            dt1 = (DataTable)Session["temp_cld"];
            GridView2.DataSource = dt1;
            GridView2.DataBind();
            int cld = 0;
            if (dt1 != null)
            {
                cld = dt1.Rows.Count;

                for (int i = 0; i < cld; i++)
                {
                    adp.InsertCommand = new SqlCommand("insert into book_person(booking_id,sr_no,name,age,gender,proof_type,proof_no,child)values(@bkid,@sr,@name,@age,@gender,null,null,@cld)", con);

                    adp.InsertCommand.Parameters.Add("@bkid", SqlDbType.Decimal).Value = Convert.ToDecimal(a[0]);
                    adp.InsertCommand.Parameters.Add("@sr", SqlDbType.Int).Value = i + 1;
                    adp.InsertCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = dt1.Rows[i]["Name"].ToString();
                    adp.InsertCommand.Parameters.Add("@age", SqlDbType.Int).Value = Convert.ToInt32(dt1.Rows[i]["Age"].ToString());
                    adp.InsertCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = dt1.Rows[i]["Gender"].ToString();

                    adp.InsertCommand.Parameters.Add("@cld", SqlDbType.Char).Value = 'Y';

                    adp.InsertCommand.ExecuteNonQuery();

                }

            }

            int type = Convert.ToInt32(HttpUtility.UrlDecode(a[5]));

         
                adp.InsertCommand = new SqlCommand("insert into book_air(booking_id,one_or_round,adults,child,one_aid,round_aid,one_E_lug,round_E_lug,dept_date,return_date,class,round_type)values(@bkid,@oor,@adt,@cld,null,@raid,null,@rel,@dd,@rd,@cls,@type)", con);

                adp.InsertCommand.Parameters.Add("@bkid", SqlDbType.Decimal).Value = Convert.ToDecimal(a[0]);
                adp.InsertCommand.Parameters.Add("@oor", SqlDbType.Char).Value = 'R';
                adp.InsertCommand.Parameters.Add("@adt", SqlDbType.Int).Value = adt;
                adp.InsertCommand.Parameters.Add("@cld", SqlDbType.Int).Value = cld;
               
                adp.InsertCommand.Parameters.Add("@raid", SqlDbType.VarChar).Value = Session["depart_fid"].ToString() +","+ Session["return_fid"].ToString();
          
                adp.InsertCommand.Parameters.Add("@rel", SqlDbType.VarChar).Value =Session["e_luggage"];
                adp.InsertCommand.Parameters.Add("@dd", SqlDbType.VarChar).Value = Session["dt"];
                adp.InsertCommand.Parameters.Add("@rd", SqlDbType.VarChar).Value = Session["rdt"];
                adp.InsertCommand.Parameters.Add("@cls", SqlDbType.Char).Value = Convert.ToChar((Session["Class"].ToString()).FirstOrDefault());
                adp.InsertCommand.Parameters.Add("@type", SqlDbType.Int).Value = type;

                adp.InsertCommand.ExecuteNonQuery();

            String aid1, aid2, raid1, raid2;

            DataTable dt5 = new DataTable();

            if(type==0)
            {
                aid1 = (Session["depart_fid"].ToString()).Split(',')[0];
                aid2 = (Session["depart_fid"].ToString()).Split(',')[1];
                raid1 = (Session["return_fid"].ToString()).Split(',')[0];
                raid2 = (Session["return_fid"].ToString()).Split(',')[1];

                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked+'" + adt + "' where fid='" + aid1 + "' and class='" + Convert.ToChar((Session["Class"].ToString()).FirstOrDefault()) + "' and bdate='" + Session["dt"] + "'", con);
                adp.UpdateCommand.ExecuteNonQuery();

                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked+'" + adt + "' where fid='" + aid2 + "' and class='" + Convert.ToChar((Session["Class"].ToString()).FirstOrDefault()) + "' and bdate='" + Session["dt"] + "'", con);
                adp.UpdateCommand.ExecuteNonQuery();

                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked+'" + adt + "' where fid='" + raid1 + "' and class='" + Convert.ToChar((Session["Class"].ToString()).FirstOrDefault()) + "' and bdate='" + Session["rdt"] + "'", con);
                adp.UpdateCommand.ExecuteNonQuery();

                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked+'" + adt + "' where fid='" + raid2 + "' and class='" + Convert.ToChar((Session["Class"].ToString()).FirstOrDefault()) + "' and bdate='" + Session["rdt"] + "'", con);
                adp.UpdateCommand.ExecuteNonQuery();

                DataTable dt7 = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter("select src_airp,dest_airp,dept_time,arr_time from flights where fid='"+aid1+"'",con);
                ad.Fill(dt7);

               ad.SelectCommand = new SqlCommand("select src_airp,dest_airp,dept_time,arr_time from flights where fid='" + aid2 + "'", con);
                ad.Fill(dt7);

                ad.SelectCommand = new SqlCommand("select src_airp,dest_airp,dept_time,arr_time from flights where fid='" + raid1 + "'", con);
                ad.Fill(dt7);

                ad.SelectCommand = new SqlCommand("select src_airp,dest_airp,dept_time,arr_time from flights where fid='" + raid2 + "'", con);
                ad.Fill(dt7);

                Label4.Text = dt7.Rows[0]["src_airp"].ToString();
                Label5.Text = dt7.Rows[1]["dest_airp"].ToString();
                Label12.Text = dt7.Rows[0]["dest_airp"].ToString();
                Label6.Text = dt7.Rows[0]["dept_time"].ToString();
                Label7.Text = dt7.Rows[1]["arr_time"].ToString();
                Label13.Text = aid1 + "," + aid2;

                Label17.Text = dt7.Rows[2]["src_airp"].ToString();
                Label18.Text = dt7.Rows[3]["dest_airp"].ToString();
                Label19.Text = dt7.Rows[2]["dest_airp"].ToString();
                Label20.Text = dt7.Rows[2]["dept_time"].ToString();
                Label21.Text = dt7.Rows[3]["arr_time"].ToString();
                Label22.Text = raid1 + "," + raid2;

            }

            if (type==1)
            {
                aid1 = (Session["depart_fid"].ToString()).Split(',')[0];
                raid1 = (Session["return_fid"].ToString()).Split(',')[0];
                raid2 = (Session["return_fid"].ToString()).Split(',')[1];

                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked+'" + adt + "' where fid='" + aid1 + "' and class='" + Convert.ToChar((Session["Class"].ToString()).FirstOrDefault()) + "' and bdate='" + Session["dt"] + "'", con);
                adp.UpdateCommand.ExecuteNonQuery();

                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked+'" + adt + "' where fid='" + raid1 + "' and class='" + Convert.ToChar((Session["Class"].ToString()).FirstOrDefault()) + "' and bdate='" + Session["rdt"] + "'", con);
                adp.UpdateCommand.ExecuteNonQuery();

                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked+'" + adt + "' where fid='" + raid2 + "' and class='" + Convert.ToChar((Session["Class"].ToString()).FirstOrDefault()) + "' and bdate='" + Session["rdt"] + "'", con);
                adp.UpdateCommand.ExecuteNonQuery();

                DataTable dt7 = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter("select src_airp,dest_airp,dept_time,arr_time from flights where fid='" + aid1 + "'", con);
                ad.Fill(dt7);

                ad.SelectCommand = new SqlCommand("select src_airp,dest_airp,dept_time,arr_time from flights where fid='" + raid1 + "'", con);
                ad.Fill(dt7);

                ad.SelectCommand = new SqlCommand("select src_airp,dest_airp,dept_time,arr_time from flights where fid='" + raid2 + "'", con);
                ad.Fill(dt7);

                Label4.Text = dt7.Rows[0]["src_airp"].ToString();
                Label5.Text = dt7.Rows[0]["dest_airp"].ToString();
                //Label12.Text = dt7.Rows[0]["dest_airp"].ToString();
                Label6.Text = dt7.Rows[0]["dept_time"].ToString();
                Label7.Text = dt7.Rows[0]["arr_time"].ToString();
                Label13.Text = aid1;

                Label17.Text = dt7.Rows[1]["src_airp"].ToString();
                Label18.Text = dt7.Rows[2]["dest_airp"].ToString();
                //Label19.Text = dt7.Rows[0]["dest_airp"].ToString();
                Label20.Text = dt7.Rows[1]["dept_time"].ToString();
                Label21.Text = dt7.Rows[2]["arr_time"].ToString();
                Label22.Text = raid1 + "," + raid2;
            }

            if(type==2)
            {

                aid1 = (Session["depart_fid"].ToString()).Split(',')[0];
                aid2 = (Session["depart_fid"].ToString()).Split(',')[1];
                raid1 = (Session["return_fid"].ToString()).Split(',')[0];

                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked+'" + adt + "' where fid='" + aid1 + "' and class='" + Convert.ToChar((Session["Class"].ToString()).FirstOrDefault()) + "' and bdate='" + Session["dt"] + "'", con);
                adp.UpdateCommand.ExecuteNonQuery();

                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked+'" + adt + "' where fid='" + aid2 + "' and class='" + Convert.ToChar((Session["Class"].ToString()).FirstOrDefault()) + "' and bdate='" + Session["dt"] + "'", con);
                adp.UpdateCommand.ExecuteNonQuery();

                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked+'" + adt + "' where fid='" + raid1 + "' and class='" + Convert.ToChar((Session["Class"].ToString()).FirstOrDefault()) + "' and bdate='" + Session["rdt"] + "'", con);
                adp.UpdateCommand.ExecuteNonQuery();

                DataTable dt7 = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter("select src_airp,dest_airp,dept_time,arr_time from flights where fid='" + aid1 + "'", con);
                ad.Fill(dt7);

                ad.SelectCommand = new SqlCommand("select src_airp,dest_airp,dept_time,arr_time from flights where fid='" + aid2 + "'", con);
                ad.Fill(dt7);

                ad.SelectCommand = new SqlCommand("select src_airp,dest_airp,dept_time,arr_time from flights where fid='" + raid1 + "'", con);
                ad.Fill(dt7);

                Label4.Text = dt7.Rows[0]["src_airp"].ToString();
                Label5.Text = dt7.Rows[1]["dest_airp"].ToString();
                Label12.Text = dt7.Rows[0]["dest_airp"].ToString();
                Label6.Text = dt7.Rows[0]["dept_time"].ToString();
                Label7.Text = dt7.Rows[1]["arr_time"].ToString();
                Label13.Text = aid1 + "," + aid2;

                Label17.Text = dt7.Rows[2]["src_airp"].ToString();
                Label18.Text = dt7.Rows[2]["dest_airp"].ToString();
                //Label19.Text = dt7.Rows[0]["dest_airp"].ToString();
                Label20.Text = dt7.Rows[2]["dept_time"].ToString();
                Label21.Text = dt7.Rows[2]["arr_time"].ToString();
                Label22.Text = raid1;



            }

            if(type==3)
            {
                aid1 = (Session["depart_fid"].ToString()).Split(',')[0];
                raid1 = (Session["return_fid"].ToString()).Split(',')[0];

                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked+'" + adt + "' where fid='" + aid1 + "' and class='" + Convert.ToChar((Session["Class"].ToString()).FirstOrDefault()) + "' and bdate='" + Session["dt"] + "'", con);
                adp.UpdateCommand.ExecuteNonQuery();

                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked+'" + adt + "' where fid='" + raid1 + "' and class='" + Convert.ToChar((Session["Class"].ToString()).FirstOrDefault()) + "' and bdate='" + Session["rdt"] + "'", con);
                adp.UpdateCommand.ExecuteNonQuery();

                DataTable dt7 = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter("select src_airp,dest_airp,dept_time,arr_time from flights where fid='" + aid1 + "'", con);
                ad.Fill(dt7);

                ad.SelectCommand = new SqlCommand("select src_airp,dest_airp,dept_time,arr_time from flights where fid='" + raid1 + "'", con);
                ad.Fill(dt7);

                Label4.Text = dt7.Rows[0]["src_airp"].ToString();
                Label5.Text = dt7.Rows[0]["dest_airp"].ToString();
                //Label12.Text = dt7.Rows[0]["dest_airp"].ToString();
                Label6.Text = dt7.Rows[0]["dept_time"].ToString();
                Label7.Text = dt7.Rows[0]["arr_time"].ToString();
                Label13.Text = aid1;

                Label17.Text = dt7.Rows[1]["src_airp"].ToString();
                Label18.Text = dt7.Rows[1]["dest_airp"].ToString();
                //Label19.Text = dt7.Rows[0]["dest_airp"].ToString();
                Label20.Text = dt7.Rows[1]["dept_time"].ToString();
                Label21.Text = dt7.Rows[1]["arr_time"].ToString();
                Label22.Text = raid1;


            }

            


            Label1.Text = Convert.ToString(bid);
            Label2.Text = Session["class"].ToString();
            Label3.Text = Session["dt"].ToString();

            
              
          
            Label15.Text = Session["class"].ToString();
            Label16.Text = Session["rdt"].ToString();

            Label26.Text = "₹"+Session["gprice"].ToString();
            Label24.Text = Session["e_luggage"].ToString() + " Kg";
            Label25.Text = Session["e_lug_price"].ToString() + " Kg";

            Label8.Text = Session["free_lug1"].ToString();
            Label23.Text = Session["free_lug2"].ToString();

            Image1.ImageUrl = "images/" + Convert.ToString(bid) + ".png";



        }
    }
}