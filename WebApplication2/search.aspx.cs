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
                DataTable dt = new DataTable();   //Direct flight
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();
                DataTable dt6 = new DataTable();
               

                dt4.Columns.Add("fid");
                dt4.Columns.Add("air_id");
                dt4.Columns.Add("src_airp");
               
                dt4.Columns.Add("dest_airp");
                dt4.Columns.Add("dept_time");
                dt4.Columns.Add("arr_time");
                
                dt5.Columns.Add("fid");
                dt5.Columns.Add("air_id");
                dt5.Columns.Add("src_airp");
               
                dt5.Columns.Add("dest_airp");
                dt5.Columns.Add("dept_time");
                dt5.Columns.Add("arr_time");

               

               

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
                SqlDataAdapter adp2 = new SqlDataAdapter("select * from flights where src_airp='" + src + "' and dest_airp='" + dest + "' ", con);
                adp2.Fill(dt);
                String mid;
                int count = 0;
                dt4.Reset();
           

                for (int i = 0; i < dt6.Rows.Count; i++)
                {
                   
                        mid = (dt6.Rows[i]["airport"]).ToString();

                        adp.SelectCommand = new SqlCommand("select * from flights where src_airp='" + src + "' and dest_airp='" + mid + "'", con);
                        adp.Fill(dt2);
                        adp.SelectCommand = new SqlCommand("select * from flights where src_airp='" + mid + "' and dest_airp='" + dest + "'", con);
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
                                DateTime time1 = Convert.ToDateTime(dt2.Rows[a]["arr_time"].ToString());
                                DateTime time2 = Convert.ToDateTime(dt3.Rows[b]["dept_time"].ToString());

                                int result = DateTime.Compare(time1, time2);

                                

                                if (result < 0)
                                {
                                    dt2.AcceptChanges();

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
                        Debug.WriteLine(dr["fid"]);
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

    }

    }


