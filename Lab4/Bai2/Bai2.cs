using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace _24521120_NT106_Lab4
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
            this.Load += (s, e) => CenterContent();
            this.Resize += (s, e) => CenterContent();
        }

        private void CenterContent()
        {
            int spacing = 20;
            int totalWidth = textURL.Width + spacing + btnPost.Width;
            int left = (this.ClientSize.Width - totalWidth) / 2;
            textURL.Left = left;
            btnPost.Left = left + textURL.Width + spacing;

            int totalWidth2 = textData.Width + spacing + btnClear.Width;
            int left2 = (this.ClientSize.Width - totalWidth2) / 2;
            textData.Left = left2;
            btnClear.Left = left2 + textData.Width + spacing;

            textHTML.Left = (this.ClientSize.Width - textHTML.Width) / 2;
            richtextHTML.Left = (this.ClientSize.Width - richtextHTML.Width) / 2;

            int firstTop = textURL.Top;
            int lastBottom = richtextHTML.Bottom;
            int blockHeight = lastBottom - firstTop;
            int newFirstTop = Math.Max(10, (this.ClientSize.Height - blockHeight) / 2);
            int dy = newFirstTop - firstTop;

            textURL.Top += dy;
            btnPost.Top += dy;
            textData.Top += dy;
            btnClear.Top += dy;
            textHTML.Top += dy;
            richtextHTML.Top += dy;
        }

        private void btnPost_Click(object sender, EventArgs e)
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

                string filePath = textData.Text.Trim();
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Title = "Choose where to save HTML";
                        sfd.Filter = "HTML files (*.html;*.htm)|*.html;*.htm|All files (*.*)|*.*";
                        sfd.FileName = "download.html";

                        if (sfd.ShowDialog() != DialogResult.OK)
                        {
                            return; // user bấm Cancel
                        }

                        filePath = sfd.FileName;
                        textData.Text = filePath;
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

                richtextHTML.Text = File.ReadAllText(filePath, Encoding.UTF8);
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
            textURL.Clear();
            textData.Clear();
            richtextHTML.Clear();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
