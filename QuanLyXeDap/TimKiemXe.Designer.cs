
namespace QuanLyXeDap
{
    partial class TimKiemXe
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
            this.dgvXe = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colXuatXu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHinhAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvXe
            // 
            this.dgvXe.AllowUserToAddRows = false;
            this.dgvXe.AllowUserToDeleteRows = false;
            this.dgvXe.BackgroundColor = System.Drawing.Color.Violet;
            this.dgvXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMa,
            this.colTen,
            this.colHang,
            this.colXuatXu,
            this.colTon,
            this.colSoLuong,
            this.colGia,
            this.colTien,
            this.colHinhAnh});
            this.dgvXe.Location = new System.Drawing.Point(15, 215);
            this.dgvXe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvXe.Name = "dgvXe";
            this.dgvXe.RowHeadersWidth = 51;
            this.dgvXe.RowTemplate.Height = 25;
            this.dgvXe.Size = new System.Drawing.Size(1269, 230);
            this.dgvXe.TabIndex = 10;
            this.dgvXe.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvXe_CellMouseDoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::QuanLyXeDap.Properties.Resources.images__2_;
            this.pictureBox1.Location = new System.Drawing.Point(377, 142);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.Violet;
            this.btnFind.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnFind.Location = new System.Drawing.Point(848, 133);
            this.btnFind.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(113, 39);
            this.btnFind.TabIndex = 12;
            this.btnFind.Text = "Tìm Kiếm";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtTuKhoa.Location = new System.Drawing.Point(433, 139);
            this.txtTuKhoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(388, 30);
            this.txtTuKhoa.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.CausesValidation = false;
            this.label1.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(512, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 40);
            this.label1.TabIndex = 14;
            this.label1.Text = "TÌM KIẾM XE ĐẠP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // colMa
            // 
            this.colMa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMa.DataPropertyName = "colMa";
            this.colMa.HeaderText = "MÃ XE";
            this.colMa.MinimumWidth = 6;
            this.colMa.Name = "colMa";
            // 
            // colTen
            // 
            this.colTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTen.DataPropertyName = "colTen";
            this.colTen.HeaderText = "TÊN XE";
            this.colTen.MinimumWidth = 6;
            this.colTen.Name = "colTen";
            // 
            // colHang
            // 
            this.colHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHang.DataPropertyName = "colHang";
            this.colHang.HeaderText = "HÃNG SẢN XUẤT";
            this.colHang.MinimumWidth = 6;
            this.colHang.Name = "colHang";
            // 
            // colXuatXu
            // 
            this.colXuatXu.DataPropertyName = "colXuatXu";
            this.colXuatXu.HeaderText = "XUẤT XỨ";
            this.colXuatXu.MinimumWidth = 6;
            this.colXuatXu.Name = "colXuatXu";
            this.colXuatXu.Width = 125;
            // 
            // colTon
            // 
            this.colTon.DataPropertyName = "colTon";
            this.colTon.HeaderText = "TỒN KHO";
            this.colTon.Name = "colTon";
            // 
            // colSoLuong
            // 
            this.colSoLuong.DataPropertyName = "colSoLuong";
            this.colSoLuong.HeaderText = "SỐ LƯỢNG NHẬP";
            this.colSoLuong.MinimumWidth = 6;
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.Width = 125;
            // 
            // colGia
            // 
            this.colGia.DataPropertyName = "colGia";
            this.colGia.HeaderText = "ĐƠN GIÁ";
            this.colGia.MinimumWidth = 6;
            this.colGia.Name = "colGia";
            this.colGia.Width = 150;
            // 
            // colTien
            // 
            this.colTien.DataPropertyName = "colTien";
            this.colTien.HeaderText = "THÀNH TIỀN";
            this.colTien.MinimumWidth = 6;
            this.colTien.Name = "colTien";
            this.colTien.Width = 125;
            // 
            // colHinhAnh
            // 
            this.colHinhAnh.DataPropertyName = "colHinhAnh";
            this.colHinhAnh.HeaderText = "HÌNH ẢNH";
            this.colHinhAnh.MinimumWidth = 6;
            this.colHinhAnh.Name = "colHinhAnh";
            this.colHinhAnh.Visible = false;
            this.colHinhAnh.Width = 125;
            // 
            // TimKiemXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyXeDap.Properties.Resources._3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1327, 530);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.dgvXe);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TimKiemXe";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TimKiemXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvXe;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colXuatXu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHinhAnh;
    }
}