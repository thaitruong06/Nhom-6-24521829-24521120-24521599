using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace Lab4_Bai7_HomNayAnGi
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // Biến static để lưu Token dùng chung cho toàn bộ ứng dụng
        public static string AccessToken = "";
        public static string LoggedInUser = "";

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string url = "https://nt106.uitiot.vn/auth/token";
            var client = new HttpClient();

            // Tạo dữ liệu form-data
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(txtUser.Text), "username");
            content.Add(new StringContent(txtPass.Text), "password");

            try
            {
                var response = await client.PostAsync(url, content);
                string responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jObj = JObject.Parse(responseString);
                    AccessToken = jObj["access_token"].ToString(); // LƯU TOKEN LẠI
                    LoggedInUser = txtUser.Text;

                    MessageBox.Show("Đăng nhập thành công!");

                    // Mở Form chính
                    FormMain main = new FormMain();
                    this.Hide();
                    main.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại: " + responseString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
    }
}