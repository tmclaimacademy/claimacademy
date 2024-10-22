using System;
using System.Web;
using System.Web.UI;

namespace SimpleWebFormsApp
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = int.Parse(Request.QueryString["userId"]);

        }
    }
}
