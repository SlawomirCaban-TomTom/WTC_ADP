using System;
using System.Web.UI.WebControls;

namespace TomTom_Info_Page.WTC
{
    public partial class calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            string script = "javascript:passDateValue('" + Request.QueryString["ctlid"] + "','" + e.Day.Date.ToString("dd MMM yyyy") + "')";

            e.Cell.Text = "<a href=\"" + script + "\">" + e.Day.Date.Day.ToString() + "</a>";
        }
    }
}