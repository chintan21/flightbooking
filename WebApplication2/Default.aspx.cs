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
        

        Debug.WriteLine(TextBox1.Text);
            Debug.WriteLine(TextBox2.Text);
            Debug.WriteLine(TextBox3.Text);


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(TextBox4.Text);
            Debug.WriteLine(TextBox5.Text);
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}