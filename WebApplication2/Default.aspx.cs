using System;
using System.Diagnostics;


namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void OnewaySearch_Click(object sender, EventArgs e)
        {
            
            String src = DropDownList7.SelectedValue;
            String dest = DropDownList8.SelectedValue;
            if(src!=dest)
            { 
            Debug.WriteLine("in if statement");
            String url = (String.Format("search.aspx?{0}&{1}", src, dest));
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


    }
}