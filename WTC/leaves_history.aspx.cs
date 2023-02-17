using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Npgsql;
using Syn.Bot.Oscova;

namespace TomTom_Info_Page.WTC
{
    public partial class leaves_history : System.Web.UI.Page
    {

        protected int validate_user()
        {
            int role_id = 0;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "select user_id,first_name from users where domain_username='" + User.Identity.Name + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                //da.FillSchema(ds, SchemaType.Source, "project_types_id");
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["user"] = dt.Rows[0][0].ToString();
                    string query2 = "select top(1) role_id from user_role where user_id =" + Session["user"] +"  order by role_id asc";
                    SqlCommand cmd = new SqlCommand(query2, conn);
                    object test = cmd.ExecuteScalar();
                    if (test != null)
                        int.TryParse(test.ToString(), out role_id);
                }
                else
                {
                    lbl_err.Visible = true;
                    lbl_err.Text = "User not found in WTC database! Please contact TCO!";
                }
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
            Session["role"] = role_id;
            return role_id;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            fill_grid();
            if (validate_user() == 1)
            {

                p_team.Visible = true;
                fill_team_grid();
            }
            else
                p_team.Visible = false;
        }
        protected void fill_grid()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "select [leave date], [type], description, [duration [h]]], reported from v_leave_history where user_id=" + Session["user"].ToString() + "  order by 1 desc";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                //da.FillSchema(ds, SchemaType.Source, "project_types_id");
                da.Fill(dt);
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
            gv_lhistory.DataSource = dt;
            gv_lhistory.DataBind();
            Session["leaves"] = dt;
            if (dt.Rows.Count < 1)
                lbl_results.Text = "No records found!";

            else
                lbl_results.Text = "Done! Number of rows found: " + dt.Rows.Count;

        }

        protected void fill_team_grid()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "select [leave date],Employee, [type], description, [duration [h]]], reported from v_leave_history where user_id in (select user_id from user_team ut where team_id = (select top(1) team_id from teams t where lead_user_id=" + Session["user"].ToString() + ") and user_id <>" + Session["user"].ToString() + ") order by 1 desc";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                //da.FillSchema(ds, SchemaType.Source, "project_types_id");
                da.Fill(dt);
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
            gv_team_grid.DataSource = dt;
            gv_team_grid.DataBind();
            if (dt.Rows.Count < 1)
                lbl_results_2.Text = "No records found!";

            else
                lbl_results_2.Text = "Done! Number of rows found: " + dt.Rows.Count;

        }
        protected void gvVochByDate_RowCommand(object sender, GridViewDeleteEventArgs e)
        {
            DataTable temp = (DataTable)Session["leaves"];
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "sp_del_leaves";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("date", SqlDbType.NVarChar,20).Value = temp.Rows[e.RowIndex][0].ToString();

            cmd.Parameters.Add("type", SqlDbType.NVarChar,20).Value = temp.Rows[e.RowIndex][1].ToString();
            cmd.Parameters.Add("user", SqlDbType.Int).Value = Session["user"].ToString();
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                //fill_grid(1);
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                conn.Close();
                conn.Dispose();
                lbl_err.Text = ex.ToString() + query;
                lbl_err.Visible = true;
            }
        }

    }
}