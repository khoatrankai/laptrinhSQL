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
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }
        private int chon = 0;
        private string maNV = "";
        void DataLoad()
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select * from NhanVien where MaNV != '1'");
            dataGridView1.DataSource = dt;
        }
        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            DataLoad();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnRepair.Enabled = false;
            btnDelete.Enabled = false;
            btnSearch.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnSave.BackColor = Color.Red;
            btnCancel.BackColor = Color.Red;
            tbName.Text = "";   
            tbUserLogin.Text = "";
            tbPassLogin.Text = "";
            chon = 1;
        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            string HoTen = dataGridView1.Rows[r].Cells[1].Value.ToString();
            DateTime NgaySinh = DateTime.Parse(dataGridView1.Rows[r].Cells[2].Value.ToString());
            string UserLogin = dataGridView1.Rows[r].Cells[3].Value.ToString();
            string PassLogin = dataGridView1.Rows[r].Cells[4].Value.ToString();
            maNV = dataGridView1.Rows[r].Cells[0].Value.ToString();
            tbName.Text = HoTen;
            dtpTime.Value = NgaySinh;
            tbUserLogin.Text = UserLogin;
            tbPassLogin.Text = PassLogin;
            btnAdd.Enabled = false;
            btnRepair.Enabled = false;
            btnDelete.Enabled = false;
            btnSearch.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnSave.BackColor = Color.Red;
            btnCancel.BackColor = Color.Red;
            chon = 2;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(chon == 1)
            {
                try
                {
                    DataProvider.Instance.ExecuteNonQuery("EXEC USP_KTUser @hoTen = '" + tbName.Text + "', @ngaySinh = '" + dtpTime.Text + "', @userLogin = '" + tbUserLogin.Text + "', @passLogin = '" + tbPassLogin.Text + "'");
                    MessageBox.Show("Thêm Thành Công", "Thông Báo");
                    btnAdd.Enabled = true;
                    btnRepair.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSearch.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    tbName.Text = "";
                    tbUserLogin.Text = "";
                    tbPassLogin.Text = "";
                    btnSave.BackColor = Color.White;
                    btnCancel.BackColor = Color.White;
                    DataLoad();
                }
                catch
                {
                    MessageBox.Show("Tài Khoản này đã tồn tại", "Thông Báo");
                }
            }else
            {
                if (chon == 2)
                {
                    try
                    {
                        DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateNhanVien  @MaNV = '"+maNV+"' ,@HoTen = '" + tbName.Text + "' , @NS = '" + dtpTime.Text + "', @userLogin = '" + tbUserLogin.Text + "', @passLogin = '" + tbPassLogin.Text + "'");
                        btnAdd.Enabled = true;
                        btnRepair.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSearch.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        MessageBox.Show("Đã Cập Nhật");  
                        DataLoad();
                    }catch
                    {
                        MessageBox.Show("Tài khoản mới cập nhật đã tồn tại");
                    }
                }
            }
                
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnRepair.Enabled = true;
            btnDelete.Enabled = true;
            btnSearch.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            tbName.Text = "";
            tbUserLogin.Text = "";
            tbPassLogin.Text = "";
            btnSave.BackColor = Color.White;
            btnCancel.BackColor = Color.White;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            maNV = dataGridView1.Rows[r].Cells[0].Value.ToString();

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa Nhân Viên " + maNV + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataProvider.Instance.ExecuteNonQuery("EXEC USP_DeleteNhanVien  @maNV = '" + maNV + "'");
                    DataLoad();
                }
                catch
                {
                    MessageBox.Show("Không thể xóa");
                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select * from NhanVien where UserLogin like '%"+tbUserLogin.Text+"%' and PassLogin like '%"+tbPassLogin.Text+"%' and HoVaTen like '%"+tbName.Text+"%' and MaNV != '"+Form1.ID+"'");
            dataGridView1.DataSource = dt;
        }
    }
}
