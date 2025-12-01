using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace _24521120_NT106_Lab4
{
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
            this.Load += Lab4_Bai3_Load;
            this.Resize += Lab4_Bai3_Resize;
        }

        private async void Lab4_Bai3_Load(object sender, EventArgs e)
        {
            try
            {
                await webView.EnsureCoreWebView2Async(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Cannot initialize WebView2. Please install Microsoft Edge WebView2 Runtime.\n\nDetails: " + ex.Message,
                    "WebView2 Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            CenterContent();
        }

        private void Lab4_Bai3_Resize(object sender, EventArgs e)
        {
            CenterContent();
        }

        private void CenterContent()
        {
            int spacing = 20;
            textHTML.Left = (this.ClientSize.Width - textHTML.Width) / 2;

            int leftInputs = textHTML.Left;
            textURL.Left = leftInputs;
            textPath.Left = leftInputs;

            btnLoad.Left = textURL.Right + spacing;
            btnDownload.Left = textPath.Right + spacing;
            btnClear.Left = btnDownload.Left;

            int firstTop = textURL.Top;
            int lastBottom = textHTML.Bottom;
            int blockHeight = lastBottom - firstTop;
            int minTop = 80;
            int newFirstTop = Math.Max(minTop, (this.ClientSize.Height - blockHeight) / 2);
            int dy = newFirstTop - firstTop;

            textURL.Top += dy;
            textPath.Top += dy;
            btnLoad.Top += dy;
            btnDownload.Top += dy;
            btnClear.Top += dy;
            textHTML.Top += dy;

            webView.Left = textHTML.Left + 20;
            webView.Width = textHTML.Width - 40;
            webView.Top = textHTML.Top + 20;
            webView.Height = textHTML.Height - 40;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                string correctURL;
                if (string.IsNullOrWhiteSpace(textURL.Text))
                {
                    MessageBox.Show("URL is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!textURL.Text.Contains("https://") && !textURL.Text.Contains("http://"))
                {
                    correctURL = "https://" + textURL.Text.Trim();
                }
                else
                {
                    correctURL = textURL.Text.Trim();
                }

                string filePath = textPath.Text.Trim();
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Title = "Choose where to save HTML";
                        sfd.Filter = "HTML files (*.html;*.htm)|*.html;*.htm|All files (*.*)|*.*";
                        sfd.FileName = "page.html";

                        if (sfd.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }

                        filePath = sfd.FileName;
                        textPath.Text = filePath;
                    }
                }

                string dir = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                {
                    MessageBox.Show("Folder in file path does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(correctURL, filePath);
                }

                MessageBox.Show("HTML file downloaded successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (WebException ex)
            {
                string message = "Download error: " + ex.Message;
                if (ex.Response is HttpWebResponse resp)
                {
                    message += "\nHTTP Status: " + (int)resp.StatusCode + " " + resp.StatusCode;
                }
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                string correctURL;
                if (string.IsNullOrWhiteSpace(textURL.Text))
                {
                    MessageBox.Show("URL is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!textURL.Text.Contains("https://") && !textURL.Text.Contains("http://"))
                {
                    correctURL = "https://" + textURL.Text.Trim();
                }
                else
                {
                    correctURL = textURL.Text.Trim();
                }

                string folderPath;
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Choose folder to save images";
                    if (fbd.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    folderPath = fbd.SelectedPath;
                }

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(correctURL);

                var imgNodes = doc.DocumentNode.SelectNodes("//img[@src]");
                if (imgNodes == null || imgNodes.Count == 0)
                {
                    MessageBox.Show("No images found on this page.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int downloaded = 0;
                using (WebClient client = new WebClient())
                {
                    foreach (var node in imgNodes)
                    {
                        string src = node.GetAttributeValue("src", null);
                        if (string.IsNullOrWhiteSpace(src))
                            continue;

                        Uri imgUri;
                        if (!Uri.TryCreate(src, UriKind.Absolute, out imgUri))
                        {
                            if (!Uri.TryCreate(new Uri(correctURL), src, out imgUri))
                                continue;
                        }

                        string fileName = Path.GetFileName(imgUri.LocalPath);
                        if (string.IsNullOrEmpty(fileName))
                        {
                            fileName = "image_" + (downloaded + 1) + ".png";
                        }

                        string destPath = Path.Combine(folderPath, fileName);
                        try
                        {
                            client.DownloadFile(imgUri, destPath);
                            downloaded++;
                        }
                        catch
                        {
                        }
                    }
                }

                MessageBox.Show($"Downloaded {downloaded} images to {folderPath}", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string correctURL;
                if (string.IsNullOrWhiteSpace(textURL.Text))
                {
                    MessageBox.Show("URL is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!textURL.Text.Contains("https://") && !textURL.Text.Contains("http://"))
                {
                    correctURL = "https://" + textURL.Text.Trim();
                }
                else
                {
                    correctURL = textURL.Text.Trim();
                }

                if (webView.CoreWebView2 == null)
                {
                    try
                    {
                        await webView.EnsureCoreWebView2Async(null);
                    }
                    catch (Exception exInit)
                    {
                        MessageBox.Show(
                            "Cannot initialize WebView2. Please install Microsoft Edge WebView2 Runtime.\n\nDetails: " + exInit.Message,
                            "WebView2 Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }

                webView.Source = new Uri(correctURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
