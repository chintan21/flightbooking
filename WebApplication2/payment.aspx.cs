using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class payment : System.Web.UI.Page
    {
        Decimal bid;
        int gprice;
        String mno;

        protected void Page_Load(object sender, EventArgs e)
        {
            var queryStrings = (Request.QueryString.ToString());
            var a = queryStrings.Split('&');
            Label9.Text = HttpUtility.UrlDecode(a[0]);
            Label10.Text = "Date: " + HttpUtility.UrlDecode(a[1]);
            Label11.Text = "Flight ID:" + HttpUtility.UrlDecode(a[2]);
            mno = HttpUtility.UrlDecode(a[3]);
            Label12.Text = "Mobile no: " + HttpUtility.UrlDecode(a[3]);
            Label13.Text = "Email ID: " + Session["user"];
            Label14.Text = "Flight Fare:" + Session["price"]; 

            if(Session["e_luggage"]==null)
            {
                Label15.Text = "Extra Luggage Fair: 0";
            }
            else
            {
                Label15.Text = "Extra Luggage Fair: " + Convert.ToString((Convert.ToInt32(Session["e_luggage"]))*(Convert.ToInt32(Session["e_lug_price"])));
            }

           gprice= (Convert.ToInt32(Session["price"])) + ((Convert.ToInt32(Session["e_luggage"])) * (Convert.ToInt32(Session["e_lug_price"])));

            Label16.Text = "Grand Total: " + Convert.ToString(gprice); 

            GridView1.DataSource= (DataTable)Session["temp_adt"];
            GridView1.DataBind();

                GridView2.DataSource = (DataTable)Session["temp_cld"];
                GridView2.DataBind();

            DataTable dt1 = new DataTable();
            String constring = ConfigurationManager.ConnectionStrings["flight"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            con.Open();

            SqlDataAdapter adp = new SqlDataAdapter("select id from book_id", con);
            adp.Fill(dt1);

            bid = Convert.ToDecimal(dt1.Rows[0]["id"].ToString());



            adp.UpdateCommand = new SqlCommand("update book_id set id=@bid where id='" + bid + "'", con);
            adp.UpdateCommand.Parameters.Add("@bid", SqlDbType.Decimal).Value = bid+1;
            adp.UpdateCommand.ExecuteNonQuery();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String url = (String.Format("Final.aspx?{0}&{1}&{2}&{3}&{4}&{5}&{6}&{7}&{8}&{9}&{10}", HttpUtility.UrlEncode(Convert.ToString(bid)), HttpUtility.UrlEncode("Debitcard"), HttpUtility.UrlEncode(Label10.Text), HttpUtility.UrlEncode(Convert.ToString(gprice)), HttpUtility.UrlEncode(mno), HttpUtility.UrlEncode(Label11.Text), HttpUtility.UrlEncode(TextBox3.Text), HttpUtility.UrlEncode(TextBox5.Text), HttpUtility.UrlEncode(TextBox6.Text), HttpUtility.UrlEncode(DropDownList3.SelectedValue), HttpUtility.UrlEncode(DropDownList4.SelectedValue)));

            if (CheckBox2.Checked)
            {
                Response.Redirect(url);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have to accept T&C to make payment..!')", true);

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String url = (String.Format("Final.aspx?{0}&{1}&{2}&{3}&{4}&{5}&{6}&{7}&{8}&{9}&{10}", HttpUtility.UrlEncode(Convert.ToString(bid)), HttpUtility.UrlEncode("Creditcard"), HttpUtility.UrlEncode(Label10.Text), HttpUtility.UrlEncode(Convert.ToString(gprice)), HttpUtility.UrlEncode(mno), HttpUtility.UrlEncode(Label11.Text), HttpUtility.UrlEncode(TextBox1.Text), HttpUtility.UrlEncode(TextBox2.Text), HttpUtility.UrlEncode(TextBox4.Text), HttpUtility.UrlEncode(DropDownList1.SelectedValue), HttpUtility.UrlEncode(DropDownList2.SelectedValue)));

            if (CheckBox1.Checked)
            {
                Response.Redirect(url);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have to accept T&C to make payment..!')", true);

            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String url = (String.Format("Final.aspx?{0}&{1}&{2}&{3}&{4}&{5}", HttpUtility.UrlEncode(Convert.ToString(bid)), HttpUtility.UrlEncode("NetBanking"), HttpUtility.UrlEncode(Label10.Text), HttpUtility.UrlEncode(Convert.ToString(gprice)), HttpUtility.UrlEncode(mno), HttpUtility.UrlEncode(Label11.Text),HttpUtility.UrlEncode(RadioButtonList1.SelectedValue)));
            Response.Redirect(url);
        }
    }
}