
namespace QuanLiNhaXe
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbTaiKhoan = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tbMatKhau = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.chbPass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbTaiKhoan
            // 
            this.tbTaiKhoan.BackColor = System.Drawing.Color.Black;
            this.tbTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.tbTaiKhoan.Location = new System.Drawing.Point(264, 177);
            this.tbTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTaiKhoan.Multiline = true;
            this.tbTaiKhoan.Name = "tbTaiKhoan";
            this.tbTaiKhoan.Size = new System.Drawing.Size(159, 15);
            this.tbTaiKhoan.TabIndex = 1;
            this.tbTaiKhoan.Text = "User name";
            this.tbTaiKhoan.Click += new System.EventHandler(this.tbTaiKhoan_Click);
            this.tbTaiKhoan.TextChanged += new System.EventHandler(this.tbTaiKhoan_TextChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Cyan;
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(399, 300);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(98, 32);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // tbMatKhau
            // 
            this.tbMatKhau.BackColor = System.Drawing.Color.Black;
            this.tbMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMatKhau.ForeColor = System.Drawing.Color.White;
            this.tbMatKhau.Location = new System.Drawing.Point(264, 246);
            this.tbMatKhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMatKhau.Multiline = true;
            this.tbMatKhau.Name = "tbMatKhau";
            this.tbMatKhau.PasswordChar = '*';
            this.tbMatKhau.Size = new System.Drawing.Size(159, 19);
            this.tbMatKhau.TabIndex = 2;
            this.tbMatKhau.Text = "Pass word";
            this.tbMatKhau.Click += new System.EventHandler(this.tbMatKhau_Click);
            this.tbMatKhau.Enter += new System.EventHandler(this.tbMatKhau_Enter);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Cyan;
            this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(246, 300);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(80, 32);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // chbPass
            // 
            this.chbPass.AutoSize = true;
            this.chbPass.BackColor = System.Drawing.Color.Black;
            this.chbPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbPass.ForeColor = System.Drawing.Color.White;
            this.chbPass.Location = new System.Drawing.Point(429, 245);
            this.chbPass.Name = "chbPass";
            this.chbPass.Size = new System.Drawing.Size(130, 20);
            this.chbPass.TabIndex = 3;
            this.chbPass.Text = "Hiển thị mật khẩu";
            this.chbPass.UseVisualStyleBackColor = false;
            this.chbPass.CheckedChanged += new System.EventHandler(this.chbPass_CheckedChanged);
            this.chbPass.Click += new System.EventHandler(this.chbPass_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImage = global::QuanLiNhaXe.Properties.Resources.LOGIN__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(768, 463);
            this.Controls.Add(this.chbPass);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.tbMatKhau);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tbTaiKhoan);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbTaiKhoan;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox tbMatKhau;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.CheckBox chbPass;
    }
}

