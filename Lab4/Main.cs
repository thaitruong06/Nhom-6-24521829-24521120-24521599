using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24521120_NT106_Lab4
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            guna2CircleButton1.BringToFront();
            guna2CircleButton2.BringToFront();
            guna2CircleButton4.BringToFront();
            this.Load += (s, e) => CenterGroupArea();
            this.Resize += (s, e) => CenterGroupArea();
        }

        private void CenterGroupArea()
        {
            if (groupBox1 == null) return;
            var x = (this.ClientSize.Width - groupBox1.Width) / 2;
            var y = groupBox1.Location.Y;
            if (x < 0) x = 0;
            groupBox1.Left = x;
            groupBox1.Top = y;
        }

        private void btnBai1_Click(object sender, EventArgs e)
        {
            var bai1 = new Bai1();
            bai1.FormClosed += (s, args) =>
            {
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            };
            bai1.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnBai2_Click(object sender, EventArgs e)
        {
            var bai2 = new Bai2();
            bai2.FormClosed += (s, args) =>
            {
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            };
            bai2.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnBai3_Click(object sender, EventArgs e)
        {
            var bai3 = new Bai3();
            bai3.FormClosed += (s, args) =>
            {
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            };
            bai3.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnBai4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bài 4 chưa được triển khai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBai5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bài 5 chưa được triển khai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBai6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bài 6 chưa được triển khai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBai7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bài 7 chưa được triển khai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
