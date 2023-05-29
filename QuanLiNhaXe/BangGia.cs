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
    public partial class BangGia : Form
    {
        public BangGia()
        {
            InitializeComponent();
            showBangGia();
        }
        void showBangGia()
        {
            DataTable a = DataProvider.Instance.ExecuteQuery("Select * from BangGia");
            dataGridView1.DataSource = a;
           
           
        }
           
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            string LoaiXe = dataGridView1.Rows[r].Cells[1].Value.ToString();
            int Gia = int.Parse(dataGridView1.Rows[r].Cells[2].Value.ToString());
            BangGiaSua bgs = new BangGiaSua();
            bgs.Repair(LoaiXe, Gia);
            bgs.ShowDialog();
            showBangGia();
        }

        private void lsvBangGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            BangGiaThem bgt = new BangGiaThem();
            bgt.ShowDialog();
            showBangGia();
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BangGia_Load(object sender, EventArgs e)
        {

        }

        private void tbLoaiXe_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            string LoaiXe = dataGridView1.Rows[r].Cells[1].Value.ToString();
            int Gia = int.Parse(dataGridView1.Rows[r].Cells[2].Value.ToString());
            BangGiaSua bgs = new BangGiaSua();
            bgs.Repair(LoaiXe, Gia);
            bgs.ShowDialog();
            showBangGia();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            string maLoaiXe = dataGridView1.Rows[r].Cells[0].Value.ToString();
            string LoaiXe = dataGridView1.Rows[r].Cells[1].Value.ToString();
            DialogResult kq = MessageBox.Show("Bạn có muốn chắc muốn xóa Giá loại " + LoaiXe + " ra khỏi bảng ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                try
                {
                    DataProvider.Instance.ExecuteNonQuery("EXEC USP_DeleteLoaiXe @maLoaiXe = '"+maLoaiXe+"'");
                }catch
                {
                    MessageBox.Show("không thể xóa");
                }
                showBangGia();
            }

        }
    }
}
