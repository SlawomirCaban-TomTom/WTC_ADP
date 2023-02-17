using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace TomTom_Info_Page.WTC
{
    public partial class history : System.Web.UI.Page
    {
        public static string main_query = string.Empty;

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
                    string query2 = "select role_id from user_role where user_id =" + Session["user"];
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

        private void fill_team()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "select team_id,team_name from teams order by team_id";
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

            ddl_team.DataSource = dt;
            ddl_team.DataValueField = "team_id";
            ddl_team.DataTextField = "team_name";
            ddl_team.DataBind();
            ddl_team.Items.Insert(0, "--All teams--");

        }
        public void fill_user()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "select user_id,user_name from users order by user_name";
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

            ddl_user.DataSource = dt;
            ddl_user.DataValueField = "user_id";
            ddl_user.DataTextField = "user_name";
            ddl_user.DataBind();
            ddl_user.Items.Insert(0, "--All Users--");

        }
        public void fill_user(string team_id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "select u.user_id,user_name from users u join user_team ut on u.user_id=ut.user_id where team_id=" + ddl_team.SelectedItem.Value + " order by user_name";
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

            ddl_user.DataSource = dt;
            ddl_user.DataValueField = "user_id";
            ddl_user.DataTextField = "user_name";
            ddl_user.DataBind();
            ddl_user.Items.Insert(0, "--All team " + ddl_team.SelectedItem.Value + " Users--");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fill_team();
                fill_user();
                int validate = validate_user();
                if (validate > 0)
                {
                    p_user.Visible = true;
                    main_query = "select * from WTC_5_0 where user_id>0";

                    //-- and (iptt.unit_id in(select unit_id from teams t join user_team ut on t.team_id=ut.team_id where user_id =" + Session["user"] + ") )";
                    Session["query"] = main_query;

                    menu_std.Visible = false;
                    Menu_mng.Visible = true;
                }
                else
                {

                    menu_std.Visible = true;
                    Menu_mng.Visible = false;
                    main_query = "select * from WTC_5_0 where user_id =" + Session["user"];
                    Session["query"] = main_query;
                }
                fill_grid(run_filter(Session["query"].ToString()));

            }

        }
        protected void UserListGridViewIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_data.PageIndex = e.NewPageIndex;
            fill_grid(run_filter(Session["query"].ToString()));

            // you data bind code
        }
        protected string create_csv()
        {
            StringBuilder sb = new StringBuilder();
            string query = run_filter(Session["query"].ToString());
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
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
                lbl_err.Text = ex.ToString() + " " + query;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            string[] columnNames = dt.Columns.Cast<DataColumn>().
                                  Select(column => column.ColumnName).
                                  ToArray();
            sb.AppendLine(string.Join(";", columnNames));
            foreach (DataRow row in dt.Rows)
            {
                string[] fields = row.ItemArray.Select(field => string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\"")).ToArray();
                sb.AppendLine(string.Join(";", fields));
            }

            return sb.ToString();
        }
        protected string run_filter(string query)
        {
            if (tb_start_date.Text.Length > 4)
            {
                query = query + " and date >='" + tb_start_date.Text + "'";
            }
            else
            {
                DateTime start_date = DateTime.Now.AddMonths(-1);
                query = query + " and date >='" + start_date.ToString() + "'";
            }
            if (tb_end_date.Text.Length > 4)
            {
                query = query + " and date <='" + DateTime.Parse(tb_end_date.Text).AddDays(1).ToString() + "'";
            }
            else
            {
                DateTime end_date = DateTime.Now;
                query = query + " and date <'" + end_date.ToString() + "'";
            }
            if (ddl_team.SelectedIndex > 0)
                query = query + " and team ='" + ddl_team.SelectedItem.Text + "'";
            if (ddl_user.SelectedIndex > 0)
                query = query + " and user_id =" + ddl_user.SelectedItem.Value;
            if (ddl_project.SelectedIndex > 0)
                query = query + " and project_name ='" + ddl_project.SelectedItem.Text + "'";
            if (ddl_task.SelectedIndex > 0)
                query = query + " and task_type_name ='" + ddl_task.SelectedItem.Text + "'";
            if (ddl_sub_task.SelectedIndex > 0)
                query = query + " and sub_task_name ='" + ddl_sub_task.SelectedItem.Text + "'";


            return query + "  order by date desc";
        }
        protected void on_tb_date_update(object sender, EventArgs e)
        {
            fill_grid(run_filter(Session["query"].ToString()));
        }
        protected void fill_grid(string query)
        {
            string base_query = query.Substring(query.IndexOf("from"));
            base_query = base_query.Substring(0, base_query.IndexOf("order"));
            string query1 = "select distinct project_name " + base_query + " order by project_name";
            string query2 = "select distinct task_type_name " + base_query + " order by task_type_name";
            string query3 = "select distinct sub_task_name " + base_query + " order by sub_task_name";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlDataAdapter da1 = new SqlDataAdapter(query1, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(query2, conn);
            SqlDataAdapter da3 = new SqlDataAdapter(query3, conn);

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            try
            {
                conn.Open();
                //da.FillSchema(ds, SchemaType.Source, "project_types_id");
                da.Fill(dt);
                da1.Fill(dt1); da2.Fill(dt2); da3.Fill(dt3);
                ddl_project.DataSource = dt1;
                ddl_project.DataTextField = "project_name";
                ddl_project.DataBind();

                ddl_project.Items.Insert(0, "--All Projects--");
                ddl_task.DataSource = dt2;
                ddl_task.DataTextField = "task_type_name";
                ddl_task.DataBind();
                ddl_task.Items.Insert(0, "--All Tasks--");

                ddl_sub_task.DataSource = dt3;
                ddl_sub_task.DataTextField = "sub_task_name";
                ddl_sub_task.DataBind();
                ddl_sub_task.Items.Insert(0, "--All Sub Tasks--");

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
                gv_data.Visible = true;
                gv_data.DataSource = dt;
                gv_data.DataBind();
                lbl_results.Text = "Number of rows: " + dt.Rows.Count;
            }
            else
            {
                gv_data.Visible = false;

                lbl_results.Text = "No data";
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://wtcadp.azurewebsites.net/WTC/wtc_main.aspx");
        }
        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_data.PageIndex = e.NewPageIndex;
            fill_grid(run_filter(Session["query"].ToString()));
        }

        protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = gv_data.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                gv_data.DataSource = dataView;
                gv_data.DataBind();
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            fill_grid(run_filter(Session["query"].ToString()));
        }

        protected void ddl_team_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_grid(run_filter(Session["query"].ToString()));
            if (ddl_team.SelectedIndex > 0)
                fill_user(ddl_team.SelectedItem.Value);
            else
                fill_user();
        }

        protected void ddl_user_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_grid(run_filter(Session["query"].ToString()));
        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=dump.csv");
            Response.Write(create_csv());
            Response.End();
        }

        protected void ddl_project_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_grid(run_filter(Session["query"].ToString()));

        }

        protected void ddl_task_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_grid(run_filter(Session["query"].ToString()));

        }

        protected void ddl_sub_task_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_grid(run_filter(Session["query"].ToString()));

        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {


            Response.Redirect(Request.RawUrl);
        }
    }
}