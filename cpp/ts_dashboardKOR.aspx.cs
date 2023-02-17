using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Npgsql;

namespace TomTom_Info_Page.cpp
{
    public partial class ts_dashboardKOR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fill_grid();
        }
        DataTable DataTabletemp = new DataTable();
        DataTable DataTabletemp1 = new DataTable();
        protected void fill_grid()
        {
            string query = "select * from transactions.ts_dashboard_aws order by 4 desc";
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["trafficsignsfusionawsKOR"].ConnectionString);
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn);
           

            try
            {
                conn.Open();
                sda.Fill(DataTabletemp);
               conn.Close();
                conn.Dispose();
                dgDashboard.DataSource = DataTabletemp;
                Session["dgDashboard_Ses"] = DataTabletemp;
                dgDashboard.DataBind();
               
            }
            catch (Exception ex)
            {
                lbl_err.ForeColor = System.Drawing.Color.Red;
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString();
            }
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