namespace AnLibrary.FormList.Form_Main
{
    partial class MainForm
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTaiSanOverview = new System.Windows.Forms.Button();
            this.btnNhanVienOverview = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLeaseOrderOverview = new System.Windows.Forms.Button();
            this.btnImportOrderOverview = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1317, 55);
            this.panel1.TabIndex = 2;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(1149, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblWelcome.Size = new System.Drawing.Size(156, 16);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome <someone>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "An Library";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnImportOrderOverview);
            this.panel2.Controls.Add(this.btnLeaseOrderOverview);
            this.panel2.Controls.Add(this.btnTaiSanOverview);
            this.panel2.Controls.Add(this.btnNhanVienOverview);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 55);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(6);
            this.panel2.Size = new System.Drawing.Size(233, 647);
            this.panel2.TabIndex = 3;
            // 
            // btnTaiSanOverview
            // 
            this.btnTaiSanOverview.Location = new System.Drawing.Point(9, 55);
            this.btnTaiSanOverview.Name = "btnTaiSanOverview";
            this.btnTaiSanOverview.Size = new System.Drawing.Size(218, 40);
            this.btnTaiSanOverview.TabIndex = 1;
            this.btnTaiSanOverview.Text = "Quản lý danh mục sách";
            this.btnTaiSanOverview.UseVisualStyleBackColor = true;
            this.btnTaiSanOverview.Click += new System.EventHandler(this.btnTaiSanOverview_Click);
            // 
            // btnNhanVienOverview
            // 
            this.btnNhanVienOverview.Location = new System.Drawing.Point(9, 9);
            this.btnNhanVienOverview.Name = "btnNhanVienOverview";
            this.btnNhanVienOverview.Size = new System.Drawing.Size(218, 40);
            this.btnNhanVienOverview.TabIndex = 0;
            this.btnNhanVienOverview.Text = "Quản lý nhân viên";
            this.btnNhanVienOverview.UseVisualStyleBackColor = true;
            this.btnNhanVienOverview.Click += new System.EventHandler(this.btnNhanVienOverview_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(233, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1084, 647);
            this.panel3.TabIndex = 4;
            // 
            // btnLeaseOrderOverview
            // 
            this.btnLeaseOrderOverview.Location = new System.Drawing.Point(9, 101);
            this.btnLeaseOrderOverview.Name = "btnLeaseOrderOverview";
            this.btnLeaseOrderOverview.Size = new System.Drawing.Size(218, 40);
            this.btnLeaseOrderOverview.TabIndex = 2;
            this.btnLeaseOrderOverview.Text = "Quản lý mượn sách";
            this.btnLeaseOrderOverview.UseVisualStyleBackColor = true;
            this.btnLeaseOrderOverview.Click += new System.EventHandler(this.btnLeaseOrderOverview_Click);
            // 
            // btnImportOrderOverview
            // 
            this.btnImportOrderOverview.Location = new System.Drawing.Point(9, 147);
            this.btnImportOrderOverview.Name = "btnImportOrderOverview";
            this.btnImportOrderOverview.Size = new System.Drawing.Size(218, 40);
            this.btnImportOrderOverview.TabIndex = 3;
            this.btnImportOrderOverview.Text = "Quản lý nhập sách";
            this.btnImportOrderOverview.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 702);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "An Library | Trang chủ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnTaiSanOverview;
        private System.Windows.Forms.Button btnNhanVienOverview;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLeaseOrderOverview;
        private System.Windows.Forms.Button btnImportOrderOverview;
        //private System.Diagnostics.PerformanceCounter performanceCounter1;
    }
}