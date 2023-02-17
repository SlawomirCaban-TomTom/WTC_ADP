using System;


namespace TomTom_Info_Page
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl2.Text = User.Identity.Name;
        }
    }
}