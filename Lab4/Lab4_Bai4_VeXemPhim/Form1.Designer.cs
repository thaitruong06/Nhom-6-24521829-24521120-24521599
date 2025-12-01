namespace Lab4_Bai4_VeXemPhim
{
    partial class Form1
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
            this.flpList = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnGet = new System.Windows.Forms.Button();
            this.flpList.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpList
            // 
            this.flpList.AutoScroll = true;
            this.flpList.Controls.Add(this.progressBar1);
            this.flpList.Controls.Add(this.btnGet);
            this.flpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpList.Location = new System.Drawing.Point(0, 0);
            this.flpList.Name = "flpList";
            this.flpList.Size = new System.Drawing.Size(800, 450);
            this.flpList.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(109, 3);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(143, 23);
            this.btnGet.TabIndex = 1;
            this.btnGet.Text = "Lấy danh sách phim";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flpList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flpList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpList;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnGet;
    }
}

