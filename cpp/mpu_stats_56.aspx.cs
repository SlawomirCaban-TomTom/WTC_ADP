using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Npgsql;

namespace TomTom_Info_Page.cpp
{
    public partial class mpu_stats_56 : System.Web.UI.Page
    {
        public class Tables
        {
            public string Table_name { get; set; }
            public string query_type { get; set; }
            public GridView grid_name { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            table_info();
        }

        protected string prepare_query(string table, string query_type)
        {
            //string result_query = string.Empty;
            string query = "SELECT TOP 10 [release],COUNT(poi_country) AS CC_count FROM DoretoReports.Doreto.weeklymnr_" + table + " GROUP BY [release] ORDER by [release] DESC";
            string query_ver = "SELECT TOP 10 [release_version] AS release, COUNT(poi_country) AS CC_count FROM DoretoReports.Doreto.weeklymnr_" + table + " GROUP BY [release_version] order by [release_version] desc";
            if (query_type == "version")
                return query_ver;
            else
                return query;
        }
        protected void fill_grid(Dictionary<int, Tables> tableDict, SqlConnection conn)
        {
            for (int i = 0; i < tableDict.Count; i++)
            {
                string table_name = tableDict[tableDict.Keys.ElementAt(i)].Table_name;
                string query_type = tableDict[tableDict.Keys.ElementAt(i)].query_type;
                GridView gridName = tableDict[tableDict.Keys.ElementAt(i)].grid_name;
                string query = prepare_query(table_name, query_type);
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridName.DataSource = dt;


                gridName.DataBind();
            }
        }

        protected void fill_grid_signposts()
        {
            string query_signposts = "SELECT substring(run_name, 1,11) as release,count(*) as CC_count from signposts_coverage.signposts_coverage.signposts_coverage_run_parameters where run_name like ('20%') group by substring(run_name, 1,11) order by 1 desc";
            NpgsqlConnection conn_sign = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["signposts_coverage"].ConnectionString);

            NpgsqlDataAdapter da_signposts = new NpgsqlDataAdapter(query_signposts, conn_sign);
            DataTable dt_signposts = new DataTable();
            da_signposts.Fill(dt_signposts);
            gv_signposts.DataSource = dt_signposts;
            gv_signposts.DataBind();
        }

        protected void table_info()
        {
            Dictionary<int, Tables> poi = new Dictionary<int, Tables>()
            {
                { 1, new Tables { Table_name = "stats_poi_Drive_Discover", query_type = "version", grid_name = gv_poi_DD } },
                { 2, new Tables { Table_name = "stats_poi_category_005", query_type = "release", grid_name = gv_poi_005 } },
                { 3, new Tables { Table_name = "stats_poi_category_006", query_type = "release", grid_name = gv_poi_006 } }
            };

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Doreto"].ConnectionString);
            try
            {
                conn.Open();
                fill_grid(poi, conn);
                fill_grid_signposts();

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }


        }

    }
}