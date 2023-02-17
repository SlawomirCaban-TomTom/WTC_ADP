using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace TomTom_Info_Page
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected bool validate()
        {
            bool result = false;
            
                result = true;
            
            return result;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (validate())
            {
if (!Page.IsPostBack)
                {
                    load_gv();
                }
}
            else
Response.Redirect("http://infopage-lodz.ttg.global");
        }
        protected void load_gv()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WTCConnStr"].ConnectionString);
            DataTable temp = new DataTable();
            
            string query = string.Empty;

            //sumertime    
            //   query = "select user_name,remark,isnull([login time],'off')[login time],[worked time],[reported time] from (select user_id, cast(sum(duration)/60. as decimal(5,1)) as [reported time] from timesheet t join task ta on t.timesheet_id = ta.timesheet_id where user_id in (select user_id from v_adp_members) and datediff(dd, start_time_local, DATEADD(HOUR, 2, GETDATE()))= 0 and task_type_id<> 34 group by user_id) bb right join(select uu.user_id, uu.first_name + ' ' + uu.last_name  AS user_name, remark,[login time],[worked time] from users uu left join (SELECT        u.user_id, first_name + ' ' + last_name  AS user_name, remark AS last_name, start_time_local, right(left((convert(nvarchar, DATEADD(HOUR, 2, start_time_local), 113)), 17), 5) as [login time], cast((datediff(mi, start_time_local, GETDATE()) / 60.) as decimal(5, 1)) as [worked time] FROM dbo.users u  join timesheet t on u.user_id = t.user_id where remark in ('ADP','TSD') and end_time_local is null) a  on a.user_id = uu.user_id where remark in ('ADP','TSD') )cc on bb.user_id = cc.user_id order by 2,3,5,1 ";
            //winter time
            //query = "select user_name,team_name,isnull([login time],'off')[login time],[worked time],[reported time] from (select user_id,cast(sum(duration) / 60. as decimal(5, 1)) as [reported time] from timesheet t join task ta on t.timesheet_id = ta.timesheet_id    where  datediff(dd, start_time_local, DATEADD(HOUR, 1, GETDATE())) = 0  and t.end_time_local is not null group by user_id) bb  right join(select uu.user_id, uu.first_name + ' ' + uu.last_name  AS user_name, uu.team_name,team_id,[login time],[worked time] from v_adp_members  uu left join (SELECT        u.user_id, first_name + ' ' + last_name  AS user_name, team_name,team_id AS last_name, start_time_local,  right(left((convert(nvarchar, DATEADD(HOUR, utc, start_time_local), 113)), 17), 5) as [login time],  cast((datediff(mi, start_time_local, GETDATE()) / 60.) as decimal(5, 1)) as [worked time]  FROM dbo.v_adp_members u join timesheet t on u.user_id = t.user_id where end_time_local is null) a on a.user_id = uu.user_id )cc on bb.user_id = cc.user_id order by 2,3,5,1
            // query = "select user_name,team_name,isnull([login time CET],'off')[login time CET],isnull([login time IST],'off')[login time IST],[worked time],[reported time] from (select user_id,cast(sum(duration) / 60. as decimal(5, 1)) as [reported time] from timesheet t join task ta on t.timesheet_id = ta.timesheet_id    where  datediff(dd, start_time_local, DATEADD(HOUR, 1, GETDATE())) = 0  and t.end_time_local is not null group by user_id) bb  right join(select uu.user_id, uu.first_name + ' ' + uu.last_name  AS user_name, uu.team_name,team_id,[login time CET],[login time IST],[worked time] from v_adp_members  uu left join (SELECT        u.user_id, first_name + ' ' + last_name  AS user_name, team_name,team_id AS last_name, start_time_local,  right(left((convert(nvarchar, DATEADD(HOUR, 1, start_time_local), 113)), 17), 5) as [login time CET], right(left((convert(nvarchar, DATEADD(HOUR, 5, start_time_local), 113)), 17), 5) as [login time IST],  cast((datediff(mi, start_time_local, GETDATE()) / 60.) as decimal(5, 1)) as [worked time]  FROM dbo.v_adp_members u join timesheet t on u.user_id = t.user_id where end_time_local is null) a on a.user_id = uu.user_id )cc on bb.user_id = cc.user_id order by 2,3,5,1\n\n";
            query = "select * from v_adp_active_members order by 2,3,5,1";
            SqlDataAdapter cmd = new SqlDataAdapter(query, conn);
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
      
    }

}
