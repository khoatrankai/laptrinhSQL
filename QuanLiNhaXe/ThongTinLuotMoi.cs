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
    public partial class ThongTinLuotMoi : Form
    {
        public ThongTinLuotMoi()
        {
            InitializeComponent();
        }

       
        private void ThongTinLuotMoi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNhaXeDataSet2.BangGia' table. You can move, or remove it, as needed.
            DataTable gt = DataProvider.Instance.ExecuteQuery("Select * from GioiTinh");
            cbGT.DataSource = gt;
            cbGT.DisplayMember = "GT";
            cbGT.ValueMember = "MaGT";
            DataTable ms = DataProvider.Instance.ExecuteQuery("Select * from MauSac");
            cbMS.DataSource = ms;
            cbMS.DisplayMember = "MS";
            cbMS.ValueMember = "MaMS";
            DataTable lx = DataProvider.Instance.ExecuteQuery("Select * from BangGia");
            cbLoaiXe.DataSource = lx;
            cbLoaiXe.DisplayMember = "LoaiXe";
            cbLoaiXe.ValueMember = "MaGia";
            cbLoaiXe.Text = "";
            
            
        }
        

        private void cbLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dtlx = DataProvider.Instance.ExecuteQuery("Select * from BangGia where LoaiXe = '" + cbLoaiXe.Text + "'");
            
            DataRow drlx;
            string a = "1" ;
           
            if(cbLoaiXe.SelectedIndex != 0)
            {
                drlx = dtlx.Rows[0];
                a = drlx["MaGia"].ToString();
                cbHangXe.Text = "";
                cbHangXe.Enabled = true;
            }
            else
            {
                cbHangXe.Text = "";
                cbHangXe.Enabled=false;
            }
            
            DataTable hx = DataProvider.Instance.ExecuteQuery("Select * from HangXe where MaLoaiXe = '" + a + "'");
            cbHangXe.DataSource = hx;
            cbHangXe.DisplayMember = "HangXe";
            cbHangXe.ValueMember = "MaHangXe";
            cbHangXe.Text = "";
            
           

        }
      
        private void cbHangXe_SelectedIndexChanged(object sender, EventArgs e)
        {

            
           
            

        }

        private void cbMaXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string BSX = tbBSX.Text;
            string hoten = tbName.Text;
            string date = dtpDateofbirth.Text.ToString();
            string gt = (cbGT.SelectedValue).ToString();
            DataTable ms1 = DataProvider.Instance.ExecuteQuery("Select * from MauSac where MS = '" + cbMS.Text + "'");
            DataRow drms = ms1.Rows[0];
            string ms = drms["MaMS"].ToString();
            DataTable lx1 = DataProvider.Instance.ExecuteQuery("Select * from BangGia where LoaiXe = '" + cbLoaiXe.Text + "'");
            DataRow drlx = lx1.Rows[0];
            string lx = drlx["MaGia"].ToString();
            DataTable hx1 = DataProvider.Instance.ExecuteQuery("Select * from HangXe where HangXe = '" + cbHangXe.Text + "'");
            DataRow drhx = hx1.Rows[0];
            string hx = drhx["MaHangXe"].ToString();
            int update1 = DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertThongTinXe @MaBSX = '"+BSX+"' , @HoVaTen = '"+hoten+"', @NgaySinh = '"+date+ "',@GT = '" + gt + "',@LoaiMau = '" + ms + "',@LoaiXe = '" + lx + "',@HangXe = '" + hx + "'");
            int update2 = DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertThongTinLuot @MaNV = '"+Form1.ID+ "',@ThoiGianGui = '"+DateTime.Now.ToString()+ "',@MaBSX = '" + BSX + "',@LoaiXe = '" + lx + "',@GiaLoaiXe = '" + lx + "',@TrangThai = 1 ");
            this.Close();
        }

        private void cbGT_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        private void tbBSX_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
