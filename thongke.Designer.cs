namespace bc_cnpm
{
    partial class thongke
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(thongke));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvmuanhieu = new System.Windows.Forms.DataGridView();
            this.btninbanchay = new System.Windows.Forms.Button();
            this.btndong = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmuanhieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(830, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvmuanhieu);
            this.groupBox1.Location = new System.Drawing.Point(472, 200);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(764, 293);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sản phẩm bán chạy nhất năm 2020:";
            // 
            // dgvmuanhieu
            // 
            this.dgvmuanhieu.AllowUserToAddRows = false;
            this.dgvmuanhieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmuanhieu.Location = new System.Drawing.Point(12, 37);
            this.dgvmuanhieu.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvmuanhieu.Name = "dgvmuanhieu";
            this.dgvmuanhieu.RowHeadersWidth = 82;
            this.dgvmuanhieu.Size = new System.Drawing.Size(740, 244);
            this.dgvmuanhieu.TabIndex = 0;
            // 
            // btninbanchay
            // 
            this.btninbanchay.Image = ((System.Drawing.Image)(resources.GetObject("btninbanchay.Image")));
            this.btninbanchay.Location = new System.Drawing.Point(124, 237);
            this.btninbanchay.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btninbanchay.Name = "btninbanchay";
            this.btninbanchay.Size = new System.Drawing.Size(212, 79);
            this.btninbanchay.TabIndex = 1;
            this.btninbanchay.Text = "In thông tin";
            this.btninbanchay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btninbanchay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btninbanchay.UseVisualStyleBackColor = true;
            this.btninbanchay.Click += new System.EventHandler(this.btninbanchay_Click);
            // 
            // btndong
            // 
            this.btndong.Image = ((System.Drawing.Image)(resources.GetObject("btndong.Image")));
            this.btndong.Location = new System.Drawing.Point(124, 367);
            this.btndong.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(212, 79);
            this.btndong.TabIndex = 2;
            this.btndong.Text = "Đóng";
            this.btndong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(666, 17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 138);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // thongke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1600, 781);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.btninbanchay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "thongke";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "thongke";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvmuanhieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvmuanhieu;
        private System.Windows.Forms.Button btninbanchay;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}