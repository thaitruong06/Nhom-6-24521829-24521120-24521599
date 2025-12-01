using System;
using System.Windows.Forms;

namespace Lab4_Bai4_VeXemPhim
{
    public partial class FormDatVe : Form
    {
        Movie _phim;
        public FormDatVe(Movie phim)
        {
            InitializeComponent();
            _phim = phim;
            this.Load += (s, e) => { lblTenPhim.Text = _phim.TenPhim; };
        }

        // Bạn hãy tự click đúp vào nút Mua để tạo sự kiện này nhé
        private void btnMua_Click(object sender, EventArgs e)
        {
            double giaVe = 90000; // Giả sử 90k/vé
            double tongTien = (double)numSoLuong.Value * giaVe;

            MessageBox.Show($"Khách: {txtTen.Text}\nPhim: {_phim.TenPhim}\nTổng tiền: {tongTien} VNĐ");
            this.Close();
        }
    }
}