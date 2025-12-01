using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using HtmlAgilityPack; // Thư viện đọc Web
using Newtonsoft.Json; // Thư viện JSON

namespace Lab4_Bai4_VeXemPhim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Sự kiện khi bấm nút
        private void btnGet_Click(object sender, EventArgs e)
        {
            // Reset giao diện
            flpList.Controls.Clear();
            progressBar1.Value = 10;

            // Đường dẫn web cần lấy
            string url = "https://betacinemas.vn/phim.htm";

            // 1. Tải trang web về
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            progressBar1.Value = 30;

            // 2. Tìm vị trí các bộ phim (Dựa vào cấu trúc HTML của web)
            // Lưu ý: Nếu web thay đổi giao diện, dòng này cần sửa lại XPath
            var cacBoPhim = doc.DocumentNode.SelectNodes("//div[contains(@class, 'tab-pane') and contains(@class, 'active')]//div[contains(@class, 'row')]//div[contains(@class, 'col-lg-4')]");

            if (cacBoPhim == null)
            {
                MessageBox.Show("Không tìm thấy phim nào! Có thể web đã đổi cấu trúc.");
                return;
            }

            List<Movie> danhSachPhim = new List<Movie>();

            // 3. Duyệt qua từng bộ phim tìm được
            foreach (var phimNode in cacBoPhim)
            {
                try
                {
                    // Lấy Tên phim (nằm trong thẻ h3 a)
                    var tenNode = phimNode.SelectSingleNode(".//h3/a");
                    string ten = tenNode.InnerText.Trim();
                    string linkChiTiet = "https://betacinemas.vn" + tenNode.GetAttributeValue("href", "");

                    // Lấy Ảnh (nằm trong thẻ img)
                    var anhNode = phimNode.SelectSingleNode(".//img");
                    string linkAnh = anhNode.GetAttributeValue("src", "");

                    // Tạo đối tượng phim và thêm vào danh sách
                    Movie m = new Movie(ten, linkAnh, linkChiTiet);
                    danhSachPhim.Add(m);

                    // Vẽ phim lên giao diện
                    TaoGiaoDienPhim(m);
                }
                catch
                {
                    // Bỏ qua lỗi nhỏ nếu một phim bị lỗi
                }
            }

            // 4. Lưu xuống file JSON
            string json = JsonConvert.SerializeObject(danhSachPhim, Formatting.Indented);
            File.WriteAllText("data.json", json);

            progressBar1.Value = 100;
            MessageBox.Show("Đã lấy xong dữ liệu!");
        }

        // Hàm này tự vẽ ra một ô phim gồm Ảnh + Tên + Nút
        void TaoGiaoDienPhim(Movie m)
        {
            Panel p = new Panel();
            p.Size = new Size(220, 350);
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Margin = new Padding(10);

            // Ảnh phim
            PictureBox pb = new PictureBox();
            pb.Size = new Size(200, 250);
            pb.Location = new Point(10, 10);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            try { pb.Load(m.LinkAnh); } catch { } // Tải ảnh từ mạng

            // Sự kiện click ảnh -> Xem chi tiết
            pb.Click += (s, e) => {
                FormChiTiet frm = new FormChiTiet(m.LinkChiTiet);
                frm.Show();
            };

            // Tên phim
            Label lb = new Label();
            lb.Text = m.TenPhim;
            lb.Location = new Point(10, 270);
            lb.Size = new Size(200, 40);
            lb.Font = new Font("Arial", 10, FontStyle.Bold);

            // Nút Đặt vé
            Button btn = new Button();
            btn.Text = "Đặt vé";
            btn.Location = new Point(60, 310);
            btn.Click += (s, e) => {
                FormDatVe frm = new FormDatVe(m);
                frm.ShowDialog();
            };

            // Thêm các cái nhỏ vào cái Panel to
            p.Controls.Add(pb);
            p.Controls.Add(lb);
            p.Controls.Add(btn);

            // Thêm Panel to vào danh sách cuộn
            flpList.Controls.Add(p);
        }
    }
}