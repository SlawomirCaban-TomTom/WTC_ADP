using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using Npgsql;
using System.Web.UI.WebControls;

namespace TomTom_Info_Page.cpp
{
    public partial class cc_readonly : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                load_gv();
        }
        protected void load_gv()
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["tool_import"].ConnectionString);
            DataTable temp = new DataTable();
            string query = "SELECT distinct tool_name \"Tool Name\",priority \"Priority\" from committer_config_rprod_cpp_r2.tool_config where destination='PROCESSING' order by priority,tool_name asc";
            NpgsqlDataAdapter cmd = new NpgsqlDataAdapter(query, conn);
            DataTable results = new DataTable();
            try
            {
                conn.Open();
                cmd.Fill(results);
                conn.Close();
                conn.Dispose();

                gv_results.DataSource = results;
                gv_results.DataBind();
            }
            catch (Exception ex)
            {
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString();
            }
        }
    }
}