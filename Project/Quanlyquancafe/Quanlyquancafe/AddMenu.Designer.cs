namespace Quanlyquancafe
{
    partial class AddMenu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ptbExit = new System.Windows.Forms.PictureBox();
            this.btnaddSP = new System.Windows.Forms.Button();
            this.txtIDThucDon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.cbbDanhMucTD = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ptbExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 26);
            this.panel1.TabIndex = 28;
            // 
            // ptbExit
            // 
            this.ptbExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbExit.Image = global::Quanlyquancafe.Properties.Resources.close_icon_16;
            this.ptbExit.Location = new System.Drawing.Point(487, 4);
            this.ptbExit.Name = "ptbExit";
            this.ptbExit.Size = new System.Drawing.Size(20, 20);
            this.ptbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbExit.TabIndex = 4;
            this.ptbExit.TabStop = false;
            this.ptbExit.Click += new System.EventHandler(this.ptbExit_Click);
            // 
            // btnaddSP
            // 
            this.btnaddSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(73)))), ((int)(((byte)(16)))));
            this.btnaddSP.FlatAppearance.BorderSize = 0;
            this.btnaddSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddSP.ForeColor = System.Drawing.Color.White;
            this.btnaddSP.Location = new System.Drawing.Point(198, 347);
            this.btnaddSP.Margin = new System.Windows.Forms.Padding(4);
            this.btnaddSP.Name = "btnaddSP";
            this.btnaddSP.Size = new System.Drawing.Size(193, 32);
            this.btnaddSP.TabIndex = 27;
            this.btnaddSP.Text = "Thêm thực đơn";
            this.btnaddSP.UseVisualStyleBackColor = false;
            // 
            // txtIDThucDon
            // 
            this.txtIDThucDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIDThucDon.Location = new System.Drawing.Point(198, 118);
            this.txtIDThucDon.Multiline = true;
            this.txtIDThucDon.Name = "txtIDThucDon";
            this.txtIDThucDon.Size = new System.Drawing.Size(193, 26);
            this.txtIDThucDon.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(73)))), ((int)(((byte)(16)))));
            this.label5.Location = new System.Drawing.Point(34, 126);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "ID";
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(198, 280);
            this.numSoLuong.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(193, 20);
            this.numSoLuong.TabIndex = 24;
            // 
            // cbbDanhMucTD
            // 
            this.cbbDanhMucTD.FormattingEnabled = true;
            this.cbbDanhMucTD.Location = new System.Drawing.Point(198, 227);
            this.cbbDanhMucTD.Name = "cbbDanhMucTD";
            this.cbbDanhMucTD.Size = new System.Drawing.Size(193, 21);
            this.cbbDanhMucTD.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(73)))), ((int)(((byte)(16)))));
            this.label3.Location = new System.Drawing.Point(38, 282);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "Số Lượng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(73)))), ((int)(((byte)(16)))));
            this.label2.Location = new System.Drawing.Point(34, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(73)))), ((int)(((byte)(16)))));
            this.label1.Location = new System.Drawing.Point(13, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Thêm Thực Đơn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(73)))), ((int)(((byte)(16)))));
            this.label6.Location = new System.Drawing.Point(34, 230);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 18);
            this.label6.TabIndex = 29;
            this.label6.Text = "Danh Mục";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Location = new System.Drawing.Point(198, 176);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(193, 20);
            this.dtpNgay.TabIndex = 31;
            // 
            // AddMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(515, 426);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnaddSP);
            this.Controls.Add(this.txtIDThucDon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numSoLuong);
            this.Controls.Add(this.cbbDanhMucTD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddMenu";
            this.Text = "Menu";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ptbExit;
        private System.Windows.Forms.Button btnaddSP;
        private System.Windows.Forms.TextBox txtIDThucDon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.ComboBox cbbDanhMucTD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpNgay;
    }
}