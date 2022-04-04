
namespace QuanLyNhanVien
{
    partial class frmTrangChu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.trangChủToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLoaiPB = new System.Windows.Forms.Button();
            this.btnChucVu = new System.Windows.Forms.Button();
            this.btnLuong = new System.Windows.Forms.Button();
            this.btnPhongBan = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.lbDisplayName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnChiTietLuong = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trangChủToolStripMenuItem,
            this.hệThốngToolStripMenuItem,
            this.quảnLýToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(841, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // trangChủToolStripMenuItem
            // 
            this.trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            this.trangChủToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.trangChủToolStripMenuItem.Text = "Trang chủ";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.Checked = true;
            this.hệThốngToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinTàiKhoảnToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            this.thôngTinTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.thôngTinTàiKhoảnToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.quảnLýToolStripMenuItem.Text = "Trợ giúp";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lbDisplayName);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 495);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnChiTietLuong);
            this.panel3.Controls.Add(this.btnLoaiPB);
            this.panel3.Controls.Add(this.btnChucVu);
            this.panel3.Controls.Add(this.btnLuong);
            this.panel3.Controls.Add(this.btnPhongBan);
            this.panel3.Controls.Add(this.btnNhanVien);
            this.panel3.Location = new System.Drawing.Point(12, 186);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(811, 270);
            this.panel3.TabIndex = 1;
            // 
            // btnLoaiPB
            // 
            this.btnLoaiPB.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLoaiPB.FlatAppearance.BorderColor = System.Drawing.Color.MintCream;
            this.btnLoaiPB.FlatAppearance.BorderSize = 0;
            this.btnLoaiPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoaiPB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoaiPB.Location = new System.Drawing.Point(103, 137);
            this.btnLoaiPB.Name = "btnLoaiPB";
            this.btnLoaiPB.Size = new System.Drawing.Size(179, 79);
            this.btnLoaiPB.TabIndex = 4;
            this.btnLoaiPB.Text = "LOẠI PHÒNG BAN";
            this.btnLoaiPB.UseVisualStyleBackColor = false;
            this.btnLoaiPB.Click += new System.EventHandler(this.btnLoaiPB_Click);
            // 
            // btnChucVu
            // 
            this.btnChucVu.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnChucVu.FlatAppearance.BorderColor = System.Drawing.Color.MintCream;
            this.btnChucVu.FlatAppearance.BorderSize = 0;
            this.btnChucVu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChucVu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChucVu.Location = new System.Drawing.Point(323, 137);
            this.btnChucVu.Name = "btnChucVu";
            this.btnChucVu.Size = new System.Drawing.Size(179, 79);
            this.btnChucVu.TabIndex = 3;
            this.btnChucVu.Text = "CHỨC VỤ";
            this.btnChucVu.UseVisualStyleBackColor = false;
            this.btnChucVu.Click += new System.EventHandler(this.btnChucVu_Click);
            // 
            // btnLuong
            // 
            this.btnLuong.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLuong.FlatAppearance.BorderColor = System.Drawing.Color.MintCream;
            this.btnLuong.FlatAppearance.BorderSize = 0;
            this.btnLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuong.Location = new System.Drawing.Point(546, 24);
            this.btnLuong.Name = "btnLuong";
            this.btnLuong.Size = new System.Drawing.Size(179, 79);
            this.btnLuong.TabIndex = 2;
            this.btnLuong.Text = "LƯƠNG";
            this.btnLuong.UseVisualStyleBackColor = false;
            this.btnLuong.Click += new System.EventHandler(this.btnLuong_Click);
            // 
            // btnPhongBan
            // 
            this.btnPhongBan.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnPhongBan.FlatAppearance.BorderColor = System.Drawing.Color.MintCream;
            this.btnPhongBan.FlatAppearance.BorderSize = 0;
            this.btnPhongBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhongBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhongBan.Location = new System.Drawing.Point(103, 24);
            this.btnPhongBan.Name = "btnPhongBan";
            this.btnPhongBan.Size = new System.Drawing.Size(179, 79);
            this.btnPhongBan.TabIndex = 1;
            this.btnPhongBan.Text = "PHÒNG BAN";
            this.btnPhongBan.UseVisualStyleBackColor = false;
            this.btnPhongBan.Click += new System.EventHandler(this.btnPhongBan_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnNhanVien.FlatAppearance.BorderColor = System.Drawing.Color.MintCream;
            this.btnNhanVien.FlatAppearance.BorderSize = 0;
            this.btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanVien.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.ForeColor = System.Drawing.Color.Black;
            this.btnNhanVien.Location = new System.Drawing.Point(323, 24);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(179, 79);
            this.btnNhanVien.TabIndex = 0;
            this.btnNhanVien.Text = "NHÂN VIÊN";
            this.btnNhanVien.UseVisualStyleBackColor = false;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // lbDisplayName
            // 
            this.lbDisplayName.AutoSize = true;
            this.lbDisplayName.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDisplayName.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lbDisplayName.Location = new System.Drawing.Point(560, 13);
            this.lbDisplayName.Name = "lbDisplayName";
            this.lbDisplayName.Size = new System.Drawing.Size(254, 23);
            this.lbDisplayName.TabIndex = 1;
            this.lbDisplayName.Text = "Xin chào Kiều Hoàng Dương";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(10, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(811, 130);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(258, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.Font = new System.Drawing.Font("Arial", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(202, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "CÔNG TY TNHH DTTV";
            // 
            // btnChiTietLuong
            // 
            this.btnChiTietLuong.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnChiTietLuong.FlatAppearance.BorderColor = System.Drawing.Color.MintCream;
            this.btnChiTietLuong.FlatAppearance.BorderSize = 0;
            this.btnChiTietLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiTietLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiTietLuong.Location = new System.Drawing.Point(546, 137);
            this.btnChiTietLuong.Name = "btnChiTietLuong";
            this.btnChiTietLuong.Size = new System.Drawing.Size(179, 79);
            this.btnChiTietLuong.TabIndex = 5;
            this.btnChiTietLuong.Text = "CHI TIẾT LƯƠNG";
            this.btnChiTietLuong.UseVisualStyleBackColor = false;
            this.btnChiTietLuong.Click += new System.EventHandler(this.btnChiTietLuong_Click);
            // 
            // frmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(841, 523);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmTrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhân viên - Công ty TNHH DTTV";
            this.Load += new System.EventHandler(this.frmTrangChu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnPhongBan;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnLuong;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnChucVu;
        private System.Windows.Forms.Button btnLoaiPB;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.Label lbDisplayName;
        private System.Windows.Forms.ToolStripMenuItem trangChủToolStripMenuItem;
        private System.Windows.Forms.Button btnChiTietLuong;
    }
}