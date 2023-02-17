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
    public partial class caj_dashboard_new : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fill_grid();
        }

        protected void gvDistricts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                    e.Row.Style.Add("height", "20px");
            }
        }   

        DataTable DataTabletemp = new DataTable();
        DataTable DataTabletemp1 = new DataTable();
        protected void fill_grid()
        {
            string query = string.Empty; string queryDataset = string.Empty;
            string arg1 = string.Empty;
            if (ddProject.SelectedIndex > 0) { arg1 = " and project_id='" + ddProject.SelectedValue + "'"; }
            query = "SELECT * FROM state_manager.dashboard where active='t'" + arg1;
            queryDataset = "select distinct name, project_id from project_manager.projects where active='t' order by 1";
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["cajporduction4"].ConnectionString);
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
                ddProject.DataSource = DataTabletemp1;
                ddProject.DataTextField = "name";
                ddProject.DataValueField = "project_id";
                ddProject.Dispose();
                //Session["ddProject_Ses"] = DataTabletemp1;
                if (!IsPostBack) ddProject.DataBind();
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