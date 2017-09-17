using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication2
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            for(int i=1;i<5;i++)
            {
                Panel pl = new Panel();
                Panel1.Controls.Add(pl);
                
                Label lb1 = new Label();
                lb1.Text = "Label ";
                pl.Controls.Add(lb1);

                Label lb2 = new Label();
                lb2.Text = "Label ";
                pl.Controls.Add(lb2);

                Label lb3 = new Label();
                lb3.Text = "Label " ;
                pl.Controls.Add(lb3);

                Label lb4 = new Label();
                lb4.Text = "Label " ;
                pl.Controls.Add(lb4);

                Label lb5 = new Label();
                lb5.Text = "Label " ;
                pl.Controls.Add(lb5);

                Label lbl6 = new Label();
                lbl6.Text = "Label " ;
                pl.Controls.Add(lbl6);
            }
            for (int i = 1; i < 5; i++)
            {
                Panel pl = new Panel();
                Panel1.Controls.Add(pl);

                Label lb1 = new Label();
                lb1.Text = "Label ";
                pl.Controls.Add(lb1);

                Label lb2 = new Label();
                lb2.Text = "Label ";
                pl.Controls.Add(lb2);

                Label lb3 = new Label();
                lb3.Text = "Label ";
                pl.Controls.Add(lb3);

                Label lb4 = new Label();
                lb4.Text = "Label ";
                pl.Controls.Add(lb4);

                Label lb5 = new Label();
                lb5.Text = "Label ";
                pl.Controls.Add(lb5);
                Label lb6 = new Label();
                lb6.Text = "Label ";
                pl.Controls.Add(lb6);

                Label lb7 = new Label();
                lb7.Text = "Label ";
                pl.Controls.Add(lb7);

                Label lbl8 = new Label();
                lbl8.Text = "Label ";
                pl.Controls.Add(lbl8);
            }

        }
    }
}