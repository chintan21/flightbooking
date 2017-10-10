using System;
using System.Diagnostics;
using System.Globalization;
using System.Web.UI;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox5.Visible = false;
                ImageButton4.Visible = false;
                Calendar1.Visible = false;
                Calendar4.Visible = false;
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
            String rdt = TextBox5.Text;

            if (RadioButtonList1.SelectedIndex.ToString() == "0")
            {

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
            if(RadioButtonList1.SelectedIndex.ToString()=="1")
            {
                Debug.WriteLine("Round Trip selected");
                if ((Calendar1.SelectedDate > System.DateTime.Today) && (Calendar1.SelectedDate < System.DateTime.Today.AddDays(300)) && (Calendar4.SelectedDate > System.DateTime.Today) && (Calendar4.SelectedDate < System.DateTime.Today.AddDays(300)))
                {
                    if (src != dest)
                    {
                        String url = (String.Format("search_round.aspx?{0}&{1}&{2}&{3}&{4}&{5}&{6}", src, dest, dt, DropDownList3.SelectedValue, DropDownList1.SelectedValue, DropDownList2.SelectedValue, rdt));
                        Response.Redirect(url);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Entered date is invalid!!')", true);

                }
            }
        }
    

        protected void Button2_Click(object sender, EventArgs e)
        {
           

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

        protected void Calendar4_SelectionChanged(object sender, EventArgs e)
        {
            TextBox5.Text = Calendar4.SelectedDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            Calendar4.Visible = false;
        }

        protected void ImageButton4_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (Calendar4.Visible)
            {
                Calendar4.Visible = false;
            }
            else
            {
                Calendar4.Visible = true;
            }
        }

        


        protected void Calendar1_SelectionChanged(object sender, EventArgs e)

        {
            TextBox1.Text = Calendar1.SelectedDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            Calendar1.Visible = false;
        }



        protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 1)
            {
                TextBox5.Visible = true;
                ImageButton4.Visible = true;

            }
            if (RadioButtonList1.SelectedIndex == 0)
            {
                TextBox5.Visible = false;
                ImageButton4.Visible = false;
            }
        }
    }
}