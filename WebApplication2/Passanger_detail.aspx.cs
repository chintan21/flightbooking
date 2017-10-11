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
        int adt;
        int cld;
        int e1;
        int e2;
        int ep1;
        int ep2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"]==null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('MUST LOGIN BEFORE BOOKING..!!')", true);
                Response.Redirect("Default.aspx");
            }

            var queryStrings = (Request.QueryString.ToString());
            var a = queryStrings.Split('&');
            String id = HttpUtility.UrlDecode(a[0]);
            String src = HttpUtility.UrlDecode(a[1]);
            String dest = HttpUtility.UrlDecode(a[2]);
            String dt = HttpUtility.UrlDecode(a[3]);
            adt = Convert.ToInt32(HttpUtility.UrlDecode(a[4]));
            cld = Convert.ToInt32(HttpUtility.UrlDecode(a[5]));
            String cls = HttpUtility.UrlDecode(a[6]);
            inter = Convert.ToBoolean(HttpUtility.UrlDecode(a[7]));
            String id1 = "0";

            Session["Class"] = cls;

            String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();

            if (Session["user"] != null)
            {
                String user = Session["user"].ToString();
                String user1 = "I am" + user;
                Debug.WriteLine(user1);
                SqlDataAdapter adp3 = new SqlDataAdapter("select mobileno from signup where email='" + user + "' ", con);
                adp3.Fill(dt2);
                TextBox23.Text = dt2.Rows[0]["mobileno"].ToString();
                dt2.Reset();
            }


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
                adp1.SelectCommand = new SqlCommand("select price,e_lug,e_lug_price from Seats where fid='" + id + "' and seat_class='" + cls.FirstOrDefault() + "'", con);
                adp1.Fill(dt2);

                int prc = Convert.ToInt32(dt2.Rows[0]["price"].ToString());
                e1 = Convert.ToInt32(dt2.Rows[0]["e_lug"].ToString());
                ep1 = Convert.ToInt32(dt2.Rows[0]["e_lug_price"].ToString());
                Label14.Text = Convert.ToString(prc * adt);
                dt2.Reset();
            }

            else
            {
                id1 = HttpUtility.UrlDecode(a[8]);
                String mid = HttpUtility.UrlDecode(a[9]);
                way = src + " to " + dest + " via " + mid;
                Label2.Text = way;
                Label4.Text = id + "," + id1;
                SqlDataAdapter adp1 = new SqlDataAdapter("select dept_time from flights where fid='" + id + "'", con);
                adp1.Fill(dt2);
                Label10.Text = dt2.Rows[0]["dept_time"].ToString();
                dt2.Reset();
                adp1.SelectCommand = new SqlCommand("select arr_time from flights where fid='" + id1 + "'", con);
                adp1.Fill(dt2);
                Label12.Text = dt2.Rows[0]["arr_time"].ToString();
                dt2.Reset();
                adp1.SelectCommand = new SqlCommand("select price,e_lug,e_lug_price from Seats where fid='" + id + "' and seat_class='" + cls.FirstOrDefault() + "'", con);
                adp1.Fill(dt2);
                adp1.SelectCommand = new SqlCommand("select price,e_lug,e_lug_price from Seats where fid='" + id1 + "' and seat_class='" + cls.FirstOrDefault() + "'", con);
                adp1.Fill(dt3);
                int prc = Convert.ToInt32(((Convert.ToInt32(dt2.Rows[0]["price"].ToString()) + (Convert.ToInt32(dt3.Rows[0]["price"].ToString())))) * 0.6);
                e1 = Convert.ToInt32(dt2.Rows[0]["e_lug"].ToString());
                e2 = Convert.ToInt32(dt3.Rows[0]["e_lug"].ToString());
                ep1 = Convert.ToInt32(dt2.Rows[0]["e_lug_price"].ToString());
                ep2 = Convert.ToInt32(dt3.Rows[0]["e_lug_price"].ToString());
                Label14.Text = Convert.ToString(prc * adt);
                dt2.Reset();
                dt3.Reset();
            }
            if (inter == false)
            {
                Label21.Text = Convert.ToString(ep1);
                Label22.Text = Convert.ToString(e1 * adt) + " kg";

            }
            else
            {
                if (e1 <= e2)
                {
                    Label22.Text = Convert.ToString(e1 * adt) + " kg";

                }
                else
                {
                    Label22.Text = Convert.ToString(e2 * adt) + " kg";
                }
                Label21.Text = Convert.ToString((ep1 + ep2) * 0.6);

            }

            if (adt < 6)
            {
                a6.Visible = false;
                TextBox16.Enabled = false;
                TextBox17.Enabled = false;
                TextBox18.Enabled = false;
                DropDownList11.Enabled = false;
                DropDownList12.Enabled = false;

                if (adt < 5)
                {
                    a5.Visible = false;
                    TextBox13.Enabled = false;
                    TextBox14.Enabled = false;
                    TextBox15.Enabled = false;
                    DropDownList9.Enabled = false;
                    DropDownList10.Enabled = false;

                    if (adt < 4)
                    {
                        a4.Visible = false;
                        TextBox10.Enabled = false;
                        TextBox11.Enabled = false;
                        TextBox12.Enabled = false;
                        DropDownList7.Enabled = false;
                        DropDownList8.Enabled = false;

                        if (adt < 3)
                        {
                            a3.Visible = false;
                            TextBox7.Enabled = false;
                            TextBox8.Enabled = false;
                            TextBox9.Enabled = false;
                            DropDownList5.Enabled = false;
                            DropDownList6.Enabled = false;

                            if (adt < 2)
                            {
                                a2.Visible = false;
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

            if (cld < 2)
            {
                c2.Visible = false;
                TextBox21.Enabled = false;
                TextBox22.Enabled = false;
                DropDownList14.Enabled = false;

                if (cld < 1)
                {
                    tchild.Visible = false;
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
                    Session["d_lug"] = Label20.Text;
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

            if (inter == true)
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

                Label20.Text = Convert.ToString(lug1 * adt) + " Kg, " + Convert.ToString(lug2 * adt) + " Kg";
                Session["d_lug"] = Label20.Text;
                dt2.Reset();
                dt3.Reset();

                adp.SelectCommand = new SqlCommand("select booked from Seat_booked where fid='" + id + "' and class='" + cls1 + "' and bdate='" + dt + "'", con);
                adp.Fill(dt2);



                adp1.SelectCommand = new SqlCommand("select booked from Seat_booked where fid='" + id1 + "' and class='" + cls1 + "' and bdate='" + dt + "'", con);
                adp1.Fill(dt3);





                if (dt2.Rows.Count > 0 && dt3.Rows.Count > 0)
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
                else if (dt2.Rows.Count > 0)
                {
                    int bk1 = Convert.ToInt32(dt2.Rows[0]["booked"].ToString());

                    if (tot2 > (tot1 - bk1))
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
                else if (dt3.Rows.Count > 0)
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

            Debug.WriteLine(Session["user"]);
            

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
            row[0] = TextBox1.Text;
            row[1] = TextBox2.Text;
            row[2] = DropDownList1.SelectedValue;
            row[3] = DropDownList2.SelectedValue;
            row[4] = TextBox3.Text;

            dt.Rows.Add(row);


            if (adt > 1)
            {
                DataRow row1 = dt.NewRow();
                row1[0] = TextBox4.Text;
                row1[1] = TextBox5.Text;
                row1[2] = DropDownList3.SelectedValue;
                row1[3] = DropDownList4.SelectedValue;
                row1[4] = TextBox6.Text;

                dt.Rows.Add(row1);

                if (adt > 2)
                {
                    DataRow row2 = dt.NewRow();
                    row2[0] = TextBox7.Text;
                    row2[1] = TextBox8.Text;
                    row2[2] = DropDownList5.SelectedValue;
                    row2[3] = DropDownList6.SelectedValue;
                    row2[4] = TextBox9.Text;

                    dt.Rows.Add(row2);


                    if (adt > 3)
                    {
                        DataRow row3 = dt.NewRow();
                        row3[0] = TextBox10.Text;
                        row3[1] = TextBox11.Text;
                        row3[2] = DropDownList7.SelectedValue;
                        row3[3] = DropDownList8.SelectedValue;
                        row3[4] = TextBox12.Text;

                        dt.Rows.Add(row3);

                        if (adt > 4)
                        {
                            DataRow row4 = dt.NewRow();
                            row4[0] = TextBox13.Text;
                            row4[1] = TextBox14.Text;
                            row4[2] = DropDownList9.SelectedValue;
                            row4[3] = DropDownList10.SelectedValue;
                            row4[4] = TextBox15.Text;

                            dt.Rows.Add(row4);

                            if (adt > 5)
                            {
                                DataRow row5 = dt.NewRow();
                                row5[0] = TextBox16.Text;
                                row5[1] = TextBox17.Text;
                                row5[2] = DropDownList11.SelectedValue;
                                row5[3] = DropDownList12.SelectedValue;
                                row5[4] = TextBox18.Text;

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
                row[0] = TextBox19.Text;
                row[1] = TextBox20.Text;
                row[2] = DropDownList13.SelectedValue;
                dt1.Rows.Add(row);
                if (cld > 1)
                {
                    DataRow row1 = dt1.NewRow();

                    row1[0] = TextBox21.Text;
                    row1[1] = TextBox22.Text;
                    row1[2] = DropDownList14.SelectedValue;
                    dt1.Rows.Add(row1);
                }
            }

            Session["price"] = Label14.Text;
            Session["temp_adt"] = dt;
            Session["temp_cld"] = dt1;
            Session["e_luggage"] = TextBox24.Text;
            Session["e_lug_price"] = Label21.Text;
            


            bool isHuman = example.Validate(txtCaptcha.Text);
             txtCaptcha.Text = null;
             if (!isHuman)
             {
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Incorrect Captcha')", true);

             }
             else
             {
                String url = (String.Format("Payment.aspx?{0}&{1}&{2}&{3}", HttpUtility.UrlEncode(Label2.Text),HttpUtility.UrlEncode(Label16.Text),HttpUtility.UrlEncode(Label4.Text),HttpUtility.UrlEncode(TextBox23.Text)));
                Response.Redirect(url);
             }
             

        }

        protected void TextBox24_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextBox24.Text))
            {
                TextBox24.Text = "0";
            }     
          
        }
    }
}