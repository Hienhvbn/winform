namespace quan_li_ban_sach
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
            this.mnufile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuthoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnudanhmuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnunhanvien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnukhachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnusach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuhoadon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuhoadonban = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutimkiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutimkiemhoadon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutimkiemsanpham = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutimkiemkhachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnufile,
            this.mnudanhmuc,
            this.mnuhoadon,
            this.mnutimkiem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnufile
            // 
            this.mnufile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuthoat});
            this.mnufile.Name = "mnufile";
            this.mnufile.Size = new System.Drawing.Size(55, 20);
            this.mnufile.Text = "&Tệp tin";
            // 
            // mnuthoat
            // 
            this.mnuthoat.Name = "mnuthoat";
            this.mnuthoat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuthoat.Size = new System.Drawing.Size(180, 22);
            this.mnuthoat.Text = "Thoát";
            this.mnuthoat.Click += new System.EventHandler(this.mnuthoat_Click);
            // 
            // mnudanhmuc
            // 
            this.mnudanhmuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnunhanvien,
            this.mnukhachhang,
            this.mnusach});
            this.mnudanhmuc.Name = "mnudanhmuc";
            this.mnudanhmuc.Size = new System.Drawing.Size(74, 20);
            this.mnudanhmuc.Text = "&Danh mục";
            // 
            // mnunhanvien
            // 
            this.mnunhanvien.Name = "mnunhanvien";
            this.mnunhanvien.Size = new System.Drawing.Size(180, 22);
            this.mnunhanvien.Text = "Nhân viên";
            // 
            // mnukhachhang
            // 
            this.mnukhachhang.Name = "mnukhachhang";
            this.mnukhachhang.Size = new System.Drawing.Size(180, 22);
            this.mnukhachhang.Text = "Khách hàng";
            // 
            // mnusach
            // 
            this.mnusach.Name = "mnusach";
            this.mnusach.Size = new System.Drawing.Size(180, 22);
            this.mnusach.Text = "Sách";
            this.mnusach.Click += new System.EventHandler(this.mnusach_Click);
            // 
            // mnuhoadon
            // 
            this.mnuhoadon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuhoadonban});
            this.mnuhoadon.Name = "mnuhoadon";
            this.mnuhoadon.Size = new System.Drawing.Size(65, 20);
            this.mnuhoadon.Text = "&Hoá đơn";
            // 
            // mnuhoadonban
            // 
            this.mnuhoadonban.Name = "mnuhoadonban";
            this.mnuhoadonban.Size = new System.Drawing.Size(180, 22);
            this.mnuhoadonban.Text = "Hoá đơn bán";
            this.mnuhoadonban.Click += new System.EventHandler(this.mnuhoadonban_Click);
            // 
            // mnutimkiem
            // 
            this.mnutimkiem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnutimkiemhoadon,
            this.mnutimkiemsanpham,
            this.mnutimkiemkhachhang});
            this.mnutimkiem.Name = "mnutimkiem";
            this.mnutimkiem.Size = new System.Drawing.Size(68, 20);
            this.mnutimkiem.Text = "&Tìm kiếm";
            // 
            // mnutimkiemhoadon
            // 
            this.mnutimkiemhoadon.Name = "mnutimkiemhoadon";
            this.mnutimkiemhoadon.Size = new System.Drawing.Size(180, 22);
            this.mnutimkiemhoadon.Text = "Hoá đơn";
            // 
            // mnutimkiemsanpham
            // 
            this.mnutimkiemsanpham.Name = "mnutimkiemsanpham";
            this.mnutimkiemsanpham.Size = new System.Drawing.Size(180, 22);
            this.mnutimkiemsanpham.Text = "Sản phẩm";
            // 
            // mnutimkiemkhachhang
            // 
            this.mnutimkiemkhachhang.Name = "mnutimkiemkhachhang";
            this.mnutimkiemkhachhang.Size = new System.Drawing.Size(180, 22);
            this.mnutimkiemkhachhang.Text = "Khách hàng";
            // 
            // frmtrang_chu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmtrang_chu";
            this.Text = "Phần mềm quản lí bán sách";
            this.Load += new System.EventHandler(this.frmtrang_chu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnufile;
        private System.Windows.Forms.ToolStripMenuItem mnuthoat;
        private System.Windows.Forms.ToolStripMenuItem mnudanhmuc;
        private System.Windows.Forms.ToolStripMenuItem mnunhanvien;
        private System.Windows.Forms.ToolStripMenuItem mnukhachhang;
        private System.Windows.Forms.ToolStripMenuItem mnusach;
        private System.Windows.Forms.ToolStripMenuItem mnuhoadon;
        private System.Windows.Forms.ToolStripMenuItem mnuhoadonban;
        private System.Windows.Forms.ToolStripMenuItem mnutimkiem;
        private System.Windows.Forms.ToolStripMenuItem mnutimkiemhoadon;
        private System.Windows.Forms.ToolStripMenuItem mnutimkiemsanpham;
        private System.Windows.Forms.ToolStripMenuItem mnutimkiemkhachhang;
    }
}

