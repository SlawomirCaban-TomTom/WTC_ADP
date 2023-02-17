using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace TomTom_Info_Page
{
    public partial class yardtag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { RadioButtonList1.SelectedIndex = 0; branchID.Visible = true; branchTxtbox.Visible = true; continent.Visible = false; continentTxtbox.Visible = false; version.Visible = false; versionTxtbox.Visible = false; };
        }
        
        
        
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            /*http://yard.maps-contentops.amiefarm.com;*/
            
            output.Text = ""; string url="";
            if (DropDownList1.SelectedValue == "WORLD") url = "http://yard-prod.maps-applications-prod.amiefarm.com";
            if (DropDownList1.SelectedValue == "INDIA") url = "http://yard-ind.maps-applications-prod.amiefarm.com";
            if (DropDownList1.SelectedValue == "KOREA") url = "http://yard-skor.maps-applications-prod.amiefarm.com";

            if (RadioButtonList1.SelectedValue == "branch")
            {
                if (branchTxtbox.Text == "")
                {
                    output.Text = "please provide branch uuid";
                }
                else
                {
                    WebClient client = new WebClient();
                    try
                    {
                        string outString = client.DownloadString(url + "/ap-mediator-ws/branchids/" + branchTxtbox.Text + "/types/YARD_TAG/tag");
                    outString = outString.Replace(",", System.Environment.NewLine);
                    output.Text = outString;
                    }
                    catch (Exception ex)
                    {
                        output.Text = "branch not found error[404]   " + System.Environment.NewLine + System.Environment.NewLine + ex;
                    }
                }


            }


            if (RadioButtonList1.SelectedValue == "continent")
            {
                if (continentTxtbox.Text == "")
                {
                    output.Text = "please provide continent and version (ex.MNR_MEA and 2015.06) ";
                }
                else
                {
                    WebClient client = new WebClient();
                    try
                    {
                        string outString = client.DownloadString(url + "/ap-mediator-ws/accesspointids/" + continentTxtbox.Text + "/" + versionTxtbox.Text + "/types/YARD_TAG/tag");
                        outString = outString.Replace(",", System.Environment.NewLine);
                        output.Text = outString;
                    }
                    catch (Exception ex)
                    {
                        output.Text = "not found or baseline is NOT PUBLISHED - please search using branch id " 
                            + System.Environment.NewLine + System.Environment.NewLine + ex.ToString(); // +ex;
                    }
                }
            }

        }

     
      

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (RadioButtonList1.SelectedValue == "branch") { branchID.Visible = true; branchTxtbox.Visible = true; continent.Visible = false; continentTxtbox.Visible = false; version.Visible = false; versionTxtbox.Visible = false; }
            if (RadioButtonList1.SelectedValue == "continent") { branchID.Visible = false; branchTxtbox.Visible = false; continent.Visible = true; continentTxtbox.Visible = true; version.Visible = true; versionTxtbox.Visible = true; }
        } 


    }
}