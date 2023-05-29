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
    public partial class CacHangXe : Form
    {
        public CacHangXe()
        {
            InitializeComponent();
        }

        void DataLoad()
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select * from HangXe");
            DataTable dt2 = DataProvider.Instance.ExecuteQuery("Select * from BangGia");
            (dataGridView1.Columns["LoaiXe"] as DataGridViewComboBoxColumn).DataSource = dt2;
            (dataGridView1.Columns["LoaiXe"] as DataGridViewComboBoxColumn).DisplayMember = "LoaiXe";
            (dataGridView1.Columns["LoaiXe"] as DataGridViewComboBoxColumn).ValueMember = "MaGia";
            dataGridView1.DataSource = dt;
            cbLoaiXe.DataSource = dt2;
            cbLoaiXe.DisplayMember = "LoaiXe";
            cbLoaiXe.ValueMember = "MaGia";
           
        }
        private void ThanhToan_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select * from BangGia where LoaiXe = '" + cbLoaiXe.Text + "'");
            DataRow dr = dt.Rows[0];
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_AddHangXe @LoaiXe1 = '" + dr["MaGia"].ToString() + "', @HangXe1 = '" + tbHangXe.Text + "'");
            DataLoad();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            string MaHangXe = dataGridView1.Rows[r].Cells[0].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa hãng xe " + MaHangXe + " ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataProvider.Instance.ExecuteNonQuery("EXEC USP_DeleteHangXe @maHangXe   = '" + MaHangXe + "'");
                    MessageBox.Show("Đã xóa thành công");
                    DataLoad();
                }
                catch
                {
                    MessageBox.Show("Bạn không thể xóa", "Thông báo");
                }
            }
        }
    }
}
