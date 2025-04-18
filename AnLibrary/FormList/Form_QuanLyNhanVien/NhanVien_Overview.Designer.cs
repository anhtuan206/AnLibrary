namespace AnLibrary.FormList.Form_QuanLyNhanVien
{
    partial class NhanVien_Overview
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvAccount = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAccountEdit = new System.Windows.Forms.Button();
            this.btnAccountNew = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1236, 55);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý nhân viên";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvAccount);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 55);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(12, 0, 12, 12);
            this.panel2.Size = new System.Drawing.Size(1236, 648);
            this.panel2.TabIndex = 2;
            // 
            // dgvAccount
            // 
            this.dgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccount.Location = new System.Drawing.Point(12, 47);
            this.dgvAccount.Name = "dgvAccount";
            this.dgvAccount.Size = new System.Drawing.Size(1212, 589);
            this.dgvAccount.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAccountEdit);
            this.panel3.Controls.Add(this.btnAccountNew);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(12, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1212, 47);
            this.panel3.TabIndex = 0;
            // 
            // btnAccountEdit
            // 
            this.btnAccountEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccountEdit.Location = new System.Drawing.Point(1110, 6);
            this.btnAccountEdit.Name = "btnAccountEdit";
            this.btnAccountEdit.Size = new System.Drawing.Size(99, 23);
            this.btnAccountEdit.TabIndex = 1;
            this.btnAccountEdit.Text = "Sửa Nhân Viên";
            this.btnAccountEdit.UseVisualStyleBackColor = true;
            this.btnAccountEdit.Click += new System.EventHandler(this.btnAccountEdit_Click);
            // 
            // btnAccountNew
            // 
            this.btnAccountNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccountNew.Location = new System.Drawing.Point(1005, 6);
            this.btnAccountNew.Name = "btnAccountNew";
            this.btnAccountNew.Size = new System.Drawing.Size(99, 23);
            this.btnAccountNew.TabIndex = 0;
            this.btnAccountNew.Text = "Tạo Nhân Viên";
            this.btnAccountNew.UseVisualStyleBackColor = true;
            this.btnAccountNew.Click += new System.EventHandler(this.btnAccountNew_Click);
            // 
            // NhanVien_Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 703);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "NhanVien_Overview";
            this.Text = "NhanVien_Overview";
            this.Load += new System.EventHandler(this.NhanVien_Overview_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvAccount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAccountEdit;
        private System.Windows.Forms.Button btnAccountNew;
    }
}