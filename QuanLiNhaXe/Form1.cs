using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiNhaXe.DAO;

namespace QuanLiNhaXe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string ID = "";
        public static string userLoginID = "";
        public static string passLoginID = "";
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string userName = tbTaiKhoan.Text;
            string passWord = tbMatKhau.Text;
            userLoginID = tbTaiKhoan.Text;
            passLoginID = tbMatKhau.Text;
            //if (Login(userName, passWord))
            if(true)
            {
                ChucNang cn = new ChucNang(); 
                this.Hide();
                cn.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("no ok");
        }
        bool Login(string userName, string passWord)
        {
            return Account.Instance.Login(userName, passWord);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(a == DialogResult.Yes)
            {
                Application.Exit();
            }    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        private void chbPass_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chbPass_Click(object sender, EventArgs e)
        { 
            if(tbMatKhau.PasswordChar == '*')
            {
                tbMatKhau.PasswordChar = '\0';
            }else
                tbMatKhau.PasswordChar= '*';
        }

        private void tbTaiKhoan_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tbTaiKhoan_Click(object sender, EventArgs e)
        {
            if(tbTaiKhoan.Text == "User name")
                tbTaiKhoan.Text = "";
            if(tbMatKhau.Text == "" )
            {
                tbMatKhau.Text = "Pass word";
            }


           
        }

        private void tbMatKhau_Click(object sender, EventArgs e)
        {
            if(tbMatKhau.Text == "Pass word")
                tbMatKhau.Text = "";
            if(tbTaiKhoan.Text == "")
            {
                tbTaiKhoan.Text = "User name";
            }
            
        }

        private void Form1_Click(object sender, EventArgs e)
        {

            if (tbTaiKhoan.Text == "")
            {
                tbTaiKhoan.Text = "User name";
            }
            if (tbMatKhau.Text == "")
            {
                tbMatKhau.Text = "Pass word";
            }
        }

        private void tbMatKhau_Enter(object sender, EventArgs e)
        {
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(sender,e);
            }    
        }
    }
}
