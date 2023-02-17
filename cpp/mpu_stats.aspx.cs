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
    public partial class mpu_stats : System.Web.UI.Page
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
            string query = "SELECT TOP 3 COUNT(DISTINCT cc) AS CC_count,[release] FROM DoretoReports.Doreto.weeklymnr_" + table + " GROUP BY [release] ORDER by [release] DESC";
            string query_ver = "SELECT TOP 3 [release_version] AS release, COUNT(DISTINCT cc) AS CC_count FROM DoretoReports.Doreto.weeklymnr_" + table + " GROUP BY [release_version] order by [release_version] desc";
             
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


        protected void fill_grid_mpuvis(NpgsqlConnection connP)
        {
                //string table_name = tableDict[tableDict.Keys.ElementAt(i)].Table_name;
                //string query_type = tableDict[tableDict.Keys.ElementAt(i)].query_type;
                //GridView gridName = tableDict[tableDict.Keys.ElementAt(i)].grid_name;
                string query_aa0 = "select count(schemaname) as stat_count,schemaname as release from pg_stat_user_tables where schemaname like('%mpu_viz_stats_aa0%') group by schemaname order by schemaname desc limit 3";
                //string query_aa8 = "select count(schemaname) as stat_count,schemaname as release from pg_stat_user_tables where schemaname like('%mpu_viz_stats_%') and schemaname not like('%mpu_viz_stats_aa0%') and schemaname not like('%mpu_viz_stats_c%') group by schemaname order by schemaname desc limit 3";

                NpgsqlDataAdapter da_aa0 = new NpgsqlDataAdapter(query_aa0, connP);
                //NpgsqlDataAdapter da_aa8 = new NpgsqlDataAdapter(query_aa8, connP);
                DataTable dt_aa0 = new DataTable();
                DataTable dt_aa8 = new DataTable();
                da_aa0.Fill(dt_aa0);
                //da_aa8.Fill(dt_aa8);
                gv_mpuviz_aa0.DataSource = dt_aa0;
                gv_mpuviz_aa0.DataBind();
                //gv_mpuviz_aa8.DataSource = dt_aa8;
                //gv_mpuviz_aa8.DataBind();
        }

        protected void fill_grid_buildingsvis(NpgsqlConnection connP)
        {
            string query_vis = "SELECT release,count(distinct country)AS CC_count FROM mpu_viz_stats_country.\"VIS_tiled_coverage\" where release is not null group by release order by release desc limit 3";

            NpgsqlDataAdapter da_bvis = new NpgsqlDataAdapter(query_vis, connP);
            DataTable dt_bvis = new DataTable();
            da_bvis.Fill(dt_bvis);
            gv_mpuviz_bvis.DataSource = dt_bvis;
            gv_mpuviz_bvis.DataBind();
        }


        protected void table_info()
        {
            //string query = string.Empty;
            Dictionary<int, Tables> geo_comp_dict = new Dictionary<int, Tables>()
            {
                //{ 1, new Tables { Table_name = "geo_order8_totalanddelta", query_type = "version", grid_name = gv_geo_o8 } },
                { 2, new Tables { Table_name = "geo_tier_totalanddelta", query_type = "version", grid_name = gv_geo_tier } },

            };
            Dictionary<int, Tables> country_stats = new Dictionary<int, Tables>()
            {
                { 1, new Tables { Table_name = "country_roadkm", query_type = "release", grid_name = gv_country_roadk}},
                { 2, new Tables { Table_name = "country_roadkm_routingclass_countkm", query_type = "release", grid_name = gv_country_roadkm_routingclass_countkm}},
                { 3, new Tables { Table_name = "country_logistics", query_type = "version", grid_name = gv_country_logistics}}

            };
            Dictionary<int, Tables> bram = new Dictionary<int, Tables>()
            {
                { 1, new Tables { Table_name = "country_navkm", query_type = "release", grid_name = gv_navkm}},
                { 2, new Tables { Table_name = "country_namedkm", query_type = "release", grid_name = gv_namedkm}},
                { 3, new Tables { Table_name = "country_pavedkm", query_type = "release", grid_name = gv_pavedkm}},
                { 4, new Tables { Table_name = "country_tollroadkm", query_type = "release", grid_name = gv_toll_roadkm}},
                //{ 5, new Tables { Table_name = "country_onewaykm", query_type = "release", grid_name = gv_onewaykm}},
                //{ 6, new Tables { Table_name = "country_laneinfokm", query_type = "release", grid_name = gv_laneinfokm}},
                { 7, new Tables { Table_name = "country_speedlimitct", query_type = "release", grid_name = gv_speedlimitct}},
                //{ 8, new Tables { Table_name = "country_turn_restrct", query_type = "release", grid_name = gv_turn_restrct}},
                //{ 9, new Tables { Table_name = "country_backroad", query_type = "version", grid_name = gv_backroad}},
                { 10, new Tables { Table_name = "country_frc_displayclass", query_type = "version", grid_name = gv_displayclass}},
                //{ 11, new Tables { Table_name = "country_restrictacc", query_type = "version", grid_name = gv_restrictacc}},
                //{ 12, new Tables { Table_name = "country_speedprofiles", query_type = "release", grid_name = gv_speedprofiles}},
                //{ 13, new Tables { Table_name = "country_bpcount", query_type = "release", grid_name = gv_bpcount}},
                { 14, new Tables { Table_name = "country_mancount", query_type = "release", grid_name = gv_mancount}},
                //{ 15, new Tables { Table_name = "country_fow", query_type = "release", grid_name = gv_fow}},
                //{ 16, new Tables { Table_name = "country_restrictions", query_type = "version", grid_name = gv_restrictions}}
            };
            Dictionary<int, Tables> OSM = new Dictionary<int, Tables>()
            {			
                { 1, new Tables { Table_name = "country_turn_restrct_osm", query_type = "release", grid_name = gv_turnrestrst}},
                { 2, new Tables { Table_name = "country_bpcount_osm", query_type = "release", grid_name = gv_bpcount2}},
                { 3, new Tables { Table_name = "country_rnr_km_osm", query_type = "release", grid_name = gv_rnrkm}},
                //{ 4, new Tables { Table_name = "country_tollroadkm_osm", query_type = "release", grid_name = gv_tollroadkm}},
                //{ 5, new Tables { Table_name = "country_toll_gate_count_osm", query_type = "release", grid_name = gv_tollgatecount}},
                { 6, new Tables { Table_name = "country_stop_sign_count_osm", query_type = "release", grid_name = gv_signcount}},
                //{ 7, new Tables { Table_name = "country_hsn_ranges_count_km_osm", query_type = "release", grid_name = gv_hsnranges}},
                //{ 8, new Tables { Table_name = "country_brunnels_count_osm", query_type = "release", grid_name = gv_brunnelscount}},
                //{ 9, new Tables { Table_name = "country_CC_count_osm", query_type = "release", grid_name = gv_CCcount}},
                { 10, new Tables { Table_name = "country_laneinfokm_osm", query_type = "release", grid_name = gv_laneinfo}},
                //{ 11, new Tables { Table_name = "country_lane_hov_km_osm", query_type = "release", grid_name = gv_lanehov}},
                //{ 12, new Tables { Table_name = "country_turn_restr_timebased_count_osm", query_type = "release", grid_name = gv_turnrestrsttimebased}},
                { 13, new Tables { Table_name = "country_ferry_all_count_osm", query_type = "release", grid_name = gv_ferry_all}},
                //{ 14, new Tables { Table_name = "country_ferry_navi_count_osm", query_type = "release", grid_name = gv_ferry_navi}},
            };
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Doreto"].ConnectionString);
            try
            {
                conn.Open();
                fill_grid(geo_comp_dict, conn);                
                fill_grid(country_stats, conn);
                fill_grid(bram, conn);
                fill_grid(OSM, conn);
               

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            NpgsqlConnection connP = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["mpu-viz-gis-db"].ConnectionString);
            try
            {
                connP.Open();

                fill_grid_mpuvis(connP);
                fill_grid_buildingsvis(connP);

            }
            finally
            {
                connP.Close();
                connP.Dispose();
            }

        }
    }
}