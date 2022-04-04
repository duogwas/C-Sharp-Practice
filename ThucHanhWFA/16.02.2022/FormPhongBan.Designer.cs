
namespace _16._02._2022
{
    partial class FormPhongBan
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
            this.dgvPhongBan = new System.Windows.Forms.DataGridView();
            this.txtMaPB = new System.Windows.Forms.TextBox();
            this.txtTenPB = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lbMaPB = new System.Windows.Forms.Label();
            this.lbMaLoaiPB = new System.Windows.Forms.Label();
            this.lbTenPB = new System.Windows.Forms.Label();
            this.lbDiaChi = new System.Windows.Forms.Label();
            this.cbMaLoaiPb = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lbTimKiem = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbTbaoLoi = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPhongBan
            // 
            this.dgvPhongBan.AllowUserToAddRows = false;
            this.dgvPhongBan.AllowUserToDeleteRows = false;
            this.dgvPhongBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvPhongBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhongBan.Location = new System.Drawing.Point(47, 56);
            this.dgvPhongBan.Name = "dgvPhongBan";
            this.dgvPhongBan.ReadOnly = true;
            this.dgvPhongBan.RowHeadersWidth = 51;
            this.dgvPhongBan.RowTemplate.Height = 24;
            this.dgvPhongBan.Size = new System.Drawing.Size(595, 400);
            this.dgvPhongBan.TabIndex = 0;
            this.dgvPhongBan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtMaPB
            // 
            this.txtMaPB.Location = new System.Drawing.Point(832, 92);
            this.txtMaPB.Name = "txtMaPB";
            this.txtMaPB.Size = new System.Drawing.Size(268, 22);
            this.txtMaPB.TabIndex = 1;
            // 
            // txtTenPB
            // 
            this.txtTenPB.Location = new System.Drawing.Point(832, 206);
            this.txtTenPB.Name = "txtTenPB";
            this.txtTenPB.Size = new System.Drawing.Size(268, 22);
            this.txtTenPB.TabIndex = 3;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(832, 259);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(268, 22);
            this.txtDiaChi.TabIndex = 4;
            // 
            // lbMaPB
            // 
            this.lbMaPB.AutoSize = true;
            this.lbMaPB.Location = new System.Drawing.Point(732, 97);
            this.lbMaPB.Name = "lbMaPB";
            this.lbMaPB.Size = new System.Drawing.Size(49, 17);
            this.lbMaPB.TabIndex = 5;
            this.lbMaPB.Text = "Mã PB";
            // 
            // lbMaLoaiPB
            // 
            this.lbMaLoaiPB.AutoSize = true;
            this.lbMaLoaiPB.Location = new System.Drawing.Point(732, 166);
            this.lbMaLoaiPB.Name = "lbMaLoaiPB";
            this.lbMaLoaiPB.Size = new System.Drawing.Size(80, 17);
            this.lbMaLoaiPB.TabIndex = 6;
            this.lbMaLoaiPB.Text = "Mã Loại PB";
            // 
            // lbTenPB
            // 
            this.lbTenPB.AutoSize = true;
            this.lbTenPB.Location = new System.Drawing.Point(732, 211);
            this.lbTenPB.Name = "lbTenPB";
            this.lbTenPB.Size = new System.Drawing.Size(55, 17);
            this.lbTenPB.TabIndex = 7;
            this.lbTenPB.Text = "Tên PB";
            // 
            // lbDiaChi
            // 
            this.lbDiaChi.AutoSize = true;
            this.lbDiaChi.Location = new System.Drawing.Point(734, 262);
            this.lbDiaChi.Name = "lbDiaChi";
            this.lbDiaChi.Size = new System.Drawing.Size(53, 17);
            this.lbDiaChi.TabIndex = 8;
            this.lbDiaChi.Text = "Địa Chỉ";
            // 
            // cbMaLoaiPb
            // 
            this.cbMaLoaiPb.FormattingEnabled = true;
            this.cbMaLoaiPb.Location = new System.Drawing.Point(832, 166);
            this.cbMaLoaiPb.Name = "cbMaLoaiPb";
            this.cbMaLoaiPb.Size = new System.Drawing.Size(268, 24);
            this.cbMaLoaiPb.TabIndex = 9;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(747, 310);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(97, 42);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(876, 310);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 42);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(995, 310);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(87, 42);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(832, 403);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(268, 22);
            this.txtTimKiem.TabIndex = 13;
            // 
            // lbTimKiem
            // 
            this.lbTimKiem.AutoSize = true;
            this.lbTimKiem.Location = new System.Drawing.Point(734, 403);
            this.lbTimKiem.Name = "lbTimKiem";
            this.lbTimKiem.Size = new System.Drawing.Size(66, 17);
            this.lbTimKiem.TabIndex = 14;
            this.lbTimKiem.Text = "Tìm Kiếm";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lbTbaoLoi
            // 
            this.lbTbaoLoi.AutoSize = true;
            this.lbTbaoLoi.Location = new System.Drawing.Point(829, 130);
            this.lbTbaoLoi.Name = "lbTbaoLoi";
            this.lbTbaoLoi.Size = new System.Drawing.Size(31, 17);
            this.lbTbaoLoi.TabIndex = 15;
            this.lbTbaoLoi.Text = "test";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FormPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 560);
            this.Controls.Add(this.lbTbaoLoi);
            this.Controls.Add(this.lbTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cbMaLoaiPb);
            this.Controls.Add(this.lbDiaChi);
            this.Controls.Add(this.lbTenPB);
            this.Controls.Add(this.lbMaLoaiPB);
            this.Controls.Add(this.lbMaPB);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtTenPB);
            this.Controls.Add(this.txtMaPB);
            this.Controls.Add(this.dgvPhongBan);
            this.Name = "FormPhongBan";
            this.Text = "FormPhongBan";
            this.Load += new System.EventHandler(this.FormPhongBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPhongBan;
        private System.Windows.Forms.TextBox txtMaPB;
        private System.Windows.Forms.TextBox txtTenPB;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lbMaPB;
        private System.Windows.Forms.Label lbMaLoaiPB;
        private System.Windows.Forms.Label lbTenPB;
        private System.Windows.Forms.Label lbDiaChi;
        private System.Windows.Forms.ComboBox cbMaLoaiPb;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lbTimKiem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbTbaoLoi;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}