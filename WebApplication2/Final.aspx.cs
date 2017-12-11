using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using GemBox.Document;

namespace WebApplication2
{
    public partial class Final : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string previousPage = HttpContext.Current.Request.UrlReferrer.AbsolutePath;



                String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                con.Open();

                DataTable dt1 = new DataTable();
                var queryStrings = (Request.QueryString.ToString());
                var a = queryStrings.Split('&');

                Decimal bid = Convert.ToDecimal(a[0]);



                SqlDataAdapter adp = new SqlDataAdapter();

                if (HttpUtility.UrlDecode(a[1]) == "NetBanking")
                {
                    Debug.WriteLine("Net Banking");
                    adp.InsertCommand = new SqlCommand("insert into book_payment(booking_id,email,mobileno,payment_mode,dc_card_no,price)values(@bid,@email,@mno,@pmode,null,@price)", con);
                    adp.InsertCommand.Parameters.Add("@bid", SqlDbType.Decimal).Value = Convert.ToDecimal(a[0]);
                    adp.InsertCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = Session["user"].ToString();
                    adp.InsertCommand.Parameters.Add("@mno", SqlDbType.Decimal).Value = Convert.ToDecimal(a[4]);
                    adp.InsertCommand.Parameters.Add("@pmode", SqlDbType.VarChar).Value = a[1].FirstOrDefault();

                    adp.InsertCommand.Parameters.Add("@price", SqlDbType.Int).Value = Convert.ToInt32(a[3]);

                    adp.InsertCommand.ExecuteNonQuery();
                }

                else
                {
                    adp.InsertCommand = new SqlCommand("insert into book_payment(booking_id,email,mobileno,payment_mode,dc_card_no,price)values(@bid,@email,@mno,@pmode,@dcno,@price)", con);

                    adp.InsertCommand.Parameters.Add("@bid", SqlDbType.Decimal).Value = Convert.ToDecimal(a[0]);
                    adp.InsertCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = Session["user"].ToString();
                    adp.InsertCommand.Parameters.Add("@mno", SqlDbType.Decimal).Value = Convert.ToDecimal(a[4]);
                    adp.InsertCommand.Parameters.Add("@pmode", SqlDbType.VarChar).Value = a[1].FirstOrDefault();
                    adp.InsertCommand.Parameters.Add("@dcno", SqlDbType.Decimal).Value = Convert.ToDecimal(a[7]);
                    adp.InsertCommand.Parameters.Add("@price", SqlDbType.Int).Value = Convert.ToInt32(a[3]);

                    adp.InsertCommand.ExecuteNonQuery();
                }

                DataTable dt5 = (DataTable)Session["temp_adt"];
                int adt = dt5.Rows.Count;



                for (int i = 0; i < adt; i++)
                {
                    adp.InsertCommand = new SqlCommand("insert into book_person(booking_id,sr_no,name,age,gender,proof_type,proof_no,child)values(@bkid,@sr,@name,@age,@gender,@proof,@pfno,@cld)", con);

                    adp.InsertCommand.Parameters.Add("@bkid", SqlDbType.Decimal).Value = Convert.ToDecimal(a[0]);
                    adp.InsertCommand.Parameters.Add("@sr", SqlDbType.Int).Value = i + 1;
                    adp.InsertCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = dt5.Rows[i]["Name"].ToString();
                    adp.InsertCommand.Parameters.Add("@age", SqlDbType.Int).Value = Convert.ToInt32(dt5.Rows[i]["Age"].ToString());
                    adp.InsertCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = dt5.Rows[i]["Gender"].ToString();
                    adp.InsertCommand.Parameters.Add("@proof", SqlDbType.VarChar).Value = dt5.Rows[i]["ID Card Type"].ToString();
                    adp.InsertCommand.Parameters.Add("@pfno", SqlDbType.Decimal).Value = dt5.Rows[i]["ID Card No."].ToString();
                    adp.InsertCommand.Parameters.Add("@cld", SqlDbType.Char).Value = 'N';

                    adp.InsertCommand.ExecuteNonQuery();

                }

                dt1.Reset();

                dt1 = (DataTable)Session["temp_cld"];
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

                String aid = ((HttpUtility.UrlDecode(a[5]).Split(':'))[1]);

                adp.InsertCommand = new SqlCommand("insert into book_air(booking_id,one_or_round,adults,child,one_aid,round_aid,one_E_lug,round_E_lug,dept_date,return_date,class)values(@bkid,@oor,@adt,@cld,@oaid,null,@oel,null,@dd,null,@cls)", con);

                adp.InsertCommand.Parameters.Add("@bkid", SqlDbType.Decimal).Value = Convert.ToDecimal(a[0]);
                adp.InsertCommand.Parameters.Add("@oor", SqlDbType.Char).Value = 'O';
                adp.InsertCommand.Parameters.Add("@adt", SqlDbType.Int).Value = adt;
                adp.InsertCommand.Parameters.Add("@cld", SqlDbType.Int).Value = cld;
                adp.InsertCommand.Parameters.Add("@oaid", SqlDbType.VarChar).Value = aid;
                // adp.InsertCommand.Parameters.Add("@raid", SqlDbType.VarChar).Value = null;
                adp.InsertCommand.Parameters.Add("@oel", SqlDbType.VarChar).Value = Session["e_luggage"];
                //adp.InsertCommand.Parameters.Add("@rel", SqlDbType.VarChar).Value = null;
                adp.InsertCommand.Parameters.Add("@dd", SqlDbType.VarChar).Value = ((HttpUtility.UrlDecode(a[2]).Split(':'))[1].Split(' '))[1];
                // adp.InsertCommand.Parameters.Add("@rd", SqlDbType.VarChar).Value = null;
                adp.InsertCommand.Parameters.Add("@cls", SqlDbType.Char).Value = Convert.ToChar((Session["Class"].ToString()).FirstOrDefault());

                adp.InsertCommand.ExecuteNonQuery();


                var b = aid.Split(',');

                String aid1 = b[0];
                String aid2 = null;

                int blen = b.Length;

                if (blen > 1)
                {
                    aid2 = b[1];
                    adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked+'" + adt + "' where fid='" + aid2 + "' and class='" + Convert.ToChar((Session["Class"].ToString()).FirstOrDefault()) + "' and bdate='" + ((HttpUtility.UrlDecode(a[2]).Split(':'))[1].Split(' '))[1] + "'", con);
                    adp.UpdateCommand.ExecuteNonQuery();
                }

                adp.UpdateCommand = new SqlCommand("update Seat_booked set booked=booked+'" + adt + "' where fid='" + aid1 + "' and class='" + Convert.ToChar((Session["Class"].ToString()).FirstOrDefault()) + "'and bdate='" + ((HttpUtility.UrlDecode(a[2]).Split(':'))[1].Split(' '))[1] + "'", con);
                adp.UpdateCommand.ExecuteNonQuery();


                if (File.Exists(Server.MapPath("Barcode.txt")))
                {
                    File.Delete(Server.MapPath("BarCode.txt"));
                }
                File.WriteAllText(Server.MapPath("BarCode.txt"), Convert.ToString(bid));
                Process.Start(Server.MapPath("BarCodeGenerate.exe"));


                MemoryStream mms = new MemoryStream();
                String src, dest, dept, arr;
                DataTable dt2 = new DataTable();

                if (blen > 1)
                {
                    adp.SelectCommand = new SqlCommand("select src_airp,dest_airp,arr_time,dept_time from flights where fid='" + aid2 + "'", con);
                    adp.Fill(dt2);

                    dest = dt2.Rows[0]["dest_airp"].ToString();
                    arr = dt2.Rows[0]["arr_time"].ToString();
                    Label12.Text = dt2.Rows[0]["src_airp"].ToString();
                    Label12.Visible = true;

                    dt2.Reset();

                    adp.SelectCommand = new SqlCommand("select src_airp,dest_airp,arr_time,dept_time from flights where fid='" + aid1 + "'", con);
                    adp.Fill(dt2);

                    src = dt2.Rows[0]["src_airp"].ToString();
                    dept = dt2.Rows[0]["dept_time"].ToString();

                    Label13.Text = aid1 + "," + aid2;
                }

                else
                {
                    adp.SelectCommand = new SqlCommand("select src_airp,dest_airp,arr_time,dept_time from flights where fid='" + aid1 + "'", con);
                    adp.Fill(dt2);

                    src = dt2.Rows[0]["src_airp"].ToString();
                    dept = dt2.Rows[0]["dept_time"].ToString();
                    dest = dt2.Rows[0]["dest_airp"].ToString();
                    arr = dt2.Rows[0]["arr_time"].ToString();
                    Label13.Text = aid1;
                }


                Label1.Text = Convert.ToString(bid);
                Label2.Text = Session["Class"].ToString();
                Label3.Text = ((HttpUtility.UrlDecode(a[2]).Split(':'))[1].Split(' '))[1];
                Label4.Text = src;
                Label5.Text = dest;
                Label6.Text = dept;
                Label7.Text = arr;
                Label8.Text = Session["d_lug"].ToString();
                Label9.Text = Session["e_luggage"].ToString();

                if (Session["e_luggage"].ToString() == "0")
                {
                    Label10.Text = "0";
                }
                else
                {
                    Label10.Text = Session["e_lug_price"].ToString();
                }

                Label11.Text = Session["gprice"].ToString();

                GridView1.DataSource = dt5;
                GridView1.DataBind();

                GridView2.DataSource = (DataTable)Session["temp_cld"];
                GridView2.DataBind();

            Image1.ImageUrl = "images/" + Convert.ToString(bid) + ".png";



            Page.Title = src + " to " + dest;

         
            
                 string body = string.Empty;
                 using (StreamReader reader = new StreamReader(Server.MapPath("~/mail.html")))
                 {
                     body = reader.ReadToEnd();
                 }
                 body = body.Replace("{UserName}",Session["user"].ToString());
            body = body.Replace("{0}", "Booking ID:" + Label1.Text);
            body = body.Replace("{1}", "Class:" + Label2.Text);
            body = body.Replace("{2}", "Date: " +(Convert.ToDateTime(Label3.Text)).ToString("dd.MM.yyyy"));
            body = body.Replace("{3}", "Source:" + Label4.Text);
            body = body.Replace("{4}", "Destination:" + Label5.Text);
            body = body.Replace("{5}",  Label12.Text);
            body = body.Replace("{6}", "Departure Time: " + Label6.Text);
            body = body.Replace("{7}", "Arrival Time:" + Label7.Text);
            body = body.Replace("{8}", "Flight ID:" + Label13.Text);
            body = body.Replace("{9}", "Free Luggage:" + Label8.Text);
            body = body.Replace("{10}", "             ");
            body = body.Replace("{11}", "Extra Luggage:" + Label9.Text);
            body = body.Replace("{12}", "             ");
            body = body.Replace("{13}", "Total Price:" +Label11.Text);
            body = body.Replace("{14}", "             ");


            int acount = GridView1.Rows.Count;

            if(acount>0)
            {
                body = body.Replace("{40}",GridView1.Rows[0].Cells[0].Text);
                body = body.Replace("{41}", GridView1.Rows[0].Cells[1].Text);
                body = body.Replace("{42}", GridView1.Rows[0].Cells[2].Text);
                body = body.Replace("{43}", GridView1.Rows[0].Cells[3].Text);
                body = body.Replace("{44}", GridView1.Rows[0].Cells[4].Text);

                if(acount>1)
                {
                    body = body.Replace("{45}", GridView1.Rows[1].Cells[0].Text);
                    body = body.Replace("{46}", GridView1.Rows[1].Cells[1].Text);
                    body = body.Replace("{47}", GridView1.Rows[1].Cells[2].Text);
                    body = body.Replace("{48}", GridView1.Rows[1].Cells[3].Text);
                    body = body.Replace("{49}", GridView1.Rows[1].Cells[4].Text);

                    if(acount>2)
                    {
                        body = body.Replace("{50}", GridView1.Rows[2].Cells[0].Text);
                        body = body.Replace("{51}", GridView1.Rows[2].Cells[1].Text);
                        body = body.Replace("{52}", GridView1.Rows[2].Cells[2].Text);
                        body = body.Replace("{53}", GridView1.Rows[2].Cells[3].Text);
                        body = body.Replace("{54}", GridView1.Rows[2].Cells[4].Text);

                        if(acount>3)
                        {
                            body = body.Replace("{15}", GridView1.Rows[3].Cells[0].Text);
                            body = body.Replace("{16}", GridView1.Rows[3].Cells[1].Text);
                            body = body.Replace("{17}", GridView1.Rows[3].Cells[2].Text);
                            body = body.Replace("{18}", GridView1.Rows[3].Cells[3].Text);
                            body = body.Replace("{19}", GridView1.Rows[3].Cells[4].Text);

                            if(acount>4)
                            {
                                body = body.Replace("{20}", GridView1.Rows[4].Cells[0].Text);
                                body = body.Replace("{21}", GridView1.Rows[4].Cells[1].Text);
                                body = body.Replace("{22}", GridView1.Rows[4].Cells[2].Text);
                                body = body.Replace("{23}", GridView1.Rows[4].Cells[3].Text);
                                body = body.Replace("{24}", GridView1.Rows[4].Cells[4].Text);

                                if(acount>5)
                                {
                                    body = body.Replace("{25}", GridView1.Rows[5].Cells[0].Text);
                                    body = body.Replace("{26}", GridView1.Rows[5].Cells[1].Text);
                                    body = body.Replace("{27}", GridView1.Rows[5].Cells[2].Text);
                                    body = body.Replace("{28}", GridView1.Rows[5].Cells[3].Text);
                                    body = body.Replace("{29}", GridView1.Rows[5].Cells[4].Text);
                                }
                            }

                        }
                    }
                }              
            }

            if(acount<6)
            {
                body = body.Replace("{25}", null);
                body = body.Replace("{26}", null);
                body = body.Replace("{27}",null);
                body = body.Replace("{28}", null);
                body = body.Replace("{29}", null);

                if(acount<5)
                {
                    body = body.Replace("{20}", null);
                    body = body.Replace("{21}", null);
                    body = body.Replace("{22}", null);
                    body = body.Replace("{23}", null);
                    body = body.Replace("{24}", null);

                    if(acount<4)
                    {
                        body = body.Replace("{15}", null);
                        body = body.Replace("{16}", null);
                        body = body.Replace("{17}", null);
                        body = body.Replace("{18}", null);
                        body = body.Replace("{19}", null);

                        if(acount<3)
                        {
                            body = body.Replace("{50}", null);
                            body = body.Replace("{51}", null);
                            body = body.Replace("{52}", null);
                            body = body.Replace("{53}", null);
                            body = body.Replace("{54}", null);

                            if(acount<2)
                            {
                                body = body.Replace("{45}", null);
                                body = body.Replace("{46}", null);
                                body = body.Replace("{47}", null);
                                body = body.Replace("{48}", null);
                                body = body.Replace("{49}", null);

                            }
                        }
                    }

                }
            }

            int acount1 = GridView2.Rows.Count;

            if(acount1==0)
            {
                body = body.Replace("{30}", null);
                body = body.Replace("{31}", null);
                body = body.Replace("{32}", null);
               
                body = body.Replace("{35}", null);
                body = body.Replace("{36}", null);
                body = body.Replace("{37}", null);
                body = body.Replace("{99}", null);

                body = body.Replace("{90}", null);
                body = body.Replace("{91}", null);
                body = body.Replace("{92}", null);
            }

            if (acount1==1)
            {
                body = body.Replace("{99}", "Child");
                body = body.Replace("{90}", "Name");
                body = body.Replace("{91}", "Age");
                body = body.Replace("{92}", "Gender");

                body = body.Replace("{30}", GridView2.Rows[0].Cells[0].Text);
                body = body.Replace("{31}", GridView2.Rows[0].Cells[1].Text);
                body = body.Replace("{32}", GridView2.Rows[0].Cells[2].Text);
               
                body = body.Replace("{35}", null);
                body = body.Replace("{36}", null);
                body = body.Replace("{37}", null);
              
            }

            if(acount1==2)
            {
                body = body.Replace("{99}", "Children");
                body = body.Replace("{90}", "Name");
                body = body.Replace("{91}", "Age");
                body = body.Replace("{92}", "Gender");

                body = body.Replace("{30}", GridView2.Rows[0].Cells[0].Text);
                body = body.Replace("{31}", GridView2.Rows[0].Cells[1].Text);
                body = body.Replace("{32}", GridView2.Rows[0].Cells[2].Text);
               
                body = body.Replace("{35}", GridView2.Rows[1].Cells[0].Text);
                body = body.Replace("{36}", GridView2.Rows[1].Cells[1].Text);
                body = body.Replace("{37}", GridView2.Rows[1].Cells[2].Text);
              
            }

            MailMessage mail = new MailMessage();
                 SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");


                 mail.From = new MailAddress("rohandhamecha45@gmail.com");
                 mail.To.Add(Session["user"].ToString());
                 mail.Subject = "UDAAN - Online Flight Booking";
                 mail.Body = body;
                 mail.IsBodyHtml = true;



                 SmtpServer.Port = 25;
                 SmtpServer.Credentials = new System.Net.NetworkCredential("rohandhamecha45@gmail.com", "24111974");
                 SmtpServer.EnableSsl = true;

                 SmtpServer.Send(mail);

        }

       
      
    }
}