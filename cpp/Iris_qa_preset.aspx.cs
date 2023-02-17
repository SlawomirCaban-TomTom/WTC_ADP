using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using Npgsql;

namespace TomTom_Info_Page.cpp
{
    public partial class Iris_qa_preset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_add_Click(object sender, EventArgs e)
        {
            if (tb_project.Text.Length < 5)
            {
                lbl_err.Text = "Please provide project name!";
                lbl_err.Visible = true;
            }
            else
            {
                NpgsqlConnection conn2 = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["rms"].ConnectionString);

                NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["iris_slave"].ConnectionString);
                DataTable temp = new DataTable();
                string query = "SELECT projectid,ruleset  FROM iris_rprod_cpp_r2.projects where projectname = '"+tb_project.Text+"'";
                NpgsqlDataAdapter cmd = new NpgsqlDataAdapter(query, conn);

                try
                {
                    lbl_err.Visible = false;
                    lbl_result.Text = "";
                    conn.Open();
                    cmd.Fill(temp);
                    if (temp.Rows.Count < 1)
                    {
                        lbl_result.Text = "Project " + tb_project.Text + " not found in IRIS!";                 
                    }
                    else
                    {
                        if (temp.Rows[0][1].ToString().Length > 0)
                        {
                            string query2 = "SELECT rulesetname FROM rms.rulesets where rulesetid= " + temp.Rows[0][1].ToString();
                            conn2.Open();
                            NpgsqlCommand cmd2 = new NpgsqlCommand(query2, conn2);
                            lbl_result.Text = "There is preset assigned for project: " + tb_project.Text + " in IRIS - " + temp.Rows[0][1].ToString() + " " + cmd2.ExecuteScalar().ToString();
                        }
                        else
                        {
                            lbl_result.Text = "No preset set for project: " + tb_project.Text + " in IRIS!";
                        }
                    }
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
                    conn2.Close();
                    conn2.Dispose();
                }
            }
        }
    }
}