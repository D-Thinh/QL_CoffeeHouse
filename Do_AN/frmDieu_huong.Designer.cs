
namespace Do_AN
{
    partial class frmDieu_huong
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPhan_Hoi = new System.Windows.Forms.Button();
            this.btn_Doi_MK = new System.Windows.Forms.Button();
            this.btnThong_tin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.txtOrder = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.txtOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(12, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 42);
            this.label2.TabIndex = 5;
            this.label2.Text = "ĐỀ TÀI:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(97, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 42);
            this.label1.TabIndex = 4;
            this.label1.Text = "Phần mềm quản lý quán cafe ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangXuat.Location = new System.Drawing.Point(500, 310);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(111, 42);
            this.btnDangXuat.TabIndex = 16;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightPink;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(755, 35);
            this.label3.TabIndex = 18;
            this.label3.Text = "CHÀO MỪNG BẠN ĐẾN VỚI PHẦN MỀN QUẢN LÝ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPhan_Hoi);
            this.panel1.Controls.Add(this.btn_Doi_MK);
            this.panel1.Controls.Add(this.btnThong_tin);
            this.panel1.Location = new System.Drawing.Point(617, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 314);
            this.panel1.TabIndex = 19;
            // 
            // btnPhan_Hoi
            // 
            this.btnPhan_Hoi.BackgroundImage = global::Do_AN.Properties.Resources.Phan_hoi;
            this.btnPhan_Hoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPhan_Hoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhan_Hoi.Location = new System.Drawing.Point(4, 215);
            this.btnPhan_Hoi.Name = "btnPhan_Hoi";
            this.btnPhan_Hoi.Size = new System.Drawing.Size(123, 69);
            this.btnPhan_Hoi.TabIndex = 2;
            this.btnPhan_Hoi.Text = "Phản hồi";
            this.btnPhan_Hoi.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPhan_Hoi.UseVisualStyleBackColor = true;
            this.btnPhan_Hoi.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_Doi_MK
            // 
            this.btn_Doi_MK.BackgroundImage = global::Do_AN.Properties.Resources.Doi_MK;
            this.btn_Doi_MK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Doi_MK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Doi_MK.Location = new System.Drawing.Point(4, 123);
            this.btn_Doi_MK.Name = "btn_Doi_MK";
            this.btn_Doi_MK.Size = new System.Drawing.Size(123, 69);
            this.btn_Doi_MK.TabIndex = 1;
            this.btn_Doi_MK.Text = "Đổi mật khẩu";
            this.btn_Doi_MK.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btn_Doi_MK.UseVisualStyleBackColor = true;
            this.btn_Doi_MK.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnThong_tin
            // 
            this.btnThong_tin.BackgroundImage = global::Do_AN.Properties.Resources.Thong_Tin_NV;
            this.btnThong_tin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnThong_tin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThong_tin.Location = new System.Drawing.Point(4, 18);
            this.btnThong_tin.Name = "btnThong_tin";
            this.btnThong_tin.Size = new System.Drawing.Size(122, 68);
            this.btnThong_tin.TabIndex = 0;
            this.btnThong_tin.Text = "information";
            this.btnThong_tin.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnThong_tin.UseVisualStyleBackColor = true;
            this.btnThong_tin.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Do_AN.Properties.Resources.logo_ca_phe_nong;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnAdmin.Location = new System.Drawing.Point(3, 18);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(283, 183);
            this.btnAdmin.TabIndex = 0;
            this.btnAdmin.Text = "QUẢN TRỊ HỆ THỐNG";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold);
            this.btnOrder.ForeColor = System.Drawing.Color.Orange;
            this.btnOrder.Location = new System.Drawing.Point(306, 80);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(280, 183);
            this.btnOrder.TabIndex = 1;
            this.btnOrder.Text = "QUẢN LÝ BÁN HÀNG";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // txtOrder
            // 
            this.txtOrder.AutoScroll = true;
            this.txtOrder.Controls.Add(this.btnOrder);
            this.txtOrder.Controls.Add(this.btnAdmin);
            this.txtOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtOrder.Location = new System.Drawing.Point(22, 38);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(589, 266);
            this.txtOrder.TabIndex = 17;
            // 
            // frmDieu_huong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 376);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "frmDieu_huong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều hướng quản lý";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDieu_huong_FormClosed);
            this.Load += new System.EventHandler(this.frmDieu_huong_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.txtOrder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPhan_Hoi;
        private System.Windows.Forms.Button btn_Doi_MK;
        private System.Windows.Forms.Button btnThong_tin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Panel txtOrder;
    }
}