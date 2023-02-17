using Microsoft.Win32;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TomTom_Info_Page.WTC
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void fill_project_data(string id, bool onlyactive)
        {
            string query = "select project_name, pu from project p join pus m on p.pu_id=m.pu_id  where p.project_id=" + id;
            string query3 = "SELECT pu_id,[pu] FROM [pus] ORDER BY [pu]";
            string query5 = string.Empty;
            if (onlyactive)
                query5 = "select p.task_type_id,task_type_name from int_project_task_type p join task_type tt on p.task_type_id=tt.task_type_id where is_active=1 and  p.project_id =" + id + " order by task_type_name";
            else
                query5 = "select p.task_type_id,task_type_name from int_project_task_type p join task_type tt on p.task_type_id=tt.task_type_id where p.project_id =" + id + " order by task_type_name";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlDataAdapter da3 = new SqlDataAdapter(query3, conn);
            SqlDataAdapter da5 = new SqlDataAdapter(query5, conn);
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();
            DataTable dt7 = new DataTable();
            DataTable dt8 = new DataTable();
            DataTable dt9 = new DataTable();
            DataTable dt10 = new DataTable();
            try
            {
                conn.Open();
                //da.FillSchema(ds, SchemaType.Source, "project_types_id");
                da.Fill(dt);
                da3.Fill(dt3);
                da5.Fill(dt5);
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
            lbl_p_name.Text = dt.Rows[0][0].ToString();
            lbl_pu.Text = dt.Rows[0][1].ToString();
            
            ddl_pu.DataSource = dt3;
            ddl_pu.DataValueField = "pu_id";
            ddl_pu.DataTextField = "pu";
            ddl_pu.DataBind();
            ddl_pu.Items.Insert(0, "-- SELECT --");

            gv_tasks.DataSource = dt5;
            gv_tasks.DataBind();





        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                fill_project_data(Request.QueryString["ID"], true);
            /*  else
              {
                  if(cb_nonactive.Checked)
                      fill_project_data(Request.QueryString["ID"], true);
                  else
                      fill_project_data(Request.QueryString["ID"], false);
              }*/
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {

            Server.Transfer("~/wtc/edit_project.aspx");
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            if (tb_p_name.Text.Length > 0)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
                string query = "update project set project_name ='" + tb_p_name.Text + "' where project_id=" + Request.QueryString["ID"];
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //da.FillSchema(ds, SchemaType.Source, "project_types_id");
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

                Server.Transfer(Request.RawUrl);
            }
            else
            {
                lbl_err.Text = "Name cannot be empty!";
                lbl_err.Visible = true;
            }
        }

           protected void Unnamed8_Click(object sender, EventArgs e)
        {

            if (ddl_pm.SelectedIndex > 0)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
                string query = "update project set pm_id ='" + ddl_pm.SelectedItem.Value + "' where project_id=" + Request.QueryString["ID"];
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //da.FillSchema(ds, SchemaType.Source, "project_types_id");
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

                Server.Transfer(Request.RawUrl);
            }
            else
            {
                lbl_err.Text = "Please select new PM!";
                lbl_err.Visible = true;
            }

        }

        protected void Unnamed10_Click(object sender, EventArgs e)
        {
            if (ddl_qtm.SelectedIndex > 0)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
                string query = "update project set qtm_id ='" + ddl_qtm.SelectedItem.Value + "' where project_id=" + Request.QueryString["ID"];
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //da.FillSchema(ds, SchemaType.Source, "project_types_id");
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

                Server.Transfer(Request.RawUrl);
            }
            else
            {
                lbl_err.Text = "Please select new QTM!";
                lbl_err.Visible = true;
            }
        }

        protected void Unnamed12_Click(object sender, EventArgs e)
        {
            if (ddl_pu.SelectedIndex > 0)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
                string query = "update project set pu_id ='" + ddl_pu.SelectedItem.Value + "' where project_id=" + Request.QueryString["ID"];
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //da.FillSchema(ds, SchemaType.Source, "project_types_id");
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

                Server.Transfer(Request.RawUrl);
            }
            else
            {
                lbl_err.Text = "Please select new pu!";
                lbl_err.Visible = true;
            }
        }
        

        protected void gv_tasks_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int task_id = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "task_type_id"));
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
                RadioButtonList active = (RadioButtonList)e.Item.FindControl("rb_active");
                string query1 = "select case when is_active ='true' then 1 else 0 end from int_project_task_type where project_id = " + Request.QueryString["ID"] + " and task_type_id=" + task_id;
              
                DataTable topic_list = new DataTable();
                DataTable iris_list = new DataTable();
                DataTable at_list = new DataTable();
                DataTable uom_list = new DataTable();
                DataTable effi_t_list = new DataTable();
                DataTable pt_list = new DataTable();
                SqlCommand cmd1 = new SqlCommand(query1, conn); //dpu remarks
          


                try
                {
                    conn.Open();

                   int tr1 = 0;
                    int tr2 = 0;
                    int tr3 = 0;
                    int tr4 = 0;
                    int tr5 = 0;
                    int tr6 = 0;
                    int tr7 = 0;
                    int tr8 = 0;
                    int tr13 = 0;
                    int tr15 = 0;
                    int.TryParse(cmd1.ExecuteScalar().ToString(), out tr1);
                     active.SelectedValue = tr1.ToString();
          }
                catch (Exception ex)
                {
                    lbl_err.Text = ex.ToString();
                    lbl_err.Visible = true;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        protected void update_active(string project, string task_id, string value)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);

            string query = "update int_project_task_type set is_active=" + value + " where project_id=" + project + " and task_type_id=" + task_id;
            SqlCommand cmd = new SqlCommand(query, conn);
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
        protected void update_iris(string project, string task_id, string value)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "update int_project_task_type set workflow_id =" + value + " where project_id=" + project + " and task_type_id=" + task_id;
            SqlCommand cmd = new SqlCommand(query, conn);
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
        protected void update_topic(string project, string task_id, string value)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "update int_project_task_type set topic_id =" + value + " where project_id=" + project + " and task_type_id=" + task_id;
            SqlCommand cmd = new SqlCommand(query, conn);
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
        protected void update_at(string project, string task_id, string value)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "update int_project_task_type set activity_id=" + value + " where project_id=" + project + " and task_type_id=" + task_id;
            SqlCommand cmd = new SqlCommand(query, conn);
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
        protected void update_uom(string project, string task_id, string value)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "update int_project_task_type set uom_id=" + value + " where project_id=" + project + " and task_type_id=" + task_id;
            SqlCommand cmd = new SqlCommand(query, conn);
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
        protected void update_quom(string project, string task_id, string value)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "update int_project_task_type set q_uom_id=" + value + " where project_id=" + project + " and task_type_id=" + task_id;
            SqlCommand cmd = new SqlCommand(query, conn);
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
        protected void update_effi_t(string project, string task_id, string value)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "update int_project_task_type set effi_type=" + value + " where project_id=" + project + " and task_type_id=" + task_id;
            SqlCommand cmd = new SqlCommand(query, conn);
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
        protected void update_pt(string project, string task_id, string value)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "update int_project_task_type set process_type_id=" + value + " where project_id=" + project + " and task_type_id=" + task_id;
            SqlCommand cmd = new SqlCommand(query, conn);
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
        protected void update_t(string project, string task_id, string value)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "update int_project_task_type set target=" + value + " where project_id=" + project + " and task_type_id=" + task_id;
            SqlCommand cmd = new SqlCommand(query, conn);
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


        protected void update_unit(string project, string task_id, string value)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "update int_project_task_type set unit_id=" + value + " where project_id=" + project + " and task_type_id=" + task_id;
            SqlCommand cmd = new SqlCommand(query, conn);
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
        protected void rb_active_change(object sender, EventArgs e)
        {
            //shows the following message when linkbutton is clicked.                   
            int rowindex = 0;
            RadioButtonList rb = (RadioButtonList)sender;
            DataGridItem item = (DataGridItem)rb.Parent.Parent;
            rowindex = item.ItemIndex;

            update_active(Request.QueryString["ID"], gv_tasks.Items[rowindex].Cells[0].Text.ToString(), rb.SelectedValue.ToString());

            fill_project_data(Request.QueryString["ID"], cb_nonactive.Checked);

        }
        protected void rb_iris_change(object sender, EventArgs e)
        {
            //shows the following message when linkbutton is clicked.                   
            int rowindex = 0;
            RadioButtonList rb = (RadioButtonList)sender;
            DataGridItem item = (DataGridItem)rb.Parent.Parent;
            rowindex = item.ItemIndex;

            update_iris(Request.QueryString["ID"], gv_tasks.Items[rowindex].Cells[0].Text.ToString(), rb.SelectedValue.ToString());
        }
        protected void rb_topic_change(object sender, EventArgs e)
        {
            //shows the following message when linkbutton is clicked.                   
            int rowindex = 0;
            RadioButtonList rb = (RadioButtonList)sender;
            DataGridItem item = (DataGridItem)rb.Parent.Parent;
            rowindex = item.ItemIndex;

            update_topic(Request.QueryString["ID"], gv_tasks.Items[rowindex].Cells[0].Text.ToString(), rb.SelectedValue.ToString());
        }


        protected void rb_unit_change(object sender, EventArgs e)
        {
            //shows the following message when linkbutton is clicked.                   
            int rowindex = 0;
            RadioButtonList rb = (RadioButtonList)sender;
            DataGridItem item = (DataGridItem)rb.Parent.Parent;
            rowindex = item.ItemIndex;

            update_unit(Request.QueryString["ID"], gv_tasks.Items[rowindex].Cells[0].Text.ToString(), rb.SelectedValue.ToString());
        }
        protected void topic_change(object sender, EventArgs e)
        {
            //shows the following message when linkbutton is clicked.                   
            int rowindex = 0;
            DropDownList topic = (DropDownList)sender;
            DataGridItem item = (DataGridItem)topic.Parent.Parent;
            rowindex = item.ItemIndex;

            update_iris(Request.QueryString["ID"], gv_tasks.Items[rowindex].Cells[0].Text.ToString(), topic.SelectedValue.ToString());
        }

        protected void iris_change(object sender, EventArgs e)
        {
            //shows the following message when linkbutton is clicked.                   
            int rowindex = 0;
            DropDownList iris = (DropDownList)sender;
            DataGridItem item = (DataGridItem)iris.Parent.Parent;
            rowindex = item.ItemIndex;

            update_iris(Request.QueryString["ID"], gv_tasks.Items[rowindex].Cells[0].Text.ToString(), iris.SelectedValue.ToString());
        }
        protected void at_change(object sender, EventArgs e)
        {
            //shows the following message when linkbutton is clicked.                   
            int rowindex = 0;
            DropDownList at = (DropDownList)sender;
            DataGridItem item = (DataGridItem)at.Parent.Parent;
            rowindex = item.ItemIndex;

            update_at(Request.QueryString["ID"], gv_tasks.Items[rowindex].Cells[0].Text.ToString(), at.SelectedValue.ToString());
        }
        protected void uom_change(object sender, EventArgs e)
        {
            //shows the following message when linkbutton is clicked.                   
            int rowindex = 0;
            DropDownList uom = (DropDownList)sender;
            DataGridItem item = (DataGridItem)uom.Parent.Parent;
            rowindex = item.ItemIndex;

            update_uom(Request.QueryString["ID"], gv_tasks.Items[rowindex].Cells[0].Text.ToString(), uom.SelectedValue.ToString());
        }
        protected void effi_t_change(object sender, EventArgs e)
        {
            //shows the following message when linkbutton is clicked.                   
            int rowindex = 0;
            DropDownList uom = (DropDownList)sender;
            DataGridItem item = (DataGridItem)uom.Parent.Parent;
            rowindex = item.ItemIndex;

            update_effi_t(Request.QueryString["ID"], gv_tasks.Items[rowindex].Cells[0].Text.ToString(), uom.SelectedValue.ToString());
        }
        protected void pt_change(object sender, EventArgs e)
        {
            //shows the following message when linkbutton is clicked.                   
            int rowindex = 0;
            DropDownList pt = (DropDownList)sender;
            DataGridItem item = (DataGridItem)pt.Parent.Parent;
            rowindex = item.ItemIndex;

            update_pt(Request.QueryString["ID"], gv_tasks.Items[rowindex].Cells[0].Text.ToString(), pt.SelectedValue.ToString());
        }
        protected void quom_change(object sender, EventArgs e)
        {
            //shows the following message when linkbutton is clicked.                   
            int rowindex = 0;
            DropDownList quom = (DropDownList)sender;
            DataGridItem item = (DataGridItem)quom.Parent.Parent;
            rowindex = item.ItemIndex;

            update_quom(Request.QueryString["ID"], gv_tasks.Items[rowindex].Cells[0].Text.ToString(), quom.SelectedValue.ToString());
        }


        protected void t_change(object sender, EventArgs e)
        {
            int rowindex = 0;
            Button tb = (Button)sender;
            DataGridItem item = (DataGridItem)tb.Parent.Parent;
            TextBox target = item.FindControl("tb_target") as TextBox;
            rowindex = item.ItemIndex;
            update_t(Request.QueryString["ID"], gv_tasks.Items[rowindex].Cells[0].Text.ToString(), target.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (tb_new_task_name.Text.Length < 1)
            {
                lbl_err.Visible = true;
                lbl_err.Text = "New Task Name field is empty!";
            }
           
            else
            {
                if (!exist_project_task(Request.QueryString["ID"], tb_new_task_name.Text))
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("sp_add_new_task_to_project", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@project", SqlDbType.Int).Value = Request.QueryString["ID"];
                    cmd.Parameters.Add("@task", SqlDbType.NVarChar).Value = tb_new_task_name.Text;
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        Response.Redirect(Request.RawUrl);
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
                else
                {
                    lbl_err.Visible = true;
                    lbl_err.Text = "Task Already exist!";
                }
            }
        }
        protected bool exist_project_task(string project_id, string task_name)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "select top(1) p.project_id from int_project_task_type ipt  join task_type t on t.task_type_id=ipt.task_type_id join project p on p.project_id=ipt.project_id where p.project_id = '" + project_id + "' and task_type_name='" + task_name + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                object res = cmd.ExecuteScalar();
                if (res != DBNull.Value && res != null)
                    result = true;
                else
                    result = false;
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

        protected void nddl_iris_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Unnamed14_CheckedChanged(object sender, EventArgs e)
        {
            fill_project_data(Request.QueryString["ID"], cb_nonactive.Checked);
        }

        protected void gv_tasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddl_topic_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void nddl_topic_SelectedIndexChanged(object sender, EventArgs e)
        {
            nddl_topic.BackColor = System.Drawing.Color.White;
        }

        protected void Unnamed13_Click(object sender, EventArgs e)
        {

        }
    }
}