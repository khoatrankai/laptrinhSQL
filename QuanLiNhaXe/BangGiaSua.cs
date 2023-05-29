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
    public partial class BangGiaSua : Form
    {
        public BangGiaSua()
        {
            InitializeComponent();
        }
        private string loaiXe;
        private int gia;
        public void Repair(string LoaiXe, int Gia)
        {
            loaiXe = LoaiXe;
            gia = Gia;
        }
        private void BangGiaSua_Load(object sender, EventArgs e)
        {
            tbLoaiXe.Text = loaiXe;
            tbGia.Text = gia.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc muốn sửa " + gia.ToString() + " thành " + tbGia.Text + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (kq == DialogResult.Yes)
            {
                DataProvider.Instance.ExecuteNonQuery("UPDATE BangGia set Gia = '" + tbGia.Text + "' where LoaiXe= '" + tbLoaiXe.Text + "'");
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
