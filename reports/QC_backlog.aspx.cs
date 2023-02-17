using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace TomTom_Info_Page.reports
{
    public partial class QC_backlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fill_grid();
        }
        protected void fill_grid()
        {
            //string query = "select c.projectname \"project name\", count(a.taskid) \"qc task count\", SUM(Date_part('day', statement_timestamp() - time)*24 + Date_part('hour', statement_timestamp() - time)) as \"aging hrs\", Round(CAST(SUM(Date_part('day', statement_timestamp() - time)*24 + Date_part('hour', statement_timestamp() - time)) / count(a.taskid) as numeric),1) as \"avg. hrs per task\" FROM iris_rprod_cpp_r2.statuschanges a inner join iris_rprod_cpp_r2.irisusers u on a.username = u.username, iris_rprod_cpp_r2.tasks c, iris_rprod_cpp_r2.projects e, (SELECT max(statuschanges.statuschangeid) AS maxId FROM iris_rprod_cpp_r2.tasks, iris_rprod_cpp_r2.statuschanges WHERE statuschanges.taskid = tasks.taskid and tasks.status = 'QC' GROUP BY statuschanges.taskid) b WHERE a.statuschangeid = b.maxId and a.status = 'QC' and a.taskid=c.taskid and e.projectname=c.projectname and u.companydepartment IN ('TomTom Polska Sp.Z.o.o. : MAPS-Competence Center', 'TomTom Polska Sp.Z.o.o. : MAPS-CO DPU Poland') and e.projectactive = true group by c.projectname order by \"avg. hrs per task\" DESC  ";
            string query = "select c.projectname \"project\",    count(a.taskid) \"qc tasks count\",   SUM(Date_part('day', now()::timestamp - time::timestamp)*24 +  Date_part('hour',  now()::timestamp - time::timestamp)) as \"aging hrs\",  SUM(Date_part('day', now()::timestamp - time::timestamp)*24 +  Date_part('hour',  now()::timestamp - time::timestamp)) /   count(a.taskid) \"avg. hrs per qc task\"          FROM  iris_rprod_cpp_r2.statuschanges a, iris_rprod_cpp_r2.tasks c, iris_rprod_cpp_r2.irisusers i, iris_rprod_cpp_r2.projects e,                                (SELECT max(statuschanges.statuschangeid) AS maxId                 FROM                       iris_rprod_cpp_r2.tasks,                       iris_rprod_cpp_r2.statuschanges                  WHERE                       statuschanges.taskid = tasks.taskid and                      tasks.status = 'QC'                   GROUP BY statuschanges.taskid ) b  WHERE       a.statuschangeid = b.maxId and       a.status = 'QC' and       a.taskid = c.taskid and       a.username = i.username and       i.companydepartment in ('TomTom Polska Sp.Z.o.o. : CO DPU Poland',                                       'TomTom Polska Sp.Z.o.o. : MAPS-CO DPU Poland',                                       'TomTom Polska Sp.Z.o.o. : MAPS-Competence Center',                                       'MAPS-Competence Center') and       c.projectname = e.projectname and       e.projectactive = true and not        c.projectname like '%training%'and not        c.projectname like '%Training%'         GROUP BY project  ORDER BY \"avg. hrs per qc task\" DESC";
            string query2 = "SELECT     c.projectname \"project\",    lower(a.username) \"production user\",    c.claimedby \"claimed by\",     a.taskid,    date_trunc('second',time::timestamp) as \"available on QC from\", Date_part('day', now()::timestamp - time::timestamp)*24 +  Date_part('hour',  now()::timestamp - time::timestamp) as \"aging hrs\"          FROM  		  iris_rprod_cpp_r2.statuschanges a, iris_rprod_cpp_r2.tasks c, iris_rprod_cpp_r2.irisusers i, iris_rprod_cpp_r2.projects e,  		  (SELECT max(statuschanges.statuschangeid) AS maxId  		 	FROM   			    iris_rprod_cpp_r2.tasks,   			    iris_rprod_cpp_r2.statuschanges  		  	WHERE   			    statuschanges.taskid = tasks.taskid and  			    tasks.status = 'QC'   		    GROUP BY statuschanges.taskid ) b  			WHERE  				a.statuschangeid = b.maxId and  				a.status = 'QC' and  				a.taskid = c.taskid and  				a.username = i.username and  				i.companydepartment in ('TomTom Polska Sp.Z.o.o. : CO DPU Poland',  										'TomTom Polska Sp.Z.o.o. : MAPS-CO DPU Poland',  										'TomTom Polska Sp.Z.o.o. : MAPS-Competence Center',  										'MAPS-Competence Center') and  				c.projectname = e.projectname and  				e.projectactive = true and not  				c.projectname like '%training%'and not   				c.projectname like '%Training%'  			ORDER BY \"aging hrs\" DESC  ";
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["iris_slave"].ConnectionString);
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn);
            NpgsqlDataAdapter sda2 = new NpgsqlDataAdapter(query2, conn);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            try
            {
                conn.Open();
                sda.Fill(dt);
                sda2.Fill(dt2);
                conn.Close();
                conn.Dispose();
                gv_results.DataSource = dt;
                gv_results.DataBind();
                gv_results2.DataSource = dt2;
                gv_results2.DataBind();
            }
            catch (Exception ex)
            {
                lbl_err.ForeColor = System.Drawing.Color.Red;
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString();
            }
        }
    }
}