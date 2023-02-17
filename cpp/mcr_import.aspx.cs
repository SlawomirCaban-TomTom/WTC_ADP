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
    public partial class mcr_import : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
 
            
            fill_grid();
            if (!Page.IsPostBack)
            {
                fill_ddl();
                fill_grid();
            }
        }

        protected void fill_grid()
        {
            DataTable datatable_fillgrid = new DataTable();
            string query = string.Empty;
            string release = string.Empty;
            release = DropDownList1.SelectedValue.ToString();
            query = "SELECT * FROM public.import_run WHERE release='"+release+"' ORDER BY created DESC";
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["mcrspeeddb"].ConnectionString);
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn);


            try
            {
                conn.Open();
                sda.Fill(datatable_fillgrid);
                //sda1.Fill(DataTabletemp1);
                conn.Close();
                conn.Dispose();
                gv.DataSource = datatable_fillgrid;
                gv.DataBind();


            }
            catch (Exception ex)
            {
                lbl_err.ForeColor = System.Drawing.Color.Red;
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString();
            }
        }


        protected void fill_ddl()
        {
            DataTable datatable_fillgrid = new DataTable();
            string query = string.Empty;

            query = "SELECT distinct release FROM public.import_run order by release desc";
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["mcrspeeddb"].ConnectionString);
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn);


            try
            {
                conn.Open();
                sda.Fill(datatable_fillgrid);
                conn.Close();
                conn.Dispose();
     

                DropDownList1.DataSource = datatable_fillgrid;
                DropDownList1.DataValueField = "release";
                DropDownList1.DataTextField = "release";
                DropDownList1.DataBind();
                //DropDownList1.Items.Insert(0, "--release--");


            }
            catch (Exception ex)
            {
                lbl_err.ForeColor = System.Drawing.Color.Red;
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            fill_grid();
        }

    }
}