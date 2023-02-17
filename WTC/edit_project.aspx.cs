using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace TomTom_Info_Page.WTC
{
    public partial class edit_project : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fill_pu();
                fill_grid();
            }
        }
        protected void fill_grid()
        {
            string query = "select * from (select project_id,project_name,pu from project p join pus m on p.pu_id = m.pu_id  ) a where a.project_id>0 ";
            if (ddl_pu.SelectedIndex > 0)
                query = query + " and pu='" + ddl_pu.SelectedItem.Text + "'";
            query = query + " order by project_name";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString() + " " + query;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            if (dt.Rows.Count > 0)
            {
                gv.DataSource = dt;
                gv.Visible = true;
                gv.DataBind();
                lbl_status.Text = "Rows selected: " + dt.Rows.Count;
            }
            else
            {
                gv.Visible = false;
                lbl_status.Text = "No data";
            }
        }
        protected void fill_pu()
        {
            string query = "select pu_id, pu from pus";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString() + " " + query;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            ddl_pu.DataSource = dt;
            ddl_pu.DataValueField = "pu_id";
            ddl_pu.DataTextField = "pu";
            ddl_pu.DataBind();
            ddl_pu.Items.Insert(0, "-- SELECT --");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/wtc/project.aspx");
        }

        protected void ddl_pu_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_grid();
        }

        protected void ddl_state_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_grid();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Server.Transfer("~/WTC/edit_project.aspx");
        }
    }
}