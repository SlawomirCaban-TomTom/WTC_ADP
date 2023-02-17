using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Npgsql;
namespace TomTom_Info_Page.cpp
{
    public partial class cc_india : System.Web.UI.Page
    {
        protected bool validate()
        {
            bool result = false;
            string username = User.Identity.Name.ToLower();
            List<string> valid = new List<string>();
            valid.Add("slawomir.caban@tomtom.com");
            valid.Add("lukasz.przyborowski@tomtom.com");
            valid.Add("ketki.avachat@tomtom.com");
            valid.Add("lukasz.zajac@tomtom.com");
            valid.Add("pawel.swierczynski@tomtom.com");
            valid.Add(@"ttg\caban");
            valid.Add(@"ttg\zajac");
            valid.Add(@"ttg\avachat");
            valid.Add(@"ttg\przyboro");
            valid.Add(@"ttg\swierczy");

            if (valid.Contains(username) == true)
            {
                result =true;
            }
            return result;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (validate())
            {
                if (!Page.IsPostBack)
                {
                    load_gv();
                    dd_priority.SelectedIndex = 1;
                }
            }
            else
                Response.Redirect("http://infopage-lodz.ttg.global");
        }

        protected void bt_add_Click(object sender, EventArgs e)
        {
            if (p_add.Visible == false)
            {
                p_add.Visible = true;
                bt_add.Text = "Cancel";
            }
            else
            {
                p_add.Visible = false;
                bt_add.Text = "Add new project to CC";
            }
        }
        protected void load_gv()
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["tool_import_india"].ConnectionString);
            DataTable temp = new DataTable();
            string query = "SELECT distinct tool_name \"Tool Name\",priority \"Priority\" from committer_config_india_cpp_r2.tool_config where destination='PROCESSING' order by priority,tool_name asc";
            NpgsqlDataAdapter cmd = new NpgsqlDataAdapter(query, conn);
            DataTable results = new DataTable();
            try
            {
                conn.Open();
                cmd.Fill(results);
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString();
            }
            gv_results.DataSource = results;
            gv_results.DataBind();
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            if (tb_new_project.Text.Length < 3)
            {
                lbl_err_np.Text = "Please check project name!";
            }
            else
            {

                NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["tool_import_india"].ConnectionString);
                DataTable temp = new DataTable();
                string query = "SELECT count(tool_name) from committer_config_india_cpp_r2.tool_config where tool_name = '" + tb_new_project.Text + "' and destination='PROCESSING'";
                string insert1 = "insert into committer_config_india_cpp_r2.tool_config values('" + tb_new_project.Text + "','ASYNC','PROCESSING',"+ dd_priority.SelectedValue + ")";
                string insert2 = "insert into committer_config_india_cpp_r2.tool_config values('" + tb_new_project.Text + "','SYNC','PROCESSING'," + dd_priority.SelectedValue + ")";
                string update = " update committer_config_india_cpp_r2.tool_config set priority =" + dd_priority.SelectedValue+" where tool_name = '" + tb_new_project.Text + "' and destination='PROCESSING'";
                NpgsqlCommand check = new NpgsqlCommand(query,conn);
                try
                {
                    conn.Open();
                    int test = 0;
                    int.TryParse(check.ExecuteScalar().ToString(), out test);
                    if (test > 0)
                    {
                        NpgsqlCommand do_update = new NpgsqlCommand(update, conn);
                        do_update.ExecuteNonQuery();
                        lbl_status_new.Text = "Provided project already exist - priority updated! " + tb_new_project.Text + " Priority= " + dd_priority.SelectedValue;
                        save_history(tb_new_project.Text, dd_priority.SelectedValue, "update");
                    }
                    else
                    {
                        NpgsqlCommand do_insert1 = new NpgsqlCommand(insert1, conn);
                        NpgsqlCommand do_insert2 = new NpgsqlCommand(insert2, conn);
                        do_insert1.ExecuteNonQuery();
                        do_insert2.ExecuteNonQuery();
                        lbl_status_new.Text = "Project added! " + tb_new_project.Text + " Priority= " + dd_priority.SelectedValue;
                        lbl_status_new.Text = "new";
                        save_history(tb_new_project.Text, dd_priority.SelectedValue, "new");
                    }
                    conn.Close();
                    conn.Dispose();
                }
                catch (Exception ex)
                {
                    lbl_err_np.Visible = true;
                    lbl_err_np.Text = ex.ToString();
                }
                p_add.Visible = false;
                bt_add.Text = "Add new project to CC";

               Response.Redirect(Request.RawUrl);

            }
        }
        protected void gd_results_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
               
                string t_name = DataBinder.Eval(e.Item.DataItem, "Tool Name").ToString();
                string prio = DataBinder.Eval(e.Item.DataItem, "Priority").ToString();
                DropDownList ddl = (DropDownList)e.Item.FindControl("ddl_new_prio");
                List<ListItem> items = new List<ListItem>();
                items.Add(new ListItem("2", "2"));
                items.Add(new ListItem("3", "3"));
                items.Add(new ListItem("4", "4"));
                items.Add(new ListItem("5", "5"));
                ddl.Items.AddRange(items.ToArray());
                ddl.SelectedIndex =ddl.Items.IndexOf(ddl.Items.FindByText(prio));
            }

        }

        public void change_prio(object sender, EventArgs e)
        {
            //shows the following message when linkbutton is clicked.                   
          
            DropDownList ddl =  (DropDownList)sender;
            TableCell cell = ddl.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            string new_prio = ddl.SelectedItem.Text;
            string project = item.Cells[0].Text;
            update_priority(project, new_prio);
            save_history(project, new_prio, "update");
            Response.Redirect(Request.RawUrl);
        }
        protected void update_priority(string t_name, string new_prio)
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["tool_import_india"].ConnectionString);
            string update = "update committer_config_india_cpp_r2.tool_config set priority =" + new_prio + " where tool_name = '" + t_name + "' and destination='PROCESSING'";
            NpgsqlCommand cmd = new NpgsqlCommand(update, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
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
        }

        protected void dd_priority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Unnamed4_Click1(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            TableCell cell = btn.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            delete_project(item.Cells[0].Text);
            save_history(item.Cells[0].Text, item.Cells[1].Text, "delete");
            Response.Redirect(Request.RawUrl);
        }
        protected void delete_project(string t_name)
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["tool_import_india"].ConnectionString);
            string update = "delete from committer_config_india_cpp_r2.tool_config where tool_name = '" + t_name + "' and destination='PROCESSING'";
            NpgsqlCommand cmd = new NpgsqlCommand(update, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
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
        }
        protected void save_history(string project, string priority, string action)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string update = "insert into cc_history (username,action,project,priority,activity_time,env) values ('" + User.Identity.Name.ToLower() + "','"+action+"','"+project+"',"+priority+",'"+DateTime.Now.ToString()+"','INDIA')";
      
            SqlCommand cmd = new SqlCommand(update, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
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

        }

    }
}