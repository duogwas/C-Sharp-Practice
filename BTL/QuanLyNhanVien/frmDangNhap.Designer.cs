
namespace QuanLyNhanVien
{
    partial class frmDangNhap
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
            this.panelDemNguoc = new System.Windows.Forms.Panel();
            this.lbGiay = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbPhut = new System.Windows.Forms.Label();
            this.lbDem = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.linkLabelDangKy = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panelDemNguoc.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelDemNguoc);
            this.panel1.Controls.Add(this.lbDem);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnDangNhap);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 426);
            this.panel1.TabIndex = 0;
            // 
            // panelDemNguoc
            // 
            this.panelDemNguoc.Controls.Add(this.lbGiay);
            this.panelDemNguoc.Controls.Add(this.label7);
            this.panelDemNguoc.Controls.Add(this.lbPhut);
            this.panelDemNguoc.Location = new System.Drawing.Point(118, 282);
            this.panelDemNguoc.Name = "panelDemNguoc";
            this.panelDemNguoc.Size = new System.Drawing.Size(118, 43);
            this.panelDemNguoc.TabIndex = 8;
            this.panelDemNguoc.Visible = false;
            // 
            // lbGiay
            // 
            this.lbGiay.AutoSize = true;
            this.lbGiay.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGiay.Location = new System.Drawing.Point(78, 11);
            this.lbGiay.Name = "lbGiay";
            this.lbGiay.Size = new System.Drawing.Size(36, 26);
            this.lbGiay.TabIndex = 2;
            this.lbGiay.Text = "59";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(53, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 26);
            this.label7.TabIndex = 1;
            this.label7.Text = ":";
            // 
            // lbPhut
            // 
            this.lbPhut.AutoSize = true;
            this.lbPhut.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhut.Location = new System.Drawing.Point(17, 10);
            this.lbPhut.Name = "lbPhut";
            this.lbPhut.Size = new System.Drawing.Size(36, 26);
            this.lbPhut.TabIndex = 0;
            this.lbPhut.Text = "04";
            // 
            // lbDem
            // 
            this.lbDem.AutoSize = true;
            this.lbDem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDem.ForeColor = System.Drawing.Color.Red;
            this.lbDem.Location = new System.Drawing.Point(127, 257);
            this.lbDem.Name = "lbDem";
            this.lbDem.Size = new System.Drawing.Size(94, 22);
            this.lbDem.TabIndex = 7;
            this.lbDem.Text = "Số lần sai:";
            this.lbDem.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(664, 205);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.linkLabelDangKy);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(140, 346);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(509, 38);
            this.panel4.TabIndex = 6;
            // 
            // linkLabelDangKy
            // 
            this.linkLabelDangKy.AutoSize = true;
            this.linkLabelDangKy.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelDangKy.Location = new System.Drawing.Point(298, 10);
            this.linkLabelDangKy.Name = "linkLabelDangKy";
            this.linkLabelDangKy.Size = new System.Drawing.Size(123, 22);
            this.linkLabelDangKy.TabIndex = 1;
            this.linkLabelDangKy.TabStop = true;
            this.linkLabelDangKy.Text = "Đăng ký ngay";
            this.linkLabelDangKy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDangKy_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bạn chưa có tài khoản?";
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDangNhap.FlatAppearance.BorderColor = System.Drawing.Color.MintCream;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.Location = new System.Drawing.Point(309, 278);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(195, 43);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.Text = "ĐĂNG NHẬP";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtMatKhau);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(100, 182);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(549, 61);
            this.panel3.TabIndex = 2;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(192, 15);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(310, 30);
            this.txtMatKhau.TabIndex = 1;
            this.txtMatKhau.Text = "1234567";
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.Validating += new System.ComponentModel.CancelEventHandler(this.txtMatKhau_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTaiKhoan);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(100, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(549, 61);
            this.panel2.TabIndex = 1;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaiKhoan.Location = new System.Drawing.Point(192, 17);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(310, 30);
            this.txtTaiKhoan.TabIndex = 1;
            this.txtTaiKhoan.Text = "duong";
            this.txtTaiKhoan.Validating += new System.ComponentModel.CancelEventHandler(this.txtTaiKhoan_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 18);
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
            this.label1.Size = new System.Drawing.Size(428, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ NHÂN SỰ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDangNhap_FormClosing);
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDemNguoc.ResumeLayout(false);
            this.panelDemNguoc.PerformLayout();
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
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.LinkLabel linkLabelDangKy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panelDemNguoc;
        private System.Windows.Forms.Label lbGiay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbPhut;
        private System.Windows.Forms.Label lbDem;
        private System.Windows.Forms.Timer timer1;
    }
}