using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;  

namespace TomTom_Info_Page.cpp
{
    public partial class ts_propagate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "Running query \r\n"; 
            triger();
        }


        DataTable DTPackages = new DataTable();
        DataTable DTProjects = new DataTable();
        protected void triger()
        {
            string domain_username = User.Identity.Name.Substring(4);
            //string qrypackages = string.Empty;
            string qryprojects = string.Empty;
            //qrypackages = "SELECT LEFT(tm.dataset,2) as p,ROW_NUMBER() OVER () AS package_id FROM transactions.transaction_metadata tm JOIN transactions.transaction_status ts ON tm.transaction_id = ts.transaction_id JOIN transactions.transaction t ON ts.transaction_id = t.transaction_id WHERE ts.status_id = 2100 AND t.deleted = 0 GROUP BY p";
            qryprojects = "SELECT p.project_name, p.project_id,l.type, count(*) AS qcver_2100 FROM transactions.transaction_metadata tm JOIN transactions.transaction_status ts ON tm.transaction_id = ts.transaction_id JOIN workflow.project p ON tm.project_id = p.project_id JOIN transactions.transaction t ON ts.transaction_id = t.transaction_id left join test.leftside_countries l on tm.dataset = l.dataset WHERE ts.status_id = 2100 AND t.deleted = 0 GROUP BY p.project_name, p.project_id,l.type order by project_id";
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["trafficsignsfusionaws"].ConnectionString);
            //NpgsqlDataAdapter sdapackages = new NpgsqlDataAdapter(qrypackages, conn);
            NpgsqlDataAdapter sdaprojects = new NpgsqlDataAdapter(qryprojects, conn);
            conn.Open();
                
            try
            {
                
                if (!CheckBox2.Checked)
                {
                    sdaprojects.Fill(DTProjects);
                    if (!CheckBox1.Checked) TextBox1.Text += "\r\nIt was only dry run. Nothing started\r\n ";
                    TextBox1.Text += "Build user: " + domain_username + "\r\n";
                    //int splitskip = (DTProjects.Rows.Count + 9) / 8;
                    //int rows = DTProjects.Rows.Count;

                    if (DTProjects.Rows.Count > 0)
                    {
                        
                        TextBox1.Text += "Projects to start:" + DTProjects.Rows.Count + "\r\n";
                        // "\r\n regions in batch: " + splitskip + "\r\n all regions: " + rows + "\r\n";
                        //int row = rows - 1;
                        int txs = 0;
                        //for (int batid = 1; batid < 9; batid++)
                        //{
                            string path = @"\\plsrvwp-tsd02\c$\tools\TS_generator\TS1\ts1.bat";
                            if (!CheckBox1.Checked) { path = @"\\plsrvwp-tsd02\c$\temp\ts1.bat";  }

                            //TextBox1.Text += "---------------\r\n";
                            using (StreamWriter writetext = new StreamWriter(path))
                            {

                                writetext.WriteLine(":1");
                                //writetext.WriteLine("call start.bat UI2	428196" + Environment.NewLine);
                                //writetext.WriteLine(DTPackages.Columns[1].ColumnName + " ");
                                //int j = 0;
                                //for (int i = row; j < splitskip; row--)
                               // {

                                   // if (row >= 0)
                                   // {
                                        //writetext.WriteLine(DTPackages.Rows[row].ItemArray[0].ToString());
                                        foreach (DataRow rowproject in DTProjects.Rows)
                                        {
                                            //if (rowproject["p"].ToString() == DTPackages.Rows[row].ItemArray[0].ToString())
                                            //{
                                                //TextBox1.Text += "-sync -d " + rowproject["dataset"].ToString() + " -p " + rowproject["project_id"].ToString() + " " + rowproject["type"].ToString() + " " + rowproject["qcver_2100"].ToString() + "\r\n";
                                            TextBox1.Text += rowproject["project_id"].ToString() + " " + rowproject["type"].ToString() + " (" + rowproject["qcver_2100"].ToString() + ") " + rowproject["project_name"].ToString() + "\r\n";
                                                txs += Convert.ToInt32(rowproject["qcver_2100"]);
                                                writetext.WriteLine("call start.bat " + rowproject["project_name"].ToString() + " " + rowproject["project_id"].ToString() + " " + rowproject["type"].ToString());
                                            //}
                                        }
                                    //}
                                    //j++;
                                //}
                                writetext.WriteLine("TIMEOUT 10");
                                writetext.WriteLine("GOTO 1");
                            }
                        //}
                        TextBox1.Text += "\r\n " + DTProjects.Rows.Count + " projects (" + txs + " transactions)";

                    }
                    else
                    {
                        TextBox1.Text += "Projects to split:" + DTProjects.Rows.Count + "\r\n";
                    }
                }


                if (CheckBox2.Checked)
                {
                    sdaprojects.Fill(DTProjects);
                    //int rows = DTProjects.Rows.Count;
                    //int splitskip = (DTPackages.Rows.Count + 9) / 8;
                    if (DTProjects.Rows.Count > 0)
                    {
                        
                        string url = @"http://172.29.53.119:8080/jenkins/job/ts-traffic-signs-transaction-generator-batch/buildWithParameters?token=ccb67bb84c55d753c7d176fa20ec137c&BUILD_USER=infopage_"+domain_username+"&loadThreads="+TextBox3.Text+"&applyThreads="+TextBox4.Text+"&coredbBranch="+TextBox2.Text+"&jarArgsLines=";
                        TextBox1.Text += "Build user: " + domain_username + "\r\n";
                        TextBox1.Text += "Projects to start:" + DTProjects.Rows.Count + "\r\n";
                        // "\r\n regions in batch: " + splitskip + "\r\n all regions: " + rows + "\r\n";
                        //int row = rows - 1;
                        int txs = 0;
                        
                        //int j = 0;
                        //for (int i = row; j < rows; row--)
                        //

                            //if (row >= 0)
                            //{
                                foreach (DataRow rowproject in DTProjects.Rows)
                                {
                                    
                                    //if (rowproject["p"].ToString() == DTPackages.Rows[row].ItemArray[0].ToString())
                                    //{
                                        //TextBox1.Text += "-sync -d " + rowproject["dataset"].ToString() + " -p " + rowproject["project_id"].ToString() + " " + rowproject["type"].ToString() + " " + rowproject["qcver_2100"].ToString() + "\r\n";
                                    TextBox1.Text += "-sync -p " + rowproject["project_id"].ToString() + " " + rowproject["type"].ToString() + " (" + rowproject["project_name"].ToString() + ")\r\n";
                                        txs += Convert.ToInt32(rowproject["qcver_2100"]);
                                        url += "-sync%20-p%20" + rowproject["project_id"].ToString() + "%20" + rowproject["type"].ToString() + "%0A";
                                    //}
                                }
                            //}
                            //j++;
                        //}
                        TextBox1.Text += "\r\n " + DTProjects.Rows.Count + " projects (" + txs + " transactions) started on jenkins";
           
                        // Using WebRequest
                                WebRequest request = WebRequest.Create(url);
                                WebResponse response = request.GetResponse();
                                string result = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        // Using WebClient
                                string result1 = new WebClient().DownloadString(url);
                                TextBox1.Text += "\r\n " + result1 + "\r\n" + result;
                    }
                    
                }

                conn.Close();
                conn.Dispose();
            }

            catch (Exception ex)
            {
                lbl_err.Text = ex.ToString();
                lbl_err.Visible = true;
                conn.Close();
                conn.Dispose();
            }

        }



    }
}