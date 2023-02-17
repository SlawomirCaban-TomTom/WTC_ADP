using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Npgsql;
using System.Data;
using System.IO;
using System.Net;  

namespace TomTom_Info_Page.cpp
{
    public partial class cor_dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImportCSV();
        }

        protected void gvDistricts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                    e.Row.Style.Add("height", "20px");
            }
        }


        protected void ImportCSV()
        {
            /*
-- (1) -- dump AKTYWNYCH projektow do bazy state_manager
DROP TABLE IF EXISTS state_manager.projects_dump;

CREATE TABLE state_manager.projects_dump
AS (select project_id,name,active from dblink('host=db.pm.curv.prod.tthad.net user=HeliumWorkflowDb password=HeliumWorkflowDb port=5432 dbname=cpp_wf_8080', 'SELECT project_id, name, active FROM project_manager.projects WHERE active=true ')as p_names (project_id uuid,name text, active boolean)
)


*/


            var inputDirectory = new DirectoryInfo(@"\\ams3-svm-maps-cifs01.ttg.global\sppproc\tifdata\TSD\COR\dashboard");
            var myFile = inputDirectory.GetFiles().OrderByDescending(f => f.CreationTimeUtc).First();
            string dst_path = myFile.FullName;

            HyperLink1.NavigateUrl = "http://jenkins.prod.tcnfs.tthad.net:8080/jenkins/job/CoR-Process-Dashboard/lastSuccessfulBuild/artifact/" + myFile.Name;
            HyperLink1.Text = myFile.Name;

            Label5.Text = myFile.Name.Substring(13, 13);

            //Create a DataTable.  
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { 
                new DataColumn("project_id", typeof(string)),
                new DataColumn("name", typeof(string)),
                new DataColumn("ready_to_calculate", typeof(string)),
                new DataColumn("tx_to_commit", typeof(string)),
                new DataColumn("calculation_quality_violation", typeof(string))  });

            //Read the contents of CSV file.  
            string csvData = File.ReadAllText(dst_path);
            int lines = File.ReadAllLines(dst_path).Length;
            int showlatest = int.Parse(TextBox1.Text);
            // loop over the rows.  
            // skip(1) skip header
            foreach (string row in csvData.Split('\n').Skip(1))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;

                    // loop over the columns.  
                    foreach (string cell in row.Split(';'))
                    {
                        // dt.Columns.Add();

                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }


            //lbl_err.Text = lines.ToString();

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }



      


    }
}