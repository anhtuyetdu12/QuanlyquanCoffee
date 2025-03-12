namespace Quanlyquancafe
{
    partial class UCCategoryy
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCategory = new System.Windows.Forms.DataGridView();
            this.btnThemDM = new System.Windows.Forms.Button();
            this.btnTimKiemDM = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnThemDM);
            this.panel2.Controls.Add(this.btnTimKiemDM);
            this.panel2.Controls.Add(this.txtCategory);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(874, 81);
            this.panel2.TabIndex = 4;
            // 
            // txtCategory
            // 
            this.txtCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(94)))));
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.ForeColor = System.Drawing.Color.White;
            this.txtCategory.Location = new System.Drawing.Point(146, 34);
            this.txtCategory.Multiline = true;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(171, 33);
            this.txtCategory.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(94)))));
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Category";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvCategory);
            this.panel1.Location = new System.Drawing.Point(0, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 407);
            this.panel1.TabIndex = 3;
            // 
            // dgvCategory
            // 
            this.dgvCategory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(41)))), ((int)(((byte)(35)))));
            this.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategory.Location = new System.Drawing.Point(0, 0);
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.Size = new System.Drawing.Size(871, 501);
            this.dgvCategory.TabIndex = 0;
            // 
            // btnThemDM
            // 
            this.btnThemDM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(94)))));
            this.btnThemDM.FlatAppearance.BorderSize = 0;
            this.btnThemDM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemDM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemDM.ForeColor = System.Drawing.Color.White;
            this.btnThemDM.Image = global::Quanlyquancafe.Properties.Resources.add;
            this.btnThemDM.Location = new System.Drawing.Point(781, 28);
            this.btnThemDM.Name = "btnThemDM";
            this.btnThemDM.Size = new System.Drawing.Size(45, 39);
            this.btnThemDM.TabIndex = 6;
            this.btnThemDM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThemDM.UseVisualStyleBackColor = false;
            this.btnThemDM.Click += new System.EventHandler(this.btnThemDM_Click);
            // 
            // btnTimKiemDM
            // 
            this.btnTimKiemDM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(94)))));
            this.btnTimKiemDM.FlatAppearance.BorderSize = 0;
            this.btnTimKiemDM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemDM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemDM.ForeColor = System.Drawing.Color.White;
            this.btnTimKiemDM.Image = global::Quanlyquancafe.Properties.Resources.transparency;
            this.btnTimKiemDM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiemDM.Location = new System.Drawing.Point(323, 34);
            this.btnTimKiemDM.Name = "btnTimKiemDM";
            this.btnTimKiemDM.Size = new System.Drawing.Size(77, 33);
            this.btnTimKiemDM.TabIndex = 5;
            this.btnTimKiemDM.Text = "Tìm kiếm";
            this.btnTimKiemDM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiemDM.UseVisualStyleBackColor = false;
            // 
            // UCCategoryy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(41)))), ((int)(((byte)(35)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UCCategoryy";
            this.Size = new System.Drawing.Size(874, 591);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnThemDM;
        private System.Windows.Forms.Button btnTimKiemDM;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCategory;
    }
}
