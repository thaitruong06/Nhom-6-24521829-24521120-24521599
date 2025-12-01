namespace Lab4_Bai4_VeXemPhim
{
    partial class FormDatVe
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
            this.lblTenPhim = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnMua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTenPhim
            // 
            this.lblTenPhim.AutoSize = true;
            this.lblTenPhim.Location = new System.Drawing.Point(116, 109);
            this.lblTenPhim.Name = "lblTenPhim";
            this.lblTenPhim.Size = new System.Drawing.Size(63, 16);
            this.lblTenPhim.TabIndex = 0;
            this.lblTenPhim.Text = "Tên phim";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(119, 157);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(100, 22);
            this.txtTen.TabIndex = 1;
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(119, 210);
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(120, 22);
            this.numSoLuong.TabIndex = 2;
            // 
            // btnMua
            // 
            this.btnMua.Location = new System.Drawing.Point(119, 270);
            this.btnMua.Name = "btnMua";
            this.btnMua.Size = new System.Drawing.Size(75, 23);
            this.btnMua.TabIndex = 3;
            this.btnMua.Text = "Xác nhận";
            this.btnMua.UseVisualStyleBackColor = true;
            this.btnMua.Click += new System.EventHandler(this.btnMua_Click);
            // 
            // FormDatVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMua);
            this.Controls.Add(this.numSoLuong);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lblTenPhim);
            this.Name = "FormDatVe";
            this.Text = "FormDatVe";
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTenPhim;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Button btnMua;
    }
}