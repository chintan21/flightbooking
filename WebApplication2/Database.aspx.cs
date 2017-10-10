using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Database : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            String fid = GridView1.Rows[index].Cells[1].Text.ToString();

            String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Seats where fid='"+fid+"'", con);
            
            cmd.ExecuteNonQuery();
            con.Close();


        }
    }
}