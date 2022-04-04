
namespace QuanLyNhanVien
{
    partial class frmDangKy
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbCheckPassword = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.txtXacNhanMk = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.linkLabelDangNhap = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbCheckUsername = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbMK = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnDangKy);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(7, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 581);
            this.panel1.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtDisplayName);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(100, 180);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(619, 61);
            this.panel6.TabIndex = 2;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplayName.Location = new System.Drawing.Point(218, 19);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(310, 30);
            this.txtDisplayName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(62, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tên hiển thị:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbCheckPassword);
            this.panel5.Controls.Add(this.checkBox2);
            this.panel5.Controls.Add(this.txtXacNhanMk);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(100, 358);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(619, 88);
            this.panel5.TabIndex = 4;
            // 
            // lbCheckPassword
            // 
            this.lbCheckPassword.AutoSize = true;
            this.lbCheckPassword.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCheckPassword.ForeColor = System.Drawing.Color.Red;
            this.lbCheckPassword.Location = new System.Drawing.Point(280, 55);
            this.lbCheckPassword.Name = "lbCheckPassword";
            this.lbCheckPassword.Size = new System.Drawing.Size(289, 21);
            this.lbCheckPassword.TabIndex = 4;
            this.lbCheckPassword.Text = "Xác nhận mật khẩu không trùng khớp";
            this.lbCheckPassword.Visible = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(542, 24);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 17);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // txtXacNhanMk
            // 
            this.txtXacNhanMk.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXacNhanMk.Location = new System.Drawing.Point(218, 16);
            this.txtXacNhanMk.Name = "txtXacNhanMk";
            this.txtXacNhanMk.Size = new System.Drawing.Size(310, 30);
            this.txtXacNhanMk.TabIndex = 1;
            this.txtXacNhanMk.UseSystemPasswordChar = true;
            this.txtXacNhanMk.TextChanged += new System.EventHandler(this.txtXacNhanMk_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Xác nhận mật khẩu:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.linkLabelDangNhap);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(136, 518);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(509, 38);
            this.panel4.TabIndex = 6;
            // 
            // linkLabelDangNhap
            // 
            this.linkLabelDangNhap.AutoSize = true;
            this.linkLabelDangNhap.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelDangNhap.Location = new System.Drawing.Point(298, 10);
            this.linkLabelDangNhap.Name = "linkLabelDangNhap";
            this.linkLabelDangNhap.Size = new System.Drawing.Size(146, 22);
            this.linkLabelDangNhap.TabIndex = 1;
            this.linkLabelDangNhap.TabStop = true;
            this.linkLabelDangNhap.Text = "Đăng nhập ngay";
            this.linkLabelDangNhap.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDangNhap_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bạn đã có tài khoản?";
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDangKy.FlatAppearance.BorderColor = System.Drawing.Color.MintCream;
            this.btnDangKy.FlatAppearance.BorderSize = 0;
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.Location = new System.Drawing.Point(307, 461);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(195, 43);
            this.btnDangKy.TabIndex = 5;
            this.btnDangKy.Text = "ĐĂNG KÝ";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbMK);
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.txtMatKhau);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(100, 245);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(619, 107);
            this.panel3.TabIndex = 3;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(542, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(218, 27);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(310, 30);
            this.txtMatKhau.TabIndex = 1;
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.TextChanged += new System.EventHandler(this.txtMatKhau_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(87, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbCheckUsername);
            this.panel2.Controls.Add(this.txtTaiKhoan);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(100, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(619, 83);
            this.panel2.TabIndex = 1;
            // 
            // lbCheckUsername
            // 
            this.lbCheckUsername.AutoSize = true;
            this.lbCheckUsername.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCheckUsername.ForeColor = System.Drawing.Color.Red;
            this.lbCheckUsername.Location = new System.Drawing.Point(280, 55);
            this.lbCheckUsername.Name = "lbCheckUsername";
            this.lbCheckUsername.Size = new System.Drawing.Size(243, 21);
            this.lbCheckUsername.TabIndex = 2;
            this.lbCheckUsername.Text = "Tên tài khoản đã được sử dụng";
            this.lbCheckUsername.Visible = false;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaiKhoan.Location = new System.Drawing.Point(218, 21);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(310, 30);
            this.txtTaiKhoan.TabIndex = 1;
            this.txtTaiKhoan.TextChanged += new System.EventHandler(this.txtTaiKhoan_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.YellowGreen;
            this.label1.Location = new System.Drawing.Point(174, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐĂNG KÝ TÀI KHOẢN";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lbMK
            // 
            this.lbMK.AutoSize = true;
            this.lbMK.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMK.ForeColor = System.Drawing.Color.Red;
            this.lbMK.Location = new System.Drawing.Point(99, 64);
            this.lbMK.Name = "lbMK";
            this.lbMK.Size = new System.Drawing.Size(289, 21);
            this.lbMK.TabIndex = 5;
            this.lbMK.Text = "Xác nhận mật khẩu không trùng khớp";
            this.lbMK.Visible = false;
            // 
            // frmDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 629);
            this.Controls.Add(this.panel1);
            this.Name = "frmDangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký tài khoản";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtXacNhanMk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.LinkLabel linkLabelDangNhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lbCheckUsername;
        private System.Windows.Forms.Label lbCheckPassword;
        private System.Windows.Forms.Label lbMK;
    }
}