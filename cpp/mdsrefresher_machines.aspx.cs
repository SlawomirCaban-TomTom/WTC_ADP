using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Data;

using System.Configuration;
using Npgsql;

namespace TomTom_Info_Page.cpp
{
    public partial class mdsrefresher_machines : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string details = Request.Params["details"];
            //TextBox1.Text = "";
            /*for (int machine = 201; machine < 223; machine++)
            {   
                readpage(machine,details);
            }*/

            fill_grid();
            
        }

        WebResponse response = null;
        StreamReader reader = null;
            protected void readpage(int machine, string details)
            {
            try
            {
                string result = null;
                string url = @"http://rprod-cpp-mdscontentrefresher"+machine+"-r2-101.flatns.net:8080/mds-content-refresher-service/status/ongoingRetries";

                // wylaczone dopoki nie poprawią calla 
                if (details == "true")
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    response = request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream());
                    result = reader.ReadToEnd();
                }
                // wylaczone dopoki nie poprawią calla 
                    string[] values = result.Split(new string[] { "retry" }, StringSplitOptions.RemoveEmptyEntries);


                    List<string> list = new List<string>(values);
                    List<string> tools = new List<string>();
                    tools.Add("job");
                

                if (details=="true")
                {
                    TextBox1.Text += machine.ToString() + "\r\n";
                    for (int i = 0; i < list.Count; i++)
                    {
                        TextBox1.Text += list[i];
                    }
                }
                else
                {
                    string record = machine.ToString() + "  ";
                    if (list.Count>0)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            record += list[i];
                        }
                    }
                    record +=  "\r\n";
                    TextBox1.Text += record;
                }


           /*     string plus = "";
                for (int j = 0; j < tools.Count; j++)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        TextBox1.Text += list[i + 1];
                        //if (list[i].Contains(tools[j]))
                        if (list[i] == tools[j])
                        {
                            if (Int32.Parse(list[i + 1]) > 3) { plus = ">>"; } else { plus = "  "; }
                            TextBox1.Text += plus + list[i + 1] + "   " + list[i] + "\r\n";
                        }
                    }
                }
                */

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (response != null)
                    response.Close();
            }
            }

            protected void refresh_Click(object sender, EventArgs e)
            {
                Response.Redirect("http://infopage-lodz.ttg.global/cpp/mdsrefresher_machines.aspx");
            }

            protected void Button1_Click(object sender, EventArgs e)
            {
                Response.Redirect("http://infopage-lodz.ttg.global/cpp/mdsrefresher_machines.aspx?details=true");
            }





            protected void fill_grid()
            {

                DataTable DataTabletemp = new DataTable();
                string query = string.Empty;
                //query = "select remark,hostname,CASE WHEN (working_processors_count>0) THEN ' RUNNING' END AS status from (select count(datid) as working_processors_count,client_hostname from pg_stat_activity where usename = 'mdscontentrefresher' and current_query like '%in transaction%' and client_hostname NOT LIKE ('pl%') group by client_hostname)a right join mdscontentrefresher_rprod_cpp_r2.machines b on a.client_hostname=b.hostname order by hostname";
                query = "select remark,CAST(client_addr AS text),working_processors_count,CASE WHEN (working_processors_count>0) THEN ' RUNNING' END AS status from (select count(datid) as working_processors_count,client_addr from pg_stat_activity where usename = 'mdscontentrefresher' and state like '%in transaction%' group by client_addr)a right join mdscontentrefresher_mcrcore03_r2.machines b on a.client_addr=b.hostname order by hostname";
                //query = "select * from pg_stat_activity";
                NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["mdsrefresheraws"].ConnectionString);
                NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn);
            
                try
                {
                    conn.Open();
                    sda.Fill(DataTabletemp);
                    conn.Close();
                    conn.Dispose();
                    dgDashboard.DataSource = DataTabletemp;
                    //Session["dgDashboard_Ses"] = DataTabletemp;
                    dgDashboard.DataBind();
                }
                catch (Exception ex)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Visible = true;
                    lblError.Text = ex.ToString();
                }
            }


    }
}