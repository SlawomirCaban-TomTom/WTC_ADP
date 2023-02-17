using System;
using System.Configuration;
using System.Data.SqlClient;

namespace TomTom_Info_Page.TEAMS
{
    public partial class teams_content2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "select team_name from teams where team_id =" + Request.QueryString["team_id"];
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                //da.FillSchema(ds, SchemaType.Source, "project_types_id");
                Label1.Text = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Teams/TEAMS_content.aspx");
        }
    }
}
