using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Net;

namespace TomTom_Info_Page.cpp
{
    public partial class height_dashboard : System.Web.UI.Page
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


            var inputDirectory = new DirectoryInfo(@"\\ams3-svm-maps-cifs01.ttg.global\sppproc\tifdata\TSD\Height\dashboard");
            var myFile = inputDirectory.GetFiles().OrderByDescending(f => f.CreationTimeUtc).First();
            string dst_path = myFile.FullName;

            HyperLink1.NavigateUrl = "http://jenkins-adp-lodz.tomtomgroup.com:8080/view/Dashboards/job/HeightDashboard/ws/" + myFile.Name;
            HyperLink1.Text = myFile.Name;

            Label5.Text = myFile.Name.Substring(16, 14);

            //Create a DataTable.  
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[33] { 
                new DataColumn("pID", typeof(int)),
                new DataColumn("pName", typeof(string)),
                new DataColumn("Total", typeof(int)),
                new DataColumn("Total to write", typeof(int)),
                new DataColumn("ToDo", typeof(int)),
                new DataColumn("Progress %", typeof(int)),
                new DataColumn("Success", typeof(int)),
                new DataColumn("Total failed", typeof(int)),
                new DataColumn("CSR %", typeof(int)),
                new DataColumn("Failed - NTC", typeof(int)),
                new DataColumn("Failed - QA", typeof(int)),
                new DataColumn("QAR %", typeof(int)),
                new DataColumn("Failed - Decode", typeof(int)),
                new DataColumn("Failed - Other", typeof(int)),
                new DataColumn("Failed - IAE", typeof(int)),
                new DataColumn("Failed - PE", typeof(int)),
                new DataColumn("Failed - CCFT", typeof(int)),
                new DataColumn("Failed - CCE", typeof(int)),
                new DataColumn("Failed - CRF", typeof(int)),
                new DataColumn("Failed - CE", typeof(int)),
                new DataColumn("Failed - DAE", typeof(int)),
                new DataColumn("Failed - ISE", typeof(int)),
                new DataColumn("Failed - ILAC", typeof(int)),
                new DataColumn("Failed - IVV", typeof(int)),
                new DataColumn("Failed - NER", typeof(int)),
                new DataColumn("Failed - OCP", typeof(int)),
                new DataColumn("Not Processed - ME", typeof(int)),
                new DataColumn("Not Processed - NFC", typeof(int)),
                new DataColumn("Not Processed - UE", typeof(int)),
                new DataColumn("Not Processed - LQ", typeof(int)),
                new DataColumn("Not Processed - ND", typeof(int)),
                new DataColumn("Not Processed - LOC", typeof(int)),
                new DataColumn("Other", typeof(int))              });

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            RefreshTriger();

        }

        protected void RefreshTriger()
        {
            //Button1.Enabled = false;
            //
            string url = "http://jenkins.prod.tcnfs.tthad.net:8080/jenkins/view/Gradient%20(New%20Process)/job/Gradient-Process-Dashboard/build?token=dbsjajcn636bdhdb";
            // Using WebRequest
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            string result = new StreamReader(response.GetResponseStream()).ReadToEnd();
            // Using WebClient
            string result1 = new WebClient().DownloadString(url);


        }




    }
}



