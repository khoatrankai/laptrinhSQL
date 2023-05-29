using QuanLiNhaXe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhaXe
{
    public partial class ThongTinNhanVien : Form
    {
        public ThongTinNhanVien()
        {
            InitializeComponent();
        }
     
        
      
        private void btnRepair_Click(object sender, EventArgs e)
        {
           
            string Name = tbName.Text;
            string Date = dtpNgaySinh.Text;
            if (Form1.ID != "1")
            {
                int update = DataProvider.Instance.ExecuteNonQuery("EXEC USP_updateNV2 @User = '" + tbUser.Text + "', @Name = '" + Name + "',@Date = '" + Date + "'");
            } else
            {
                try
                {
                    DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateNhanVien @MaNV = '" + tbNV.Text + "', @HoTen = '" + tbName.Text + "',@NS = '" + dtpNgaySinh.Text + "',@userLogin = '" + tbUser.Text + "', @passLogin = '" + tbPass.Text + "'");
                }catch
                {
                    MessageBox.Show("Lỗi");
                }
            }
            MessageBox.Show("Đã thay đổi thành công");
      
        }

        private void ThongTinNhanVien_Load(object sender, EventArgs e)
        {

            DataTable dt = DataProvider.Instance.ExecuteQuery("Select * from NhanVien where MaNV = '" + Form1.ID + "'");
            DataRow row = dt.Rows[0];
            tbNV.Text = Form1.ID;
            tbName.Text = (string)row["HoVaTen"];
            dtpNgaySinh.Value = (DateTime)row["NgaySinh"];
            tbUser.Text = (string)row["UserLogin"];
            tbPass.Text = (string)row["PassLogin"];
            if(Form1.ID == "1")
            {
                tbUser.Enabled = true;
                tbPass.Enabled = true;
            }    
            
        }

        private void tbNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát?","Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)== DialogResult.OK)
            {
                this.Close();
            }       
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
