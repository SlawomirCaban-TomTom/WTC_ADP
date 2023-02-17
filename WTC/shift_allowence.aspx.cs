using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
namespace TomTom_Info_Page.WTC
{
    public partial class shift_allowence : System.Web.UI.Page
    {
        public static string main_query11 = string.Empty;
        public static string date_query = string.Empty;
        public static string csv_dump = string.Empty;
        public static int run_filter = 0;
        public string name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        protected int validate_user1()
        {
            int role_id = 0;
            //bool result11 = false;
            var identity = User.Identity.Name;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            //string query = "select user_id,first_name from users where domain_username='" + name + "' ";
            string query = "select user_id,first_name from users where domain_username='" + identity + "' ";
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
                    //fill_grid_allowence();
                }
                else
                {
                    lbl_err1.Visible = true;
                    lbl_err1.Text = "User not found in WTC database! Please contact TCO!";
                }
            }
            catch (Exception ex)
            {
                lbl_err1.Visible = true;
                lbl_err1.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            Session["role"] = role_id;
            return role_id;
        }

        private void fill_team1()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            string query = "select team_id from teams order by 1";
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
                lbl_err1.Visible = true;
                lbl_err1.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            // ddl_team1.DataSource = dt;


            //ddl_team1.DataValueField = "team_id";
            //ddl_team1.DataTextField = "team_id";
            //ddl_team1.DataBind();
            //ddl_team1.Items.Insert(0, "--All teams--");

        }
        public void fill_user1()
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
                lbl_err1.Visible = true;
                lbl_err1.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            //ddl_user1.DataSource = dt;
            //ddl_user1.DataValueField = "user_id";
            //ddl_user1.DataTextField = "user_name";
            //ddl_user1.DataBind();
            //ddl_user1.Items.Insert(0, "--All Users--");


        }
        //public void fill_user1(string team_id)
        //{
        //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
        //    string query = "select u.user_id,user_name from users u join user_team ut on u.user_id=ut.user_id where team_id=" + ddl_team1.SelectedItem.Value + " order by user_name";
        //    SqlDataAdapter da = new SqlDataAdapter(query, conn);
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        conn.Open();
        //        //da.FillSchema(ds, SchemaType.Source, "project_types_id");
        //        da.Fill(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        lbl_err1.Visible = true;
        //        lbl_err1.Text = ex.ToString();
        //    }
        //    finally
        //    {
        //        conn.Close();
        //        conn.Dispose();
        //    }

        //    ddl_user1.DataSource = dt;
        //    ddl_user1.DataValueField = "user_id";
        //    ddl_user1.DataTextField = "user_name";
        //    ddl_user1.DataBind();
        //    ddl_user1.Items.Insert(0, "--All team " + ddl_team1.SelectedItem.Value + " Users--");

        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fill_team1();
                fill_user1();
                int validate = validate_user1();
                if (validate > 0)
                {
                    menu_std.Visible = false;
                    Menu_mng1.Visible = true;
                    p_user1.Visible = true;

                    //          main_query11 = "SELECT CONVERT(VARCHAR(10),timesheet.start_time_server , 111) as Date ,users.first_name + ' ' + users.last_name as Employee_Name, Teams.team_name, Teams.lead_user_id, project.project_name, task_type.task_type_name as Task_Name, sub_task.sub_task_name as Sub_Task,round(cast(task.duration as float) / cast(60 as float),2) Time_hours , task.description,CASE  WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '06:00:00' AND '08:00:00' THEN 'Morning' WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '08:30:00' AND '11:00:00' THEN 'General' WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '11:00:00' AND '17:00:00' THEN 'Evening' ELSE '0' END AS shift" +
                    //" FROM Teams INNER JOIN user_team ON Teams.team_id = user_team.team_id RIGHT OUTER JOIN timesheet INNER JOIN users ON timesheet.user_id =users.user_id INNER JOIN task ON timesheet.timesheet_id = task.timesheet_id INNER JOIN task_type ON task.task_type_id = task_type.task_type_id INNER JOIN project ON task.project_id = project.project_id INNER JOIN sub_task ON task.sub_task_id = sub_task.sub_task_id ON user_team.user_id = users.user_id  inner join tool_task_type on tool_task_type.task_type_id=task_type.task_type_id inner join tool on tool_task_type.tool_type_id=tool.tool_type_id where timesheet.start_time_local between '07/01/2019' and '07/31/2019' union all" +
                    //" select CONVERT(VARCHAR(10),leaves.start_time_server , 111) as Date,leaves.first_name + ' ' + leaves.last_name as Employee_Name,null,null," +
                    // " project.project_name,task_type.task_type_name,null,SUM(round(cast(dbo.[leaves].duration as float) / cast(60 as  float),2)) as time_spent,leaves.description,null from leaves " +
                    // "INNER JOIN task_type ON leaves.task_type_id = task_type.task_type_id  INNER JOIN project ON leaves.project_id = project.project_id" +
                    //" where  user_id>1 and leaves.start_time_server between '07/01/2019' and '07/31/2019' group by leaves.start_time_server, leaves.first_name + ' ' + leaves.last_name , project.project_name, task_type.task_type_name, leaves.description ";

                    ////org//
                    DateTime now = DateTime.Now;
                    var startDate = new DateTime(now.Year, now.Month, 1);
                    var endDate = startDate.AddMonths(1).AddDays(-1);
                    //between '07/01/2019' and '07/31/2019' 
                    ///////////////code for store proceudre//////////////
                    //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
                    //string query = "shift_allowance";
                    //SqlCommand cmd = new SqlCommand(query, conn);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    main_query11 = "with shiftalloence as (select (timesheet.start_time_server)  ,users.first_name + ' ' + users.last_name as Employee_Name , " +
"CASE  WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '05:30:00' AND '08:00:00' THEN 'Morning' WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '08:01:00' AND '11:00:00' THEN 'General' WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '11:01:00' AND '17:00:00' THEN 'Evening' WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '17:01:00' AND '23:00:00' THEN 'Night' ELSE '0' END AS shift " +
"from timesheet join users on timesheet.user_id=users.user_id where  MONTH(timesheet.start_time_local)=MONTH(GETDATE()) " +
  "and  datename(WEEKDAY,timesheet.start_time_server)   in " +
"('Monday', 'Tuesday','Wednesday','Thursday','Friday') and MONTH(timesheet.start_time_server)=MONTH(GETDATE())  and YEAR(timesheet.start_time_server)=YEAR(GETDATE()) and start_time_server not in ( select timesheet.start_time_server from timesheet join leaves on timesheet.user_id=leaves.user_id where " +
 " CONVERT(varchar(10),timesheet.start_time_server,111) =CONVERT(varchar(10),leaves.start_time_server,111)" +
  "and task_type_name in ('leave','Half Day')" +
"))," +
"tt as  " +
 "(select shiftalloence.Employee_Name  ," +
 "COUNT(CASE WHEN shift = 'Morning' then 1 ELSE NULL END) as 'Morning', " +
   "COUNT(CASE WHEN shift = 'General' then 1 ELSE NULL END) as 'General' " +
     ",COUNT(CASE WHEN shift = 'Evening' then 1 ELSE NULL END) as 'Evening' " +
      ",COUNT(CASE WHEN shift = 'Night' then 1 ELSE NULL END) as 'Night' " +
    " from shiftalloence group by Employee_Name )" +
  "select * from tt ";


                    // main_query11 = "select ut.user_id,user_name,ut.team_id,team_name,convert(nvarchar,start_time_server,111) date,p.project_id,project_name,mppi_id,ta.task_type_id,task_name,st.sub_task_id,sub_task_name,t.timesheet_id,description,entities,duration/60. time_spent,tl.tool_type_id,tool_name from users u join timesheet t on u.user_id=t.user_id join task_type ta on t.timesheet_id=ta.timesheet_id join project p on ta.project_id=p.project_id join task tt on ta.task_type_id=tt.task_type_id left join sub_task st on ta.sub_task_id=st.sub_task_id left join tool tl on ta.tool_type_id=tl.tool_type_id left join user_team ut on u.user_id=ut.user_id left join Teams tea on ut.team_id=tea.team_id where u.user_id>1";
                    Session["query"] = main_query11;

                }
                else
                {
                    menu_std.Visible = true;
                    Menu_mng1.Visible = false;

                    main_query11 = "with shiftalloence as (select (timesheet.start_time_server)  ,users.first_name + ' ' + users.last_name as Employee_Name , " +
"CASE  WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '05:30:00' AND '08:00:00' THEN 'Morning' WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '08:01:00' AND '11:00:00' THEN 'General' WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '11:01:00' AND '17:00:00' THEN  'Evening' WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '17:01:00' AND '23:00:00' THEN 'Night' ELSE '0' END AS shift " +
"from timesheet join users on timesheet.user_id=users.user_id where  MONTH(timesheet.start_time_local)=MONTH(GETDATE()) " +
  "and  datename(WEEKDAY,timesheet.start_time_server)   in " +
"('Monday', 'Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday') and MONTH(timesheet.start_time_server)=MONTH(GETDATE())  and YEAR(timesheet.start_time_server)=YEAR(GETDATE()) and start_time_server not in ( select timesheet.start_time_server from timesheet join leaves on timesheet.user_id=leaves.user_id where " +
 " CONVERT(varchar(10),timesheet.start_time_server,111) =CONVERT(varchar(10),leaves.start_time_server,111)" +
  "and task_type_name in ('leave','Half Day')" +
"))," +
"tt as  " +
 "(select shiftalloence.Employee_Name  ," +
 "COUNT(CASE WHEN shift = 'Morning' then 1 ELSE NULL END) as 'Morning', " +
   "COUNT(CASE WHEN shift = 'General' then 1 ELSE NULL END) as 'General' " +
     ",COUNT(CASE WHEN shift = 'Evening' then 1 ELSE NULL END) as 'Evening' " +
     ",COUNT(CASE WHEN shift = 'Night' then 1 ELSE NULL END) as 'Night' " +
    " from shiftalloence group by Employee_Name )" +
  "select * from tt ";
                    //ar,start_time_server,111)date,u.user_id,p.project_id,project_name,mppi_id,ta.task_type_id,task_name,st.sub_task_id,sub_task_name,description,t.timesheet_id,entities,duration/60. time_spent,tl.tool_type_id,tool_name from users u join timesheet t on u.user_id=t.user_id join task_type ta on t.timesheet_id=ta.timesheet_id join project p on ta.project_id=p.project_id join task tt on ta.task_type_id=tt.task_type_id left join sub_task st on ta.sub_task_id=st.sub_task_id left join tool tl on ta.tool_type_id=tl.tool_type_id where u.user_id=" + Session["user"];
                    Session["query"] = main_query11;

                }
                // fill_grid1(run_filter1(Session["query"].ToString()));
                fill_grid1(Session["query"].ToString());
                //string base_query_grp = query.Substring(query.IndexOf("group by"));




            }

        }
        protected void UserListGridViewIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            gv_data111.PageIndex = e.NewPageIndex;
            fill_grid1(run_filter1(Session["query"].ToString()));

            // you data bind code
        }
        protected string create_csv1()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                // Response.Write("start date " + tb_start_date1.ToString() + "end date "+tb_end_date1.ToString());
                //"and Ends date " + tb_end_date1.ToString());

                //if (tb_start_date1.ToString() != null && tb_start_date1.ToString() != null)
                //{
                //    csv_dump = withdate();

                //}

                //else
                //{
                //    csv_dump = Session["query"].ToString();
                //}

                //string query = run_filter1(Session["query"].ToString());

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
                conn.Open();
                //SqlDataAdapter da = new SqlDataAdapter(csv_dump, conn);
                DataTable dt = new DataTable();
                dt = GetDataTable();

                //try
                //{


                //da.Fill(dt);
                string[] columnNames = dt.Columns.Cast<DataColumn>().
                                                 Select(column => column.ColumnName).
                                                 ToArray();
                sb.AppendLine(string.Join(";", columnNames));
                foreach (DataRow row in dt.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\"")).ToArray();
                    sb.AppendLine(string.Join(";", fields));
                }


                //}



            }
            catch (Exception ex)
            {
                lbl_err1.Visible = true;
                lbl_err1.Text = ex.ToString() + " " + csv_dump;
            }
            //finally
            //{
            //    conn.Close();
            //    conn.Dispose();
            //}
            return sb.ToString();
        }
        protected string run_filter1(string query)
        {


            //  string grp = "   group by leaves.start_time_server, leaves.first_name + ' ' + leaves.last_name , project.project_name, task_type.task_type_name, leaves.description ";
            //string sql2 = " union all select CONVERT(VARCHAR(10),leaves.start_time_server , 111) as Date,leaves.first_name + ' ' + leaves.last_name as Employee_Name,null,null, project.project_name,task_type.task_type_name,null,SUM(round(cast(dbo.[leaves].duration as float) / cast(60 as  float),2)) as time_spent,leaves.description,null from leaves INNER JOIN task_type ON leaves.task_type_id = task_type.task_type_id  INNER JOIN project ON leaves.project_id = project.project_id where  user_id>1 and leaves.start_time_server between '07/01/2019' and '07/31/2019' and user_id =120   group by leaves.start_time_server, leaves.first_name + ' ' + leaves.last_name , project.project_name, task_type.task_type_name, leaves.description";

            //string l = "group by";
            //string ll = "union";

            //int Pos2 = query.IndexOf(ll);

            string f = "FROM Teams";
            string part2 = " ) ," +
 "tt as (select distinct( CONVERT(VARCHAR(10),   start_time_server , 111) )as Date,Employee_Name," +
"  COUNT(CASE WHEN shift = 'Morning' then 1 ELSE NULL END) as 'Morning', " +
   " COUNT(CASE WHEN shift = 'General' then 1 ELSE NULL END) as 'General' " +
     ",COUNT(CASE WHEN shift = 'Evening' then 1 ELSE NULL END) as 'Evening' " +
    " ,count( distinct shiftallownececount.start_time_server) as totaldays  from shiftallownececount " +
    "group by shiftallownececount.start_time_server ,Employee_Name, team_name, lead_user_id, project_name, Task_Name, Time_hours ,description)" +
"select   tt.Employee_Name ,COUNT (tt.totaldays) from  tt  group by tt.Employee_Name";




            // string l = "group by";
            string l = " ) ,tt as";

            int Pos1 = query.IndexOf(f) + f.Length;


            int Pos2 = query.IndexOf(l);
            string FinalString1 = query.Substring(0, (Pos2 - 1));


            //string FinalString1 = query.Substring(0, (Pos2 - 1));
            // Response.Write("Final sub string inside  in filter  all q flll grid" + FinalString1);

            query = FinalString1;

            if (tb_start_date1.Text.Length > 4)
            {
                query = query + " and start_time_server >='" + tb_start_date1.Text + "'";
            }
            //else
            //{
            //    DateTime start_date = DateTime.Now.AddMonths(-1);
            //    query = query + " and start_time_server >='" + start_date.ToString() + "'";
            //}
            if (tb_end_date1.Text.Length > 4)
            {
                query = query + " and end_time_server <='" + DateTime.Parse(tb_end_date1.Text).AddDays(1).ToString() + "'";
            }
            //else
            //{
            //    DateTime end_date = DateTime.Now;
            //    query = query + " and start_time_server <'" + end_date.ToString() + "'";


            //}

            //if (ddl_team1.SelectedIndex > 0)
            //    query = query + " and Teams.team_id =" + ddl_team1.SelectedItem.Value;
            //if (ddl_user1.SelectedIndex > 0)
            //    query = query + " and users.user_id =" + ddl_user1.SelectedItem.Value;
            //if (ddl_project1.SelectedIndex > 0)
            //    query = query + " and project.project_name ='" + ddl_project1.SelectedItem.Text + "'";
            //if (ddl_task1.SelectedIndex > 0)
            //    query = query + " and task_type.task_type_name ='" + ddl_task1.SelectedItem.Text + "'";
            //if (ddl_sub_task1.SelectedIndex > 0)
            //    query = query + " and sub_task_name ='" + ddl_sub_task1.SelectedItem.Text + "'";
            //if (ddl_category.SelectedIndex > 0)
            //    query = query + " and catagories ='" + ddl_category.SelectedItem.Text + "'";
            //if (ddl_tool1.SelectedIndex > 0)
            //    query = query + " and tool.tools ='" + ddl_tool1.SelectedItem.Text + "'";

            return query + part2;
            //+ sql2 + "  order by date desc";


        }



        DataTable GetDataTable()
        {
            DataTable dt = new DataTable();

            // add the columns to the datatable    

            //if (gv_data111.HeaderRow != null)
            //{

            //    for (int i = 0; i < gv_data111.HeaderRow.Cells.Count; i++)
            //    {
            //        dt.Columns.Add(gv_data111.HeaderRow.Cells[i].Text);
            //    }
            //}
            dt.Columns.Add("Employee Name");
            //dt.Columns.Add("Emp ID");
            dt.Columns.Add("Morning ");
            dt.Columns.Add("General");
            dt.Columns.Add("Evening ");
            //    ;



            //  add each of the data rows to the table
            // gv_data111.AllowPaging = false;
            gv_data111.PagerSettings.Visible = false;

            //To Export all pages
            gv_data111.AllowPaging = false;

            int row_count = gv_data111.Rows.Count;
            foreach (GridViewRow row in gv_data111.Rows)
            {
                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dr[i] = row.Cells[i].Text.Replace(" ", "");
                }
                dt.Rows.Add(dr);
            }


            dt.DefaultView.Sort = "Employee Name";
            dt.DefaultView.ToTable();
            gv_data111.AllowPaging = true;
            return dt;
        }
        protected string withdate()
        {

            try
            {
                run_filter = 1;
                var startDate = tb_start_date1.Text.ToString();
                var endDate = tb_end_date1.Text.ToString();

                // Response.Write("datest"+startDate +"endate"+endDate);
                string query1 = "with shiftalloence as (select (timesheet.start_time_server)  ,users.first_name + ' ' + users.last_name as Employee_Name , " +
   "CASE  WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '05:30:00' AND '08:00:00' THEN 'Morning' WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '08:01:00' AND '11:00:00' THEN 'General' WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '11:01:00' AND '17:00:00' THEN 'Evening' WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '17:01:00' AND '23:00:00' THEN 'Night' ELSE '0' END AS shift " +
   "from timesheet join users on timesheet.user_id=users.user_id where  timesheet.start_time_local between  " + " ' " + startDate + " ' " + "  and " + " ' " + endDate + " ' " + " and  datename(WEEKDAY,timesheet.start_time_server)   in " +


   "('Monday', 'Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday')   and start_time_server not in ( select timesheet.start_time_server from timesheet join leaves on timesheet.user_id=leaves.user_id where " +
    " CONVERT(varchar(10),timesheet.start_time_server,111) =CONVERT(varchar(10),leaves.start_time_server,111)" +
     "and task_type_name in ('leave','Half Day')" +
   "))," +
   "tt as  " +
    "(select shiftalloence.Employee_Name ," +
    "COUNT(CASE WHEN shift = 'Morning' then 1 ELSE NULL END) as 'Morning', " +
      "COUNT(CASE WHEN shift = 'General' then 1 ELSE NULL END) as 'General' " +
        ",COUNT(CASE WHEN shift = 'Evening' then 1 ELSE NULL END) as 'Evening' " +
        ",COUNT(CASE WHEN shift = 'Night' then 1 ELSE NULL END) as 'Night' " +
       " from shiftalloence group by Employee_Name )" +
     "select * from tt ";

                date_query = query1;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);

                SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dt.DefaultView.Sort = "Employee_Name";
                dt = dt.DefaultView.ToTable();

                gv_data111.Visible = true;
                gv_data111.DataSource = dt;



                gv_data111.DataBind();
                lbl_results1.Text = "Number of rows: " + dt.Rows.Count;


            }
            catch (Exception ex)
            {
                lbl_err1.Visible = true;

                lbl_err1.Text = ex.ToString() + " " + date_query;
            }

            return date_query;
        }


        protected void on_tb_date_update1(object sender, EventArgs e)
        {
            //fill_grid1(run_filter1(Session["query"].ToString()));





        }
        protected void fill_grid1(string query)
        {
          

            // string l = "group by";

            //int Pos1 = query.IndexOf(f) + f.Length;


            //int Pos2 = query.IndexOf(l);
            //string FinalString = query.Substring(Pos1, (Pos2 - Pos1) - 1);

            //string FinalString = query.Substring(Pos1,( Pos2-1));
            // Response.Write("Final sub string inside flll grid" + query);

            //string base_query ="from Teams  " + FinalString;
            //string bb = query.Substring(query.IndexOf("group by"));
            //string news = query - bb;

            // string base_query = query.Substring(query.IndexOf("from"));
            //string base_query_grp = query.Substring(query.IndexOf("group by"));
            //Response.Write("base qqqqqqury " +base_query);
            // string base_query1 = query.Substring(query.IndexOf("group by "));
            //int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
            //int Pos2 = STR.IndexOf(LastString);
            //FinalString = STR.Substring(Pos1, Pos2 - Pos1);

            //var firstWordIndex = str.IndexOf(firstWord) + firstWord.Length;
            //var secondWordIndex = str.IndexOf(secondWord);

            //string grp = "  group by leaves.start_time_server, leaves.first_name + ' ' + leaves.last_name , project.project_name, task_type.task_type_name, leaves.description ";


            //base_query = base_query.Substring(0, base_query.IndexOf("order"));
            // string query1 = "select distinct project.project_name " + base_query + " order by project_name";
            // new string query1 = "select distinct project_name from project order by project_name ";
            //new  string query2 = "select distinct task_type_name from task_type order by task_type_name";
            //  string query2 = "select distinct task_type.task_type_name " + base_query + " order by task_type_name";
            // string query3 = "select distinct sub_task_name " + base_query + " order by sub_task_name";
            //string query4 = "select distinct catagories " + base_query + " order by catagories";
            //string query5 = "select distinct tool_name " + base_query + " order by tool_name";
            //new   string query5 = "select distinct tool_name from tool order by tool_name";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            //   SqlDataAdapter da1 = new SqlDataAdapter(query1, conn);
            //   SqlDataAdapter da2 = new SqlDataAdapter(query2, conn);
            ////   SqlDataAdapter da3 = new SqlDataAdapter(query3, conn);
            //   //SqlDataAdapter da4 = new SqlDataAdapter(query4, conn);
            //   SqlDataAdapter da5 = new SqlDataAdapter(query5, conn);


            //DataTable dt1 = new DataTable();
            //DataTable dt2 = new DataTable();
            //DataTable dt3 = new DataTable();
            ////DataTable dt4 = new DataTable();
            //DataTable dt5 = new DataTable();
            try
            {
                conn.Open();
                //da.FillSchema(ds, SchemaType.Source, "project_types_id");
                da.Fill(dt);
                //da1.Fill(dt1);
                // da2.Fill(dt2);
                //da3.Fill(dt3);
                //da4.Fill(dt4);
                //  da5.Fill(dt5);
                //ddl_project1.DataSource = dt1;
                //ddl_project1.DataTextField = "project_name";
                //ddl_project1.DataBind();

                //ddl_project1.Items.Insert(0, "--All Projects--");
                //ddl_task1.DataSource = dt2;
                //ddl_task1.DataTextField = "task_type_name";
                //ddl_task1.DataBind();
                //ddl_task1.Items.Insert(0, "--All Tasks--");

                //ddl_sub_task1.DataSource = dt3;
                //ddl_sub_task1.DataTextField = "sub_task_name";
                //ddl_sub_task1.DataBind();
                //ddl_sub_task1.Items.Insert(0, "--All Sub Tasks--");

                //ddl_category.DataSource = dt4;
                //ddl_category.DataTextField = "catagories";
                //ddl_category.DataBind();
                //ddl_category.Items.Insert(0, "--All Category--");

                //ddl_tool1.DataSource = dt5;
                //ddl_tool1.DataTextField = "tool_name";
                //ddl_tool1.DataBind();
                //ddl_tool1.Items.Insert(0, "--All tool--");

            }
            catch (Exception ex)
            {
                lbl_err1.Visible = true;
                lbl_err1.Text = ex.ToString() + " " + query;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            if (dt.Rows.Count > 0)
            {
                gv_data111.Visible = true;
                dt.DefaultView.Sort = "Employee_Name";
                dt.DefaultView.ToTable();
                gv_data111.DataSource = dt;
                gv_data111.DataBind();
                lbl_results1.Text = "Number of rows: " + dt.Rows.Count;
            }
            else
            {
                gv_data111.Visible = false;

                lbl_results1.Text = "No data";
            }

        }
        protected void fill_grid_allowence()
        {
            //string sql = "(SELECT CONVERT(VARCHAR(10),timesheet.start_time_server , 111) as Date ,users.first_name + ' ' + users.last_name as Employee_Name, Teams.team_name, Teams.lead_user_id, project.project_name, task_type.task_type_name as Task_Name, sub_task.sub_task_name as Sub_Task,round(cast(task.duration as float) / cast(60 as float),2) Time_hours , task.description,CASE  WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '06:00:00' AND '08:00:00' THEN 'Morning' WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '08:30:00' AND '11:00:00' THEN 'General' WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '11:00:00' AND '17:00:00' THEN 'Evening' ELSE '0' END AS shift";
            //sql=sql+"FROM Teams INNER JOIN user_team ON Teams.team_id = user_team.team_id RIGHT OUTER JOIN timesheet INNER JOIN users ON timesheet.user_id =users.user_id INNER JOIN task ON timesheet.timesheet_id = task.timesheet_id INNER JOIN task_type ON task.task_type_id = task_type.task_type_id INNER JOIN project ON task.project_id = project.project_id INNER JOIN sub_task ON task.sub_task_id = sub_task.sub_task_id ON user_team.user_id = users.user_id where timesheet.start_time_local between '07/01/2019' and '07/31/2019' union all";
            //sql=sql+"select CONVERT(VARCHAR(10),leaves.start_time_server , 111) as Date,leaves.first_name + ' ' + leaves.last_name as Employee_Name,null,null,";
            //sql=sql+"project.project_name,task_type.task_type_name,null,SUM(round(cast(dbo.[leaves].duration as float) / cast(60 as  float),2)) as time_spent,leaves.description,null from leaves";
            //sql=sql+"INNER JOIN task_type ON leaves.task_type_id = task_type.task_type_id  INNER JOIN project ON leaves.project_id = project.project_id";
            //sql=sql+"where leaves.start_time_server between '07/01/2019' and '07/31/2019' group by leaves.start_time_server, leaves.first_name + ' ' + leaves.last_name , project.project_name, task_type.task_type_name, leaves.description ";

            string st_date = tb_start_date1.Text.ToString();
            string end_date = tb_end_date1.Text.ToString();
            string sql = "SELECT CONVERT(VARCHAR(10),timesheet.start_time_server , 111) as Date ,users.first_name + ' ' + users.last_name as Employee_Name, Teams.team_name, Teams.lead_user_id, project.project_name, task_type.task_type_name as Task_Name, sub_task.sub_task_name as Sub_Task,round(cast(task.duration as float) / cast(60 as float),2) Time_hours , task.description,CASE  WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '06:00:00' AND '08:00:00' THEN 'Morning' WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '08:30:00' AND '11:00:00' THEN 'General' WHEN DATEADD(d, -DATEDIFF(d, 0, dbo.[timesheet].start_time_server), dbo.[timesheet].start_time_server) BETWEEN '11:00:00' AND '17:00:00' THEN 'Evening' ELSE '0' END AS shift" +
          " FROM Teams INNER JOIN user_team ON Teams.team_id = user_team.team_id RIGHT OUTER JOIN timesheet INNER JOIN users ON timesheet.user_id =users.user_id INNER JOIN task ON timesheet.timesheet_id = task.timesheet_id INNER JOIN task_type ON task.task_type_id = task_type.task_type_id INNER JOIN project ON task.project_id = project.project_id INNER JOIN sub_task ON task.sub_task_id = sub_task.sub_task_id ON user_team.user_id = users.user_id where timesheet.start_time_local between '07/01/2019' and '07/31/2019' union all" +
          " select CONVERT(VARCHAR(10),leaves.start_time_server , 111) as Date,leaves.first_name + ' ' + leaves.last_name as Employee_Name,null,null," +
           " project.project_name,task_type.task_type_name,null,SUM(round(cast(dbo.[leaves].duration as float) / cast(60 as  float),2)) as time_spent,leaves.description,null from leaves " +
           "INNER JOIN task_type ON leaves.task_type_id = task_type.task_type_id  INNER JOIN project ON leaves.project_id = project.project_id" +
          " where leaves.start_time_server between '07/01/2019' and '07/31/2019' group by leaves.start_time_server, leaves.first_name + ' ' + leaves.last_name , project.project_name, task_type.task_type_name, leaves.description ";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            SqlDataAdapter da11 = new SqlDataAdapter(sql, conn);
            DataTable dt11 = new DataTable();

            try
            {

                conn.Open();
                da11.Fill(dt11);
                dt11 = format_dt(dt11);
                GridView1.DataSource = dt11;

                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                lbl_err1.Visible = true;
                lbl_err1.Text = ex.ToString() + " " + sql;
            }









        }
        protected void Button111_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://infopage-lodz.tomtomgroup.com/wtc/wtc_main.aspx");
        }
        protected DataTable format_dt(DataTable dat)
        {
            DataTable t1 = dat;
            try
            {

                int c = t1.Rows.Count;
                for (int i = 0; i < c; i++)
                {
                    string str = String.Format("{0:F2}", t1.Rows[i][1]);
                    t1.Rows[i][1] = str;
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

            return t1;
        }
        private string ConvertSortDirectionToSql1(SortDirection sortDirection)
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


        protected void gridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.fill_grid1(run_filter1(Session["query"].ToString()));
            gv_data111.PageIndex = e.NewPageIndex;
            gv_data111.DataBind();
            // fill_grid1(run_filter1(Session["query"].ToString()));
            // this.fill_grid1(run_filter1(Session["query"].ToString()));
        }

        protected void gridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = gv_data111.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql1(e.SortDirection);

                gv_data111.DataSource = dataView;
                gv_data111.DataBind();
            }
        }

        protected void Unnamed33_Click(object sender, EventArgs e)
        {
            //fill_grid1(run_filter1(Session["query"].ToString()));

            withdate();

        }

        //protected void ddl_team1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    fill_grid1(run_filter1(Session["query"].ToString()));
        //    if (ddl_team1.SelectedIndex > 0)
        //        fill_user1(ddl_team1.SelectedItem.Value);
        //    else
        //        fill_user1();
        //}

        //protected void ddl_user1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    fill_grid1(run_filter1(Session["query"].ToString()));
        //}

        protected void Unnamed55_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=dump.csv");
            Response.Write(create_csv1());
            Response.End();
        }

        protected void ddl_project1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_grid1(run_filter1(Session["query"].ToString()));

        }

        protected void ddl_task1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_grid1(run_filter1(Session["query"].ToString()));

        }

        protected void ddl_sub_task1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_grid1(run_filter1(Session["query"].ToString()));

        }

        protected void Unnamed44_Click(object sender, EventArgs e)
        {

            run_filter = 0;
            // Response.Redirect(Request.RawUrl);
            Server.Transfer("~/shift_allowence.aspx");


        }

        //protected void ddl_category_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    fill_grid1(run_filter1(Session["query"].ToString()));
        //}

        protected void ddl_tool1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_grid1(run_filter1(Session["query"].ToString()));
        }

        protected void Unnamed555_Click(object sender, EventArgs e)
        {
            fill_grid_allowence();
        }

        protected void Button22_Click(object sender, EventArgs e)
        {

        }


        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=Dump.csv");

            //Response.AppendHeader("content-disposition","attachment;filename=Dump.csv");
            //Response.Charset = "";
            //   Response.ContentType = "application/csv";
            Response.AddHeader("content-disposition", "attachment;filename=Dump.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            //System.IO.StringWriter sw = new System.IO.StringWriter();
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gv_data111.AllowPaging = false;
            //gv_data111.DataBind();fill_grid1
            if (run_filter == 1)
            { withdate(); }
            else
            { fill_grid1(Session["query"].ToString()); }
            gv_data111.DataBind();

            gv_data111.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gv_data111.HeaderRow.Cells)
            {
                cell.BackColor = gv_data111.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gv_data111.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gv_data111.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gv_data111.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }
            gv_data111.RenderControl(hw);
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            Response.End();
            gv_data111.AllowPaging = true;
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_data111.PageIndex = e.NewPageIndex;
            // fill_grid1(run_filter1(Session["query"].ToString()));
            fill_grid1(Session["query"].ToString());
            // this.fill_grid1(run_filter1(Session["query"].ToString()));

        }
    }


}