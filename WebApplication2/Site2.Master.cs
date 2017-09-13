using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0)
            {
                var queryStrings = (Request.QueryString.ToString());
                var arrQueryStrings = queryStrings.Split('=');
                String user = arrQueryStrings[1];
                string[] stringSeparators = new string[] { "%" };
                var result = user.Split(stringSeparators, StringSplitOptions.None);
                Label2.Text = result[0];
               
            }
        }
    }
}