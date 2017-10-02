using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var queryStrings = (Request.QueryString.ToString());
            var a = queryStrings.Split('?');
            Label9.Text = HttpUtility.UrlDecode(a[0]);
            

            GridView1.DataSource= (DataTable)Session["temp_adt"];
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Final.aspx");
        }
    }
}