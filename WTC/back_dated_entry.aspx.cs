using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Threading;
using System.Data.SqlTypes;
using System.Drawing;
namespace TomTom_Info_Page.WTC
{
    public partial class back_dated_entry : System.Web.UI.Page
    {
        public static DataTable reported;
        public static int reported_time;
        public SqlConnection conn;
        public SqlCommand cmd;
        public SqlDataAdapter da;
        public DataSet ds;
        public DataTable dt;
        public string sql1;
        public int state = 0;
        public int timesheet_id;


      


        private void fill_leave_type()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "select leave_type_name, leave_type_id from leave_type order by 2";
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

            ddl_leave_type.DataSource = dt;
            ddl_leave_type.DataValueField = "leave_type_id";
            ddl_leave_type.DataTextField = "leave_type_name";
            ddl_leave_type.DataBind();
            ddl_leave_type.Items.Insert(0, "--Select--");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 180;
            Page.EnableViewState = true;
            Page.MaintainScrollPositionOnPostBack = true;


            if (!Page.IsPostBack)
            {

                if (check_login())
                {
                    lbl_date.Visible = true;
                    report_time.Visible = true;
                    fill_leave_type();
                    state++;
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert(' User not started work!')</script>");
                   // Response.Redirect("https://wtcadp.azurewebsites.net/wtc/wtc_main.aspx");
                }
            }
           
        }
        public bool check_login()
        {
            string user = Request.LogonUserIdentity.Name;

            bool result = false;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "select user_id,first_name, last_name from users where domain_username='" + User.Identity.Name + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                da.Fill(dt);

                Session["user"] = dt.Rows[0][0].ToString();
                lbl_name.Text = "Hi " + dt.Rows[0][1].ToString() + "!";
                lbl_firstname.Text = dt.Rows[0][1].ToString();
                lbl_lastname.Text = dt.Rows[0][2].ToString();
                string query2 = "select timesheet_id,start_time_local from timesheet where user_id =" + Session["user"] + " and end_time_local is null";
                SqlDataAdapter da2 = new SqlDataAdapter(query2, conn);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    timesheet_id = Convert.ToInt32(dt2.Rows[0][0]);


                    Session["timesheet"] = dt2.Rows[0][0].ToString();
                    lbl_date.Text = dt2.Rows[0][1].ToString();
                    Session["login_time"] = DateTime.Parse(dt2.Rows[0][1].ToString());
                    lbl_date.Text = "Start time: " + DateTime.Parse(Session["login_time"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");

                    result = true;
                }
                else
                    result=false;
                //lbl_err.Visible = true;
                //lbl_err.Text = "User not found in WTC database! Please contact TCO!";

            }
            catch (Exception ex)
            {

                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString();
                result = false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return result;
        }


        protected void Unnamed7_Click(object sender, EventArgs e)
        {

            try
            {
                string user = User.Identity.Name;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);

                string query4 = "select user_id,first_name, last_name from users where domain_username='" + user + "' ";
                SqlDataAdapter da4 = new SqlDataAdapter(query4, conn);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                Session["user"] = dt4.Rows[0][0].ToString();
                //  string query3 = "select  local_time, start_time_server, end_time_server, first_name, last_name, domain_username, task_type_id,  duration, description, task_type_name from leaves where user_id='" + Session["user"] + "' ";

                string query = "";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd = new SqlCommand(query, conn);
                conn.Open();
                int cnt1;
                string sql22 = "select start_time_server, task_type_name from leaves where  user_id='" + Session["user"] + "'  " + " and  start_time_server = '" + txtdate.Text + "'   ";
                cmd = new SqlCommand(sql22, conn);
                SqlDataAdapter da5 = new SqlDataAdapter(cmd);


                // ds = new DataSet();
                //da.Fill(ds, "Leaves");
                DataTable dt_samerec = new DataTable();
                da5.Fill(dt_samerec);
                cnt1 = dt_samerec.Rows.Count;

                // cnt1 = ds.Tables[0].Rows.Count;
                int smtask = 0;
                int i = 0;
                //  Response.Write("count isssss" + cnt1);
                for (i = 0; i < cnt1; i++)
                {
                    if (ddl_leave_type.SelectedItem.Text == dt_samerec.Rows[i][1].ToString())
                        smtask++;

                }
                // int timesheet_id = Convert.ToInt32(Session["timesheet_id"]);


                if (smtask > 0)
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert(' You can not insert Record,its already  present  ')</script>");
                    Server.Transfer("~/wtc/back_dated_entry.aspx");

                }

                else
                {
                    if (txtdate.Text.Equals(""))
                    {
                        Response.Write("<script LANGUAGE='JavaScript' >alert(' Please Select Date')</script>");
                        txtdate.BorderColor = Color.Red;
                    }



                    else if (ddl_leave_type.SelectedValue.Equals("249"))
                    {
                        int cnt;
                        string sql2 = "select * from leaves  ";
                        cmd = new SqlCommand(sql2, conn);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds, "Leaves1");
                        cnt = ds.Tables[0].Rows.Count;
                        cnt++;

                        SqlDateTime sqldatenull = SqlDateTime.Null;
                        string a = "1/1/1900 12:00:00 AM";
                        string tt1 = txtdate.Text;

                        if (tt1.Equals(a))
                        {
                            txtdate.Text = "ffffff";
                        }

                        sql1 = " insert into leaves (timesheet_id, user_id, local_time, start_time_server, end_time_server, first_name, last_name, domain_username, task_type_id,  duration, description, task_type_name ) "
                       + "values ('" + Session["timesheet"] + "', "
                              + " '" + Session["user"] + "', dateadd(\"mi\",(select utc from users where user_id=" + Session["user"].ToString() +"),getdate()), '" + txtdate.Text + "' , '" + txtdate.Text + "','" + lbl_firstname.Text + "', '" + lbl_lastname.Text + "', '" + user + "', '" + ddl_leave_type.SelectedValue + "', "
                             + " '480', '" + txt_desc.Text + "', '" + ddl_leave_type.SelectedItem.Text + "') ";

                        cmd = new SqlCommand(sql1, conn);
                        cmd.ExecuteNonQuery();
                        Server.Transfer("~/WTC/leaves_history.aspx");
                    }

                    else if (ddl_leave_type.SelectedValue.Equals("954"))
                    {
                        int cnt;
                        string sql2 = "select * from leaves ";
                        cmd = new SqlCommand(sql2, conn);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds, "Leaves");
                        cnt = ds.Tables[0].Rows.Count;
                        cnt++;

                        SqlDateTime sqldatenull = SqlDateTime.Null;
                        string a = "1/1/1900 12:00:00 AM";
                        string tt1 = txtdate.Text;

                        if (tt1.Equals(a))
                        {
                            txtdate.Text = "ffffff";
                        }

                        sql1 = " insert into leaves (timesheet_id, user_id, local_time, start_time_server, end_time_server, first_name, last_name, domain_username, task_type_id,  duration, description, task_type_name ) values ('" + Session["timesheet"] + "', " +
                               " '" + Session["user"] + "', dateadd(\"mi\",(select utc from users where user_id=" + Session["user"].ToString() + "),getdate()), '" + txtdate.Text + "' , '" + txtdate.Text + "','" + lbl_firstname.Text + "', '" + lbl_lastname.Text + "', '" + user + "', '" + ddl_leave_type.SelectedValue + "', " +
                               " '240', '" + txt_desc.Text + "', '" + ddl_leave_type.SelectedItem.Text + "') ";

                        cmd = new SqlCommand(sql1, conn);
                        cmd.ExecuteNonQuery();
                        Server.Transfer("~/WTC/leaves_history.aspx");
                    }

                    else if (ddl_leave_type.SelectedValue.Equals("10"))
                    {
                        int cnt;
                        string sql2 = "select * from leaves ";
                        cmd = new SqlCommand(sql2, conn);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds, "Leaves");
                        cnt = ds.Tables[0].Rows.Count;
                        cnt++;

                        SqlDateTime sqldatenull = SqlDateTime.Null;
                        string a = "1/1/1900 12:00:00 AM";
                        string tt1 = txtdate.Text;

                        if (tt1.Equals(a))
                        {
                            txtdate.Text = "ffffff";
                        }

                        sql1 = " insert into leaves (timesheet_id, user_id, local_time, start_time_server, end_time_server, first_name, last_name, domain_username, task_type_id,  duration, description, task_type_name ) values ('" + Session["timesheet"] + "', " +
                               " '" + Session["user"] + "', dateadd(\"mi\",(select utc from users where user_id=" + Session["user"].ToString() + "),getdate()), '" + txtdate.Text + "' , '" + txtdate.Text + "','" + lbl_firstname.Text + "', '" + lbl_lastname.Text + "', '" + user + "', '" + ddl_leave_type.SelectedValue + "', " +
                               " '30', '" + txt_desc.Text + "', '" + ddl_leave_type.SelectedItem.Text + "') ";

                        cmd = new SqlCommand(sql1, conn);
                        cmd.ExecuteNonQuery();
                        Server.Transfer("~/WTC/leaves_history.aspx");
                        //Server.Transfer("leave_wtc.aspx");
                    }

                    else if (ddl_leave_type.SelectedValue.Equals("407"))
                    {
                        int cnt;
                        string sql2 = "select * from leaves ";
                        cmd = new SqlCommand(sql2, conn);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds, "Leaves");
                        cnt = ds.Tables[0].Rows.Count;
                        cnt++;

                        SqlDateTime sqldatenull = SqlDateTime.Null;
                        string a = "1/1/1900 12:00:00 AM";
                        string tt1 = txtdate.Text;

                        if (tt1.Equals(a))
                        {
                            txtdate.Text = "ffffff";
                        }

                        //sql1 = " insert into timesheet (timesheet_id, user_id, start_local_time, start_time_server, end_time_local, end_time_server, login_workstation, login_by, logout_workstation, logout_by) values ('" + cnt + "', " +
                        //       " '" + Session["user"] + "', '" + txtdate.Text + "', '" + + "', ' ', ' ', ' ') ";

                        sql1 = " insert into leaves (timesheet_id, user_id, local_time, start_time_server, end_time_server, first_name, last_name, domain_username, task_type_id,  duration, description, task_type_name ) values ('" + Session["timesheet"] + "', " +
                               " '" + Session["user"] + "', dateadd(\"mi\",(select utc from users where user_id=" + Session["user"].ToString() + "),getdate()), '" + txtdate.Text + "' , '" + txtdate.Text + "','" + lbl_firstname.Text + "', '" + lbl_lastname.Text + "', '" + user + "', '" + ddl_leave_type.SelectedValue + "', " +
                               " '30', '" + txt_desc.Text + "', '" + ddl_leave_type.SelectedItem.Text + "') ";
                        //, '" + User.Identity.Name + "', '" + Request.UserHostName + "', '" + User.Identity.Name + "'

                        cmd = new SqlCommand(sql1, conn);
                        cmd.ExecuteNonQuery();
                        Server.Transfer("~/WTC/leaves_history.aspx");
                        //Server.Transfer("leave_wtc.aspx");
                    }

                    else if (ddl_leave_type.SelectedValue.Equals("955"))
                    {
                        int cnt;
                        int delay_time;
                        string sql2 = "select * from leaves ";
                        cmd = new SqlCommand(sql2, conn);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds, "Leaves");
                        cnt = ds.Tables[0].Rows.Count;
                        cnt++;
                        delay_time = Convert.ToInt32(txt_time.Text);
                        SqlDateTime sqldatenull = SqlDateTime.Null;
                        string a = "1/1/1900 12:00:00 AM";
                        string tt1 = txtdate.Text;

                        if (tt1.Equals(a))
                        {
                            txtdate.Text = "ffffff";
                        }

                        //sql1 = " insert into timesheet (timesheet_id, user_id, start_local_time, start_time_server, end_time_local, end_time_server, login_workstation, login_by, logout_workstation, logout_by) values ('" + cnt + "', " +
                        //       " '" + Session["user"] + "', '" + txtdate.Text + "', '" + + "', ' ', ' ', ' ') ";
                        //use Request.UserHostName to get system number 
                        //org :sql
                        //sql1 = " insert into leaves (timesheet_id, user_id, local_time, start_time_server, end_time_server, first_name, last_name, domain_username, task_type_id,  duration, description, task_type_name ) values ('" + cnt + "', " +
                        //       " '" + Session["user"] + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + txtdate.Text + "' , '" + txtdate.Text + "','" + lbl_firstname.Text + "', '" + lbl_lastname.Text + "', '" + User.Identity.Name + "', '" + ddl_leave_type.SelectedValue + "', " +
                        //       " '30', '" + txt_desc.Text + "', '" + ddl_leave_type.SelectedItem.Text + "') ";

                        //new sql
                        //Response.Write("Current seesion id" + Session["timesheet_id"]);
                        sql1 = " insert into leaves (timesheet_id, user_id, local_time, start_time_server, end_time_server, first_name, last_name, domain_username, task_type_id,  duration, description, task_type_name ) values ('" + Session["timesheet"] + "', " +
                               " '" + Session["user"] + "', dateadd(\"mi\",(select utc from users where user_id=" + Session["user"].ToString() + "),getdate()), '" + txtdate.Text + "' , '" + txtdate.Text + "','" + lbl_firstname.Text + "', '" + lbl_lastname.Text + "', '" + user + "', '" + ddl_leave_type.SelectedValue + "', " +
                               " '" + delay_time + "', '" + txt_desc.Text + "', '" + ddl_leave_type.SelectedItem.Text + "') ";


                        cmd = new SqlCommand(sql1, conn);
                        cmd.ExecuteNonQuery();
                        Server.Transfer("~/WTC/leaves_history.aspx");
                        //Server.Transfer("leave_wtc.aspx");
                    }

                    else if (ddl_leave_type.SelectedValue.Equals("957"))
                    {
                        // <asp:ListItem Text="Other" Value="957" />
                        if (txt_desc.Text.Equals(""))
                        {
                            Response.Write("<script Language='JavaScript'>alert('Please add remark in Description')</script> ");
                            txt_desc.BorderColor = Color.Red;

                        }
                        else
                        {

                            int cnt;
                            int delay_time;
                            string sql2 = "select * from leaves ";
                            cmd = new SqlCommand(sql2, conn);
                            da = new SqlDataAdapter(cmd);
                            ds = new DataSet();
                            da.Fill(ds, "Leaves");
                            cnt = ds.Tables[0].Rows.Count;
                            cnt++;
                            delay_time = Convert.ToInt32(txt_time.Text);
                            SqlDateTime sqldatenull = SqlDateTime.Null;
                            string a = "1/1/1900 12:00:00 AM";
                            string tt1 = txtdate.Text;

                            if (tt1.Equals(a))
                            {
                                txtdate.Text = "ffffff";
                            }

                            //sql1 = " insert into timesheet (timesheet_id, user_id, start_local_time, start_time_server, end_time_local, end_time_server, login_workstation, login_by, logout_workstation, logout_by) values ('" + cnt + "', " +
                            //       " '" + Session["user"] + "', '" + txtdate.Text + "', '" + + "', ' ', ' ', ' ') ";
                            //use Request.UserHostName to get system number 
                            //org :sql
                            //sql1 = " insert into leaves (timesheet_id, user_id, local_time, start_time_server, end_time_server, first_name, last_name, domain_username, task_type_id,  duration, description, task_type_name ) values ('" + cnt + "', " +
                            //       " '" + Session["user"] + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + txtdate.Text + "' , '" + txtdate.Text + "','" + lbl_firstname.Text + "', '" + lbl_lastname.Text + "', '" + User.Identity.Name + "', '" + ddl_leave_type.SelectedValue + "', " +
                            //       " '30', '" + txt_desc.Text + "', '" + ddl_leave_type.SelectedItem.Text + "') ";

                            //new sql
                            //Response.Write("Current seesion id" + Session["timesheet_id"]);
                            sql1 = " insert into leaves (timesheet_id, user_id, local_time, start_time_server, end_time_server, first_name, last_name, domain_username, task_type_id,  duration, description, task_type_name ) values ('" + Session["timesheet"] + "', " +
                                   " '" + Session["user"] + "', dateadd(\"mi\",(select utc from users where user_id=" + Session["user"].ToString() + "),getdate()), '" + txtdate.Text + "' , '" + txtdate.Text + "','" + lbl_firstname.Text + "', '" + lbl_lastname.Text + "', '" + user + "', '" + ddl_leave_type.SelectedValue + "', " +
                                   " '" + delay_time + "', '" + txt_desc.Text + "', '" + ddl_leave_type.SelectedItem.Text + "') ";


                            cmd = new SqlCommand(sql1, conn);
                            cmd.ExecuteNonQuery();
                            Server.Transfer("~/WTC/leaves_history.aspx");

                        }

                    }

                    else if (ddl_leave_type.SelectedValue.Equals("956"))
                    {
                        int cnt;
                        int delay_time;

                        string sql2 = "select * from leaves ";
                        cmd = new SqlCommand(sql2, conn);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds, "Leaves");
                        cnt = ds.Tables[0].Rows.Count;
                        cnt++;

                        SqlDateTime sqldatenull = SqlDateTime.Null;
                        string a = "1/1/1900 12:00:00 AM";
                        string tt1 = txtdate.Text;
                        delay_time = Convert.ToInt32(txt_time.Text);

                        if (tt1.Equals(a))
                        {
                            txtdate.Text = "ffffff";
                        }

                        //sql1 = " insert into timesheet (timesheet_id, user_id, start_local_time, start_time_server, end_time_local, end_time_server, login_workstation, login_by, logout_workstation, logout_by) values ('" + cnt + "', " +
                        //       " '" + Session["user"] + "', '" + txtdate.Text + "', '" + + "', ' ', ' ', ' ') ";
                        //use Request.UserHostName to get system number 
                        sql1 = " insert into leaves (timesheet_id, user_id, local_time, start_time_server, end_time_server, first_name, last_name, domain_username, task_type_id,  duration, description, task_type_name ) values ('" + Session["timesheet"] + "', " +
                               " '" + Session["user"] + "', dateadd(\"mi\",(select utc from users where user_id=" + Session["user"].ToString() + "),getdate()), '" + txtdate.Text + "' , '" + txtdate.Text + "','" + lbl_firstname.Text + "', '" + lbl_lastname.Text + "', '" + user + "', '" + ddl_leave_type.SelectedValue + "', " +
                               " '" + delay_time + "', '" + txt_desc.Text + "', '" + ddl_leave_type.SelectedItem.Text + "') ";
                        //, '" + User.Identity.Name + "', '" + Request.UserHostName + "', '" + User.Identity.Name + "'

                        cmd = new SqlCommand(sql1, conn);
                        cmd.ExecuteNonQuery();
                        Server.Transfer("~/WTC/leaves_history.aspx");
                        //Server.Transfer("leave_wtc.aspx");
                    }




                }


            }
            catch (Exception ex)
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
                string query = "";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd = new SqlCommand(query, conn);
                conn.Close();
                conn.Dispose();
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString();
                //bt_break.Enabled = true;
            }
            finally
            {
                txt_time.Visible = false;
                lb_dely_time.Visible = false;


                txtdate.Text = "";
                txt_desc.Text = "";
                ddl_leave_type.SelectedItem.Text = "";
                txt_time.Text = "";

                //ddl_project.
            }
        }
        protected void gvVochByDate_RowCommand(object sender, GridViewDeleteEventArgs e)
        {
            DataTable temp = (DataTable)Session["reported"];
            string query = "delete from leaves where timesheet_id=" + temp.Rows[e.RowIndex][0].ToString() +  " and task_type_id=" +temp.Rows[e.RowIndex][7].ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
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

        protected void ddl_lave_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (int.Parse(ddl_leave_type.SelectedValue)>900)
                {
                    txt_time.Visible = true;
                    lb_dely_time.Visible = true;
                }
                else
                {
                    txt_time.Visible = false;
                    lb_dely_time.Visible = false;
                }
            }
            catch (Exception ex)
            {

                Response.Write("" + ex);
            }
        }

        protected void txt_time_TextChanged(object sender, EventArgs e)
        {

            if (txt_time.Text.Length > 2)
            {
                //MessageBox.Show("Can Enter only two Characters in this Textbox.", "Textbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Response.Write("<script LANGUAGE='JavaScript' >alert(' Please enter time in two digit. MAX time you can report:99 Min')</script>");
            }



        }
       
        

    }
}