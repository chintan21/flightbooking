using System;
using System.Diagnostics;


namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Calendar1.Visible = false;
            }
        }

        protected void OnewaySearch_Click(object sender, EventArgs e)
        {
            
            String src = DropDownList7.SelectedValue;
            String dest = DropDownList8.SelectedValue;
            String dt = TextBox1.Text;

            if(src!=dest)
            { 
            Debug.WriteLine("in if statement");
            String url = (String.Format("search.aspx?{0}&{1}&{2}", src, dest,dt));
            Response.Redirect(url);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String src = DropDownList9.SelectedValue;
            String dest = DropDownList10.SelectedValue;
            if (src != dest) { 
            Debug.WriteLine("in if statement");
            String url = (String.Format("search.aspx?{0}&{1}", src, dest));
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
    }
}