
namespace QuanLyNhanVien
{
    partial class frmPhongBan
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dgvPhongBan = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbMaPB_error = new System.Windows.Forms.Label();
            this.txt_PB_maPB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cb_PB_tenLoaiPB = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnBoQua_PB = new System.Windows.Forms.Button();
            this.btnTimKiem_PB = new System.Windows.Forms.Button();
            this.btnSua_PB = new System.Windows.Forms.Button();
            this.btnXoa_PB = new System.Windows.Forms.Button();
            this.btnThem_PB = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbTenPB_error = new System.Windows.Forms.Label();
            this.txt_PB_tenPB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongBan)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThongKe);
            this.groupBox2.Controls.Add(this.dgvPhongBan);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel9);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(44, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1105, 731);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Phòng ban";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongKe.Image = global::QuanLyNhanVien.Properties.Resources.Logoexe;
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongKe.Location = new System.Drawing.Point(845, 667);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(4);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(137, 38);
            this.btnThongKe.TabIndex = 27;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.UseVisualStyleBackColor = true;
            // 
            // dgvPhongBan
            // 
            this.dgvPhongBan.AllowUserToAddRows = false;
            this.dgvPhongBan.AllowUserToDeleteRows = false;
            this.dgvPhongBan.AllowUserToResizeColumns = false;
            this.dgvPhongBan.AllowUserToResizeRows = false;
            this.dgvPhongBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPhongBan.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhongBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhongBan.Location = new System.Drawing.Point(134, 269);
            this.dgvPhongBan.Name = "dgvPhongBan";
            this.dgvPhongBan.RowHeadersWidth = 51;
            this.dgvPhongBan.RowTemplate.Height = 24;
            this.dgvPhongBan.Size = new System.Drawing.Size(796, 382);
            this.dgvPhongBan.TabIndex = 8;
            this.dgvPhongBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhongBan_CellClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbMaPB_error);
            this.panel3.Controls.Add(this.txt_PB_maPB);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(36, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(433, 68);
            this.panel3.TabIndex = 1;
            // 
            // lbMaPB_error
            // 
            this.lbMaPB_error.AutoSize = true;
            this.lbMaPB_error.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaPB_error.ForeColor = System.Drawing.Color.Red;
            this.lbMaPB_error.Location = new System.Drawing.Point(94, 44);
            this.lbMaPB_error.Name = "lbMaPB_error";
            this.lbMaPB_error.Size = new System.Drawing.Size(210, 22);
            this.lbMaPB_error.TabIndex = 3;
            this.lbMaPB_error.Text = "Mã phòng ban đã tồn tại";
            this.lbMaPB_error.Visible = false;
            // 
            // txt_PB_maPB
            // 
            this.txt_PB_maPB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PB_maPB.Location = new System.Drawing.Point(169, 6);
            this.txt_PB_maPB.Name = "txt_PB_maPB";
            this.txt_PB_maPB.Size = new System.Drawing.Size(227, 30);
            this.txt_PB_maPB.TabIndex = 1;
            this.txt_PB_maPB.TextChanged += new System.EventHandler(this.txt_PB_maPB_TextChanged);
            this.txt_PB_maPB.Validating += new System.ComponentModel.CancelEventHandler(this.txt_PB_maPB_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mã phòng ban:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cb_PB_tenLoaiPB);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(497, 30);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(433, 68);
            this.panel4.TabIndex = 4;
            // 
            // cb_PB_tenLoaiPB
            // 
            this.cb_PB_tenLoaiPB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_PB_tenLoaiPB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_PB_tenLoaiPB.FormattingEnabled = true;
            this.cb_PB_tenLoaiPB.Location = new System.Drawing.Point(172, 5);
            this.cb_PB_tenLoaiPB.Name = "cb_PB_tenLoaiPB";
            this.cb_PB_tenLoaiPB.Size = new System.Drawing.Size(226, 30);
            this.cb_PB_tenLoaiPB.TabIndex = 4;
            this.cb_PB_tenLoaiPB.SelectedIndexChanged += new System.EventHandler(this.cb_PB_tenLoaiPB_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "Loại phòng ban:";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnBoQua_PB);
            this.panel9.Controls.Add(this.btnTimKiem_PB);
            this.panel9.Controls.Add(this.btnSua_PB);
            this.panel9.Controls.Add(this.btnXoa_PB);
            this.panel9.Controls.Add(this.btnThem_PB);
            this.panel9.Location = new System.Drawing.Point(134, 182);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(796, 63);
            this.panel9.TabIndex = 7;
            // 
            // btnBoQua_PB
            // 
            this.btnBoQua_PB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBoQua_PB.Image = global::QuanLyNhanVien.Properties.Resources.iconfinder_Synchronize_278832;
            this.btnBoQua_PB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBoQua_PB.Location = new System.Drawing.Point(622, 16);
            this.btnBoQua_PB.Margin = new System.Windows.Forms.Padding(4);
            this.btnBoQua_PB.Name = "btnBoQua_PB";
            this.btnBoQua_PB.Size = new System.Drawing.Size(137, 38);
            this.btnBoQua_PB.TabIndex = 22;
            this.btnBoQua_PB.Text = "Bỏ qua";
            this.btnBoQua_PB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBoQua_PB.UseVisualStyleBackColor = true;
            this.btnBoQua_PB.Click += new System.EventHandler(this.btnBoQua_PB_Click);
            // 
            // btnTimKiem_PB
            // 
            this.btnTimKiem_PB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimKiem_PB.Image = global::QuanLyNhanVien.Properties.Resources.iconfinder_Zoom_In_278882;
            this.btnTimKiem_PB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem_PB.Location = new System.Drawing.Point(459, 16);
            this.btnTimKiem_PB.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem_PB.Name = "btnTimKiem_PB";
            this.btnTimKiem_PB.Size = new System.Drawing.Size(137, 38);
            this.btnTimKiem_PB.TabIndex = 21;
            this.btnTimKiem_PB.Text = "Tìm kiếm";
            this.btnTimKiem_PB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem_PB.UseVisualStyleBackColor = true;
            this.btnTimKiem_PB.Click += new System.EventHandler(this.btnTimKiem_PB_Click);
            // 
            // btnSua_PB
            // 
            this.btnSua_PB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSua_PB.Image = global::QuanLyNhanVien.Properties.Resources.iconfinder_Save_278762;
            this.btnSua_PB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua_PB.Location = new System.Drawing.Point(171, 16);
            this.btnSua_PB.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua_PB.Name = "btnSua_PB";
            this.btnSua_PB.Size = new System.Drawing.Size(109, 38);
            this.btnSua_PB.TabIndex = 20;
            this.btnSua_PB.Text = "Sửa";
            this.btnSua_PB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua_PB.UseVisualStyleBackColor = true;
            this.btnSua_PB.Click += new System.EventHandler(this.btnSua_PB_Click);
            // 
            // btnXoa_PB
            // 
            this.btnXoa_PB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa_PB.Image = global::QuanLyNhanVien.Properties.Resources.iconfinder_Remove_278742;
            this.btnXoa_PB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa_PB.Location = new System.Drawing.Point(317, 16);
            this.btnXoa_PB.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa_PB.Name = "btnXoa_PB";
            this.btnXoa_PB.Size = new System.Drawing.Size(109, 38);
            this.btnXoa_PB.TabIndex = 19;
            this.btnXoa_PB.Text = "Xóa";
            this.btnXoa_PB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa_PB.UseVisualStyleBackColor = true;
            this.btnXoa_PB.Click += new System.EventHandler(this.btnXoa_PB_Click);
            // 
            // btnThem_PB
            // 
            this.btnThem_PB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem_PB.Image = global::QuanLyNhanVien.Properties.Resources.iconfinder_Stock_Index_Up_278812;
            this.btnThem_PB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem_PB.Location = new System.Drawing.Point(30, 16);
            this.btnThem_PB.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem_PB.Name = "btnThem_PB";
            this.btnThem_PB.Size = new System.Drawing.Size(109, 38);
            this.btnThem_PB.TabIndex = 18;
            this.btnThem_PB.Text = "Thêm";
            this.btnThem_PB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem_PB.UseVisualStyleBackColor = true;
            this.btnThem_PB.Click += new System.EventHandler(this.btnThem_PB_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbTenPB_error);
            this.panel5.Controls.Add(this.txt_PB_tenPB);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Location = new System.Drawing.Point(222, 104);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(611, 68);
            this.panel5.TabIndex = 5;
            // 
            // lbTenPB_error
            // 
            this.lbTenPB_error.AutoSize = true;
            this.lbTenPB_error.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenPB_error.ForeColor = System.Drawing.Color.Red;
            this.lbTenPB_error.Location = new System.Drawing.Point(231, 44);
            this.lbTenPB_error.Name = "lbTenPB_error";
            this.lbTenPB_error.Size = new System.Drawing.Size(213, 22);
            this.lbTenPB_error.TabIndex = 6;
            this.lbTenPB_error.Text = "Tên phòng ban đã tồn tại";
            this.lbTenPB_error.Visible = false;
            // 
            // txt_PB_tenPB
            // 
            this.txt_PB_tenPB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PB_tenPB.Location = new System.Drawing.Point(188, 7);
            this.txt_PB_tenPB.Name = "txt_PB_tenPB";
            this.txt_PB_tenPB.Size = new System.Drawing.Size(374, 30);
            this.txt_PB_tenPB.TabIndex = 1;
            this.txt_PB_tenPB.TextChanged += new System.EventHandler(this.txt_PB_tenPB_TextChanged);
            this.txt_PB_tenPB.Validating += new System.ComponentModel.CancelEventHandler(this.txt_PB_tenPB_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(41, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tên phòng ban:";
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
            this.menuStrip1.Size = new System.Drawing.Size(1181, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // trangChủToolStripMenuItem
            // 
            this.trangChủToolStripMenuItem.Checked = true;
            this.trangChủToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trangChủToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            this.trangChủToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
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
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
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
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // phòngBanToolStripMenuItem
            // 
            this.phòngBanToolStripMenuItem.Name = "phòngBanToolStripMenuItem";
            this.phòngBanToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.phòngBanToolStripMenuItem.Text = "Loại phòng ban";
            this.phòngBanToolStripMenuItem.Click += new System.EventHandler(this.phòngBanToolStripMenuItem_Click);
            // 
            // chứcVụToolStripMenuItem
            // 
            this.chứcVụToolStripMenuItem.Name = "chứcVụToolStripMenuItem";
            this.chứcVụToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.chứcVụToolStripMenuItem.Text = "Chức vụ";
            this.chứcVụToolStripMenuItem.Click += new System.EventHandler(this.chứcVụToolStripMenuItem_Click);
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.nhânViênToolStripMenuItem.Text = "Nhân viên";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // lươngToolStripMenuItem
            // 
            this.lươngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chiTiếtLươngToolStripMenuItem});
            this.lươngToolStripMenuItem.Name = "lươngToolStripMenuItem";
            this.lươngToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.lươngToolStripMenuItem.Text = "Lương";
            this.lươngToolStripMenuItem.Click += new System.EventHandler(this.lươngToolStripMenuItem_Click);
            // 
            // chiTiếtLươngToolStripMenuItem
            // 
            this.chiTiếtLươngToolStripMenuItem.Name = "chiTiếtLươngToolStripMenuItem";
            this.chiTiếtLươngToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.chiTiếtLươngToolStripMenuItem.Text = "Chi tiết lương";
            this.chiTiếtLươngToolStripMenuItem.Click += new System.EventHandler(this.chiTiếtLươngToolStripMenuItem_Click);
            // 
            // frmPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 803);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmPhongBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý phòng ban";
            this.Load += new System.EventHandler(this.frmPhongBan_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongBan)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbTenPB_error;
        private System.Windows.Forms.TextBox txt_PB_tenPB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cb_PB_tenLoaiPB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbMaPB_error;
        private System.Windows.Forms.TextBox txt_PB_maPB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvPhongBan;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnBoQua_PB;
        private System.Windows.Forms.Button btnTimKiem_PB;
        private System.Windows.Forms.Button btnSua_PB;
        private System.Windows.Forms.Button btnXoa_PB;
        private System.Windows.Forms.Button btnThem_PB;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem trangChủToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phòngBanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chứcVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.ToolStripMenuItem lươngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chiTiếtLươngToolStripMenuItem;
    }
}