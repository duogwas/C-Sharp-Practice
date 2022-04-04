
namespace QuanLyNhanVien
{
    partial class frmLoaiPhongBan
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dgvLoaiPB = new System.Windows.Forms.DataGridView();
            this.btnBoQua_LPB = new System.Windows.Forms.Button();
            this.btnTimKiem_LPB = new System.Windows.Forms.Button();
            this.btnXoa_LPB = new System.Windows.Forms.Button();
            this.btnSua_LPB = new System.Windows.Forms.Button();
            this.btnThem_LPB = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbTenLoaiPB_error = new System.Windows.Forms.Label();
            this.txt_LPB_tenLoaiPB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbMaLoaiPB_error = new System.Windows.Forms.Label();
            this.txt_LPB_maLoaiPB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.trangChủToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phòngBanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chứcVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lươngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chiTiếtLươngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiPB)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThongKe);
            this.groupBox1.Controls.Add(this.dgvLoaiPB);
            this.groupBox1.Controls.Add(this.btnBoQua_LPB);
            this.groupBox1.Controls.Add(this.btnTimKiem_LPB);
            this.groupBox1.Controls.Add(this.btnXoa_LPB);
            this.groupBox1.Controls.Add(this.btnSua_LPB);
            this.groupBox1.Controls.Add(this.btnThem_LPB);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 749);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại phòng ban";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongKe.Image = global::QuanLyNhanVien.Properties.Resources.Logoexe;
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongKe.Location = new System.Drawing.Point(488, 686);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(4);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(137, 38);
            this.btnThongKe.TabIndex = 26;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // dgvLoaiPB
            // 
            this.dgvLoaiPB.AllowUserToAddRows = false;
            this.dgvLoaiPB.AllowUserToDeleteRows = false;
            this.dgvLoaiPB.AllowUserToResizeColumns = false;
            this.dgvLoaiPB.AllowUserToResizeRows = false;
            this.dgvLoaiPB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvLoaiPB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoaiPB.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoaiPB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiPB.Location = new System.Drawing.Point(55, 281);
            this.dgvLoaiPB.Name = "dgvLoaiPB";
            this.dgvLoaiPB.ReadOnly = true;
            this.dgvLoaiPB.RowHeadersWidth = 51;
            this.dgvLoaiPB.RowTemplate.Height = 24;
            this.dgvLoaiPB.Size = new System.Drawing.Size(583, 382);
            this.dgvLoaiPB.TabIndex = 25;
            this.dgvLoaiPB.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiPB_CellClick);
            // 
            // btnBoQua_LPB
            // 
            this.btnBoQua_LPB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBoQua_LPB.Image = global::QuanLyNhanVien.Properties.Resources.iconfinder_Synchronize_278832;
            this.btnBoQua_LPB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBoQua_LPB.Location = new System.Drawing.Point(534, 218);
            this.btnBoQua_LPB.Margin = new System.Windows.Forms.Padding(4);
            this.btnBoQua_LPB.Name = "btnBoQua_LPB";
            this.btnBoQua_LPB.Size = new System.Drawing.Size(137, 38);
            this.btnBoQua_LPB.TabIndex = 24;
            this.btnBoQua_LPB.Text = "Bỏ qua";
            this.btnBoQua_LPB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBoQua_LPB.UseVisualStyleBackColor = true;
            this.btnBoQua_LPB.Click += new System.EventHandler(this.btnBoQua_LPB_Click);
            // 
            // btnTimKiem_LPB
            // 
            this.btnTimKiem_LPB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimKiem_LPB.Image = global::QuanLyNhanVien.Properties.Resources.iconfinder_Zoom_In_278882;
            this.btnTimKiem_LPB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem_LPB.Location = new System.Drawing.Point(389, 218);
            this.btnTimKiem_LPB.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem_LPB.Name = "btnTimKiem_LPB";
            this.btnTimKiem_LPB.Size = new System.Drawing.Size(137, 38);
            this.btnTimKiem_LPB.TabIndex = 23;
            this.btnTimKiem_LPB.Text = "Tìm kiếm";
            this.btnTimKiem_LPB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem_LPB.UseVisualStyleBackColor = true;
            this.btnTimKiem_LPB.Click += new System.EventHandler(this.btnTimKiem_LPB_Click);
            // 
            // btnXoa_LPB
            // 
            this.btnXoa_LPB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa_LPB.Image = global::QuanLyNhanVien.Properties.Resources.iconfinder_Remove_278742;
            this.btnXoa_LPB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa_LPB.Location = new System.Drawing.Point(271, 218);
            this.btnXoa_LPB.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa_LPB.Name = "btnXoa_LPB";
            this.btnXoa_LPB.Size = new System.Drawing.Size(109, 38);
            this.btnXoa_LPB.TabIndex = 22;
            this.btnXoa_LPB.Text = "Xóa";
            this.btnXoa_LPB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa_LPB.UseVisualStyleBackColor = true;
            this.btnXoa_LPB.Click += new System.EventHandler(this.btnXoa_LPB_Click);
            // 
            // btnSua_LPB
            // 
            this.btnSua_LPB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSua_LPB.Image = global::QuanLyNhanVien.Properties.Resources.iconfinder_Save_278762;
            this.btnSua_LPB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua_LPB.Location = new System.Drawing.Point(154, 218);
            this.btnSua_LPB.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua_LPB.Name = "btnSua_LPB";
            this.btnSua_LPB.Size = new System.Drawing.Size(109, 38);
            this.btnSua_LPB.TabIndex = 21;
            this.btnSua_LPB.Text = "Sửa";
            this.btnSua_LPB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua_LPB.UseVisualStyleBackColor = true;
            this.btnSua_LPB.Click += new System.EventHandler(this.btnSua_LPB_Click);
            // 
            // btnThem_LPB
            // 
            this.btnThem_LPB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem_LPB.Image = global::QuanLyNhanVien.Properties.Resources.iconfinder_Stock_Index_Up_278812;
            this.btnThem_LPB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem_LPB.Location = new System.Drawing.Point(27, 218);
            this.btnThem_LPB.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem_LPB.Name = "btnThem_LPB";
            this.btnThem_LPB.Size = new System.Drawing.Size(109, 38);
            this.btnThem_LPB.TabIndex = 19;
            this.btnThem_LPB.Text = "Thêm";
            this.btnThem_LPB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem_LPB.UseVisualStyleBackColor = true;
            this.btnThem_LPB.Click += new System.EventHandler(this.btnThem_LPB_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbTenLoaiPB_error);
            this.panel2.Controls.Add(this.txt_LPB_tenLoaiPB);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel2.Location = new System.Drawing.Point(93, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 78);
            this.panel2.TabIndex = 4;
            // 
            // lbTenLoaiPB_error
            // 
            this.lbTenLoaiPB_error.AutoSize = true;
            this.lbTenLoaiPB_error.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenLoaiPB_error.ForeColor = System.Drawing.Color.Red;
            this.lbTenLoaiPB_error.Location = new System.Drawing.Point(112, 48);
            this.lbTenLoaiPB_error.Name = "lbTenLoaiPB_error";
            this.lbTenLoaiPB_error.Size = new System.Drawing.Size(250, 22);
            this.lbTenLoaiPB_error.TabIndex = 3;
            this.lbTenLoaiPB_error.Text = "Tên loại phòng ban đã tồn tại";
            this.lbTenLoaiPB_error.Visible = false;
            // 
            // txt_LPB_tenLoaiPB
            // 
            this.txt_LPB_tenLoaiPB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LPB_tenLoaiPB.Location = new System.Drawing.Point(194, 11);
            this.txt_LPB_tenLoaiPB.Name = "txt_LPB_tenLoaiPB";
            this.txt_LPB_tenLoaiPB.Size = new System.Drawing.Size(227, 30);
            this.txt_LPB_tenLoaiPB.TabIndex = 1;
            this.txt_LPB_tenLoaiPB.TextChanged += new System.EventHandler(this.txt_LPB_tenLoaiPB_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên loại phòng ban:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbMaLoaiPB_error);
            this.panel1.Controls.Add(this.txt_LPB_maLoaiPB);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(93, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 82);
            this.panel1.TabIndex = 0;
            // 
            // lbMaLoaiPB_error
            // 
            this.lbMaLoaiPB_error.AutoSize = true;
            this.lbMaLoaiPB_error.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaLoaiPB_error.ForeColor = System.Drawing.Color.Red;
            this.lbMaLoaiPB_error.Location = new System.Drawing.Point(113, 48);
            this.lbMaLoaiPB_error.Name = "lbMaLoaiPB_error";
            this.lbMaLoaiPB_error.Size = new System.Drawing.Size(247, 22);
            this.lbMaLoaiPB_error.TabIndex = 3;
            this.lbMaLoaiPB_error.Text = "Mã loại phòng ban đã tồn tại";
            this.lbMaLoaiPB_error.Visible = false;
            // 
            // txt_LPB_maLoaiPB
            // 
            this.txt_LPB_maLoaiPB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LPB_maLoaiPB.Location = new System.Drawing.Point(194, 11);
            this.txt_LPB_maLoaiPB.Name = "txt_LPB_maLoaiPB";
            this.txt_LPB_maLoaiPB.Size = new System.Drawing.Size(227, 30);
            this.txt_LPB_maLoaiPB.TabIndex = 1;
            this.txt_LPB_maLoaiPB.TextChanged += new System.EventHandler(this.txt_LPB_maLoaiPB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã loại phòng ban:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.menuStrip1.Size = new System.Drawing.Size(747, 27);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // trangChủToolStripMenuItem
            // 
            this.trangChủToolStripMenuItem.Checked = true;
            this.trangChủToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trangChủToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            this.trangChủToolStripMenuItem.Size = new System.Drawing.Size(88, 23);
            this.trangChủToolStripMenuItem.Text = "Trang chủ";
            this.trangChủToolStripMenuItem.Click += new System.EventHandler(this.trangChủToolStripMenuItem_Click);
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinTàiKhoảnToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(85, 23);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            this.thôngTinTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.thôngTinTàiKhoảnToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.Checked = true;
            this.quảnLýToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phòngBanToolStripMenuItem,
            this.chứcVụToolStripMenuItem,
            this.nhânViênToolStripMenuItem,
            this.lươngToolStripMenuItem});
            this.quảnLýToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(75, 23);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // phòngBanToolStripMenuItem
            // 
            this.phòngBanToolStripMenuItem.Name = "phòngBanToolStripMenuItem";
            this.phòngBanToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.phòngBanToolStripMenuItem.Text = "Phòng ban";
            this.phòngBanToolStripMenuItem.Click += new System.EventHandler(this.phòngBanToolStripMenuItem_Click);
            // 
            // chứcVụToolStripMenuItem
            // 
            this.chứcVụToolStripMenuItem.Name = "chứcVụToolStripMenuItem";
            this.chứcVụToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.chứcVụToolStripMenuItem.Text = "Chức vụ";
            this.chứcVụToolStripMenuItem.Click += new System.EventHandler(this.chứcVụToolStripMenuItem_Click);
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.nhânViênToolStripMenuItem.Text = "Nhân viên";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // lươngToolStripMenuItem
            // 
            this.lươngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chiTiếtLươngToolStripMenuItem});
            this.lươngToolStripMenuItem.Name = "lươngToolStripMenuItem";
            this.lươngToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.lươngToolStripMenuItem.Text = "Lương";
            this.lươngToolStripMenuItem.Click += new System.EventHandler(this.lươngToolStripMenuItem_Click);
            // 
            // chiTiếtLươngToolStripMenuItem
            // 
            this.chiTiếtLươngToolStripMenuItem.Name = "chiTiếtLươngToolStripMenuItem";
            this.chiTiếtLươngToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.chiTiếtLươngToolStripMenuItem.Text = "Chi tiết lương";
            this.chiTiếtLươngToolStripMenuItem.Click += new System.EventHandler(this.chiTiếtLươngToolStripMenuItem_Click);
            // 
            // frmLoaiPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 849);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmLoaiPhongBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loại phòng ban";
            this.Load += new System.EventHandler(this.frmLoaiPhongBan_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiPB)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvLoaiPB;
        private System.Windows.Forms.Button btnBoQua_LPB;
        private System.Windows.Forms.Button btnTimKiem_LPB;
        private System.Windows.Forms.Button btnXoa_LPB;
        private System.Windows.Forms.Button btnSua_LPB;
        private System.Windows.Forms.Button btnThem_LPB;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbTenLoaiPB_error;
        private System.Windows.Forms.TextBox txt_LPB_tenLoaiPB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbMaLoaiPB_error;
        private System.Windows.Forms.TextBox txt_LPB_maLoaiPB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem trangChủToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phòngBanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chứcVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lươngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chiTiếtLươngToolStripMenuItem;
    }
}