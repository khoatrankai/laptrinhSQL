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
    public partial class BangGiaThem : Form
    {
        public BangGiaThem()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbLoaiXe_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            string loaiXe = tbLoaiXe.Text;
            string gia = tbGia.Text;
            try
            {
                int a = DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBangGia @LoaiXe= '" + loaiXe + "',@Gia ='" + gia + "'");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Gia không được quá 500000");
            }
            
            
        }

        private void BangGiaThem_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
