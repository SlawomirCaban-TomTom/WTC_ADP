using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace TomTom_Info_Page.reports
{
    public partial class NDE_report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fill_grid();
        }
        protected void fill_grid()
        {
            //string query = "select c.projectname \"project name\", count(a.taskid) \"qc task count\", SUM(Date_part('day', statement_timestamp() - time)*24 + Date_part('hour', statement_timestamp() - time)) as \"aging hrs\", Round(CAST(SUM(Date_part('day', statement_timestamp() - time)*24 + Date_part('hour', statement_timestamp() - time)) / count(a.taskid) as numeric),1) as \"avg. hrs per task\" FROM iris_rprod_cpp_r2.statuschanges a inner join iris_rprod_cpp_r2.irisusers u on a.username = u.username, iris_rprod_cpp_r2.tasks c, iris_rprod_cpp_r2.projects e, (SELECT max(statuschanges.statuschangeid) AS maxId FROM iris_rprod_cpp_r2.tasks, iris_rprod_cpp_r2.statuschanges WHERE statuschanges.taskid = tasks.taskid and tasks.status = 'QC' GROUP BY statuschanges.taskid) b WHERE a.statuschangeid = b.maxId and a.status = 'QC' and a.taskid=c.taskid and e.projectname=c.projectname and u.companydepartment IN ('TomTom Polska Sp.Z.o.o. : MAPS-Competence Center', 'TomTom Polska Sp.Z.o.o. : MAPS-CO DPU Poland') and e.projectactive = true group by c.projectname order by \"avg. hrs per task\" DESC  ";
            string query = "select * from   (select a.projectname as project ,sum(a.NPE) npe ,sum(a.new_) new_ ,sum(a.QC) qc ,sum(a.QCAcceptwithminorremark) \"qc accept minor\" ,sum(a.QCReject) \"qc reject\" ,sum(a.Rework) rework ,sum(a.NeedSomeActions) \"need action\" ,sum(a.DPA) dpa ,sum(a.DPAAcceptwithminorremark) \"dpa accept minor\" ,sum(a.DPAReject) \"dpa reject\" ,sum(a.LBTSReject) \"lbts reject\" ,sum(a.done) done ,sum(a.status) total ,case when sum(a.NPE) > 0 then 'npe tasks available' else 'no workload' end as status  from      (select att.value, t.projectname, count(t.status) status,                           case when t.status = 'New' then count(t.status) end new_,            case when t.status = 'QC' then count(t.status) end QC,            case when t.status = 'QC Accept with minor remark' then count(t.status) end QCAcceptwithminorremark,            case when t.status = 'QC Reject' then count(t.status) end QCReject,                              case when t.status = 'Rework' then count(t.status) end Rework,            case when t.status = 'NeedsProductExpert' then count(t.status) end NPE,            case when t.status in ('NeedsFieldCollection' ,'NeedsPreActTeam' ,'NeedsDatabaseExpert',                                                                   'NeedsTranslation','NeedsRevisit','NeedsSourceMaterial','NeedsWorkInTIF','NeedsRuleExpert',                                                                      'NeedsFeatureLockingExpert','Feedback','SourcedFromGuidedCommunity' ,'AtGuidedCommunity') then count(t.status) end NeedSomeActions,                                                            case when t.status = 'DPA' then count(t.status) end DPA,                                      case when t.status = 'DPA Accept with minor remark' then count(t.status) end DPAAcceptwithminorremark,                                         case when t.status = 'DPA Reject' then count(t.status) end DPAReject,            case when t.status = 'LBTS Reject' then count(t.status) end LBTSReject,            case when t.status = 'Done' then count(t.status) end done                                            from iris_rprod_cpp_r2.tasks t join iris_rprod_cpp_r2.projectattributes att on t.projectname = att.projectname            where t.projectname in                               (                      select distinct t.projectname from iris_rprod_cpp_r2.tasks t                      join iris_rprod_cpp_r2.statuschanges s on t.taskid = s.taskid                      join iris_rprod_cpp_r2.irisusers u on s.username = u.username                      join iris_rprod_cpp_r2.projects p on t.projectname = p.projectname                                                                                where                        p.projectactive = true                                          )                      and att.key = 'MPU'                                group by att.value, t.projectname, t.status) a group by a.value, a.projectname) b  where project like '%UPDRes%'   or project like '%TbTRes%'    and npe is not null  order by status,project desc";
            //string query2 = "SELECT     c.projectname \"project\",    lower(a.username) \"production user\",    c.claimedby \"claimed by\",     a.taskid,    date_trunc('second',time::timestamp) as \"available on QC from\", Date_part('day', now()::timestamp - time::timestamp)*24 +  Date_part('hour',  now()::timestamp - time::timestamp) as \"aging hrs\"          FROM  		  iris_rprod_cpp_r2.statuschanges a, iris_rprod_cpp_r2.tasks c, iris_rprod_cpp_r2.irisusers i, iris_rprod_cpp_r2.projects e,  		  (SELECT max(statuschanges.statuschangeid) AS maxId  		 	FROM   			    iris_rprod_cpp_r2.tasks,   			    iris_rprod_cpp_r2.statuschanges  		  	WHERE   			    statuschanges.taskid = tasks.taskid and  			    tasks.status = 'QC'   		    GROUP BY statuschanges.taskid ) b  			WHERE  				a.statuschangeid = b.maxId and  				a.status = 'QC' and  				a.taskid = c.taskid and  				a.username = i.username and  				i.companydepartment in ('TomTom Polska Sp.Z.o.o. : CO DPU Poland',  										'TomTom Polska Sp.Z.o.o. : MAPS-CO DPU Poland',  										'TomTom Polska Sp.Z.o.o. : MAPS-Competence Center',  										'MAPS-Competence Center') and  				c.projectname = e.projectname and  				e.projectactive = true and not  				c.projectname like '%training%'and not   				c.projectname like '%Training%'  			ORDER BY \"aging hrs\" DESC  ";
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["iris_slave"].ConnectionString);
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                sda.Fill(dt);
                //  sda2.Fill(dt2);
                conn.Close();
                conn.Dispose();
                gv_results.DataSource = dt;
                gv_results.DataBind();
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