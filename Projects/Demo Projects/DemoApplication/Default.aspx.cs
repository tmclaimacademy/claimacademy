using System;
using System.Web.UI;

namespace SimpleWebFormsApp
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // This runs every time the page is loaded or refreshed.
        }

        protected void ButtonClickMe_Click(object sender, EventArgs e)
        {
            // This runs when the button is clicked.
            LabelMessage.Text = "Hello, you've clicked the button!";
        }
    }
}
