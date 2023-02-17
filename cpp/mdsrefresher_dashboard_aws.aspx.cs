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
    public partial class mdsrefresher_dashboard_aws : System.Web.UI.Page
    {
        public string groupid;
        protected void Page_Load(object sender, EventArgs e)
        {

           
            if (!this.IsPostBack)
            {
                //if (cbProfile.Checked == true) { Session["sp_Ses"] = true; } else { Session["sp_Ses"] = false; }
                //if (cbCategory.Checked == true) { Session["sc_Ses"] = true; } else { Session["sc_Ses"] = false; }
                //Session["ddlStatus_Ses"] = ddlStatus.SelectedValue;
                //Session["ddlFeaturesBatches_Ses"] = ddlFeaturesBatches.SelectedValue;

            fill_grid();
            fill_dailystats();
            
            }
            
            /* if (IsPostBack)
            {
                if (cbProfile.Checked == true) { Session["sp_Ses"] = true; } else { Session["sp_Ses"] = false; }
                if (cbCategory.Checked == true) { Session["sc_Ses"] = true; } else { Session["sc_Ses"] = false; }
                Session["ddlStatus_Ses"] = ddlStatus.SelectedValue;
                Session["ddlFeaturesBatches_Ses"] = ddlFeaturesBatches.SelectedValue;

                if (Request.Params["groupid"] != null && Request.QueryString["groupid"] != "")
                {
                    if (txtgroupids.Text != "")
                    {
                        groupid = txtgroupids.Text;
                    }
                    else
                    {
                        groupid = Request.Params["groupid"];
                    }
                    Session["sp_Ses"] = false;
                    Session["sc_Ses"] = false;
                    fill_groupid_details(groupid);
                    fill_grid();
                }
                else
                {
                    groupid = txtgroupids.Text;
                    fill_grid();
                }
            }
            else
            {

                if (Request.Params["groupid"] != null && Request.QueryString["groupid"] != "")
                {
                    Session["ddlStatus_Ses"] = ddlStatus.SelectedValue;
                    Session["ddlFeaturesBatches_Ses"] = ddlFeaturesBatches.SelectedValue;

                    groupid = Request.Params["groupid"];
                    Session["sp_Ses"] = false;
                    Session["sc_Ses"] = false;
                    fill_groupid_details(groupid);
                    fill_grid();
                }
                else
                {
                    Session["sp_Ses"] = true;
                    Session["sc_Ses"] = true;
                    fill_grid();
                }
            }

            */

        }


        protected void fill_dailystats()
        {
            DataTable datatable_fillgrid = new DataTable();
            string query = string.Empty;
            query = "select * from public.temptable order by 1";
             NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["mdsrefresheraws"].ConnectionString);
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn);


            try
            {
                conn.Open();
                sda.Fill(datatable_fillgrid);
                 conn.Close();
                conn.Dispose();
                dailystats_gv.DataSource = datatable_fillgrid;
                Session["dailystats_gv_Ses"] = datatable_fillgrid;
                dailystats_gv.DataBind();
            }
            catch (Exception ex)
            {
                lbl_err.ForeColor = System.Drawing.Color.Red;
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString();
            }
        }

        protected void fill_grid()
        {
            DataTable datatable_fillgrid = new DataTable();
            string query = string.Empty;
            string arg1 = string.Empty; string arg2 = string.Empty;
            arg1 += "speedprofiles-refresh";
            //if ((bool)Session["sp_Ses"] == true) { arg1 += "speedprofiles-refresh"; }
            //if ((bool)Session["sc_Ses"] == true) { arg2 += "speedcategory-refresh"; }
            query = "select ((finished_task_count::numeric+processing_task_count::numeric-failed_task_count::numeric)/total_task_count::numeric)::numeric(3,2) as progress,* from mdscontentrefresher_mcrcore03_r2.refresh_job where job_name in ('" + arg1 + "','" + arg2 + "') order by created desc";

            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["mdsrefresheraws"].ConnectionString);
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn);


            try
            {
                conn.Open();
                sda.Fill(datatable_fillgrid);
                //sda1.Fill(DataTabletemp1);
                conn.Close();
                conn.Dispose();
                refreshjobs.DataSource = datatable_fillgrid;
                Session["refreshjobs_Ses"] = datatable_fillgrid;
                refreshjobs.DataBind();


            }
            catch (Exception ex)
            {
                lbl_err.ForeColor = System.Drawing.Color.Red;
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString();
            }
        }


        protected void fill_groupid_details(string groupid)
        {
            DataTable datatable_fillgriddetails = new DataTable();
            ddlFeaturesBatches.Visible = false;
            ddlStatus.Visible = false;
            lblDetails.Visible = false;
            string query = string.Empty;
            string argstatus = "''";
            //if ((string)Session["ddlStatus_Ses"] == "0") argstatus = "''";
            //if ((string)Session["ddlStatus_Ses"] == "1") argstatus = "'PROCESSING','SPLIT','MISSING','SKIPPED','UNMODIFIED','FAILED','QA_VIOLATION'";
            string argdescr = "'Features','Batches'";
            //argdescr = (string)Session["ddlFeaturesBatches_Ses"];
            //string arg1 = string.Empty;
            query = "select rj.zone,rj.created,t.* from mdscontentrefresher_mcrcore03_r2.groupidstats('{" + groupid + "}'::uuid[]) as t(job_id uuid,status varchar,cnt bigint,descr text) join mdscontentrefresher_mcrcore03_r2.refresh_job rj on rj.job_id=t.job_id where dry_run=false and status not in (" + argstatus + ") and descr in (" + argdescr + ") order by created,zone,rj.job_id";

            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["mdsrefresheraws"].ConnectionString);
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn);

            try
            {
                conn.Open();
                sda.Fill(datatable_fillgriddetails);
                conn.Close();
                conn.Dispose();
                groupiddetails.DataSource = datatable_fillgriddetails;
                //Session["groupidjobs_Ses"] = DataTabletemp1;
                groupiddetails.DataBind();
                
                //  if (!IsPostBack) ddDataset.DataBind();*/
            }
            catch (Exception ex)
            {
                lbl_err.ForeColor = System.Drawing.Color.Red;
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString();
            }
        }


        protected void GetSelectedRecords(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[1] { new DataColumn("groupid") });
            string groupids = string.Empty;
            foreach (GridViewRow row in refreshjobs.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        //string groupid = (row.Cells[5].FindControl("group_id") as Label).Text;
                        //string groupid = row.Cells[5].Text;
                        //string country = (row.Cells[2].FindControl("lblCountry") as Label).Text;
                        //dt.Rows.Add(groupid);
                        groupids = groupids + row.Cells[5].Text + ",";
                        //groupids += (i < refreshjobs.Rows.Count) ? "," : string.Empty;
                    }
                }
            }
            //gvSelected.DataSource = dt;
            //gvSelected.DataBind();
            groupids = groupids.Remove(groupids.Length - 1);
            lbl_err.Visible = true;
            lbl_err.Text = groupids;

            fill_groupid_details(groupids);

        }


        protected void groupiddetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text == "PROCESSING")
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Green;
                    e.Row.Cells[5].Font.Bold = true;
                }
                else if (e.Row.Cells[5].Text == "FAILED")
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;
                }
                else if (e.Row.Cells[5].Text == "QA_VIOLATION")
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;
                }
                else if (e.Row.Cells[5].Text == "LOCKED")
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;
                }
                else if (e.Row.Cells[5].Text == "SPLIT")
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Black;
                }
            }
        }



        protected void btnViewgroupid_Click(object sender, EventArgs e)
        {
            fill_groupid_details(groupid);

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            //Response.Redirect("http://infopage-lodz.ttg.global/cpp/mdsrefresher_dashboard.aspx");
            fill_grid();
        }


        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_groupid_details(groupid);
        }

        protected void ddlFeaturesBatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_groupid_details(groupid);
        }

        protected void refreshjobs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text == "100 %")
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Green;
                    e.Row.Cells[1].Font.Bold = true;
                }

                if (e.Row.Cells[6].Text == "True")
                {
                    e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                }
            }
        }





    }
}