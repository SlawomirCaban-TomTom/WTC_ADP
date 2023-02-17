using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net;
using System.IO;
using Npgsql;
using System.Data;
using System.Text;
using System.Diagnostics;

namespace TomTom_Info_Page.cpp
{
    public partial class bqa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack) lbl_err.Visible = false;
          //  bqajobs_grid();
          
        }

        DataTable DataTabletemp = new DataTable();
        protected void fill_gvViolatedRules(string jobid)
        {
            string query = string.Empty;
            string violstore = string.Empty;
            query = "WITH unique_part AS  ( select distinct  v.ruleid from qavs_rprod_cpp_r2.violations v JOIN qavs_rprod_cpp_r2.VIOLATIONJOBS vj ON (v.VIOLATIONID = vj.VIOLATIONID) where committed = 1 and stateid = 'OPEN' and vj.jobid = '" + jobid + "' group by v.violationid ) SELECT distinct up.ruleid FROM unique_part up";
            if (DropDownList1.Text == "WORLD")
            {
                violstore="violationstore";
            }
            if (DropDownList1.Text == "INDIA")
            {
                violstore = "violationstore_ind";
            }
            if (DropDownList1.Text == "KOREA")
            {
                violstore = "violationstore_ind";
            }
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings[violstore].ConnectionString);
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn);
     
            try
            {
                conn.Open();
                sda.Fill(DataTabletemp);
                
                conn.Close();
                conn.Dispose();
                //gvViolatedRules.DataSource = DataTabletemp;
                Session["gvViolatedRules_Ses"] = DataTabletemp;
               // gvViolatedRules.DataBind();
                string str = string.Empty;
                for (int i = 0; i < DataTabletemp.Rows.Count; i++)
                {
                    str = str + DataTabletemp.Rows[i]["ruleid"].ToString();
                    str += (i < DataTabletemp.Rows.Count - 1) ? "," : string.Empty;
                }
                lblViolatedRules.Visible = true;
                txtViolatedRules.Visible = true;
                txtViolatedRules.Text = str;
            }
            catch (Exception ex)
            {
                lbl_err.ForeColor = System.Drawing.Color.Red;
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString();
            }
        }

        protected void getrulesforpreset(string presetid)
        {
            // List<string> result = new List<string>();
             string result = null;
             string url = @"http://rms.tomtomgroup.com/rms-webservice/presets/"+presetid+"/ruleids/%5B%22OPERATIONAL%22%5D/%5B%22TTOM_CORE%22,%22TTOM_POI%22,%22TTOM_ADA%22,%22TTOM_TOPOLOGY%22,%22TTOM_APT%22,%22TTOM%22%5D";

             WebResponse response = null;
             StreamReader reader = null;

             try
             {
                 HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                 request.Method = "GET";
                 response = request.GetResponse();
                 reader = new StreamReader(response.GetResponseStream());
                 result = reader.ReadToEnd();


                 lblRulesforpreset.Visible = true;
                 txtRulesforpreset.Visible = true;
                 txtRulesforpreset.Text = result;

          }
            catch (Exception ex)
            {
                lbl_err.Text = ex.Message;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (response != null)
                    response.Close();
            }
        }




        //DataTable DataTabletemp_jobs = new DataTable();
        //DataTable DataTabletemp_jobs3 = new DataTable();
     /*   protected void bqajobs_grid()
        {
            DataTable DataTabletemp_jobs = new DataTable();
            string query1 = string.Empty; string query3 = string.Empty;
            string query1failed = string.Empty; string query3failed = string.Empty;

            query1failed = "select a.que,a.name,a.id,a.status,t.failed ,a.time_stamp from (SELECT DISTINCT ON (j.id) 'bqamaas1' as que,j.name,j.id, js.name as status,time_stamp,email, j.job_state, queue_number, jobconfig_id, geography_id FROM bqastore_r2.job j join bqastore_r2.jobstate js on j.job_state=js.id join bqastore_r2.jobevent je on j.id=je.job_id where je.job_state=1 order by  j.id,time_stamp desc)a left join (SELECT count(id) as failed,job_id  FROM bqastore_r2.tile  where   tile_state=4  group by job_id)t on a.id=t.job_id order by time_stamp desc limit 10";
            query3failed = "select a.que,a.name,a.id,a.status,t.failed ,a.time_stamp from (SELECT DISTINCT ON (j.id) 'bqamaas3' as que,j.name,j.id, js.name as status,time_stamp,email, j.job_state, queue_number, jobconfig_id, geography_id FROM bqastore_r2.job j join bqastore_r2.jobstate js on j.job_state=js.id join bqastore_r2.jobevent je on j.id=je.job_id where je.job_state=1 order by  j.id,time_stamp desc)a left join (SELECT count(id) as failed,job_id  FROM bqastore_r2.tile  where   tile_state=4  group by job_id)t on a.id=t.job_id order by time_stamp desc limit 10";
            query1 = "select a.que,a.name,a.id,a.status, 'NA' as failed ,a.time_stamp from (SELECT DISTINCT ON (j.id) 'bqamaas1' as que,j.name,j.id, js.name as status,time_stamp,email, j.job_state, queue_number, jobconfig_id, geography_id FROM bqastore_r2.job j join bqastore_r2.jobstate js on j.job_state=js.id join bqastore_r2.jobevent je on j.id=je.job_id where je.job_state=1 order by  j.id,time_stamp desc)a order by time_stamp desc limit 10";
            query3 = "select a.que,a.name,a.id,a.status, 'NA' as failed ,a.time_stamp from (SELECT DISTINCT ON (j.id) 'bqamaas3' as que,j.name,j.id, js.name as status,time_stamp,email, j.job_state, queue_number, jobconfig_id, geography_id FROM bqastore_r2.job j join bqastore_r2.jobstate js on j.job_state=js.id join bqastore_r2.jobevent je on j.id=je.job_id where je.job_state=1 order by  j.id,time_stamp desc)a order by time_stamp desc limit 10";
            if (CheckBoxFailed.Checked) { query1 = query1failed; query3 = query3failed; }
            // queryDataset = "select distinct name, project_id from project_manager.projects order by 1";
            NpgsqlConnection conn1 = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["bqa_maas1"].ConnectionString);
            NpgsqlConnection conn3 = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["bqa_maas3"].ConnectionString);
            NpgsqlDataAdapter sda1 = new NpgsqlDataAdapter(query1, conn1);
            NpgsqlDataAdapter sda3 = new NpgsqlDataAdapter(query3, conn3);


            try
            {
                conn1.Open(); //conn3.Open();
                sda1.Fill(DataTabletemp_jobs);
                //sda3.Fill(DataTabletemp_jobs);
                conn1.Close(); //conn3.Close();
                conn1.Dispose(); //conn3.Dispose();
                GridView1.DataSource = DataTabletemp_jobs;
                Session["GridView1_Ses"] = DataTabletemp_jobs;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                lbl_err.ForeColor = System.Drawing.Color.Red;
                lbl_err.Visible = true;
                lbl_err.Text = ex.ToString();
            }
        }
        */

        protected void violations(string jobid)
        {
            ProcessStartInfo apka = new ProcessStartInfo("cmd.exe");

            apka.UseShellExecute = false;

            apka.RedirectStandardInput = true;

            apka.RedirectStandardError = true;

            apka.RedirectStandardOutput = true;

            //info.UserName = dialog.User; // see the link mentioned at the top

            //info.Password = dialog.Password;

           // using (Process install = Process.Start(apka))
            //{

                //apka.WindowStyle = ProcessWindowStyle.Minimized;
                //apka.Arguments = "c:\violation_extractor.exe 7660a8a6-ff70-4e35-bb56-82bd72f46f0d";
            apka.Arguments = @" /C C:\util\violations\violation_extractor.exe 7660a8a6-ff70-4e35-bb56-82bd72f46f0d \\10.18.252.42\sppproc\tifdata\TSD\BQA\ >> C:\util\violations\log.txt";
                    
            Process.Start(apka);
               // string output = install.StandardOutput.ReadToEnd();

                //install.WaitForExit();

                // Do something with you output data

                //Console.WriteLine(output);
                //lblViolCount.Text = output;

              //  return;
            //}
        }

        protected string violations_csv(string jobid)
        {

            string query = string.Empty;
            int vcount = 0;
            query = "WITH partly_table AS (         SELECT string_agg(featureid, '_') featureid, violationid FROM (         select v.violationid, v.stateid, v.countrycode, v.message, v.bboxsouth, v.bboxwest,                 v.bboxnorth, v.bboxeast, v.ruleid, v.rulemajorversion, v.rulemediumversion,                 v.logdate, v.committed, v.username, v.transactionid, v.action, v.targetviolation,                (v.bboxnorth+v.bboxsouth)/20000000 Latitude,(v.bboxeast+v.bboxwest)/20000000 Longitude, date_trunc('hour',v.logdate) loghour,vj.jobid, vf.featureid,            array_to_string(array_agg(variablekey||': '||variablevalue order by variablekey,','),',') viva         from qavs_rprod_cpp_r2.violations v              JOIN qavs_rprod_cpp_r2.VIOLATIONJOBS vj ON (v.VIOLATIONID = vj.VIOLATIONID)                  left outer JOIN qavs_rprod_cpp_r2.VIOLATIONROOTFEATURES vf ON (v.VIOLATIONID = vf.VIOLATIONID)             left outer join qavs_rprod_cpp_r2.violationvariables vv on (v.violationid = vv.violationid)           where committed = 1 and stateid = 'OPEN' and vj.jobid = '" + jobid + "'           group by v.violationid,vj.jobid,vf.featureid           ) alias             group by violationid           ),unique_part AS  ( select distinct v.violationid, v.stateid, v.countrycode, v.message, v.bboxsouth, v.bboxwest,      v.bboxnorth, v.bboxeast, v.ruleid, v.rulemajorversion, v.rulemediumversion,                 v.logdate, v.committed, v.username, v.transactionid, v.action, v.targetviolation,                (v.bboxnorth+v.bboxsouth)/20000000 Latitude,(v.bboxeast+v.bboxwest)/20000000 Longitude, date_trunc('hour',v.logdate) loghour,vj.jobid,        array_to_string(array_agg(variablekey||': '||variablevalue order by variablekey,','),',') viva           from qavs_rprod_cpp_r2.violations v              JOIN qavs_rprod_cpp_r2.VIOLATIONJOBS vj ON (v.VIOLATIONID = vj.VIOLATIONID)                  left outer JOIN qavs_rprod_cpp_r2.VIOLATIONROOTFEATURES vf ON (v.VIOLATIONID = vf.VIOLATIONID)             left outer join qavs_rprod_cpp_r2.violationvariables vv on (v.violationid = vv.violationid)           where committed = 1 and stateid = 'OPEN' and  vj.jobid = '" + jobid + "'           group by v.violationid,vj.jobid,vf.featureid) SELECT up.violationid, up.stateid, up.countrycode, up.message, up.bboxsouth, up.bboxwest,                 up.bboxnorth, up.bboxeast, up.ruleid, up.rulemajorversion, up.rulemediumversion,                 up.logdate, up.committed, up.username, up.transactionid, up.action, up.targetviolation,                up.Latitude,up.Longitude, up.loghour, up.jobid, up.viva, pt.featureid FROM partly_table pt, unique_part up where pt.violationid = up.violationid";
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["violationstore"].ConnectionString);
            //NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            //DataTable dt = new DataTable();

            StringBuilder sb = new StringBuilder();
            string[] columnNames = Enumerable.Range(0, dr.FieldCount).Select(dr.GetName).ToArray();
            sb.Append(string.Join(",", columnNames));
            sb.AppendLine();

            try
            {
                conn.Open();
                //da.Fill(dt);
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(": "))
                            value = "\"" + value + "\"";
                        if (value.Contains(","))
                            value = "\"" + value + "\"";

                        if (value.Contains("\""))
                            value = "\"" + value.Replace("\"", "\"\"") + "\"";

                        sb.Append(value.Replace(Environment.NewLine, " ") + ",");
                    }
                    sb.Length--; // Remove the last comma
                    sb.AppendLine(); vcount += 1;
                }
                
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



            lblViolCount.Visible = true;
            lblViolCount.Text = vcount.ToString();

            return sb.ToString();
        }

        protected void btnGetViolRules_Click(object sender, EventArgs e)
        {
            if(txtJobid.Text!="jobid")
            {
                fill_gvViolatedRules(txtJobid.Text);
            }
            else
            {
                lbl_err.Visible = true;
                lbl_err.Text = "Provide proper bulkqa jobid";
            }
        }

         

        protected void btnGetrules_Click(object sender, EventArgs e)
        {
            getrulesforpreset(txtPresetid.Text);
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://infopage-lodz.ttg.global/cpp/bqa.aspx");
        }

        protected void btnGetviolations_Click(object sender, EventArgs e)
        {
            //violations_csv(txtJobid.Text);
            //violations(txtJobid.Text);
            Response.Redirect("http://jenkins.maps-contentprocessing-prod.amiefarm.com:8080/view/BQA/job/BQA_violations_extractor/");
        }

        protected void btnGetvioltiles_Click(object sender, EventArgs e)
        {
            if (txtJobid.Text != "jobid")
            {

                bool Test1 = true; bool Test3 = true; bool TestInd1 = true; bool TestInd3 = true;
                //Uri urlCheck1 = new Uri("http://bulkqa-bqamaas1.maps-contentops.amiefarm.com/bulk-qa-ws/bulkqa/tileswithviolationsforjobid/" + txtJobid.Text);
                //Uri urlCheck3 = new Uri("http://bulkqa-bqamaas3.maps-contentops.amiefarm.com/bulk-qa-ws/bulkqa/tileswithviolationsforjobid/" + txtJobid.Text);
                //Uri urlCheckInd1 = new Uri("http://bulkqa-bqamaas1.maps-india-contentops.amiefarm.com/bulk-qa-ws/bulkqa/tileswithviolationsforjobid/" + txtJobid.Text);
                //Uri urlCheckInd3 = new Uri("http://bulkqa-bqamaas3.maps-india-contentops.amiefarm.com/bulk-qa-ws/bulkqa/tileswithviolationsforjobid/" + txtJobid.Text);
                Uri urlCheck1 = new Uri("http://bulk-qa-bulk-qa1.ttomsd.qa.maps-contentops.amiefarm.com/bulk-qa-ws/bulkqa/tileswithviolationsforjobid/" + txtJobid.Text);
                Uri urlCheck3 = new Uri("http://bulk-qa-bulk-qa2.ttomsd.qa.maps-contentops.amiefarm.com/bulk-qa-ws/bulkqa/tileswithviolationsforjobid/" + txtJobid.Text);
                Uri urlCheckInd1 = new Uri("http://bulk-qa-bulk-qa1.ttomsd.qa.maps-india-contentops.amiefarm.com/bulk-qa-ws/bulkqa/tileswithviolationsforjobid/" + txtJobid.Text);
                Uri urlCheckInd3 = new Uri("http://bulk-qa-bulk-qa2.ttomsd.qa.maps-india-contentops.amiefarm.com/bulk-qa-ws/bulkqa/tileswithviolationsforjobid/" + txtJobid.Text);

                WebRequest request1 = WebRequest.Create(urlCheck1);
                WebRequest request3 = WebRequest.Create(urlCheck3);
                WebRequest requestInd1 = WebRequest.Create(urlCheckInd1);
                WebRequest requestInd3 = WebRequest.Create(urlCheckInd3);
                request1.Timeout = 15000;
                request3.Timeout = 15000;
                requestInd1.Timeout = 15000;
                requestInd3.Timeout = 15000;

                WebResponse response1;
                WebResponse response3;
                WebResponse responseInd1;
                WebResponse responseInd3;
                try { response1 = request1.GetResponse(); }
                catch (Exception) { Test1 = false; }
                try { response3 = request3.GetResponse(); }
                catch (Exception) { Test3 = false; }
                try { responseInd1 = requestInd1.GetResponse(); }
                catch (Exception) { TestInd1 = false; }
                try { responseInd3 = requestInd3.GetResponse(); }
                catch (Exception) { TestInd3 = false; }

                //if (Test1) { Response.Redirect("http://bulkqa-bqamaas1.maps-contentops.amiefarm.com/bulk-qa-ws/bulkqa/tileswithviolationsforjobid/" + txtJobid.Text); }
                //if (Test3) { Response.Redirect("http://bulkqa-bqamaas3.maps-contentops.amiefarm.com/bulk-qa-ws/bulkqa/tileswithviolationsforjobid/" + txtJobid.Text); }
                //if (TestInd1) { Response.Redirect("http://bulkqa-bqamaas1.maps-india-contentops.amiefarm.com/bulk-qa-ws/bulkqa/tileswithviolationsforjobid/" + txtJobid.Text); }
                //if (TestInd3) { Response.Redirect("http://bulkqa-bqamaas3.maps-india-contentops.amiefarm.com/bulk-qa-ws/bulkqa/tileswithviolationsforjobid/" + txtJobid.Text); }
                if (Test1) { Response.Redirect("http://bulk-qa-bulk-qa1.ttomsd.qa.maps-contentops.amiefarm.com/bulk-qa-ws/bulkqa/tileswithviolationsforjobid/" + txtJobid.Text); }
                if (Test3) { Response.Redirect("http://bulk-qa-bulk-qa2.ttomsd.qa.maps-contentops.amiefarm.com/bulk-qa-ws/bulkqa/tileswithviolationsforjobid/" + txtJobid.Text); }
                if (TestInd1) { Response.Redirect("http://bulk-qa-bulk-qa1.ttomsd.qa.maps-india-contentops.amiefarm.com/bulk-qa-ws/bulkqa/tileswithviolationsforjobid/" + txtJobid.Text); }
                if (TestInd3) { Response.Redirect("http://bulk-qa-bulk-qa2.ttomsd.qa.maps-india-contentops.amiefarm.com/bulk-qa-ws/bulkqa/tileswithviolationsforjobid/" + txtJobid.Text); }
            }
            else
            {
                lbl_err.Visible = true;
                lbl_err.Text = "Provide proper bulkqa jobid";
            }
        }

        protected void btnSlowRulesKibana_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://kibana.maps-contentops.amiefarm.com:8080/app/kibana?#/dashboard/bulkqa-rule-executions?_g=(refreshInterval:(display:Off,pause:!f,value:0),time:(from:now-30d,mode:quick,to:now))&_a=(filters:!(),options:(darkTheme:!f),panels:!((col:1,id:bulkqa-sum-of-execution-time-per-rule,panelIndex:1,row:2,size_x:6,size_y:4,type:visualization),(col:7,id:bulkqa-average-execution-time-per-rule,panelIndex:2,row:2,size_x:6,size_y:4,type:visualization),(col:1,id:bulkqa-failure-rate,panelIndex:3,row:6,size_x:12,size_y:4,type:visualization),(col:1,id:bulkqa-average-overall-execution-time,panelIndex:4,row:10,size_x:6,size_y:4,type:visualization),(col:7,id:bulkqa-worst-morton-tiles,panelIndex:5,row:10,size_x:6,size_y:4,type:visualization),(col:1,id:bulkqa-dashboard-description,panelIndex:6,row:1,size_x:12,size_y:1,type:visualization)),query:(query_string:(analyze_wildcard:!t,query:'bulkQaJobId:%22" + txtJobid.Text + "%22')),title:'bulkqa%20rule%20executions',uiState:(P-1:(vis:(legendOpen:!f)),P-2:(vis:(legendOpen:!f)),P-3:(vis:(legendOpen:!f)),P-4:(vis:(legendOpen:!f)),P-5:(vis:(legendOpen:!f))))");
        }

        protected void btnGetallrules_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://rms.tomtomgroup.com/rms-webservice/baserules/%5B%22OPERATIONAL%22%5D/ALL/%5B%22TTOM_CORE%22,%22TTOM_POI%22,%22TTOM_ADA%22,%22TTOM_TOPOLOGY%22,%22TTOM_APT%22,%22TTOM%22%5D");
        }

        protected void btnGetfailedtiles_Click(object sender, EventArgs e)
        {
            if (txtJobid.Text != "jobid")
            {

                bool Test1 = true; bool Test3 = true; bool TestInd1 = true; bool TestInd3 = true;
                Uri urlCheck1 = new Uri("http://bulk-qa-bulk-qa1.ttomsd.qa.maps-contentops.amiefarm.com/bulk-qa-ws/bulkqa/failedtiles/" + txtJobid.Text);
                Uri urlCheck3 = new Uri("http://bulk-qa-bulk-qa2.ttomsd.qa.maps-contentops.amiefarm.com/bulk-qa-ws/bulkqa/failedtiles/" + txtJobid.Text);
                Uri urlCheckInd1 = new Uri("http://bulk-qa-bulk-qa1.ttomsd.qa.maps-india-contentops.amiefarm.com/bulk-qa-ws/bulkqa/failedtiles/" + txtJobid.Text);
                Uri urlCheckInd3 = new Uri("http://bulk-qa-bulk-qa2.ttomsd.qa.maps-india-contentops.amiefarm.com/bulk-qa-ws/bulkqa/failedtiles/" + txtJobid.Text);
                WebRequest request1 = WebRequest.Create(urlCheck1);
                WebRequest request3 = WebRequest.Create(urlCheck3);
                WebRequest requestInd1 = WebRequest.Create(urlCheckInd1);
                WebRequest requestInd3 = WebRequest.Create(urlCheckInd3);
                request1.Timeout = 15000;
                request3.Timeout = 15000;
                requestInd1.Timeout = 15000;
                requestInd3.Timeout = 15000;

                WebResponse response1;
                WebResponse response3;
                WebResponse responseInd1;
                WebResponse responseInd3;
                try { response1 = request1.GetResponse(); }
                catch (Exception) { Test1 = false; }
                try { response3 = request3.GetResponse(); }
                catch (Exception) { Test3 = false; }
                try { responseInd1 = requestInd1.GetResponse(); }
                catch (Exception) { TestInd1 = false; }
                try { responseInd3 = requestInd3.GetResponse(); }
                catch (Exception) { TestInd3 = false; }

                if (Test1) { Response.Redirect("http://bulk-qa-bulk-qa1.ttomsd.qa.maps-contentops.amiefarm.com/bulk-qa-ws/bulkqa/failedtiles/" + txtJobid.Text); }
                if (Test3) { Response.Redirect("http://bulk-qa-bulk-qa2.ttomsd.qa.maps-contentops.amiefarm.com/bulk-qa-ws/bulkqa/failedtiles/" + txtJobid.Text); }
                if (TestInd1) { Response.Redirect("http://bulk-qa-bulk-qa1.ttomsd.qa.maps-india-contentops.amiefarm.com/bulk-qa-ws/bulkqa/failedtiles/" + txtJobid.Text); }
                if (TestInd3) { Response.Redirect("http://bulk-qa-bulk-qa2.ttomsd.qa.maps-india-contentops.amiefarm.com/bulk-qa-ws/bulkqa/failedtiles/" + txtJobid.Text); }
            }
            else
            {
                lbl_err.Visible = true;
                lbl_err.Text = "Provide proper bulkqa jobid";
            }
        }
        protected void get_message_for_rules(object sender, EventArgs e)
        {
            bool valid = true;
            string[] test = tb_rid.Text.Split(',');
            if (test.Length > 0)
            {
                foreach (string str in test)
                {
                    int output = 0;
                    if (!int.TryParse(str, out output))
                        valid = false;
                }
                if (valid)
                {

                    string result = null;
                    string query = "select distinct r.ruleid,violationmessage from rule r join rule_version rv on r.ruleid=rv.ruleid where r.ruleid in (" + tb_rid.Text + " ) and status=4 order by 1";
                    NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["rms"].ConnectionString);
                    NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn);
                    DataTable temp = new DataTable();
                    try
                    {
                        conn.Open();
                        sda.Fill(temp);
                    }
                    catch (Exception ex)
                    {
                        Label2.Visible = false;
                        tb_rid_message.Visible = false;
                        lbl_err.Visible = true;
                        lbl_err.Text = ex.Message;
                    }
                    finally
                    {
                        conn.Clone();
                        conn.Dispose();
                    }
                    string results = string.Empty;
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        result = result + temp.Rows[i][0].ToString() + ";" + temp.Rows[i][1].ToString() + "\n";
                    }

                    tb_rid_message.Visible = true;
                    Label2.Visible = true;
                    tb_rid_message.Text = result;
                }
                else
                {
                    Label2.Visible = false;
                    lbl_err.Visible = true;
                    lbl_err.Text = "input inalid";
                    tb_rid_message.Visible = false;                    
                }
            }
        }

        protected void ButtonRefresh_Click(object sender, EventArgs e)
        {
            //bqajobs_grid();
        }

    

        
    }
}