using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLiNhaXe.DAO
{
    public class Account
    {
        private static Account instance;
        public static Account Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Account();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }

        }
        private Account() { }
        public bool Login(string userName, string passWord)
        {

            
            string query = "Select * from NhanVien Where UserLogin = '" + userName + "' and PassLogin = '" + passWord + "'";
            DataTable kq = DataProvider.Instance.ExecuteQuery(query);
            try
            {
                DataRow row = kq.Rows[0];
                Form1.ID = row["MaNV"].ToString();
            }
            catch { }
            return kq.Rows.Count > 0;
        }
    }
}
