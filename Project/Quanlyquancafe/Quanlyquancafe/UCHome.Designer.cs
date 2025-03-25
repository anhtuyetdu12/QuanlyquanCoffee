namespace Quanlyquancafe
{
    partial class UCHome
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGiamGia = new System.Windows.Forms.Button();
            this.btnChuyenBan = new System.Windows.Forms.Button();
            this.cbbChuyenBan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.nmGiamGia = new System.Windows.Forms.NumericUpDown();
            this.btnThanhtoan = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picDo = new System.Windows.Forms.PictureBox();
            this.picXanh = new System.Windows.Forms.PictureBox();
            this.numDemMon = new System.Windows.Forms.NumericUpDown();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.cbbMonAn = new System.Windows.Forms.ComboBox();
            this.cbbDanhMuc = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmGiamGia)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picXanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDemMon)).BeginInit();
            this.SuspendLayout();
            // 
            // flpTable
            // 
            this.flpTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpTable.Location = new System.Drawing.Point(0, 0);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(434, 589);
            this.flpTable.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(94)))));
            this.panel1.Controls.Add(this.lvBill);
            this.panel1.Location = new System.Drawing.Point(440, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 428);
            this.panel1.TabIndex = 0;
            // 
            // lvBill
            // 
            this.lvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvBill.GridLines = true;
            this.lvBill.HideSelection = false;
            this.lvBill.Location = new System.Drawing.Point(0, 0);
            this.lvBill.Name = "lvBill";
            this.lvBill.Size = new System.Drawing.Size(434, 428);
            this.lvBill.TabIndex = 0;
            this.lvBill.UseCompatibleStateImageBehavior = false;
            this.lvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 102;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 58;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 79;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 140;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(94)))));
            this.panel2.Controls.Add(this.btnGiamGia);
            this.panel2.Controls.Add(this.btnChuyenBan);
            this.panel2.Controls.Add(this.cbbChuyenBan);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtTongTien);
            this.panel2.Controls.Add(this.nmGiamGia);
            this.panel2.Controls.Add(this.btnThanhtoan);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(440, 509);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(434, 76);
            this.panel2.TabIndex = 2;
            // 
            // btnGiamGia
            // 
            this.btnGiamGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(73)))), ((int)(((byte)(16)))));
            this.btnGiamGia.FlatAppearance.BorderSize = 0;
            this.btnGiamGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiamGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiamGia.ForeColor = System.Drawing.Color.White;
            this.btnGiamGia.Location = new System.Drawing.Point(129, 9);
            this.btnGiamGia.Name = "btnGiamGia";
            this.btnGiamGia.Size = new System.Drawing.Size(75, 23);
            this.btnGiamGia.TabIndex = 10;
            this.btnGiamGia.Text = "Giảm giá";
            this.btnGiamGia.UseVisualStyleBackColor = false;
            this.btnGiamGia.Click += new System.EventHandler(this.btnGiamGia_Click);
            // 
            // btnChuyenBan
            // 
            this.btnChuyenBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(73)))), ((int)(((byte)(16)))));
            this.btnChuyenBan.FlatAppearance.BorderSize = 0;
            this.btnChuyenBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyenBan.ForeColor = System.Drawing.Color.White;
            this.btnChuyenBan.Location = new System.Drawing.Point(12, 11);
            this.btnChuyenBan.Name = "btnChuyenBan";
            this.btnChuyenBan.Size = new System.Drawing.Size(92, 23);
            this.btnChuyenBan.TabIndex = 9;
            this.btnChuyenBan.Text = "Chuyển bàn";
            this.btnChuyenBan.UseVisualStyleBackColor = false;
            // 
            // cbbChuyenBan
            // 
            this.cbbChuyenBan.FormattingEnabled = true;
            this.cbbChuyenBan.Location = new System.Drawing.Point(12, 43);
            this.cbbChuyenBan.Name = "cbbChuyenBan";
            this.cbbChuyenBan.Size = new System.Drawing.Size(92, 21);
            this.cbbChuyenBan.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 7;
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.Color.White;
            this.txtTongTien.ForeColor = System.Drawing.Color.Red;
            this.txtTongTien.Location = new System.Drawing.Point(129, 37);
            this.txtTongTien.Multiline = true;
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(155, 27);
            this.txtTongTien.TabIndex = 6;
            this.txtTongTien.Text = "0";
            // 
            // nmGiamGia
            // 
            this.nmGiamGia.Location = new System.Drawing.Point(220, 11);
            this.nmGiamGia.Name = "nmGiamGia";
            this.nmGiamGia.Size = new System.Drawing.Size(64, 20);
            this.nmGiamGia.TabIndex = 5;
            // 
            // btnThanhtoan
            // 
            this.btnThanhtoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(73)))), ((int)(((byte)(16)))));
            this.btnThanhtoan.FlatAppearance.BorderSize = 0;
            this.btnThanhtoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhtoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnThanhtoan.ForeColor = System.Drawing.Color.White;
            this.btnThanhtoan.Image = global::Quanlyquancafe.Properties.Resources.pay_later;
            this.btnThanhtoan.Location = new System.Drawing.Point(304, 11);
            this.btnThanhtoan.Name = "btnThanhtoan";
            this.btnThanhtoan.Size = new System.Drawing.Size(96, 53);
            this.btnThanhtoan.TabIndex = 3;
            this.btnThanhtoan.Text = "Thanh toán";
            this.btnThanhtoan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThanhtoan.UseVisualStyleBackColor = false;
            this.btnThanhtoan.Click += new System.EventHandler(this.btnThanhtoan_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(94)))));
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.picDo);
            this.panel3.Controls.Add(this.picXanh);
            this.panel3.Controls.Add(this.numDemMon);
            this.panel3.Controls.Add(this.btnThemMon);
            this.panel3.Controls.Add(this.cbbMonAn);
            this.panel3.Controls.Add(this.cbbDanhMuc);
            this.panel3.Location = new System.Drawing.Point(440, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(434, 69);
            this.panel3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(325, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Đang chọn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(323, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Có người";
            // 
            // picDo
            // 
            this.picDo.Image = global::Quanlyquancafe.Properties.Resources.checked__1_;
            this.picDo.Location = new System.Drawing.Point(304, 39);
            this.picDo.Name = "picDo";
            this.picDo.Size = new System.Drawing.Size(20, 20);
            this.picDo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDo.TabIndex = 5;
            this.picDo.TabStop = false;
            // 
            // picXanh
            // 
            this.picXanh.Image = global::Quanlyquancafe.Properties.Resources.check;
            this.picXanh.Location = new System.Drawing.Point(304, 12);
            this.picXanh.Name = "picXanh";
            this.picXanh.Size = new System.Drawing.Size(20, 20);
            this.picXanh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picXanh.TabIndex = 4;
            this.picXanh.TabStop = false;
            // 
            // numDemMon
            // 
            this.numDemMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numDemMon.Location = new System.Drawing.Point(251, 28);
            this.numDemMon.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numDemMon.Name = "numDemMon";
            this.numDemMon.Size = new System.Drawing.Size(45, 20);
            this.numDemMon.TabIndex = 3;
            this.numDemMon.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnThemMon
            // 
            this.btnThemMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(73)))), ((int)(((byte)(16)))));
            this.btnThemMon.FlatAppearance.BorderSize = 0;
            this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnThemMon.ForeColor = System.Drawing.Color.White;
            this.btnThemMon.Image = global::Quanlyquancafe.Properties.Resources.add_product;
            this.btnThemMon.Location = new System.Drawing.Point(166, 12);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(77, 48);
            this.btnThemMon.TabIndex = 2;
            this.btnThemMon.Text = "Thêm món";
            this.btnThemMon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThemMon.UseVisualStyleBackColor = false;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // cbbMonAn
            // 
            this.cbbMonAn.FormattingEnabled = true;
            this.cbbMonAn.Location = new System.Drawing.Point(3, 39);
            this.cbbMonAn.Name = "cbbMonAn";
            this.cbbMonAn.Size = new System.Drawing.Size(151, 21);
            this.cbbMonAn.TabIndex = 1;
            // 
            // cbbDanhMuc
            // 
            this.cbbDanhMuc.FormattingEnabled = true;
            this.cbbDanhMuc.Location = new System.Drawing.Point(3, 12);
            this.cbbDanhMuc.Name = "cbbDanhMuc";
            this.cbbDanhMuc.Size = new System.Drawing.Size(151, 21);
            this.cbbDanhMuc.TabIndex = 0;
            this.cbbDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cbbDanhMuc_SelectedIndexChanged);
            // 
            // UCHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(41)))), ((int)(((byte)(35)))));
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpTable);
            this.Location = new System.Drawing.Point(112, 16);
            this.Name = "UCHome";
            this.Size = new System.Drawing.Size(872, 589);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmGiamGia)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picXanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDemMon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvBill;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.ComboBox cbbMonAn;
        private System.Windows.Forms.ComboBox cbbDanhMuc;
        private System.Windows.Forms.NumericUpDown numDemMon;
        private System.Windows.Forms.Button btnThanhtoan;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.NumericUpDown nmGiamGia;
        private System.Windows.Forms.ComboBox cbbChuyenBan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picXanh;
        private System.Windows.Forms.PictureBox picDo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnChuyenBan;
        private System.Windows.Forms.Button btnGiamGia;
    }
}
