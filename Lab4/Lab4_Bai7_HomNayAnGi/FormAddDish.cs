using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_Bai7_HomNayAnGi
{
    public partial class FormAddDish : Form
    {
        public FormAddDish()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Cách đơn giản nhất: Lấy danh sách hiện tại đang có trên FlowLayoutPanel
            // Hoặc gọi API lấy toàn bộ list về rồi random

            if (flpList.Controls.Count == 0) return;

            Random rnd = new Random();
            int index = rnd.Next(0, flpList.Controls.Count);

            // Lấy panel ngẫu nhiên
            Panel p = (Panel)flpList.Controls[index];

            // Hiển thị thông báo (Hoặc tạo Form popup đẹp như hình đề bài)
            // Ở đây mình lấy text từ label bên trong panel ra hiển thị nhanh
            string tenMon = p.Controls[1].Text;
            MessageBox.Show("Hôm nay ăn: " + tenMon);
        }
    }
}
