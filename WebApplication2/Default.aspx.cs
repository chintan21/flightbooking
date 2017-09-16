using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }



        protected void Button1_Click(object sender, EventArgs e)
        {



           String src= DropDownList7.SelectedValue;
           String dest = DropDownList8.SelectedValue;
           String url = (String.Format("search.aspx?{0}&{1}", src, dest));
           Response.Redirect(url);
        
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
        }

        protected void TextBox15_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}