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
        {/*
            String a1 = TextBox1.Text;
            String a2 = DropDownList2.SelectedItem.ToString();
            String a3 = DropDownList3.SelectedItem.ToString();
            String a4 = TextBox2.Text;
            String a5 = TextBox3.Text;

            String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;

            SqlConnection con = new SqlConnection(constring);
            con.Open();

            string ab1 = "insert into flights(fid,air_id,src_airp,dest_airp,dept_time,arr_time)values(@a1,@a2,@a3,@a4,@a5)";

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ab1;

            cmd.Parameters.AddWithValue("@a1", a1);
            cmd.Parameters.AddWithValue("@a2", a2);
            cmd.Parameters.AddWithValue("@a3", a3);
            cmd.Parameters.AddWithValue("@a4", a4);
            cmd.Parameters.AddWithValue("@a5", a5);
            cmd.Parameters.AddWithValue("@a1", a1);

            cmd.ExecuteNonQuery();
            */
        }
    }
}