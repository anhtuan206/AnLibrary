namespace AnLibrary.FormList.Form_QuanLyMuonSach
{
    partial class LeaseOrder_NewEdit
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
            this.labelFormHeader = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelCustomer = new System.Windows.Forms.Panel();
            this.panelOrderItem = new System.Windows.Forms.Panel();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdentity = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnDeleteOrderItem = new System.Windows.Forms.Button();
            this.btnEditOrderItem = new System.Windows.Forms.Button();
            this.btnAddOrderItem = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtBirthday = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLeaseDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReturnDate = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelCustomer.SuspendLayout();
            this.panelOrderItem.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelFormHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(922, 55);
            this.panel1.TabIndex = 3;
            // 
            // labelFormHeader
            // 
            this.labelFormHeader.AutoSize = true;
            this.labelFormHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFormHeader.Location = new System.Drawing.Point(13, 13);
            this.labelFormHeader.Name = "labelFormHeader";
            this.labelFormHeader.Size = new System.Drawing.Size(149, 25);
            this.labelFormHeader.TabIndex = 0;
            this.labelFormHeader.Text = "Tạo/sửa phiếu";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 668);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(922, 52);
            this.panel2.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(103, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(22, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panelOrderItem);
            this.panel3.Controls.Add(this.panelCustomer);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(922, 613);
            this.panel3.TabIndex = 6;
            // 
            // panelCustomer
            // 
            this.panelCustomer.Controls.Add(this.txtReturnDate);
            this.panelCustomer.Controls.Add(this.txtLeaseDate);
            this.panelCustomer.Controls.Add(this.txtBirthday);
            this.panelCustomer.Controls.Add(this.txtAddress);
            this.panelCustomer.Controls.Add(this.label6);
            this.panelCustomer.Controls.Add(this.label5);
            this.panelCustomer.Controls.Add(this.label7);
            this.panelCustomer.Controls.Add(this.label4);
            this.panelCustomer.Controls.Add(this.label1);
            this.panelCustomer.Controls.Add(this.label3);
            this.panelCustomer.Controls.Add(this.label2);
            this.panelCustomer.Controls.Add(this.txtIdentity);
            this.panelCustomer.Controls.Add(this.txtMobile);
            this.panelCustomer.Controls.Add(this.txtCustomerName);
            this.panelCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCustomer.Location = new System.Drawing.Point(0, 0);
            this.panelCustomer.Name = "panelCustomer";
            this.panelCustomer.Size = new System.Drawing.Size(922, 200);
            this.panelCustomer.TabIndex = 0;
            // 
            // panelOrderItem
            // 
            this.panelOrderItem.Controls.Add(this.dataGridView1);
            this.panelOrderItem.Controls.Add(this.panel6);
            this.panelOrderItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOrderItem.Location = new System.Drawing.Point(0, 200);
            this.panelOrderItem.Name = "panelOrderItem";
            this.panelOrderItem.Size = new System.Drawing.Size(922, 413);
            this.panelOrderItem.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(129, 94);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(746, 43);
            this.txtAddress.TabIndex = 24;
            this.txtAddress.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Địa chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(477, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Số CCCD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Số điện thoại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Ngày sinh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tên khách hàng";
            // 
            // txtIdentity
            // 
            this.txtIdentity.Location = new System.Drawing.Point(581, 58);
            this.txtIdentity.Name = "txtIdentity";
            this.txtIdentity.Size = new System.Drawing.Size(294, 20);
            this.txtIdentity.TabIndex = 15;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(129, 55);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(294, 20);
            this.txtMobile.TabIndex = 16;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(129, 17);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(294, 20);
            this.txtCustomerName.TabIndex = 18;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnAddOrderItem);
            this.panel6.Controls.Add(this.btnEditOrderItem);
            this.panel6.Controls.Add(this.btnDeleteOrderItem);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(922, 45);
            this.panel6.TabIndex = 0;
            // 
            // btnDeleteOrderItem
            // 
            this.btnDeleteOrderItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteOrderItem.Location = new System.Drawing.Point(835, 7);
            this.btnDeleteOrderItem.Name = "btnDeleteOrderItem";
            this.btnDeleteOrderItem.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteOrderItem.TabIndex = 0;
            this.btnDeleteOrderItem.Text = "Xóa phiếu";
            this.btnDeleteOrderItem.UseVisualStyleBackColor = true;
            // 
            // btnEditOrderItem
            // 
            this.btnEditOrderItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditOrderItem.Location = new System.Drawing.Point(754, 6);
            this.btnEditOrderItem.Name = "btnEditOrderItem";
            this.btnEditOrderItem.Size = new System.Drawing.Size(75, 23);
            this.btnEditOrderItem.TabIndex = 1;
            this.btnEditOrderItem.Text = "Sửa";
            this.btnEditOrderItem.UseVisualStyleBackColor = true;
            // 
            // btnAddOrderItem
            // 
            this.btnAddOrderItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOrderItem.Location = new System.Drawing.Point(673, 7);
            this.btnAddOrderItem.Name = "btnAddOrderItem";
            this.btnAddOrderItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddOrderItem.TabIndex = 2;
            this.btnAddOrderItem.Text = "Thêm sách";
            this.btnAddOrderItem.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(922, 368);
            this.dataGridView1.TabIndex = 1;
            // 
            // txtBirthday
            // 
            this.txtBirthday.Location = new System.Drawing.Point(581, 17);
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.Size = new System.Drawing.Size(294, 20);
            this.txtBirthday.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Ngày mượn";
            // 
            // txtLeaseDate
            // 
            this.txtLeaseDate.Location = new System.Drawing.Point(129, 159);
            this.txtLeaseDate.Name = "txtLeaseDate";
            this.txtLeaseDate.Size = new System.Drawing.Size(294, 20);
            this.txtLeaseDate.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(477, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Ngày trả";
            // 
            // txtReturnDate
            // 
            this.txtReturnDate.Location = new System.Drawing.Point(581, 158);
            this.txtReturnDate.Name = "txtReturnDate";
            this.txtReturnDate.Size = new System.Drawing.Size(294, 20);
            this.txtReturnDate.TabIndex = 25;
            // 
            // LeaseOrder_NewEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 720);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "LeaseOrder_NewEdit";
            this.Text = "Tạo/sửa phiếu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelCustomer.ResumeLayout(false);
            this.panelCustomer.PerformLayout();
            this.panelOrderItem.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelFormHeader;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelOrderItem;
        private System.Windows.Forms.Panel panelCustomer;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnAddOrderItem;
        private System.Windows.Forms.Button btnDeleteOrderItem;
        private System.Windows.Forms.RichTextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdentity;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Button btnEditOrderItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker txtReturnDate;
        private System.Windows.Forms.DateTimePicker txtLeaseDate;
        private System.Windows.Forms.DateTimePicker txtBirthday;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
    }
}