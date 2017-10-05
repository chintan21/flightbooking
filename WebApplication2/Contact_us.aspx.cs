using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WebApplication2
{
    public partial class Contact_us : System.Web.UI.Page
    {
        public static List<String> CountryList()
        {
            List<String> ClutureList = new List<string>();
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            
            foreach (CultureInfo getCulture in getCultureInfo)
            {
                RegionInfo GetRegionInfo = new RegionInfo(getCulture.LCID);
                if (!(ClutureList.Contains(GetRegionInfo.EnglishName)))
                {
                    ClutureList.Add(GetRegionInfo.EnglishName);
                }
            }

            ClutureList.Sort();

            return ClutureList;
        }

    


        protected void Page_Load(object sender, EventArgs e)
        {


            DropDownList1.DataSource = CountryList();
            DropDownList1.DataBind();

            if(Session["user"]!=null)
            {
                String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                DataTable dt2 = new DataTable();

                String user = Session["user"].ToString();
              
               
                SqlDataAdapter adp3 = new SqlDataAdapter("select mobileno from signup where email='" + user + "' ", con);
                adp3.Fill(dt2);
                TextBox3.Text = user;
                TextBox2.Text = dt2.Rows[0]["mobileno"].ToString();
                dt2.Reset();
            }
        }    

        protected void Button1_Click(object sender, EventArgs e)
        {
            String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            con.Open();

            SqlDataAdapter adp = new SqlDataAdapter();
            adp.InsertCommand=new SqlCommand("insert into Contact_us(email,description,mobileno,name,Country)values(@email,@descn,@mno,@name,@cny)", con);

            adp.InsertCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = TextBox1.Text;
            adp.InsertCommand.Parameters.Add("@mno", SqlDbType.Decimal).Value = Convert.ToDecimal(TextBox2.Text);
            adp.InsertCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = TextBox3.Text;
            adp.InsertCommand.Parameters.Add("@cny", SqlDbType.VarChar).Value = DropDownList1.SelectedValue;
            adp.InsertCommand.Parameters.Add("@descn",SqlDbType.VarChar).Value = TextBox5.Text;

            adp.InsertCommand.ExecuteNonQuery();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('We will contact you soon..!')", true);

        }
    }
}