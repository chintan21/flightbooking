using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {//add flights
            String a1 = TextBox1.Text;

            String a2 = DropDownList2.SelectedItem.ToString();
            String a3 = DropDownList3.SelectedItem.ToString();
            String a4 = DropDownList1.SelectedItem.ToString();
            String a5 = TextBox9.Text;
            String a6 = TextBox10.Text;

            //for seats table
            String a7 = DropDownList4.SelectedItem.ToString();
            String d8 = TextBox2.Text;
            String d9 = TextBox3.Text;

            int a8 = Convert.ToInt32(d8);
            int a9 = Convert.ToInt32(d9);

            String a17 = DropDownList5.SelectedItem.ToString();
            String d18 = TextBox8.Text;
            String d19 = TextBox11.Text;

            int a18 = Convert.ToInt32(d18);
            int a19 = Convert.ToInt32(d19);

            String d10 = TextBox14.Text;
            String d11 = TextBox12.Text;
            String d12 = TextBox13.Text;

            int a10 = Convert.ToInt32(d10);
            int a11 = Convert.ToInt32(d11);
            int a12 = Convert.ToInt32(d12);

            String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;

            SqlConnection con = new SqlConnection(constring);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("select fid from flights", con);
            adp.Fill(dt);
            int count = 0;
            for(int i=0;i<dt.Rows.Count;i++)
            {
                if((dt.Rows[i]["fid"].ToString())==a1)
                {
                    count++;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fid Already Existed..')", true);

                }
            }

            if (count == 0)
            {
                string ab1 = "insert into flights(fid,air_id,src_airp,dest_airp,dept_time,arr_time)values(@a1,@a2,@a3,@a4,@a5,@a6)";


                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ab1;

                cmd.Parameters.AddWithValue("@a1", a1);
                cmd.Parameters.AddWithValue("@a2", a2);
                cmd.Parameters.AddWithValue("@a3", a3);
                cmd.Parameters.AddWithValue("@a4", a4);
                cmd.Parameters.AddWithValue("@a5", a5);
                cmd.Parameters.AddWithValue("@a6", a6);

                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("insert into Seats(fid,seat_class,Tot_seat,Price,D_lug,E_lug,E_lug_price)values(@a1,@a7,@a8,@a9,@a10,@a11,@a12)", con);

                cmd2.Parameters.AddWithValue("@a1", a1);
                cmd2.Parameters.AddWithValue("@a7", a7.FirstOrDefault());
                cmd2.Parameters.AddWithValue("@a8", a8);
                cmd2.Parameters.AddWithValue("@a9", a9);
                cmd2.Parameters.AddWithValue("@a10", a10);
                cmd2.Parameters.AddWithValue("@a11", a11);
                cmd2.Parameters.AddWithValue("@a12", a12);

                cmd2.ExecuteNonQuery();


                SqlCommand cmd3 = new SqlCommand("insert into Seats(fid,seat_class,Tot_seat,Price,D_lug,E_lug,E_lug_price)values(@a1,@a17,@a18,@a19,@a10,@a11,@a12)", con);


                cmd3.Parameters.AddWithValue("@a1", a1);
                cmd3.Parameters.AddWithValue("@a17", a17.FirstOrDefault());
                cmd3.Parameters.AddWithValue("@a18", a18);
                cmd3.Parameters.AddWithValue("@a19", a19);
                cmd3.Parameters.AddWithValue("@a10", a10);
                cmd3.Parameters.AddWithValue("@a11", a11);
                cmd3.Parameters.AddWithValue("@a12", a12);

                cmd3.ExecuteNonQuery();


                con.Close();
                Response.Write("succesfully added to the database");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Succesfully added to the database..')", true);

            }
        }

        
    }
}