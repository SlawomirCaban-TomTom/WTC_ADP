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
    public partial class ts_dashboard_oce : System.Web.UI.Page
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
            if (ddDataset.SelectedIndex > 0) { arg1 = " where dataset='" + ddDataset.SelectedValue + "'"; }
            query = "select * from transaction_db.ts_dashboard" + arg1;
            queryDataset = "select distinct dataset from transaction_db.transaction_metadata order by 1";
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["trafficsignsfusionoce"].ConnectionString);
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn);
            NpgsqlDataAdapter sda1 = new NpgsqlDataAdapter(queryDataset, conn);


            try
            {
                conn.Open();
                sda.Fill(DataTabletemp);
                sda1.Fill(DataTabletemp1);
                conn.Close();
                conn.Dispose();
                dgDashboard.DataSource = DataTabletemp;
                Session["dgDashboard_Ses"] = DataTabletemp;
                dgDashboard.DataBind();
                ddDataset.DataSource = DataTabletemp1;
                ddDataset.DataTextField = "dataset";
                ddDataset.DataValueField = "dataset";
                ddDataset.Dispose();
                //Session["ddDataset_Ses"] = DataTabletemp1;
                if (!IsPostBack) ddDataset.DataBind();
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