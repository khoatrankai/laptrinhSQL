using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiNhaXe.DAO;

namespace QuanLiNhaXe
{
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tbPassold_TextChanged(object sender, EventArgs e)
        {
            
        }
        

        private void btnChangepass_Click(object sender, EventArgs e)
        {
            DataTable dtlogin = DataProvider.Instance.ExecuteQuery("Select * from NhanVien where MaNV = '" + Form1.ID + "'");
            DataRow drlogin = dtlogin.Rows[0];
            if(tbPassold.Text != (drlogin["PassLogin"].ToString()))
            {
                MessageBox.Show("Mật khẩu cũ không đúng");
            }else
            {
                if(tbPassnew.Text != tbagainPassnew.Text)
                {
                    MessageBox.Show("Mật khẩu xác nhận lại không trùng");

                }else
                {
                    int update = DataProvider.Instance.ExecuteNonQuery("Update NhanVien set PassLogin = '" + tbPassnew.Text + "' where MaNV = '" + Form1.ID + "'");
                    MessageBox.Show("Đổi mật khẩu thành công");
                    this.Close();
                }
            }    
           
        }
      

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
           // MessageBox.Show(Form1.ID);
        }
    }
}
