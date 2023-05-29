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
    public partial class ThongTinXe : Form
    {
        public ThongTinXe()
        {
            InitializeComponent();
        }

        public void DataLoad()
        {
            DataTable dtttx = DataProvider.Instance.ExecuteQuery("Select * from ThongTinXe");
            DataTable dtbg = DataProvider.Instance.ExecuteQuery("Select * from BangGia");
            DataTable dtgt = DataProvider.Instance.ExecuteQuery("Select * from GioiTinh");
            DataTable dtms = DataProvider.Instance.ExecuteQuery("Select * from MauSac");
            DataTable dthx = DataProvider.Instance.ExecuteQuery("Select * from HangXe");
            (dataGridView1.Columns["GT"] as DataGridViewComboBoxColumn).DataSource = dtgt;
            (dataGridView1.Columns["GT"] as DataGridViewComboBoxColumn).DisplayMember = "GT";
            (dataGridView1.Columns["GT"] as DataGridViewComboBoxColumn).ValueMember = "MaGT";
            (dataGridView1.Columns["LoaiMau"] as DataGridViewComboBoxColumn).DataSource = dtms;
            (dataGridView1.Columns["LoaiMau"] as DataGridViewComboBoxColumn).DisplayMember = "MS";
            (dataGridView1.Columns["LoaiMau"] as DataGridViewComboBoxColumn).ValueMember = "MaMS";
            (dataGridView1.Columns["LoaiXe"] as DataGridViewComboBoxColumn).DataSource = dtbg;
            (dataGridView1.Columns["LoaiXe"] as DataGridViewComboBoxColumn).DisplayMember = "LoaiXe";
            (dataGridView1.Columns["LoaiXe"] as DataGridViewComboBoxColumn).ValueMember = "MaGia";
            (dataGridView1.Columns["HangXe"] as DataGridViewComboBoxColumn).DataSource = dthx;
            (dataGridView1.Columns["HangXe"] as DataGridViewComboBoxColumn).DisplayMember = "HangXe";
            (dataGridView1.Columns["HangXe"] as DataGridViewComboBoxColumn).ValueMember = "MaHangXe";
            dataGridView1.DataSource = dtttx;
            cbLoaiXe.DataSource = dtbg;
            cbLoaiXe.DisplayMember = "LoaiXe";
            cbLoaiXe.ValueMember = "MaGia";
            
            
        }

        private void ThongTinXe_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable lx = DataProvider.Instance.ExecuteQuery("Select * from BangGia where LoaiXe = '" + cbLoaiXe.Text + "'");
            DataRow dr = lx.Rows[0];
            DataTable dtttx = DataProvider.Instance.ExecuteQuery("Select * from ThongTinXe where MaBSX like '%"+tbBSX.Text+"%' and LoaiXe like '%"+dr["MaGia"].ToString()+"%'");
            dataGridView1.DataSource = dtttx;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            string BSX = dataGridView1.Rows[r].Cells[0].Value.ToString();
            string Name = dataGridView1.Rows[r].Cells[1].Value.ToString();
            DateTime dateTime =  DateTime.Parse(dataGridView1.Rows[r].Cells[2].Value.ToString());
            string GT = dataGridView1.Rows[r].Cells[3].Value.ToString();
            string MS = dataGridView1.Rows[r].Cells[4].Value.ToString();
            string LX = dataGridView1.Rows[r].Cells[5].Value.ToString();
            string HX = dataGridView1.Rows[r].Cells[6].Value.ToString();
            MessageBox.Show(HX);
            SuaThongTinXe sttx = new SuaThongTinXe();
            sttx.MaBSX = BSX;
            sttx.HoTen = Name;
            sttx.NgaySinh = dateTime;
            sttx.GT = GT;
            sttx.LoaiMau = MS;
            sttx.LoaiXe = LX;
            sttx.HangXe = HX;
           
            sttx.Show();

        }

        private void cbLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            string BSX = dataGridView1.Rows[r].Cells[0].Value.ToString();
            string Name = dataGridView1.Rows[r].Cells[1].Value.ToString();
            DateTime dateTime = DateTime.Parse(dataGridView1.Rows[r].Cells[2].Value.ToString());
            string GT = dataGridView1.Rows[r].Cells[3].Value.ToString();
            string MS = dataGridView1.Rows[r].Cells[4].Value.ToString();
            string LX = dataGridView1.Rows[r].Cells[5].Value.ToString();
            string HX = dataGridView1.Rows[r].Cells[6].Value.ToString();
            if ((MessageBox.Show("Bạn có chắc muốn xóa "+LX+" có biển số xe "+BSX+"","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                DataProvider.Instance.ExecuteNonQuery("EXEC USP_DeleteThongTinXe @maBSX = '" + BSX + "' , @loaiXe = '" + LX + "'");
                DataLoad();
            }
        }
    }
}
