using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Npgsql;
using System.Data;

namespace TomTom_Info_Page.cpp
{
    public partial class rootmods_dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                fill_grid();
        }
        DataTable DataTabletemp = new DataTable();
        DataTable DataTabletemp1 = new DataTable();
        protected void fill_grid()
        {
            string query = string.Empty; string queryDataset = string.Empty;
            string arg1 = string.Empty;
             query = "select * FROM stats.rootmods" + arg1;
            //query = "select dataset,to_do,in_progress,tech_fallout,qa_fallout,success,cast(tech_fallout+qa_fallout as DOUBLE PRECISION) / cast(success+1 as DOUBLE PRECISION) * 100 as percent_of_fallout from (select dataset, count(*) filter (where status = 3) as to_do, count(*) filter (where status = 100) as in_progress, count(*) filter (where status in (600,610,700,1000,1010)) as tech_fallout, count(*) filter (where status in (1100)) as qa_fallout, count(*) filter (where status = 300) as success from transaction_db.transactions t where dataset in (select distinct dataset from transaction_db.transactions t where status < 2000) and status in (100,1000,1010,1100,3,300,600,610,700)group by dataset) counting order by dataset";
            //queryDataset = "select distinct dataset from transaction_db.transactions order by 1";
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["rootmods"].ConnectionString);
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn);
            //NpgsqlDataAdapter sda1 = new NpgsqlDataAdapter(queryDataset, conn);

            
            try
            {
                conn.Open();
                sda.Fill(DataTabletemp);
                //sda1.Fill(DataTabletemp1);
                conn.Close();
                conn.Dispose();
                dgDashboard.DataSource = DataTabletemp;
                Session["dgDashboard_Ses"] = DataTabletemp;
                dgDashboard.DataBind();
                 //Session["ddDataset_Ses"] = DataTabletemp1;
                //if (!IsPostBack) ddDataset.DataBind();
            }
            catch (Exception ex)
            {
                lbl_err.ForeColor = System.Drawing.Color.Red;
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString();
            }
        }

        protected void ddDataset_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fill_grid();
        }

        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        private void SortGridView(string sortExpression, string direction)
        {
            //  You can cache the DataTable for improving performance
            DataTable dt = Session["dgDashboard_Ses"] as DataTable;

            DataView dv = new DataView(dt);
            dv.Sort = sortExpression + direction;
            dgDashboard.DataSource = dv;
            dgDashboard.DataBind();
        }
        protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;

            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                SortGridView(sortExpression, DESCENDING);
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                SortGridView(sortExpression, ASCENDING);
            }

        }


    }
}