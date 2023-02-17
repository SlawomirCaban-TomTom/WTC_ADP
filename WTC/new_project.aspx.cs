using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

namespace TomTom_Info_Page.WTC
{
    public partial class new_project : System.Web.UI.Page
    {

        public int imported;
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
                    string query2 = "select max(role_id) from user_role where user_id =" + Session["user"];
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
            if (!Page.IsPostBack)
                validate_user();
            if (int.Parse(Session["role"].ToString()) != 1)
            {


                Response.Redirect("https://wtcadp.azurewebsites.net/wtc/wtc_main.aspx");
            }

        }



        protected void tb_add_project_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Unnamed6_Click(object sender, EventArgs e)
        {
            List<string> missing_params = new List<string>();
            List<string> not_valid = new List<string>();
            List<string> missing_pu = new List<string>();
            List<string> missing_topic = new List<string>();
            List<string> missing_PM = new List<string>();
            List<string> missing_qtm = new List<string>();
            List<string> missing_iris = new List<string>();
            List<string> missing_at = new List<string>();
            List<string> missing_uom = new List<string>();
            List<string> missing_quom = new List<string>();
            List<string> missing_pt = new List<string>();
            List<string> missing_t = new List<string>();
            List<string> missing_unit = new List<string>();
            List<string> missing_effi = new List<string>();
            imported = 0;




            string tt = tb_add_project.Text;
            string[] alltext = tt.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = alltext.Length;
            if (rows > 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    int task_type_id = 0;
                    int project_id = 0;
                    int pu_id = 0;
                    bool import_valid = true;
                    string[] temp = alltext[i].Split(';');
                    if (temp.Count() != 3) 
                    {
                        missing_params.Add(alltext[i]);
                        import_valid = false;
                    }
                    else
                    {
                        bool is_task_valid = true;
                        project_id = check_project(temp[0].Trim());
                        if (project_id > 0)
                        {
                            task_type_id = check_task(temp[1].Trim());
                            if (task_type_id > 0)
                            {
                                is_task_valid = validate_task_project(project_id, task_type_id);
                                if (!is_task_valid)
                                {
                                    not_valid.Add(alltext[i]);
                                    import_valid = false;
                                }
                                else
                                    import_valid = true;
                            }
                        }
                        pu_id = check_pu(temp[2].Trim());
                        if (pu_id < 1)
                        {
                            import_valid = false;
                            missing_pu.Add(alltext[i]);
                        }
                    }
                    if (import_valid)
                    {
                        import_project_task(temp[0], temp[1],  pu_id);
                    }
                }
                lbl_v2_result.Text = "Done! Requested " + alltext.Length + " tasks to apply; Imported " + imported + " tasks!";
                if ((missing_params.Count > 0) || (not_valid.Count > 0) || (missing_pu.Count > 0) )
                {
                    lbl_fail.Visible = true;
                    int va = alltext.Length - imported;
                    lbl_fail.Text = "Not imported tasks count " + va + ". Following tasks were not imported:";
                }
                else
                    lbl_fail.Visible = false;



                if (missing_params.Count > 0)
                {
                    DataTable temp1 = new DataTable();
                    temp1.Columns.Add();
                    foreach (string str in missing_params)
                    {
                        temp1.Rows.Add(str);
                    }
                    gv_params.DataSource = temp1;
                    gv_params.DataBind();
                    p_params.Visible = true;
                }
                else
                    p_params.Visible = false;
                if (not_valid.Count > 0)
                {
                    p_not_valid.Visible = true;
                    DataTable temp1 = new DataTable();
                    temp1.Columns.Add();
                    foreach (string str in not_valid)
                    {
                        temp1.Rows.Add(str);
                    }
                    gv_not_valid.DataSource = temp1;
                    gv_not_valid.DataBind();
                }

                else
                    p_not_valid.Visible = false;

                if (missing_pu.Count > 0)
                {
                    p_pu.Visible = true;
                    DataTable temp1 = new DataTable();
                    temp1.Columns.Add();
                    foreach (string str in missing_pu)
                    {
                        temp1.Rows.Add(str);
                    }
                    gv_pu.DataSource = temp1;
                    gv_pu.DataBind();
                }

                else
                    p_pu.Visible = false;

            }
        }
        public void import_project_task(string project_name, string task, int pu_id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SP_add_project_task", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@project", SqlDbType.NVarChar).Value = project_name.Trim();
            cmd.Parameters.Add("@task", SqlDbType.NVarChar).Value = task.Trim();
            cmd.Parameters.Add("@pu", SqlDbType.Int).Value = pu_id;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                imported++;
            }
            catch (Exception ex)
            {
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString() +  project_name + ","  + task + "," + pu_id;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
        public int check_project(string name)
        {
            int result = 0;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "select project_id from project where project_name= '" + name + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                object res = cmd.ExecuteScalar();
                if (res != DBNull.Value && res != null)
                    result = int.Parse(cmd.ExecuteScalar().ToString());
                else
                    result = 0;
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

            return result;
        }
        public bool validate_task_project(int project_id, int task_type_id)
        {
            bool result = true;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "select project_id from int_project_task_type  where project_id=" + project_id.ToString() + " and task_type_id=" + task_type_id.ToString();
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();

                object res = cmd.ExecuteScalar();
                if (res != DBNull.Value && res != null)
                    result = false;
                else
                    result = true;
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

            return result;
        }

        public int check_pu(string name)
        {
            int result = 0;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "select  pu_id from pus where pu= '" + name + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                object res = cmd.ExecuteScalar();
                if (res != DBNull.Value && res != null)
                    result = int.Parse(cmd.ExecuteScalar().ToString());
                else
                    result = 0;
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

            return result;
        }
        public int check_task(string name)
        {
            int result = 0;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "select task_type_id from task_type where task_type_name= '" + name + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                object res = cmd.ExecuteScalar();
                if (res != DBNull.Value && res != null)
                    result = int.Parse(cmd.ExecuteScalar().ToString());
                else
                    result = 0;
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

            return result;
        }
       
        protected void bt2_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/wtc/edit_project.aspx");
        }
    }
}