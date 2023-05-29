namespace QuanLiNhaXe
{
    public class DataProviderBase1
    {
        private string conStr = "Data Source=DESKTOP-MJUEPL4;Initial Catalog=QuanLyNhaXe;Integrated Security=True";

        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
            }

        }
    }
}