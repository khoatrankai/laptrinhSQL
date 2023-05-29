using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLiNhaXe
{
    public class DataProvider

    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return DataProvider.instance;
            }
            private set
            {
                DataProvider.instance = value;
            }
        }
        private string conStr = @"Data Source=DESKTOP-MJUEPL4;Initial Catalog=QuanLyNhaXe2;Integrated Security=True";
        public DataTable ExecuteQuery(string query)
        {
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            conn.Open();

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);

            conn.Close();
            conn.Dispose();
            return table;
        }
        public int ExecuteNonQuery(string query)
        {
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            return a;
        }
        public object ExecuteScaler(string query)
        {
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            conn.Open();
            object a = cmd.ExecuteScalar();
            conn.Close();
            conn.Dispose();
            return a;
        }
    }
}
