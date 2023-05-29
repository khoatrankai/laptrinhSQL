
namespace QuanLiNhaXe
{
    partial class DoiMatKhau
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbPassold = new System.Windows.Forms.TextBox();
            this.tbPassnew = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbagainPassnew = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChangepass = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(120, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật Khẩu Cũ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbPassold
            // 
            this.tbPassold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbPassold.Location = new System.Drawing.Point(279, 97);
            this.tbPassold.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassold.Name = "tbPassold";
            this.tbPassold.PasswordChar = '*';
            this.tbPassold.Size = new System.Drawing.Size(231, 22);
            this.tbPassold.TabIndex = 1;
            this.tbPassold.TextChanged += new System.EventHandler(this.tbPassold_TextChanged);
            // 
            // tbPassnew
            // 
            this.tbPassnew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbPassnew.Location = new System.Drawing.Point(279, 158);
            this.tbPassnew.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassnew.Name = "tbPassnew";
            this.tbPassnew.PasswordChar = '*';
            this.tbPassnew.Size = new System.Drawing.Size(231, 22);
            this.tbPassnew.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(108, 157);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật Khẩu Mới";
            // 
            // tbagainPassnew
            // 
            this.tbagainPassnew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbagainPassnew.Location = new System.Drawing.Point(279, 217);
            this.tbagainPassnew.Margin = new System.Windows.Forms.Padding(4);
            this.tbagainPassnew.Name = "tbagainPassnew";
            this.tbagainPassnew.PasswordChar = ' ';
            this.tbagainPassnew.Size = new System.Drawing.Size(231, 22);
            this.tbagainPassnew.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 216);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhập Lại Mật Khẩu Mới";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnChangepass
            // 
            this.btnChangepass.BackColor = System.Drawing.Color.Red;
            this.btnChangepass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangepass.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangepass.Location = new System.Drawing.Point(157, 329);
            this.btnChangepass.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangepass.Name = "btnChangepass";
            this.btnChangepass.Size = new System.Drawing.Size(100, 28);
            this.btnChangepass.TabIndex = 6;
            this.btnChangepass.Text = "Đổi ";
            this.btnChangepass.UseVisualStyleBackColor = false;
            this.btnChangepass.Click += new System.EventHandler(this.btnChangepass_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(405, 329);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 28);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // DoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLiNhaXe.Properties.Resources.hinh_nen_bau_troi_dem_dau_sao_cho_may_tinh_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(639, 434);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnChangepass);
            this.Controls.Add(this.tbagainPassnew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPassnew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPassold);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DoiMatKhau";
            this.Text = "Đổi Mật Khẩu";
            this.Load += new System.EventHandler(this.DoiMatKhau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassold;
        private System.Windows.Forms.TextBox tbPassnew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbagainPassnew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChangepass;
        private System.Windows.Forms.Button btnExit;
    }
}