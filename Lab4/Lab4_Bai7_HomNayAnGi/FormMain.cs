using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace Lab4_Bai7_HomNayAnGi
{
    public partial class FormMain : Form
    {
        int currentPage = 1;
        int pageSize = 5;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Mặc định load trang 1
            LoadMonAn(currentPage, pageSize);
        }

        // Hàm tải món ăn từ API
        async void LoadMonAn(int page, int size)
        {
            flpList.Controls.Clear(); // Xóa cũ

            string url = $"https://nt106.uitiot.vn/api/v1/monan/all?page={page}&page_size={size}";

            // Nếu đang ở tab "Tôi đóng góp", có thể API khác hoặc lọc sau (tuỳ đề bài/API)
            // Ví dụ API: .../api/v1/monan/my-dishes

            using (HttpClient client = new HttpClient())
            {
                // Gắn Token vào đầu mỗi request (BẮT BUỘC)
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", LoginForm.AccessToken);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        // Deserialize JSON về đối tượng
                        var result = JsonConvert.DeserializeObject<PaginationResponse>(json);

                        // Vẽ từng món ăn lên giao diện
                        foreach (var mon in result.data)
                        {
                            VeMonAn(mon);
                        }

                        lblPage.Text = $"{result.page}/{result.total}"; // Cập nhật số trang
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        // Hàm vẽ giao diện cho 1 món (Tương tự bài xem phim)
        void VeMonAn(MonAn mon)
        {
            Panel p = new Panel();
            p.Size = new Size(flpList.Width - 30, 100); // Chiều ngang full, cao 100
            p.BorderStyle = BorderStyle.FixedSingle;

            // Ảnh
            PictureBox pb = new PictureBox();
            pb.Size = new Size(80, 80);
            pb.Location = new Point(10, 10);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            try { pb.Load(mon.hinh_anh); } catch { }
            p.Controls.Add(pb);

            // Tên món
            Label lbTen = new Label();
            lbTen.Text = mon.ten_mon_an;
            lbTen.Font = new Font("Arial", 12, FontStyle.Bold);
            lbTen.ForeColor = Color.OrangeRed;
            lbTen.Location = new Point(100, 10);
            lbTen.AutoSize = true;
            p.Controls.Add(lbTen);

            // Giá
            Label lbGia = new Label();
            lbGia.Text = "Giá: " + mon.gia;
            lbGia.Location = new Point(100, 40);
            p.Controls.Add(lbGia);

            // Địa chỉ
            Label lbDiaChi = new Label();
            lbDiaChi.Text = "Địa chỉ: " + mon.dia_chi;
            lbDiaChi.Location = new Point(100, 65);
            lbDiaChi.AutoSize = true;
            p.Controls.Add(lbDiaChi);

            // Nút Xóa (chỉ hiện nếu là món của mình đóng góp)
            // Giả sử API trả về user đóng góp, so sánh với user đang login
            /*
            if (mon.dong_gop == LoginForm.LoggedInUser) 
            {
                Button btnXoa = new Button();
                btnXoa.Text = "X";
                btnXoa.ForeColor = Color.Red;
                btnXoa.Location = new Point(p.Width - 40, 10);
                btnXoa.Click += (s, e) => XoaMonAn(mon.id);
                p.Controls.Add(btnXoa);
            }
            */

            flpList.Controls.Add(p);
        }

        // Sự kiện nút chuyển trang
        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadMonAn(currentPage, pageSize);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadMonAn(currentPage, pageSize);
            }
        }

        // Nút Thêm món ăn
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddDish frm = new FormAddDish();
            frm.ShowDialog();
            // Sau khi thêm xong thì load lại danh sách
            LoadMonAn(currentPage, pageSize);
        }

        private void btnRandom_Click(object sender, EventArgs e)
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