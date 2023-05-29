using QuanLiNhaXe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhaXe
{
    public partial class ChucNang : Form
    {
        public ChucNang()
        {
            InitializeComponent();
        }

       
        void Dataload()
        {
            DataTable dtLoaiXe = DataProvider.Instance.ExecuteQuery("Select * from BangGia");
            DataTable dtTrangThai = DataProvider.Instance.ExecuteQuery("Select * from TrangThaiTT");
            (dataGridView1.Columns["MaGiaLoaiXe"] as DataGridViewComboBoxColumn).DataSource = dtLoaiXe;
            (dataGridView1.Columns["MaGiaLoaiXe"] as DataGridViewComboBoxColumn).DisplayMember = "LoaiXe";
            (dataGridView1.Columns["MaGiaLoaiXe"] as DataGridViewComboBoxColumn).ValueMember = "MaGia";
            (dataGridView1.Columns["Gia"] as DataGridViewComboBoxColumn).DataSource = dtLoaiXe;
            (dataGridView1.Columns["Gia"] as DataGridViewComboBoxColumn).DisplayMember = "Gia";
            (dataGridView1.Columns["Gia"] as DataGridViewComboBoxColumn).ValueMember = "MaGia";
            (dataGridView1.Columns["TrangThai"] as DataGridViewComboBoxColumn).DataSource = dtTrangThai;
            (dataGridView1.Columns["TrangThai"] as DataGridViewComboBoxColumn).DisplayMember = "TrangThai";
            (dataGridView1.Columns["TrangThai"] as DataGridViewComboBoxColumn).ValueMember = "MaTT";
            DataTable dtLuot = DataProvider.Instance.ExecuteQuery("Select * from ThongTinLuot");
            dataGridView1.DataSource = dtLuot;
            cbLoaiXe.DataSource = dtLoaiXe;
            cbLoaiXe.DisplayMember = "LoaiXe";
            cbLoaiXe.ValueMember = "MaGia";
            cbLoaiXe.Text = "";
            
        }
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau newPass = new DoiMatKhau();
            newPass.Show();

        }
        
        private void bảngGiáToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            if(Form1.ID == "1")
            {
                BangGia bg = new BangGia();
                bg.Show();
            }else
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này");
            
        }

        private void ChucNang_Load(object sender, EventArgs e)
        {
            Dataload();
           
        }

        private void thôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinNhanVien ttnv = new ThongTinNhanVien();
            ttnv.Show();
        }

        private void thôngTinXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinXe ttx = new ThongTinXe();
            ttx.Show();
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinLượtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           int r = dataGridView1.CurrentCell.RowIndex;
           string maLuot = dataGridView1.Rows[r].Cells[0].Value.ToString();
           string MaBSX = dataGridView1.Rows[r].Cells[3].Value.ToString();
           string LoaiXe = dataGridView1.Rows[r].Cells[4].Value.ToString();
           tbBSX.Text = MaBSX;
            DataTable dtlx = DataProvider.Instance.ExecuteQuery("Select * from BangGia where MaGia = '" + LoaiXe + "'");
            
                DataRow drlx = dtlx.Rows[0];
                cbLoaiXe.Text = drlx["LoaiXe"].ToString();
                int dtgiathanh = (int)DataProvider.Instance.ExecuteScaler("Select dbo.UF_GIAXE('"+maLuot+"')");
                //DataRow drgiathanh = dtgiathanh.Rows[0];
                lbThanhToan.Text = dtgiathanh.ToString() + "VNĐ";
                if(dtgiathanh < 0)
                    MessageBox.Show("Xe này không thể thanh toán"); 
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThongTinLuotMoi ttlm = new ThongTinLuotMoi();
            ttlm.ShowDialog();
            Dataload();
        }

        private void cbLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = tbBSX.Text;
            string b = (cbLoaiXe.SelectedIndex + 1 ).ToString();
            DataTable dtLoaiXe = DataProvider.Instance.ExecuteQuery("Select * from BangGia");
            (dataGridView1.Columns["MaGiaLoaiXe"] as DataGridViewComboBoxColumn).DataSource = dtLoaiXe;
            (dataGridView1.Columns["MaGiaLoaiXe"] as DataGridViewComboBoxColumn).DisplayMember = "LoaiXe";
            (dataGridView1.Columns["MaGiaLoaiXe"] as DataGridViewComboBoxColumn).ValueMember = "MaGia";
            DataTable tk = DataProvider.Instance.ExecuteQuery("Select * from ThongTinLuot where MaBSX like '%" + a + "%' and LoaiXe = '" + b + "'");
            dataGridView1.DataSource = tk;



        }

        private void tbBSX_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            
               int r = dataGridView1.CurrentCell.RowIndex;
           
            string maLuot = dataGridView1.Rows[r].Cells[0].Value.ToString();
                string LoaiXe = dataGridView1.Rows[r].Cells[4].Value.ToString();
                string trangThai = dataGridView1.Rows[r].Cells[6].Value.ToString();
                if (trangThai == "2")
                {
                    MessageBox.Show("Xe Này Đã Được Thanh Toán ", "Thông Báo");
                }
                else
                {
                    DialogResult hoi = MessageBox.Show("Bạn có muốn thanh toán số tiền " + lbThanhToan.Text + " của xe có biển số " + tbBSX.Text + "", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (hoi == DialogResult.Yes)
                    {
                        int update = DataProvider.Instance.ExecuteNonQuery("Update ThongTinLuot set TrangThai = '2' where MaLuot = '" + maLuot + "'");
                    MessageBox.Show("Thanh Toán Thành Công");
                        Dataload();
                    }
                }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Dataload();
        }

        private void hãngXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CacHangXe hx = new CacHangXe();
            hx.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Form1.ID == "1")
            {
                QuanLyNhanVien qlnv = new QuanLyNhanVien();
                qlnv.Show();
            }
            else
                MessageBox.Show("Bạn không có quyền dùng chức năng này");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn reset?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                buttonSave_Click(sender, new EventArgs());
                DataProvider.Instance.ExecuteNonQuery("EXEC USP_Reset");
            }
            Dataload();
        }

        private void lbThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\InPhieuNhaXe.txt";
            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                //DateTime bdate;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {

                        if (j == 0)
                        {

                            writer.Write("\t" + "Luot Gui: " + dataGridView1.Rows[i].Cells[j].Value.ToString() + "|");

                        }
                        else if (j == 1)
                        {
                            writer.Write("\t" + "Ma Nhan Vien Quan Li: " + dataGridView1.Rows[i].Cells[j].Value.ToString() + "|");

                        }
                        else if (j == 2)
                        {

                            writer.Write("\t" + "Thoi Gian Vao: " + dataGridView1.Rows[i].Cells[j].Value.ToString() + "|");
                        }
                        else if (j == 3)
                        {

                            writer.Write("\t" + "Bien So Xe: " + dataGridView1.Rows[i].Cells[j].Value.ToString() + "|");
                        }

                        else if (j == 6)
                        {
                            int r = (int)dataGridView1.SelectedCells[0].OwningRow.Cells["TrangThai"].Value;
                            writer.Write("\t" + "Trang Thai: ");   // + dataGridView1.Rows[i].Cells[j].Value.ToString());
                            if (r == 1)
                            {
                                writer.Write("Chua Thanh Toan" + " | ");
                            }
                            else
                            {
                                writer.Write("Da Thanh Toan" + " | ");
                            }

                        }
                        //writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");


                    }
                    writer.WriteLine("");
                    writer.WriteLine("---------------------------------------------------------------------");

                }
            }
        
    }
    }
}
