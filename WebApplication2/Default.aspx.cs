using System;
using System.Diagnostics;
using System.Web.UI;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
            }

            if (Page.PreviousPage != null)
            {
                var queryStrings = (Request.QueryString.ToString());
                var a = queryStrings.Split('&');

                DropDownList7.ClearSelection();
                DropDownList8.ClearSelection();
            }

        }

        protected void OnewaySearch_Click(object sender, EventArgs e)
        {

            String src = DropDownList7.SelectedValue;
            String dest = DropDownList8.SelectedValue;
            String dt = TextBox1.Text;








            if ((Calendar1.SelectedDate > System.DateTime.Today) && (Calendar1.SelectedDate < System.DateTime.Today.AddDays(300)))
            {

                if (src != dest)
                {
                    Debug.WriteLine("in if statement");
                    String url = (String.Format("search.aspx?{0}&{1}&{2}&{3}&{4}&{5}", src, dest, dt, DropDownList3.SelectedValue, DropDownList1.SelectedValue, DropDownList2.SelectedValue));
                    Response.Redirect(url);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Entered date is invalid!!')", true);

            }
        }
    
        protected void Button2_Click(object sender, EventArgs e)
        {
            String src = DropDownList9.SelectedValue;
            String dest = DropDownList10.SelectedValue;
            if (src != dest) { 
            Debug.WriteLine("in if statement");
            String url = (String.Format("search.aspx?{0}&{1}&{2}&{3}&{4}&{5}&{6}", src, dest));
            Response.Redirect(url);
            }
        }

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }

        protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (Calendar2.Visible)
            {
                Calendar2.Visible = false;
            }
            else
            {
                Calendar2.Visible = true;
            }
        }
        
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            TextBox2.Text = Calendar2.SelectedDate.ToShortDateString();
            Calendar2.Visible = false;
        }
        protected void ImageButton3_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (Calendar3.Visible)
            {
                Calendar3.Visible = false;
            }
            else
            {
                Calendar3.Visible = true;
            }
        }

        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {
            TextBox4.Text = Calendar3.SelectedDate.ToShortDateString();
            Calendar3.Visible = false;
        }
    }
}