using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace Lab4_Bai4_VeXemPhim
{
    public partial class FormChiTiet : Form
    {
        string _url;
        public FormChiTiet(string url)
        {
            InitializeComponent();
            _url = url;
            this.Load += FormChiTiet_Load;
        }

        private async void FormChiTiet_Load(object sender, EventArgs e)
        {
            // Khởi tạo trình duyệt và đi tới link
            await webView21.EnsureCoreWebView2Async();
            webView21.CoreWebView2.Navigate(_url);
        }
    }
}