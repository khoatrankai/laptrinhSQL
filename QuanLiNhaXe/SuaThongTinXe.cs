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
    public partial class SuaThongTinXe : Form
    {
        public SuaThongTinXe()
        {
            InitializeComponent();
        }
        public string MaBSX;
        public string HoTen;
        public DateTime NgaySinh;
        public string GT;
        public string LoaiMau;
        public string LoaiXe;
        public string HangXe;
        public void DataLoad()
        {
            DataTable dtgt = DataProvider.Instance.ExecuteQuery("Select * from GioiTinh");
            DataTable dtMS = DataProvider.Instance.ExecuteQuery("Select * from MauSac");
            DataTable dtlx = DataProvider.Instance.ExecuteQuery("Select * from BangGia");
            DataTable dthx = DataProvider.Instance.ExecuteQuery("Select * from HangXe") ;
            DataTable dthx2 = DataProvider.Instance.ExecuteQuery("Select * from HangXe Where MaLoaiXe = '"+LoaiXe+"'");
            DataTable dtgt1 = DataProvider.Instance.ExecuteQuery("Select * from GioiTinh where MaGT = '" + GT + "'");
            DataRow drgt = dtgt.Rows[0];
            cbGT.DataSource = dtgt;
            cbGT.DisplayMember = "GT";
            cbGT.Text = drgt["GT"].ToString();

            DataTable dtms1 = DataProvider.Instance.ExecuteQuery("Select * from MauSac where MaMS = '" + LoaiMau + "'");
            DataRow drms = dtms1.Rows[0];
            cbMS.DataSource = dtMS;
            cbMS.DisplayMember = "MS";
            cbMS.Text = drms["MS"].ToString();
            DataTable dtlx1 = DataProvider.Instance.ExecuteQuery("Select * from BangGia where MaGia = '"+LoaiXe+"'");
            DataRow drlx = dtlx1.Rows[0];
            cbLoaiXe.DataSource = dtlx;
            cbLoaiXe.DisplayMember = "LoaiXe";
            cbLoaiXe.Text = drlx["LoaiXe"].ToString();
            cbHangXe.DataSource = dthx;
            cbHangXe.DisplayMember = "HangXe";
            cbHangXe.DataSource = dthx2 ;
            try
            {
                DataTable dthx1 = DataProvider.Instance.ExecuteQuery("Select * from HangXe where MaHangXe = '" + HangXe + "'");
                DataRow drhx = dthx1.Rows[0];
                cbHangXe.Text = drhx["HangXe"].ToString();
            }
            catch
            {
                cbHangXe.Text = null;
            }
            tbBSX.Text = MaBSX;
            tbName.Text = HoTen;
            dtpNgaySinh.Value = NgaySinh;

        }
        private void SuaThongTinXe_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtms = DataProvider.Instance.ExecuteQuery("Select * from MauSac where MS = '" + cbMS.Text + "'");
                DataRow drms = dtms.Rows[0];
                DataTable dthx = DataProvider.Instance.ExecuteQuery("Select * from HangXe where HangXe = '" + cbHangXe.Text + "'");
                DataRow drhx = dthx.Rows[0];
                DataProvider.Instance.ExecuteNonQuery("Update dbo.ThongTinXe set HoVaTen = '" + tbName.Text + "', NgaySinh = '" + dtpNgaySinh.Text + "', GT = '" + (cbGT.SelectedIndex + 1).ToString() + "', LoaiMau = '" + drms["MaMS"].ToString() + "', HangXe = '" + drhx["MaHangXe"].ToString() + "' where MaBSX = '" + tbBSX.Text + "' ");
                MessageBox.Show("Đã sửa thành công");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Không được để trống");
            }
            
            
        }

        private void cbLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbGT_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
